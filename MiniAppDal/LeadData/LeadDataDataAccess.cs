using Dapper;
using MiniAppApis.MiniAppDAL;
using MiniAppDal.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniAppModel.LeadData;

namespace MiniAppDal.LeadData
{
    public class LeadDataDataAccess
    {
        #region private utility methods & constructors
        static LeadDataDataAccess _instance;
        static object _lock = new object();
        string _conn = string.Empty;
        public static LeadDataDataAccess Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new LeadDataDataAccess();
                    }
                }
                return _instance;
            }
        }

        private LeadDataDataAccess()
        {
            _conn = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
        }
		#endregion

		#region rjy
		/// <summary>
		/// 异步查询数据库最近七天每天增加用户数
		/// </summary>
		/// <param name="startTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>某七天的每天用户增量</returns>
		public async Task<UserCountList> GetUserChangeCountAsync(string startTime, string endTime)
        {
            string sql = $"select count(*) as num,convert(varchar(10),user_main.create_time,120) as dates from user_main " +
                $"join user_type on user_main.id=user_type.user_id " +
                $"where user_type.user_type=3  and  user_main.create_time BETWEEN '{startTime}' AND '{endTime}'" +
                $"group by convert(varchar(10),user_main.create_time,120)" +
                $"order by convert(varchar(10),user_main.create_time,120) asc";
            var list = await DapperHelper.GetListAsync<UserCount>(sql, this._conn);
            UserCount temp = null;
            UserCountList result = new UserCountList
            {
                list = new List<UserCount>()
            };
            foreach (var item in list)
            {
                temp = new UserCount
                {
                    dates = item.dates,
                    num = item.num
                };
                result.list.Add(temp);
            }
            return result;
        }

        /// <summary>
        /// 获取当前C类用户截至某一天总量总数
        /// </summary>
        /// <param name="date">截至时间</param>
        /// <returns>记录数</returns>
        public async Task<int> GetUserCountAsync(string date)
        {
            string sql = $"select count(*) from user_main join user_type on user_main.id=user_type.user_id " +
                $"where user_type.user_type=3  and user_main.create_time<'{date}'";
            return Convert.ToInt32(await DapperHelper.ExecuteScalarAsync(sql, _conn)); ;
        }

        /// <summary>
        /// 获取某时间段每天的销售额。
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>有记录当天的销售总额,没有过滤掉未付款的</returns>
        public async Task<SaleroomList> GetSaleroomAsync(string startTime, string endTime)
        {
            string sql = $"select sum(price_total) as 'limit',convert(char(8),create_time,112) as 'date' from order_main_spnc" +
                $" where create_time  BETWEEN '{startTime}' AND '{endTime}' AND order_status=0" +
                $" group by convert(char(8),create_time,112)";
            Saleroom temp = null;
            SaleroomList result = new SaleroomList
            {
                Lists = new List<Saleroom>()
            };
            var list = await DapperHelper.GetListAsync<Saleroom>(sql, this._conn);
            foreach (var item in list)
            {
                temp = new Saleroom
                {
                    Date = item.Date.Insert(4, "-").Insert(7, "-"),  //处理字符串，20180902（2018-09-02）
                    Limit = item.Limit
                };
                result.Lists.Add(temp);
            }
            return result ?? null;
        }


		/// <summary> 
		/// 获取截止到统计日期的累计销售额 rjy 2018年10月10日11:51:13
		/// </summary>
		/// <param name="endTime">结束时间</param>
		/// <returns>有记录当天的销售总额,没有过滤掉未付款的</returns>
		public async Task<SaleroomListTwo> GetNewSaleroomAsync( string endTime)
		{
			string sql = string.Format(@"SELECT
	SUM(
		CASE
		WHEN order_status = 0 THEN
			price_total
		ELSE
			- price_total
		END
	) AS 'limit',convert(char(8),create_time,112) as 'date'
FROM
	order_main_spnc
WHERE
	create_time < '{0}' group by convert(char(8),create_time,112)", endTime);
			SaleroomTwo temp = null;
			SaleroomListTwo result = new SaleroomListTwo
			{
				Lists = new List<SaleroomTwo>()
			};
			var list = await DapperHelper.GetListAsync<Saleroom>(sql, this._conn);
			foreach (var item in list)
			{
				temp = new SaleroomTwo
				{
					Date =Convert.ToDateTime(item.Date.Insert(4, "-").Insert(7, "-")),  //处理字符串，20180902（2018-09-02）
					Limit = item.Limit
				};
				result.Lists.Add(temp);
			}
			return result ?? null;
		}

		/// <summary>
		/// 计算某段时间内的,销售额，订单数，毛利，毛利率，平均客单价
		/// </summary>
		/// <param name="startTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		public async Task<Details> GetOrderDetailsAsync(string startTime, string endTime)
        {
			#region 旧版注释 rjy 2018年10月15日10:50:30 
			//          string sql = $"select count(*) as 'sum',SUM ("+
			//	$"CASE"+
			//	$"WHEN order_status = 0 THEN"+
			//	$"	price_total"+
			//	$"ELSE"+
			//	$"	- price_total"+
			//	$"END"+
			//$") AS 'gross', sum(profit) as 'profit' from order_main_spnc " +
			//              $"where create_time  BETWEEN '{startTime}' AND '{endTime}'";// AND order_status = 0
			#endregion
			string sql =string.Format(@"
SELECT
	COUNT (*) AS 'sum',
		SUM (
			CASE
			WHEN order_status = 0 THEN
				price_total
			ELSE
				- price_total
			END
		) AS 'gross',
		SUM (profit) AS 'profit'
	FROM
		order_main_spnc
	WHERE
		create_time BETWEEN '{0}'
	AND '{1}' ",startTime,endTime);
			Details result = null;
            var data = await DapperHelper.GetListAsync<Details>(sql, this._conn);
            foreach (var item in data)
            {
                result = new Details
                {
                    Gross = item.Gross ?? "0.00", //销售额
                    Profit = item.Profit ?? "0.00",//毛利
                    Sum = item.Sum ?? "0.00",//订单总数
                    Average = ContrastTwo(item.Gross ?? "0.00", item.Sum ?? "0.00"),
					// (double.Parse(item.Gross ?? "0.00") / double.Parse(item.Sum ?? "0.00")).ToString("F2"), //平均客单价：销售额/订单数

					Profits = Contrast(item.Profit ?? "0.00", item.Gross ?? "0.00")
					//(double.Parse(item.Profit ?? "0.00") / double.Parse(item.Gross ?? "0.00") * 100).ToString("F2"),  //毛利率：毛利/销售额*100%
                };
            }
            result.Average = result.Average == "NaN" ? "0.00" : result.Average;
            result.Profits = result.Profits == "NaN" ? "0.00" : result.Profits;
            return result ?? null;
        }
		public string Contrast(string x, string xx)
		{
			double dx = double.Parse(x);
			double dxx = double.Parse(xx);
			if (dxx == 0.00)
			{
				return "0.00";
			}

			return (dx / dxx * 100).ToString("F2");
		}
		public string ContrastTwo(string x, string xx)
		{
			double dx = double.Parse(x);
			double dxx = double.Parse(xx);
			if (dxx == 0.00)
			{
				return "0.00";
			}

			return (dx / dxx).ToString("F2");
		}
		/// <summary>
		/// 计算某段时间内的分润
		/// </summary>
		/// <param name="startTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		public async Task<ShareProfit> GetShareProfitAsync(string startTime, string endTime)
        {
            string sql = $"select sum(cash) as 'cashs'  from profit where " +
                $"create_time  BETWEEN '{startTime}' AND '{endTime}'";
            ShareProfit result = null;
            var data = await DapperHelper.GetListAsync<ShareProfit>(sql, this._conn);
            foreach (var item in data)
            {
                result = new ShareProfit
                {
                    Cashs = item.Cashs ?? "0.00"
                };
            }
            return result ?? null;
        }
		#endregion

		/// <summary>
		/// 总渠道
		/// </summary>
		/// <returns></returns>
		public List<TotalChannel> GetTotalChannel()
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string sql = @"	select  CONVERT(varchar(10),um.create_time, 25)as createtime from WeChatServiceFlatform.dbo.user_main um
inner join WeChatServiceFlatform.dbo.user_type ut on um.id = ut.user_id
inner join WeChatServiceFlatform.dbo.user_main ums on um.wx_open_id_b=ums.wx_open_id
inner join WeChatServiceFlatform.dbo.user_type uts on ums.id =uts.user_id 
INNER join WeChatServiceFlatform.dbo.Sys_User sus on sus.F_Id = CONVERT(varchar(50),ums.id)
where ut.user_type=1 and uts.user_type=0";
                var result = db.Query<TotalChannel>(sql) as List<TotalChannel>;
                return result.ToList();
            }
        }

        /// <summary>
        /// 地推每日获取人数
        /// </summary>
        /// <returns></returns>
        public List<BDData> GetBDDatas()
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string date = " and DateDiff(dd,um.create_time,getdate())=0";//ub.create_time>'2018-09-19'
                string sqlName = @"
								  select ums.wx_open_id,sus.F_RealName  as name from WeChatServiceFlatform.dbo.user_main um
                                    inner join WeChatServiceFlatform.dbo.user_type ut on um.id = ut.user_id
                                    inner join WeChatServiceFlatform.dbo.user_main ums on um.wx_open_id_b=ums.wx_open_id
                                    inner join WeChatServiceFlatform.dbo.user_type uts on ums.id =uts.user_id 
                                    inner join WeChatServiceFlatform.dbo.Sys_User sus on sus.F_Id = CONVERT(varchar(50),ums.id)
                                    where ut.user_type=1 and uts.user_type=0 
                                    group by ums.wx_open_id,sus.F_RealName ";
                var resultName = db.Query<BDData>(sqlName) as List<BDData>;




                string sqlnum = string.Format(@"
								 	 select COUNT(*) as num, ums.wx_open_id,sus.F_RealName  as name from WeChatServiceFlatform.dbo.user_main um
                                    inner join WeChatServiceFlatform.dbo.user_type ut on um.id = ut.user_id
                                    inner join WeChatServiceFlatform.dbo.user_main ums on um.wx_open_id_b=ums.wx_open_id
                                    inner join WeChatServiceFlatform.dbo.user_type uts on ums.id =uts.user_id 
                                    inner join WeChatServiceFlatform.dbo.Sys_User sus on sus.F_Id = CONVERT(varchar(50),ums.id)
                                    where ut.user_type=1 and uts.user_type=0 {0}
                                    group by ums.wx_open_id,sus.F_RealName order by num ", date);
                var resultnum = db.Query<BDData>(sqlnum) as List<BDData>;


                foreach (var item in resultName.ToList())
                {
                    string num= resultnum.Where(c => c.name == item.name).Select(c => c.num).FirstOrDefault();
                    item.num= num == null?"0":num;
                }
                return resultName.ToList();
            }
        }

        /// <summary>
        /// 单日销售额
        /// </summary>
        /// <returns></returns>
        public List<DaySalesVolume> GetDaySalesVolumes(string startTime,string endTime)
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string sql = string.Format(@"select dayData.createtime,sum(isnull(dayData.pricetotal ,0)) as pricetotal from (
	                                            select CONVERT(varchar(10),ord.create_time, 25)as createtime,ord.price_total as pricetotal 
	                                            from [dbo].[order_main_spnc] as ord 
	                                            where ord.create_time BETWEEN '{0} 00:00:00' AND '{1} 23:59:59')
                                            as dayData 
	                                            group by dayData.createtime order by dayData.createtime", startTime, endTime);
                var result = db.Query<DaySalesVolume>(sql) as List<DaySalesVolume>;
                return result.ToList();
            }
        }

        /// <summary>
        /// 单日订单数
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<DayOrderNum> GetDayOrderNums(string startTime,string endTime)
        {
            using (var db=new BusinessBase().OpenConnection())
            {
                string sql = string.Format(@"select dayData.createtime,COUNT(*) as ordernum from (
	                                            select CONVERT(varchar(10),ord.create_time, 25)as createtime 
	                                            from [dbo].[order_main_spnc] as ord 
	                                            where ord.create_time BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'
                                            )as dayData
	                                            group by dayData.createtime order by dayData.createtime", startTime,endTime);
                var result = db.Query<DayOrderNum>(sql) as List<DayOrderNum>;
                return result.ToList();
            }
        }

        /// <summary>
        /// 单日授权用户
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<DayUserNum> GetUserNums(string startTime, string endTime)
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string sql = string.Format(@"select dayData.createtime,COUNT(*) as usernum from (
                                                select CONVERT(varchar(10),um.create_time, 25)as createtime 
	                                           	from [dbo].[user_main] as um left join user_type as ut on um.id=ut.user_id 
	                                            where ut.user_type=3 and um.create_time BETWEEN'{0} 00:00:00' AND '{1} 23:59:59'
                                            )as dayData
	                                            group by dayData.createtime order by dayData.createtime", startTime, endTime);
                var result = db.Query<DayUserNum>(sql) as List<DayUserNum>;
                return result.ToList();
            }
        }
    }
}

using Dapper;
using MiniAppModel.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppDal
{
	/// <summary>
	/// rjy 2018年9月21日16:45:21 我的奖励
	/// </summary>
	public partial class AccountProfitDAL
	{
		#region 配置
		/// <summary>
		/// 连接串
		/// </summary>
		string connStr = string.Empty;
		static AccountProfitDAL _instance;
		static object _lock = new object();
		public static AccountProfitDAL Instance {

			get {
				if (_instance == null)
				{
					lock (_lock)
					{
						if (_instance == null)
							_instance = new AccountProfitDAL();
					}
				}
				return _instance;
			}
		}
		public AccountProfitDAL() {
			connStr = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
		}
		#endregion

		#region rjy
		#region sql
		private string us = @"AS (
	SELECT
		user_id_c userid,
		create_time AS 'date',
		user_id_b buserid
	FROM
		user_b2c b2c
	GROUP BY
		user_id_b,
		create_time,
		user_id_c
)";
		#endregion
		public async Task<List<BDLeaderEntity>> GetBdInfo(int UserId, int Stype)
		{

			#region sql --(SELECT u.F_DepartmentId FROM Sys_User u WHERE u.F_Id = '{UserId}')
			string sql = $"WITH orm AS ( select um.id fid,u.F_RealName rname FROM 	Sys_User u JOIN user_main um on u.F_Id = CONVERT(VARCHAR(50), um.id) where u.F_DepartmentId=(SELECT u.F_DepartmentId FROM Sys_User u WHERE u.F_Id = '{UserId}'))";
			switch (Stype)
			{
				//按销售额统计
				case 1:
					#region 销售额
					sql += @",
 lim AS(
	SELECT
		SUM (
			CASE
			WHEN order_status = 0 THEN
				price_total
			ELSE
				-price_total
			END
		) AS 'limit',
		user_id_b_b buerid,
		convert(date,create_time) AS 'date'
	FROM
		order_main_spnc
	GROUP BY
		convert(date,create_time),
		user_id_b_b
) SELECT
	orm.fid,orm.rname,lim.[date],lim.limit
FROM
	orm
LEFT JOIN lim ON buerid IN(orm.fid)";
					#endregion
					break;
				case 2:
					#region 渠道数
					sql += @",
 qd AS (
	SELECT
		user_id_c userid,
		convert(date,create_time) AS 'date',
		user_id_b buserid
	FROM
		user_b2c b2c
	GROUP BY
		user_id_b,
		create_time,
		user_id_c
)
	SELECT orm.fid,orm.rname,qd.[date],qd.userid FROM
	orm LEFT JOIN
	qd
	ON
	qd.buserid IN (orm.fid)";
					#endregion
					break;
				case 3:
					#region 按用户数
					sql += @"
,
 qd AS (
	SELECT
		user_id_c userid,
		convert(date,create_time) AS 'date',
		user_id_b buserid
	FROM
		user_b2c b2c
	GROUP BY
		user_id_b,
		create_time,
		user_id_c
),
 us AS (
	SELECT
		user_id_c userid,
		convert(date,create_time) AS 'date',
		user_id_b buserid
	FROM
		user_b2c b2c
	GROUP BY
		user_id_b,
		create_time,
		user_id_c
) SELECT
	orm.fid,
	orm.rname,
	us.[date],
	us.userid
FROM
	orm,
	qd,
	us
WHERE
	qd.buserid IN (orm.fid)
AND us.buserid IN (qd.userid)";
					#endregion
					break;
				default:
					sql += "SELECT * from orm";
					break;
			}
			#endregion
			List<BDLeaderEntity> ReturnEntity = null;
			#region 数据库连接查询返回结果
			using (var db = new SqlConnection(connStr))
			{
				ReturnEntity = db.Query<BDLeaderEntity>(sql, null).ToList<BDLeaderEntity>();
			}
			#endregion
			return ReturnEntity.ToList<BDLeaderEntity>();
		}

	/// <summary>
	/// 获取我的奖励统计 rjy 2018年9月21日17:00:22
	/// </summary>
	/// <param name="UserId">用户id</param>
	/// <returns>返回结果类</returns>
	public AccountEntity GetAccountInfo(int UserId) {

		    	#region sql
			string sql = @"SELECT forecast_gain,wating_gain,balance,cash,t1.user_id,toget from account t1        
         LEFT JOIN
        --已提现金额
        (SELECT sum(cash) as toget, user_id from account_log where bill_type= 1 and user_id = @UserId  GROUP BY user_id) as t4 ON t1.user_id = t4.user_id
         where t1.user_id =@UserId; ";
				#endregion

				#region 参数
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@UserId", UserId);
				#endregion

				#region 数据库连接查询返回结果
				using (var db = new SqlConnection(connStr))
				{
					var ReturnEntity = db.QueryFirstOrDefault<AccountEntity>(sql, parameters);
					if (ReturnEntity == null)
					{
						ReturnEntity = new AccountEntity();
					}
					return ReturnEntity;
				}
				#endregion
			


		}

		/// <summary>
		/// 获取我的奖励中的今日实时奖励
		/// </summary>
		/// <returns></returns>
		public List<ProfitEntity> GetProfitsList(int UserId) {
			#region sql
			string sql = @"SELECT order_no ,cash, user_id,create_time ,status
		   from profit where user_id =@UserId  
		  and status in (0,2) and  datediff(day, create_time, getdate())=0  order by create_time desc";
			#endregion

			#region 参数
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@UserId", UserId);
			#endregion

			#region 数据库连接查询返回结果
			using (var db = new SqlConnection(connStr))
			{
				var ReturnEntity = db.Query<ProfitEntity>(sql, parameters);
				if (ReturnEntity != null)
				{
					return ReturnEntity.ToList<ProfitEntity>();
				}
				return null;
			}
			#endregion
		}

        #endregion

        #region 刘嘉辉
        /// <summary>
        /// 获取我的提现记录
        /// </summary>
        /// <returns></returns>
        public List<PutForwardRecord> GetPutForwardRecordList(int userid)
        {
            //bill_type=1 and can_cashing=0 正式判断 
            //bill_type=0 and can_cashing=1 测试判断（这样会出来数据）
            string sql = @"SELECT CONVERT(varchar(16), alog.create_time, 25) as createtime,alog.cash  as amount 
                           from account_log as alog 
                            where user_id=@userid and bill_type=1 and can_cashing=0";
            DynamicParameters param = new DynamicParameters();
            param.Add("userid", userid);
            using (var db = new SqlConnection(connStr))
            {
                var ReturnEntity = db.Query<PutForwardRecord>(sql, param);
                if (ReturnEntity != null)
                {
                    return ReturnEntity.ToList();
                }
                return null;
            }
        }
        #endregion

    }
}

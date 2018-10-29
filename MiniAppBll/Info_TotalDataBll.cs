
using Dapper;
using DapperEx;
using MiniAppApis.MiniAppBLL;
using MiniAppApis.MiniAppDal;
using MiniAppApis.MiniAppModel;
using MiniAppModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppApis.MiniAppBll
{
    public class Info_TotalDataBll
    {
        /// <summary>
        /// 按销售额查询渠道排行信息
        /// </summary>
        /// <param name="day">日期编号   0是日  1是月  2是年</param>
        /// <returns></returns>
        public List<Info_TotalDataModel> FindEarthTotalBySales(string openid, int date)
        {
            string time = string.Empty;
            using (var db = new BusinessBase().OpenConnection())
            {
                string whereStr = string.Empty ;
                string groupStr = string.Empty;
                if (date == 0)
                {
                    time = DateTime.Now.Day.ToString();//获取天数
                    whereStr = " day(create_time)=@time";
                    groupStr = " group by um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,um.id";
                }
                else if (date == 1)
                {
                    time = DateTime.Now.Month.ToString();//获取当前月份
                    whereStr = " month(create_time)=@time";
                    groupStr = " group by um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,um.id";
                }
                else if (date == 2)
                {
                    time = DateTime.Now.Year.ToString();//获取年份
                    whereStr = " year(create_time)=@time";
                    groupStr = " group by um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,um.id";
                }
                string viewSQl =string.Format( @"select um.id, um.wx_picture,ISNULL(ct.career_type_name,'未激活') as career_type_name,um.user_nickname,isnull( sum(isnull(ord.price_total ,0)), 0) show_messages,
                                   DATEDIFF(DAY,um.create_time,GETDATE()) as count_day,row_number()over(order by sum(ord.price_total)desc) as seniority 
                                   from user_main um
                                   left join (select * from order_main_spnc where {0}) ord on um.id = ord.user_id_b
                                   left join career_type ct on um.career_type = ct.id
                                   left join user_type ut on um.id = ut.user_id
                                   where um.wx_open_id_b=@openid and ut.user_type = 1 {1}", whereStr, groupStr);
              
                DynamicParameters param = new DynamicParameters();
                param.Add("openid", openid);
                param.Add("time", time);
                var result = db.Query<Info_TotalDataModel>(viewSQl, param) as List<Info_TotalDataModel>;
                return result;
            }
        }

        /// <summary>
        /// 根据订单数量显示渠道排行
        /// </summary>
        /// <returns></returns>
        public List<Info_TotalDataModel> FindEarthTotalByOrderCount(string openid, int date)
        {
            string time = string.Empty;
            using (var db = new BusinessBase().OpenConnection())
            {
                string whereStr = string.Empty;
                string groupStr = string.Empty;
                if (date == 0)
                {
                    time = DateTime.Now.Day.ToString();//获取天数
                    whereStr = " day(create_time)=@time";
                    groupStr = " group by um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,um.id";
                }
                else if (date == 1)
                {
                    time = DateTime.Now.Month.ToString();//获取当前月份
                    whereStr = " month(create_time)=@time";
                    groupStr = " group by um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,um.id";
                }
                else if (date == 2)
                {
                    time = DateTime.Now.Year.ToString();//获取年份
                    whereStr = " year(create_time)=@time";
                    groupStr = " group by um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,um.id";
                }
                string viewSQl =string.Format( @"select um.id, um.wx_picture,ISNULL(ct.career_type_name,'未激活') as career_type_name,um.user_nickname,COUNT(ord.user_id) show_messages, 
                                  DATEDIFF(DAY,um.create_time,GETDATE()) as count_day,row_number()over(order by COUNT(ord.user_id) desc) as seniority 
                                  from user_main as um 
                                  left join  (select * from order_main_spnc where  {0}) as ord on um.id=ord.user_id_b
                                  left join career_type ct on um.career_type = ct.id
                                  left join user_type ut on um.id = ut.user_id
                                  where wx_open_id_b=@openid and ut.user_type = 1  {1}", whereStr, groupStr);
                DynamicParameters param = new DynamicParameters();
                param.Add("openid", openid);
                param.Add("time", time);
                var result = db.Query<Info_TotalDataModel>(viewSQl, param) as List<Info_TotalDataModel>;
                return result;
            }
        }
        /// <summary>
        /// 统计新增用户数
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Info_TotalDataModel> FindEarthTotalByNewUserCount(string openid, int date)
        {
            int time=0;
            string filter = "";
            DateTime current = DateTime.Now;
            if (date == 0)
            {
                //日
                time = current.Day;
                filter = string.Format(" day(um.create_time)={0} ",time);
            }
            else if (date == 1)
            {
                //月
                time = current.Month;
                filter = string.Format(" month(um.create_time)={0} ", time);
            }
            else
            {
                //date == 2
                //年
                time = current.Year;
                filter = string.Format(" year(um.create_time)={0} ", time);
            }
            using (var db = new BusinessBase().OpenConnection()) 
            {
                string viewSQl =string.Format(@"with t as (
                                   select um.id,um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time from user_main um 
                                   inner join user_type  as ut on um.id=ut.user_id
                                   left join career_type as ct on um.career_type=ct.id
                                   where um.wx_open_id_b=@openid and ut.user_type=1 and {0}
                                   group by um.id,um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time
                                   )
                                   select t.*,count(*) as show_messages,row_number() over(order by count(*) desc) as seniority,DATEDIFF(DAY,t.create_time,GETDATE())as count_day 
                                   from user_b2c bc join t on bc.user_id_b = t.id
                                   group by t.id,t.wx_picture,t.user_nickname,t.career_type_name,t.create_time", filter);
                DynamicParameters param = new DynamicParameters();
                param.Add("openid", openid);
                param.Add("time", time);
                var result = db.Query<Info_TotalDataModel>(viewSQl, param) as List<Info_TotalDataModel>;
                return result;
            }
        }

        /// <summary>
        /// 统计引流用户数
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Info_TotalDataModel> FindEarthTotalByNewdrainageCount(string openid, int date)
        {
            string time = string.Empty;
            using (var db = new BusinessBase().OpenConnection())
            {
                string whereStr = string.Empty;
                string groupStr = string.Empty;
                if (date == 0)
                {
                    time = DateTime.Now.Day.ToString();//获取天数
                    whereStr = " day(create_time)=@time";
                    groupStr = " group by um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,um.id";
                }
                else if (date == 1)
                {
                    time = DateTime.Now.Month.ToString();//获取当前月份
                    whereStr = " month(create_time)=@time";
                    groupStr = " group by um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,um.id";
                }
                else if (date == 2)
                {
                    time = DateTime.Now.Year.ToString();//获取年份
                    whereStr = " year(create_time)=@time";
                    groupStr = " group by um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,um.id";
                }
                string viewSQl = string.Format(@"select um.id,um.wx_picture,um.user_nickname,ct.career_type_name,um.create_time,count(*) as show_messages,
                                   DATEDIFF(DAY,um.create_time,GETDATE()) as count_day,row_number() over(order by count(*) desc) as seniority
                                   from(select * from order_main_spnc where {0}) as oms
                                   join user_main as um on um.id=oms.user_id_b
                                   left join user_type  as ut on um.id=ut.user_id
                                   left join career_type as ct on um.career_type=ct.id
                                   where oms.Is_Import='1' and ut.user_type='1' and oms.wx_openid_bb=@openid {1}", whereStr, groupStr);
                DynamicParameters param = new DynamicParameters();
                param.Add("openid", openid);
                param.Add("time", time);
                var result = db.Query<Info_TotalDataModel>(viewSQl, param) as List<Info_TotalDataModel>;
                return result;
            }
        }


        /// <summary>
        /// 获取渠道业绩
        /// </summary>
        /// <param name="userid">用户Id</param>
        /// <param name="date">日期编号   0是日  1是月  2是年</param>
        /// <returns></returns>
        public Channel_AchievementDataModel GetChannel_Achievement(string openid, int date)
        {
            string PastTimes = string.Empty;//过去时间
            string NowData = string.Empty;//现在时间
            string userPastTimes = string.Empty;//用户表过去时间
            string userNowData = string.Empty;//用户表现在时间
            switch (date)
            {
                case 0:
                    PastTimes = " DateDiff(dd,create_time,getdate())=1";
                    NowData = "  DateDiff(dd,create_time,getdate())=0";
                    userPastTimes = " DateDiff(dd,ums.create_time,getdate())=1";
                    userNowData = "  DateDiff(dd,ums.create_time,getdate())=0";
                    break;
                case 1:
                    PastTimes = " DateDiff(mm,create_time,getdate())=1";
                    NowData = " DateDiff(mm,create_time,getdate())=0";
                    userPastTimes = " DateDiff(mm,ums.create_time,getdate())=1";
                    userNowData = "  DateDiff(mm,ums.create_time,getdate())=0";
                    break;
                case 2:
                    PastTimes = " DateDiff(yy,create_time,getdate())=1";
                    NowData = " DateDiff(yy,create_time,getdate())=0";
                    userPastTimes = " DateDiff(yy,ums.create_time,getdate())=1";
                    userNowData = "  DateDiff(yy,ums.create_time,getdate())=0";
                    break;
            }
            using (var db = new BusinessBase().OpenConnection())
            {

                string sql = string.Format(@"select (
				(   select  isnull( sum(isnull(ord.price_total ,0)), 0)
                                   from user_main um
                                   inner join (select * from order_main_spnc where  {1})  ord on um.id = ord.user_id_b
                                   left join career_type ct on um.career_type = ct.id
                                   left join user_type ut on um.id = ut.user_id
                                   where um.wx_open_id_b='{0}' and ut.user_type = 1)) as sales,
				(   select COUNT(*) 
                                  from user_main as um 
                                  inner join (select * from order_main_spnc where  {1}) as ord on um.id=ord.user_id_b
                                  left join career_type ct on um.career_type = ct.id
                                  left join user_type ut on um.id = ut.user_id
                                  where wx_open_id_b='{0}' and ut.user_type = 1  ) as ordernum,
				(	select count(*) from user_main um 
									inner join user_type ut on um.id = ut.user_id
									where wx_open_id_b in (
									select wx_open_id from user_main ums where wx_open_id_b='{0}' and {3})
									and ut.user_type=3) as newuser,
				(   select count(*)
                                   from (select * from order_main_spnc where  {1}) as oms
                                   join user_main as um on um.id=oms.user_id_b
                                   left join user_type  as ut on um.id=ut.user_id
                                   left join career_type as ct on um.career_type=ct.id
                                   where oms.Is_Import='1' and ut.user_type='1' and oms.wx_openid_bb='{0}') as drainage
				union all
				select (
				(   select isnull( sum(isnull(ord.price_total ,0)), 0)
                                   from user_main um
                                   inner join (select * from order_main_spnc where  {2}) ord on um.id = ord.user_id_b
                                   left join career_type ct on um.career_type = ct.id
                                   left join user_type ut on um.id = ut.user_id
                                   where um.wx_open_id_b='{0}' and ut.user_type = 1 )) as sales,
				(   select COUNT(*) 
                                  from user_main as um 
                                  inner join (select * from order_main_spnc where  {2}) as ord on um.id=ord.user_id_b
                                  left join career_type ct on um.career_type = ct.id
                                  left join user_type ut on um.id = ut.user_id
                                  where wx_open_id_b='{0}' and ut.user_type = 1 ) as ordernum,
				(	select count(*) from user_main um 
									inner join user_type ut on um.id = ut.user_id
									where wx_open_id_b in (
									select wx_open_id from user_main ums where wx_open_id_b='{0}'  and {4})
									and ut.user_type=3) as newuser,
				(   select count(*)
                                   from (select * from order_main_spnc where  {2}) as oms
                                   join user_main as um on um.id=oms.user_id_b
                                   left join user_type  as ut on um.id=ut.user_id
                                   left join career_type as ct on um.career_type=ct.id
                                   where oms.Is_Import='1' and ut.user_type='1' and oms.wx_openid_bb='{0}') as drainage", openid, PastTimes, NowData, userPastTimes, userNowData);

                var List = db.Query<Channel_AchievementDataModel>(sql) as List<Channel_AchievementDataModel>;
                Channel_AchievementDataModel dataModel = List[1];//赋值现在时间数据
                //今日数据 减去昨日数据 除以昨日数据
                dataModel.salestage = Convert.ToDouble(List[0].sales) > 0 ? Math.Round((Convert.ToDouble(List[1].sales) - Convert.ToDouble(List[0].sales)) / Convert.ToDouble(List[0].sales) * 100, 2) : 0.00;
                dataModel.ordernumtage = List[0].ordernum > 0 ? Math.Round(Convert.ToDouble((List[1].ordernum - List[0].ordernum) / List[0].ordernum) * 100, 2) : 0;
                dataModel.newusertage = List[0].newuser > 0 ? Math.Round((Convert.ToDouble(List[1].newuser) - Convert.ToDouble(List[0].newuser)) / Convert.ToDouble(List[0].newuser) * 100, 2): 0;
                dataModel.drainagetage = List[0].drainage > 0 ?Math.Round(Convert.ToDouble((List[1].drainage - List[0].drainage) / List[0].drainage) * 100, 2) : 0;
                dataModel.salesstates = dataModel.salestage >= 0 ? 0 : 1;
                dataModel.ordernumstates = dataModel.ordernumtage >= 0 ? 0 : 1;
                dataModel.newuserstates = dataModel.newusertage >= 0 ? 0 : 1;
                dataModel.drainagestates = dataModel.drainagetage >= 0 ? 0 : 1;
                return dataModel;
            }
        }


        /// <summary>
        /// 获取渠道详细信息
        /// </summary>
        /// <returns>渠道id</returns>
        public Channel_User_Info GetChannel_User_Info(int userid)
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string sql = @"select ut.user_type_name as channeltype,ue.name as username,ue.mobile_number as phone,ct.career_type_name as channelname,up.village as address
                               from user_main as um
                               join user_type as ut on um.id=ut.user_id
                               left join user_extra as ue on um.id=ue.user_id
                               left join career_type as ct on um.career_type=ct.id
                               left join user_pickup_info as up on um.id=up.user_id
                               where ut.user_type=1 and um.id=@userid ";
                DynamicParameters param = new DynamicParameters();
                param.Add("userid", userid);
                var result = db.Query<Channel_User_Info>(sql, param) as List<Channel_User_Info>;
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 根据渠道id查询渠道具体详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Info_TotalDataModel FindChannelDetail(int id)
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string sqlView = (@"select um.id,um.wx_picture,ISNULL(ct.career_type_name,'未激活') as career_type_name,um.user_nickname,
                                    DATEDIFF(DAY,um.create_time,GETDATE()) as count_day from user_main um
                                    left join career_type ct on um.career_type = ct.id
                                    where um.id=@id");

                DynamicParameters param = new DynamicParameters();
                param.Add("id", id);
                var result = db.Query<Info_TotalDataModel>(sqlView, param) as List<Info_TotalDataModel>;
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 查询某一具体渠道的业绩
        /// </summary>
        /// <param name="id">渠道id</param>
        /// <param name="date">日期编号   0是日  1是月  2是年</param>
        /// <returns></returns>
        public Channel_AchievementDataModel GetChannel_AchievementById(int id, int date)
        {
            string PastTimes = string.Empty;//过去时间
            string NowData = string.Empty;//现在时间
            string userPastTimes = string.Empty;//过去时间
            string userNowData = string.Empty;//现在时间


            switch (date)
            {
                case 0:
                    PastTimes = " DateDiff(dd,create_time,getdate())=1";
                    NowData = "  DateDiff(dd,create_time,getdate())=0";
                    userPastTimes = " DateDiff(dd,ums.create_time,getdate())=1";
                    userNowData = "  DateDiff(dd,ums.create_time,getdate())=0";
                    break;
                case 1:
                    PastTimes = " DateDiff(mm,create_time,getdate())=1";
                    NowData = " DateDiff(mm,create_time,getdate())=0";
                    userPastTimes = " DateDiff(mm,ums.create_time,getdate())=1";
                    userNowData = "  DateDiff(mm,ums.create_time,getdate())=0";
                    break;
                case 2:
                    PastTimes = " DateDiff(yy,create_time,getdate())=1";
                    NowData = " DateDiff(yy,create_time,getdate())=0";
                    userPastTimes = " DateDiff(yy,ums.create_time,getdate())=1";
                    userNowData = "  DateDiff(yy,ums.create_time,getdate())=0";
                    break;
            }
            using (var db = new BusinessBase().OpenConnection())
            {

                string sql = string.Format(@"select (
				(   select  isnull(sum(isnull(ord.price_total ,0)), 0)
                                   from user_main um
                                   inner join (select * from order_main_spnc where  {1})  ord on um.id = ord.user_id_b
                                   left join user_type ut on um.id = ut.user_id
                                   where um.id='{0}' and ut.user_type = 1)) as sales,
				(   select COUNT(*) 
                                  from user_main as um 
                                  inner join (select * from order_main_spnc where {1}) as ord on um.id=ord.user_id_b
                                  left join user_type ut on um.id = ut.user_id
                                  where um.id='{0}' and ut.user_type = 1 ) as ordernum,
				(	select count(*) from user_main um 
									inner join user_type ut on um.id = ut.user_id
									where wx_open_id_b in (
									select wx_open_id from user_main ums where ums.id='{0}' and {3})
									and ut.user_type=3) as newuser,
				(   select count(*)
                                   from (select * from order_main_spnc where  {1}) as oms
                                   join user_main as um on um.id=oms.user_id_b
                                   left join user_type  as ut on um.id=ut.user_id
                                   where oms.Is_Import='1' and ut.user_type='1' and oms.user_id='{0}') as drainage
				union all
				select (
				(   select isnull( sum(isnull(ord.price_total ,0)), 0)
                                   from user_main um
                                   inner join (select * from order_main_spnc where {2}) ord on um.id = ord.user_id_b
                                   left join user_type ut on um.id = ut.user_id
                                   where um.id='{0}' and ut.user_type = 1 )) as sales,
				(   select COUNT(*) 
                                  from user_main as um 
                                  inner join (select * from order_main_spnc where  {2}) as ord on um.id=ord.user_id_b
                                  left join user_type ut on um.id = ut.user_id
                                  where um.id='{0}' and ut.user_type = 1 ) as ordernum,
				(	select count(*) from user_main um 
									inner join user_type ut on um.id = ut.user_id
									where wx_open_id_b in (
									select wx_open_id from user_main ums where ums.id='{0}' and {4})
									and ut.user_type=3) as newuser,
				(   select count(*)
                                   from (select * from order_main_spnc where  {2}) as oms
                                   join user_main as um on um.id=oms.user_id_b
                                   left join user_type  as ut on um.id=ut.user_id
                                   left join career_type as ct on um.career_type=ct.id
                                   where oms.Is_Import='1' and ut.user_type='1' and oms.user_id='{0}') as drainage", id, PastTimes, NowData, userPastTimes, userNowData);

                var List = db.Query<Channel_AchievementDataModel>(sql) as List<Channel_AchievementDataModel>;
                Channel_AchievementDataModel dataModel = List[1];//赋值现在时间数据
                //今日数据 减去昨日数据 除以昨日数据
                dataModel.salestage = Convert.ToDouble(List[0].sales) > 0 ? Math.Round((Convert.ToDouble(List[1].sales) - Convert.ToDouble(List[0].sales)) / Convert.ToDouble(List[0].sales) * 100, 2) : 0.00;
                dataModel.ordernumtage = List[0].ordernum > 0 ? Math.Round(Convert.ToDouble((List[1].ordernum - List[0].ordernum) / List[0].ordernum) * 100, 2) : 0;
                dataModel.newusertage = List[0].newuser > 0 ? Math.Round((Convert.ToDouble(List[1].newuser) - Convert.ToDouble(List[0].newuser)) / Convert.ToDouble(List[0].newuser) * 100, 2) : 0;
                dataModel.drainagetage = List[0].drainage > 0 ? Math.Round(Convert.ToDouble((List[1].drainage - List[0].drainage) / List[0].drainage) * 100, 2) : 0;
                dataModel.salesstates = dataModel.salestage >= 0 ? 0 : 1;
                dataModel.ordernumstates = dataModel.ordernumtage >= 0 ? 0 : 1;
                dataModel.newuserstates = dataModel.newusertage >= 0 ? 0 : 1;
                dataModel.drainagestates = dataModel.drainagetage >= 0 ? 0 : 1;
                return dataModel;
            }

        }





    }
}

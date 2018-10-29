using Dapper;
using MiniAppApis.MiniAppDAL;
using MiniAppModel.TotalChannel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiniAppModel.TotalChannel.TotalChannelModel;

namespace MiniAppDal.TotalChannelDal
{
    public class TotalChanelDal
    {
        /// <summary>
        ///  查询7天内所有的地推下的渠道数
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<TotalChannelModel> FindAllChannelCount(string startTime, string endTime)
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string viewSQl = string.Format(@"with dtbd as (
                                               select wx_open_id,name from user_main um 
                                               inner join user_type ut on um.id=ut.user_id 
                                               inner join user_extra ue on um.id=ue.user_id
                                               where ut.user_type =0 and um.is_available =0)
                                               select count(dtbd.wx_open_id)as channelCount,convert(varchar(100),um.create_time,23)as date,
                                               isnull(dtbd.name,'匿名') as name from dtbd 
                                               inner join user_main um on dtbd.wx_open_id = um.wx_open_id_b 
                                               inner join user_type ut on um.id = ut.user_id
                                               where ut.user_type=1 and um.create_time between '{0}'and '{1}'
                                               group by convert(varchar(100),um.create_time,23),dtbd.name", startTime, endTime);
                var result = db.Query<TotalChannelModel>(viewSQl) as List<TotalChannelModel>;
                return result;
            }
        }

        /// <summary>
        /// 查询所有的地推信息
        /// </summary>
        /// <returns></returns>
        public List<TotalChannelModel> FindAllEarthPushName()
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string viewSQl = @" with dtbd as (
                                   select wx_open_id,name,um.create_time from user_main um 
                                   inner join user_type ut on um.id=ut.user_id
                                   inner join user_extra ue on um.id=ue.user_id
                                   where ut.user_type =0 and um.is_available =0)
                                   select count(dtbd.wx_open_id),dtbd.wx_open_id,dtbd.name from dtbd 
                                   inner join user_main um on dtbd.wx_open_id = um.wx_open_id_b 
                                   inner join user_type ut on um.id = ut.user_id
                                   where ut.user_type=1
                                   group by dtbd.wx_open_id,dtbd.name,dtbd.create_time
                                   order by convert(varchar(10),dtbd.create_time,23) asc";
                var result = db.Query<TotalChannelModel>(viewSQl) as List<TotalChannelModel>;
                return result;
            }
        }

        
    }
}

using Dapper;
using MiniAppModel.RewardDetail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MiniAppDal.RewardDetailDal
{
    public class DalReward
    {

        public string connStr = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
        /// <summary>
        /// 获取奖励明细，包含未分润奖励、今日预估奖励
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<ProfitInfoEntity> GetProfitList(int userid, string status)
        {
            //rjy 2018年9月19日17:46:36 奖励明细和收支明细按时间倒序排序问题处理
            string sql = @"SELECT order_no as OrderNO,cash, user_id,create_time as CreateTime,status,MONTH(create_time) as Month from profit where user_id = @userid  {0}    order by CreateTime desc;";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userid", userid);
            string whereSql = string.Empty;
            //今日预估奖励
            if (string.IsNullOrEmpty(status))
            {
                whereSql = "  and status = 0 and datediff(day, create_time, getdate())= 0";
            }
            else//各种状态的奖励
            {
                whereSql = string.Format("  and status in({0})", status);
            }

            using (SqlConnection db = new SqlConnection(connStr))
            {
                sql = string.Format(sql, whereSql);
                return db.Query<ProfitInfoEntity>(sql, parameters).AsList();
            }
        }
        public List<Profit> getProfitSum(int userid)
        {

            string sql = string.Format(@"SELECT SUM(cash) as SumCash FROM profit WHERE user_id={0}", userid);

            using (SqlConnection db = new SqlConnection(connStr))
            {
                sql = string.Format(sql);
                return db.Query<Profit>(sql).AsList(); 
            }

        }
    }
}

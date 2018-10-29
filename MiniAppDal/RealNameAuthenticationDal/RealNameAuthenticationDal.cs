using Dapper;
using MiniAppApis.MiniAppDAL;
using MiniAppDal.PutForward;
using MiniAppModel.RealNameAuthentication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppDal.RealNameAuthenticationDal
{
   public class RealNameAuthenticationDal
    {
        /// <summary>
        /// 添加用户实名认证信息
        /// </summary>
        /// <param name="realNameModel"></param>
        /// <returns></returns>
        public int AddRealName(RealNameAuthenticationModel realNameModel)
        {
            int result = 0;
            string viewSQl = (@"insert into user_realInfo (user_id,real_name,card_type,card_no,create_time,update_time)
                                values(@user_id,@real_name,@card_type,@card_no,(getdate()),(getdate()));");
            DynamicParameters insertParam = new DynamicParameters();
            insertParam.Add("@user_id", realNameModel.user_id);
            insertParam.Add("@real_name", realNameModel.real_name);
            insertParam.Add("@card_type", realNameModel.card_type);
            insertParam.Add("@card_no", realNameModel.card_no);
            using (var conn = new SqlConnection(DBConn.connStr))
            {
                conn.Open();
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    result = conn.Execute(viewSQl, insertParam, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return result;
                }
                return result;
            }
        }

        /// <summary>
        /// 查询实名认证信息
        /// </summary>
        /// <returns></returns>
        public RealNameAuthenticationModel FindRealName(int user_id)
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string viewSQl = (@"select real_name,card_no,card_type from user_realInfo where user_id=@user_id");
                DynamicParameters param = new DynamicParameters();
                param.Add("user_id", user_id);
                var result = db.Query<RealNameAuthenticationModel>(viewSQl, param);
                return result.FirstOrDefault();
            }
        }

    }
}

using Dapper;
using MiniAppModel;
using MiniAppModel.Entity;
using MiniAppModel.RewardDetail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MiniAppDal.PutForward
{
    public class NoAwardDAL
    {
        /// <summary>
        /// 暂不可提现列表
        /// </summary>
        /// <param name="userid"></param>
        public List<ProfitInfoEntity> GetProfitListNoWard(int userid)
        {
            string sql = @"SELECT order_no as OrderNO,cash,create_time as CreateTime,status from profit where user_id = @userid  and status in(0,1,2) and update_time>=@update_time  order by CreateTime desc;";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userid", userid);
            DateTime dt = DateTime.Now;
            parameters.Add("@update_time", new DateTime(dt.Year, dt.Month, 1).ToString("yyyy/MM/dd"));
            using (SqlConnection db = new SqlConnection(DBConn.connStr))
            {
                return db.Query<ProfitInfoEntity>(sql, parameters).AsList();
            }
        }


        /// <summary>
        /// 查询余额是否可提现
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public AccountEntity GetAccountInfo(int UserId)
        {
            string sql = @"SELECT t1.id as accountId,wating_gain,balance,cash,wx_open_id as openId from account t1     
         INNER  JOIN
        (SELECT wx_open_id,id from user_main where  id = @UserId  ) as t4 
                    ON t1.user_id = t4.id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", UserId);

            using (var db = new SqlConnection(DBConn.connStr))
            {
                var ReturnEntity = db.QueryFirstOrDefault<AccountEntity>(sql, parameters);
                if (ReturnEntity == null)
                {
                    ReturnEntity = new AccountEntity();
                }
                return ReturnEntity;
            }
        }

        public bool UpdateAccountInfo(Account_Log log)
        {
            //添加转账记录
            string logSql = @"INSERT INTO [WeChatServiceFlatform].[dbo].[account_log] ([create_time], [update_time], [can_cashing], [bill_type], [pay_no], 
                           [pay_way], [user_id], [account_id], [is_freezing], [collection_account], [cash]) 
                            VALUES (GETDATE(),@update_time,1,'1',@pay_no,@pay_way,@user_id, @account_id, '0', @collection_account, @cash);";
            DynamicParameters insertParam = new DynamicParameters();
            insertParam.Add("@update_time", log.update_time);
            insertParam.Add("@pay_no", log.pay_no);
            insertParam.Add("@pay_way", log.pay_way);
            insertParam.Add("@user_id", log.user_id);
            insertParam.Add("@account_id", log.account_id);
            insertParam.Add("@collection_account", log.collection_account);
            insertParam.Add("@cash", log.cash);

            //跟新账户余额
            string Accsql = @"UPDATE [dbo].[account] SET  [update_time]=@update_time,[balance]=balance-@cash,[cash]=cash-@cash 
                WHERE [user_id]=@user_id;";
            DynamicParameters updateParam = new DynamicParameters();
            updateParam.Add("@update_time", log.update_time);
            updateParam.Add("@cash", log.cash);
            updateParam.Add("@user_id", log.user_id);
            using (var conn = new SqlConnection(DBConn.connStr))
            {
                conn.Open();
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    conn.Execute(logSql, insertParam, transaction);
                    conn.Execute(Accsql, updateParam, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }

                return true;
            }
        }
    }
}

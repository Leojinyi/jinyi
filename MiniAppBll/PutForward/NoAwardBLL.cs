using MiniAppDal.PutForward;
using MiniAppModel;
using MiniAppModel.Entity;
using MiniAppModel.RewardDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppBll.PutForward
{
   public  class NoAwardBLL
    {
        public NoAwardDAL noAwardDAL { get { return new NoAwardDAL(); } }
        /// <summary>
        /// 暂不可提现列表
        /// </summary>
        /// <param name="userid"></param>
        public List<ProfitInfoEntity> GetProfitListNoWard(int userid)
        {
            return noAwardDAL.GetProfitListNoWard(userid);
        }

        /// <summary>
        /// 查询余额是否可提现
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public AccountEntity GetAccountInfo(int UserId)
        {
            return noAwardDAL.GetAccountInfo(UserId);
        }

        /// <summary>
        /// 提现加日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool UpdateAccountInfo(Account_Log log)
        {
            return  noAwardDAL.UpdateAccountInfo(log);
        }
    }
}

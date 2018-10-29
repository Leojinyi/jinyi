using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniAppDal;
using MiniAppModel;
using MiniAppModel.RewardDetail;
using MiniAppDal.RewardDetailDal;
namespace MiniAppBll.RewardDetailBll
{
    public class BllReward
    {
        DalReward dal = new DalReward();
        /// <summary>
        /// 获取奖励明细(包含未发放奖励、奖励明细)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<ProfitListEntityList> GetProfitList(int userid, string status)
        {
            List<ProfitInfoEntity> profitInfoEntities = dal.GetProfitList(userid, status);
            List<string> strMoth= profitInfoEntities.Select(c => c.Month).Distinct().ToList();
            List<ProfitListEntityList> profitListEntityList = new List<ProfitListEntityList>(); 
            foreach (var item in strMoth)
            {
                ProfitListEntityList profitListEntity = new ProfitListEntityList();
                profitListEntity.Mouth = item;
                profitListEntity.datas=profitInfoEntities.Where(c => c.Month == item).ToList();
                //profitListEntity.amount = profitInfoEntities.Sum(c => c.cash);
                profitListEntityList.Add(profitListEntity);
            }
            return profitListEntityList;
        }

        public List<Profit> getProfitSum(int userid)
        {
            return dal.getProfitSum(userid);
        }
    }
}

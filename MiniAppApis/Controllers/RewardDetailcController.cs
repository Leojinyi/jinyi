using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Common.ReturnResult;
using MiniAppApis.App_Start;
using MiniAppApis.ParamEntity;
using MiniAppBll.RewardDetailBll;
using MiniAppModel.RewardDetail;
namespace MiniAppApis.Controllers
{
    [AuthorizeFilter]
    [RoutePrefix("RewardDetailc")]
    public class RewardDetailcController : ApiController
    {
        BllReward bll = new BllReward();
        /// <summary>
        ///获取奖励明细
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetProfitList")]
        public IHttpActionResult GetProfitList(checkReward checkReward)
        {
            var json = new Dictionary<string, object>();
            json.Add("ProfitList", bll.GetProfitList(checkReward.userid, checkReward.status));
            ResultInfo<Dictionary<string, object>> resultInfo = new ResultInfo<Dictionary<string, object>>();
            resultInfo.ResultData = json;
            resultInfo.ResultMsgDetail = "奖励明细";
            return Json(resultInfo);

        }

        [HttpPost]
        [Route("getProfitSum")]
        public IHttpActionResult getProfitSum(checkReward checkReward)
        {
            var json = new Dictionary<string, object>();
            json.Add("ProfitList", bll.getProfitSum(checkReward.userid));
            ResultInfo<Dictionary<string, object>> resultInfo = new ResultInfo<Dictionary<string, object>>();
            resultInfo.ResultData = json;
            resultInfo.ResultMsgDetail = "总金额";
            return Json(resultInfo);
        }
    }
}

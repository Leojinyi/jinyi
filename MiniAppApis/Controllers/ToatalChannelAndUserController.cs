using Common.ReturnResult;
using MiniAppApis.App_Start;
using MiniAppApis.Log;
using MiniAppApis.ParamEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using MiniAppBll.BDtoCuser;
using MiniAppModel.LeadData;
using MiniAppModel.LeadResult;
using MiniAppApis.Models;
using MiniAppModel.TotalChannel;
using MiniAppBll.TotalChannelBll;

namespace MiniAppApis.Controllers
{
    [RoutePrefix("ToatalChannelAndUser")]
    /// <summary>
    /// 我的渠道
    /// </summary>
    [AuthorizeFilter]
    public class ToatalChannelAndUserController : ApiController
    {
        TotalChannelBll channelBll = new TotalChannelBll();
		/// <summary>
		/// 统计所有地推下的所有渠道数
		/// </summary>
		/// <param name="timeType"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("GetTotalChannel")]
		public ResultInfo<TotalChannelResult> GetTotalChannel(TotalChannelEntity parms)
		{
			ResultInfo<TotalChannelResult> result = new ResultInfo<TotalChannelResult>();
			try
			{
				TotalChannelResult channelResultList = new TotalChannelResult();
				if (parms != null)
				{
					channelResultList = channelBll.TotalChannelResult(parms.timeType.ToString());
					result.ResultData = channelResultList;
					result.ResultCode = EmResultDescribe.OK;
					LogInfo.InfoLogMessage("/TotalChannelData/GetTotalChannel", JsonConvert.SerializeObject(parms), JsonConvert.SerializeObject(result.ResultData));
					return result;
				}
			}
			catch (Exception ex)
			{
				result.ResultData = null;
				result.ResultCode = EmResultDescribe.系统错误;
				LogInfo.ErrorLogMessage("/TotalChannelData/GetTotalChannel", JsonConvert.SerializeObject(parms), JsonConvert.SerializeObject(result.ResultData), ex.Message);
			}
			return result;
		}

		[HttpPost]
        [Route("GetBDtoCuserList")]
        public async Task<ResultInfo<BDtoCuserResultList>> GetBDtoCuserList(checkBDtoC content)
        {
            ResultInfo<BDtoCuserResultList> result = new ResultInfo<BDtoCuserResultList>();
            dynamic data = content.conten;
            if ((string)data == null)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.缺少必要信息;
            }
            else
            {
                result.ResultCode = EmResultDescribe.OK;
                result.ResultData = await BDtoCuserBLL.Instance.GetBDtoCuserList((string)data);
                LogInfo.InfoLogMessage("/TotalChannelData/GetBDtoCuserList", JsonConvert.SerializeObject(content), JsonConvert.SerializeObject(result.ResultData));
            }
            return result;
        }
    }
}

using Common.ReturnResult;
using MiniAppApis.App_Start;
using MiniAppApis.Models;
using MiniAppBll.LeadData;
using MiniAppModel.LeadReault;
using MiniAppModel.LeadResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MiniAppApis.Controllers
{
	[AuthorizeFilter]
	/// <summary>
	/// 领导页面接口
	/// author:林辉
	/// </summary>
	[RoutePrefix("api/leadData")]
    public class LeadDataController : ApiController
    {
		#region rjy
		/// <summary>
		/// 用户七天总量
		/// </summary>
		/// <returns></returns>
		[HttpPost]
        [Route("userCount")]
        public async Task<ResultInfo<UserCountResult>> GetUserChangeCountAsync(RequestParameter content)
        {
            ResultInfo<UserCountResult> result = new ResultInfo<UserCountResult>();
			dynamic data = content.conten;
			if ((string)data.timeType == null)
			{
				result.ResultCode = EmResultDescribe.缺少必要信息;
			}
			else
			{
				result.ResultData = await LeadDataLogic.Instance.GetNewUserChangeCountAsync((string)data.timeType);
			}
			return result;
		}

		/// <summary>
		/// 用户七天总量
		/// </summary>
		/// <returns></returns>

		[HttpPost]
        [Route("getSaleroom")]
        public async Task<ResultInfo<SaleroomResult>> GetSaleroomAsync(RequestParameter content)
        {
            ResultInfo<SaleroomResult> result = new ResultInfo<SaleroomResult>();
            dynamic data = content.conten;
            if ((string)data.timeType == null)
            {
                result.ResultCode = EmResultDescribe.缺少必要信息;
            }
            else
            {
                result.ResultData = await LeadDataLogic.Instance.GetNewSaleroomAsync((string)data.timeType);
            }

            return result;
        }

		/// <summary>
		/// 用户七天总量
		/// </summary>
		/// <returns></returns>
		[HttpPost]
        [Route("getOrderDetails")]
        public async Task<ResultInfo<DetailsResult>> GetOrderDetailsAsync(RequestParameter content)
        {
            ResultInfo<DetailsResult> result = new ResultInfo<DetailsResult>();
            dynamic data = content.conten;
            if ((string)data.timeType == null || (string)data.type == null || (string)data.time == null)
            {
                result.ResultCode = EmResultDescribe.缺少必要信息;
            }
            else
            {

                result.ResultData = await LeadDataLogic.Instance.GetOrderDetailsAsync(DateTime.Parse((string)data.time), ((string)data.timeType), (string)data.type);
            }

            return result;
        }

        #endregion


        #region 刘嘉辉
        /// <summary>
        /// 总渠道
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetChannelSurvey")]
        public ResultInfo<ChannelSurvey> GetChannelSurvey(RequestParameter content)
        {
            ResultInfo<ChannelSurvey> result = new ResultInfo<ChannelSurvey>();
            ChannelSurvey channelSurvey = new ChannelSurvey();
            channelSurvey.details = LeadDataLogic.Instance.GetTotalChannel();
            channelSurvey.bDData = LeadDataLogic.Instance.GetBDDatas().OrderByDescending(c=>c.num).ToList();
            result.ResultData = channelSurvey;
            return result;
        }

        /// <summary>
        /// 单日情况数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetDayData")]
        public ResultInfo<DayDataResult> GetDayData(RequestParameter content)
        {
            ResultInfo<DayDataResult> result = new ResultInfo<DayDataResult>();
            dynamic data = content.conten;
            if ((string)data.timeType == null || (string)data.getName == null)
            {
                result.ResultCode = EmResultDescribe.缺少必要信息;
            }
            else
            {
                var dayData = LeadDataLogic.Instance.GetDayData((string)data.timeType, (string)data.getName);
                DayDataResult dayDataResult = new DayDataResult();
                dayDataResult.createtime = dayData.createtime;
                dayDataResult.value = dayData.value;
                result.ResultData = dayDataResult;
            }
            return result;
        }
        #endregion
    }

}

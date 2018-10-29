
using log4net;
using MiniAppApis.MiniAppModel;
using MiniAppApis.MiniAppBll;
using MiniAppApis.ParamEntity;
using MiniAppModel;
using System.Collections.Generic;
using System.Web.Http;
using Common.ReturnResult;
using System;
using Newtonsoft.Json;
using MiniAppApis.Log;
using MiniAppApis.App_Start;

namespace MiniAppApis.Controllers
{
    [RoutePrefix("Info_TotalData")]
    /// <summary>
    /// 我的渠道
    /// </summary>
    [AuthorizeFilter]
    public class Info_TotalDataController : ApiController
    {
        Info_TotalDataBll totalDataBll = new Info_TotalDataBll();


        [HttpPost]
        [Route("GetCanalList")]
        public ResultInfo<List<Info_TotalDataModel>>GetCanalList(ChannelParms parms)
        {
            ResultInfo<List<Info_TotalDataModel>> result = new ResultInfo<List<Info_TotalDataModel>>();
            try
            {
                List<Info_TotalDataModel> canalListByday = new List<Info_TotalDataModel>();
                if (parms.check_type ==0)//按销售额查询渠道信息
                {
                    canalListByday = totalDataBll.FindEarthTotalBySales(parms.openid, parms.date);
                }
                else if (parms.check_type==1)//按订单数查询渠道信息
                {
                    canalListByday = totalDataBll.FindEarthTotalByOrderCount(parms.openid,parms.date);
                }
                else if (parms.check_type==2)//按拉新用户查询渠道信息
                {
                    canalListByday = totalDataBll.FindEarthTotalByNewUserCount(parms.openid, parms.date);
                }
                else if (parms.check_type==3)//按引流数查询渠道信息
                {
                    canalListByday = totalDataBll.FindEarthTotalByNewdrainageCount(parms.openid, parms.date);
                }
                result.ResultData = canalListByday;
                result.ResultCode = EmResultDescribe.OK;
                LogInfo.InfoLogMessage("/Info_TotalData/GetCanalList", JsonConvert.SerializeObject(parms), JsonConvert.SerializeObject(result.ResultData));
                return result;
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/Info_TotalData/GetCanalList", JsonConvert.SerializeObject(parms), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }

        #region 刘嘉辉
        /// <summary>
        /// 获取渠道详细信息
        /// </summary>
        /// <param name="userid">渠道id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetChannelUserInfo")]
        public ResultInfo<Channel_User_Info> GetChannelUserInfo(ChannelUserInfoEntity channelui)
        {
            ResultInfo<Channel_User_Info> result = new ResultInfo<Channel_User_Info>();
            try
            {
                result.ResultData = totalDataBll.GetChannel_User_Info(channelui.id);
                result.ResultCode = EmResultDescribe.OK;
                LogInfo.InfoLogMessage("/Info_TotalData/GetChannelUserInfo", JsonConvert.SerializeObject(channelui), JsonConvert.SerializeObject(result.ResultData));
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/Info_TotalData/GetChannelUserInfo", JsonConvert.SerializeObject(channelui), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 获取某个渠道的详细信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetChannelDetail")]
        public ResultInfo<Info_TotalDataModel> GetChannelDetail(ChannelDetail parms)
        {
            ResultInfo<Info_TotalDataModel> result = new ResultInfo<Info_TotalDataModel>();
            try
            {
                result.ResultData = totalDataBll.FindChannelDetail(parms.id);
                result.ResultCode = EmResultDescribe.OK;
                LogInfo.InfoLogMessage("/Info_TotalData/GetChannelDetail", JsonConvert.SerializeObject(parms), JsonConvert.SerializeObject(result.ResultData));
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/Info_TotalData/GetChannelDetail", JsonConvert.SerializeObject(parms), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 获取某个渠道的业绩
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetChannel_AchievementById")]
        public ResultInfo<Channel_AchievementDataModel> GetChannel_AchievementById(ChannelAchievement parms)
        {
            ResultInfo<Channel_AchievementDataModel> result = new ResultInfo<Channel_AchievementDataModel>();
            try
            {
                result.ResultData = totalDataBll.GetChannel_AchievementById(parms.id, parms.date);
                result.ResultCode = EmResultDescribe.OK;
                LogInfo.InfoLogMessage("/Info_TotalData/GetChannel_AchievementById", JsonConvert.SerializeObject(parms), JsonConvert.SerializeObject(result.ResultData));
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/Info_TotalData/GetChannel_AchievementById", JsonConvert.SerializeObject(parms), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 获取渠道业绩
        /// </summary>
        /// <param name="openid">wxopenid</param>
        /// <param name="data">日期id    0是日  1是月  2是年</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetChannel_Achievement")]
        public ResultInfo<Channel_AchievementDataModel> GetChannel_Achievement(ChannelAchievementEntity channelat)
        {
            ResultInfo<Channel_AchievementDataModel> result = new ResultInfo<Channel_AchievementDataModel>();
            try
            {
                result.ResultData = totalDataBll.GetChannel_Achievement(channelat.openid, channelat.date);
                result.ResultCode = EmResultDescribe.OK;
                LogInfo.InfoLogMessage("/Info_TotalData/GetChannel_Achievement", JsonConvert.SerializeObject(channelat), JsonConvert.SerializeObject(result.ResultData));
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/Info_TotalData/GetChannel_Achievement", JsonConvert.SerializeObject(channelat), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }
        #endregion
    }
}

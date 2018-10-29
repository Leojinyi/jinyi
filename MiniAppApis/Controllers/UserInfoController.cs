using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.ReturnResult;
using Common.Extend;
using MiniAppApis.Common;
using MiniAppApis.ParamEntity;
using MiniAppModel;
using MiniAppBll;
using MiniAppApis.Log;
using Newtonsoft.Json;
using MiniAppApis.App_Start;

namespace MiniAppApis.Controllers
{
    [AuthorizeFilter]
    [RoutePrefix("UserInfo")]
    public class UserInfoController : ApiController
    {
        User_mainBll userBll = new User_mainBll();

        [HttpPost]
        [Route("GetPersonInfo")]
        //获取该用户的个人信息
        public ResultInfo<User_main> GetPersonInfo(checkUserm checkUserm)
        {
            ResultInfo<User_main> result = new ResultInfo<User_main>();
            try
            {
                
                result.ResultData = userBll.GetPersonInfo(checkUserm.openid);
                result.ResultCode = EmResultDescribe.OK;
                LogInfo.InfoLogMessage("/UserInfo/GetPersonInfo", JsonConvert.SerializeObject(checkUserm.openid), JsonConvert.SerializeObject(result.ResultData));
                
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/UserInfo/GetPersonInfo", JsonConvert.SerializeObject(checkUserm.openid), JsonConvert.SerializeObject(result.ResultData), ex.Message);

            }
            return result;
        }
    }
}

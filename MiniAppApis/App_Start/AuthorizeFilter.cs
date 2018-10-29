using Common.ReturnResult;
using MiniAppApis.Common;
using MiniAppApis.Log;
using MiniAppApis.ParamEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MiniAppApis.App_Start
{
    public class AuthorizeFilter : ActionFilterAttribute
    {
        ////重写基类的验证方式，加入我们自定义的Ticket验证
        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    ////获取请求数据  
        //    //Stream stream = actionContext.Request.Content.ReadAsStreamAsync().Result;
        //    //string requestDataStr = "";
        //    //if (stream != null && stream.Length > 0)
        //    //{
        //    //    stream.Position = 0; //当你读取完之后必须把stream的读取位置设为开始
        //    //    using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8))
        //    //    {
        //    //        requestDataStr = reader.ReadToEnd().ToString();
        //    //    }
        //    //}
        //    //CheckParameter checkParameter= JsonConvert.DeserializeObject<CheckParameter>(requestDataStr);
        //    //if (checkParameter!=null)
        //    //{
        //    //    if (Cache.GetCheckTokenCache(checkParameter.userid, checkParameter.token))
        //    //    {
        //    //        ResultInfo<object> resultInfo = new ResultInfo<object>();
        //    //        resultInfo.ResultCode = EmResultDescribe.缺少必要信息;
        //    //        throw new HttpResponseException(new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(resultInfo), Encoding.GetEncoding("UTF-8"), "application/json") });
        //    //    }
        //    //    else {

        //    //        base.IsAuthorized(actionContext);

        //    //    }
        //    //}
        //    //else {
        //    //    ResultInfo<object> resultInfo = new ResultInfo<object>();
        //    //    resultInfo.ResultCode = EmResultDescribe.缺少必要信息;
        //    //    throw new HttpResponseException(new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(resultInfo), Encoding.GetEncoding("UTF-8"), "application/json") });
        //    //}
        //}
        private const string Key = "action";
        /// <summary>
        /// 授权检测是否登录
        /// 在执行操作方法之前由 MVC 框架调用。
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Stopwatch stopWatch = new Stopwatch();//测量运行时间类
            actionContext.Request.Properties[Key] = stopWatch;
            stopWatch.Start();//时间开始
            Stream stream = actionContext.Request.Content.ReadAsStreamAsync().Result;
            string requestDataStr = "";
            if (stream != null && stream.Length > 0)
            {
                stream.Position = 0; //当你读取完之后必须把stream的读取位置设为开始
                using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8))
                {
                    requestDataStr = reader.ReadToEnd().ToString();
                }
            }
            string actionName = actionContext.ActionDescriptor.ActionName;
            LogInfo.RequestInfoLogMessage(actionName, requestDataStr);
            CheckParameter checkParameter = JsonConvert.DeserializeObject<CheckParameter>(requestDataStr);
            if (checkParameter != null)
            {
                if (!Cache.GetCheckTokenCache(checkParameter.userid, checkParameter.token))
                {
                    ResultInfo<object> resultInfo = new ResultInfo<object>();
                    resultInfo.ResultCode = EmResultDescribe.请登录;
                    throw new HttpResponseException(new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(resultInfo), Encoding.GetEncoding("UTF-8"), "application/json") });
                }
            }
            else
            {
                ResultInfo<object> resultInfo = new ResultInfo<object>();
                resultInfo.ResultCode = EmResultDescribe.请登录;
                throw new HttpResponseException(new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(resultInfo), Encoding.GetEncoding("UTF-8"), "application/json") });
            }
        }
        /// <summary>
        /// 在执行操作方法后由 MVC 框架调用。
        /// 请求结束后日志记录
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Stopwatch stopWatch = actionExecutedContext.Request.Properties[Key] as Stopwatch;

            if (stopWatch != null)
            {
                stopWatch.Stop();
                string actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                string controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string response = actionExecutedContext.Response.Content.ReadAsStringAsync().Result;
                LogInfo.ResponseInfoLogMessage(controllerName+"/"+actionName, response, stopWatch.Elapsed.TotalMilliseconds.ToString());
            }
        }
    }
}
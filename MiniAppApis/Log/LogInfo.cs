using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniAppApis.Log
{
    public static class LogInfo
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("log4net");
        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="param">参数</param>
        /// <param name="retMes">返回信息</param>
        /// <param name="mes">错误信息</param>
        public static void InfoLogMessage(String address, String param, String retMes)
        {
            log.InfoFormat(@"接口地址：{0},请求参数：{1},返回结果：{2},时间：{3},IP：{4}", address, param, retMes, DateTime.Now,GetIP());
        }
        /// <summary>
        /// 请求信息日志
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="param">参数</param>
        /// <param name="retMes">返回信息</param>
        /// <param name="mes">错误信息</param>
        public static void RequestInfoLogMessage(String address, String param)
        {
            log.InfoFormat(@"
                             请求接口
                             地址：{0},
                             请求参数：{1},
                             创建时间：{2},
                             IP：{3}
                            ", address, param, DateTime.Now, GetIP());
        }
        /// <summary>
        /// 返回信息日志
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="param">参数</param>
        /// <param name="retMes">返回信息</param>
        /// <param name="mes">错误信息</param>
        public static void ResponseInfoLogMessage(String address, String param, String datetime)
        {
            log.InfoFormat(@"
                             返回接口
                             地址：{0},
                             返回值：{1},
                             创建时间：{2},
                             调用时间：{3}ms,
                             IP：{4}
                            ", address, param, DateTime.Now, datetime, GetIP());
        }
        /// <summary>
        /// 返回信息日志
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="param">参数</param>
        /// <param name="retMes">返回信息</param>
        /// <param name="mes">错误信息</param>
        public static void InfoLogMessage(String address, String param, String retMes, String datetime)
        {
            log.InfoFormat(@"接口地址：{0},请求参数：{1},返回结果：{2},创建时间：{3},调用时间：{4}ms,IP：{5}", address, param, retMes, DateTime.Now, datetime, GetIP());
        }
        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="param">参数</param>
        /// <param name="retMes">返回信息</param>
        /// <param name="mes">错误信息</param>
        public static void ErrorLogMessage(String address, String param, String retMes, String mes)
        {
            log.ErrorFormat(@"接口地址：{0},请求参数：{1},返回结果：{2},错误信息：{3},时间：{4},IP：{5}", address, param, retMes, mes, DateTime.Now, GetIP());
        }

        #region 获取客户端IP地址

        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "0.0.0.0";
            }
            return result;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniAppApis.ParamEntity
{
    public class ParamBase
    {
        /// <summary>
        /// wxopenid
        /// </summary>
        public string WxOpenID { get; set; }
        /// <summary>
        /// 用户凭证
        /// </summary>
        public string Token { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniAppApis.ParamEntity
{
    public class CheckTokenEnt
    {
        /// <summary>  
        /// 用户id   当做Key
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        public string dateTime { get; set; }
    }
}
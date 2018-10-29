using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniAppApis.ParamEntity
{
    public class RealNameEntity
    {
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string user_real_name { get; set; }
        /// <summary>
        /// 用户身份证号
        /// </summary>
        public string user_card_no { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int userid { get; set; }
    }

    public class ValidateParameter
    {
        public int code { get; set; }
        public string msg { get; set; }
    }

    public class GetRealNameParameter
    {
        public int user_id { get; set; }
    }
}
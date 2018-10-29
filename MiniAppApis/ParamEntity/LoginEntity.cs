using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniAppApis.ParamEntity
{
    public class LoginEntity
    {
        public string Tel { get; set; }
        public string CheckCode { get; set; }
    }
    public class CheckCodeEntity {
        public string Tel { get; set; }
    }

    public class UserTokenEntity
    {
        public string Userid { get; set; }

        public string Token { get; set; }
    }
}
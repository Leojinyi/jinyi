using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.LoginInfo
{
    public class LoginInfoModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 微信Openid
        /// </summary>
        public string wxopenid { get; set; }
        /// <summary>
        /// 登录令牌
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public string Roleid { get; set; }
    }
}

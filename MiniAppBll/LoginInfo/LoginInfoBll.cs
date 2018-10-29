using Dapper;
using MiniAppApis.MiniAppBLL;
using MiniAppDal.UserLogin;
using MiniAppModel.LoginInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppBll.LoginInfo
{
    public class LoginInfoBll
    {
        public UserLoginDAL dal { get { return new UserLoginDAL(); } }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="tel">手机号</param>
        /// <returns></returns>
        public LoginInfoModel GetUserInfo(string tel)
        {
            LoginInfoModel login = dal.GetUserInfo(tel);
            if (login!=null)
            {
                string roleid = dal.GetUserRole(login.userid);
                if(string.IsNullOrEmpty(roleid))
                {
                    login = null;
                }
                else {
                    login.Roleid = roleid;
                }
            }
            return login;
        }
    }
}

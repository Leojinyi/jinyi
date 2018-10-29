using Dapper;
using MiniAppApis.MiniAppDAL;
using MiniAppModel.LoginInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppDal.UserLogin
{
    public class UserLoginDAL
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="tel">手机号</param>
        /// <returns></returns>
        public LoginInfoModel GetUserInfo(string tel)
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string sql = @"select um.id as userid,um.wx_open_id as wxopenid from user_main as um where um.user_name=@tel";
                DynamicParameters param = new DynamicParameters();
                param.Add("tel", tel);
                var result = db.Query<LoginInfoModel>(sql, param) as List<LoginInfoModel>;
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public string GetUserRole(string userid)
        {
            using (var db = new BusinessBase().OpenConnection())
            {
                string sql = @"select top 1 F_RoleId as Roleid from  Sys_User as sysuser
                            left join Sys_Role as sysrole on sysuser.F_id=sysrole.F_id
                            where sysuser.F_Id=@userid and (sysuser.F_RoleId='13b8fe89-c60c-48c0-a01d-2c4b6149fa27' or sysuser.F_RoleId='13b8fe89-c60c-48c0-a01d-2c4b6Leaders')";
                DynamicParameters param = new DynamicParameters();
                param.Add("userid", userid);
                var result = db.Query<string>(sql, param).FirstOrDefault();
                return result;
            }
        }
    }
}

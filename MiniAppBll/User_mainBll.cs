using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniAppModel;
using Dapper;
using DapperEx;
using MiniAppApis.MiniAppBLL;

namespace MiniAppBll
{
    public class User_mainBll
    {
        public string connStr = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;


        //获取该用户的个人信息
        public User_main GetPersonInfo(string openid)
        {
            using (var db=new BusinessBase().OpenConnection())
            {
                string sql = string.Format(@"SELECT su.F_Id,su.F_RealName,so.F_FullName AS F_FullNameBm,sr.F_FullName AS F_FullNameGw,su.F_MobilePhone,pf.profit_percentage FROM dbo.Sys_User su inner
                                             JOIN dbo.user_main um ON  su.F_id=CONVERT(VARCHAR(200),um.id)
                                             left JOIN dbo.profit pf ON um.id=pf.user_id  
                                             LEFT JOIN dbo.Sys_Role sr ON su.F_DutyId=sr.F_Id
                                             LEFT JOIN dbo.Sys_Organize so ON su.F_DepartmentId=so.F_Id
                                             WHERE um.wx_open_id='{0}'", openid);
                var list = db.Query<User_main>(sql) as List<User_main>;
                User_main model = new User_main()
                {
                    F_Id = list[0].F_Id,
                    F_RealName = list[0].F_RealName,
                    DepartmentId = list[0].F_FullNameBm,
                    F_DutyId = list[0].F_FullNameGw,
                    F_MobilePhone = list[0].F_MobilePhone,
                    profit_percentage = list[0].profit_percentage

                };
                return model;
            }
        }


    }
}

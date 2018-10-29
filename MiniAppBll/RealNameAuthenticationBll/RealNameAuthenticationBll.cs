using MiniAppDal.RealNameAuthenticationDal;
using MiniAppModel.RealNameAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppBll.RealNameAuthenticationBll
{
   public class RealNameAuthenticationBll
    {
        RealNameAuthenticationDal realNameBll = new RealNameAuthenticationDal();
        /// <summary>
        /// 添加用户实名认证信息
        /// </summary>
        /// <param name="realNameModel"></param>
        /// <returns></returns>
        public int AddRealName(RealNameAuthenticationModel realNameModel)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(realNameModel.real_name)&&!string.IsNullOrEmpty(realNameModel.card_no))
            {
                result = realNameBll.AddRealName(realNameModel);
            }
            else
            {
                return 0;
            }
            return result;
        }

        /// <summary>
        /// 获取实名认证信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public RealNameAuthenticationModel GetRealName(int user_id)
        {
            return realNameBll.FindRealName(user_id);
        }

    }
}

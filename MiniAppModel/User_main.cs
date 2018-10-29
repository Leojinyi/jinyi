using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel
{
     public class User_main
    {
        public int id { get; set; }

        /// <summary>
        /// 微信openid
        /// </summary>
        public string wx_open_id { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string user_type { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        public string wx_picture { get; set; }

        /// <summary>
        /// 微信名称
        /// </summary>
        public string wx_name { get; set; }

        /// <summary>
        /// 用户类型名称
        /// </summary>
        public string user_type_name { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string create_time { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string company { get; set; }

        /// <summary>
        ///身份证号
        /// </summary>
        public string idcard_number { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile_number { get; set; }

        public int month { get; set; }

        public string F_Id { get; set; }
        public string F_RealName { get; set; }
        public string F_NickName { get; set; }
        public string F_MobilePhone { get; set; }
        public string DepartmentId { get; set; }
        public string F_DutyId { get; set; }
        /// <summary>
        /// 分润比例
        /// </summary>
        public decimal? profit_percentage { get; set; }
        public int User_id { get; set; }

        //岗位
        public string F_FullNameGw { get; set; }
        //部门
        public string F_FullNameBm { get; set; }



    }
}
 
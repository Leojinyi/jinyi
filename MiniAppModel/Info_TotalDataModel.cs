using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppApis.MiniAppModel
{
   public class Info_TotalDataModel
    {

        //主表ID
        public string id { get; set; }
        //渠道名称
        public string user_nickname { get; set; }
        //渠道标签
        public string career_type_name { get; set; }
        //创建时间
        public DateTime create_time { get; set; }
        //排行
        public int seniority { get; set; }
        //销售额
        public int price_total { get; set; }
      
        //微信头像地址
        public string wx_picture { get; set; }

        //加入天数
        public int count_day { get; set; }
        //订单数量
        public int order_count { get; set; }
        //拉新用户
        public int newUser_count { get; set; }
        //引流用户
        public int drainageUser_count { get; set; }
        //显示信息
        public string show_messages { get; set; }
    }
}

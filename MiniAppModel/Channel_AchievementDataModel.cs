using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel
{
    /// <summary>
    /// 渠道业绩
    /// </summary>
    public class Channel_AchievementDataModel
    {
        /// <summary>
        /// 销售额
        /// </summary>
        public string sales { get; set; }
        /// <summary>
        /// 销售额百分比（和过去比较）
        /// </summary>
        public double salestage { get; set; }
        /// <summary>
        /// 销售额状态  0上 1下  箭头 
        /// </summary>
        public int salesstates { get; set; }
        /// <summary>
        /// 订单数
        /// </summary>
        public int ordernum { get; set; }
        /// <summary>
        /// 订单数百分比（和过去比较）
        /// </summary>
        public double ordernumtage { get; set; }
        /// <summary>
        /// 订单数状态 0上 1下  箭头 
        /// </summary>
        public int ordernumstates { get; set; }
        /// <summary>
        /// 拉新用户
        /// </summary>
        public int newuser { get; set; }
        /// <summary>
        /// 拉新用户百分比（和过去比较）
        /// </summary>
        public double newusertage { get; set; }
        /// <summary>
        /// 拉新用户状态  0上 1下  箭头 
        /// </summary>
        public int newuserstates { get; set; }
        /// <summary>
        /// 引流用户
        /// </summary>
        public int drainage { get; set; }
        /// <summary>
        /// 引流用户百分比（和过去比较）
        /// </summary>
        public double drainagetage { get; set; }
        /// <summary>
        /// 引流用户状态0上 1下  箭头 
        /// </summary>
        public int drainagestates { get; set; }


    }
}

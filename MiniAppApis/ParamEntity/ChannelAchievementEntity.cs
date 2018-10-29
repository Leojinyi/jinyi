using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniAppApis.ParamEntity
{
    public class ChannelAchievementEntity
    {
        /// <summary>
        /// 微信openid
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 日期编号   0是日  1是月  2是年
        /// </summary>
        public int date { get; set; }
    }

    public class ChannelParms
    {
        /// <summary>
        /// 微信openid
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 日期编号
        /// </summary>
        public int date { get; set; }
        public int check_type { get; set; }
    }

    /// <summary>
    /// 渠道详情参数类
    /// </summary>
    public class ChannelDetail
    {
        public int id { get; set; }
    }

    /// <summary>
    /// 个人渠道业绩
    /// </summary>
    public class ChannelAchievement
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 日期编号   0是日  1是月  2是年
        /// </summary>
        public int date { get; set; }
    }
}
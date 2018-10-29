using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel
{
    /// <summary>
    /// 渠道用户信息
    /// </summary>
    public class Channel_User_Info
    {
        /// <summary>
        /// 渠道类型
        /// </summary>
        public string channeltype { get; set; }
        /// <summary>
        /// 渠道名称
        /// </summary>
        public string channelname { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
    }
}

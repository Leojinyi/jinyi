using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.LeadData
{
    /// <summary>
    /// 销售额
    /// </summary>
    public class DaySalesVolume
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string createtime;
        /// <summary>
        /// 销售额
        /// </summary>
        public string pricetotal;
    }
    /// <summary>
    /// 订单数
    /// </summary>
    public class DayOrderNum
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string createtime;
        /// <summary>
        /// 订单数量
        /// </summary>
        public string ordernum;
    }
    /// <summary>
    /// 平均客单价
    /// </summary>
    public class DayUserPriceAvg
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string createtime;
        /// <summary>
        /// 平均单价
        /// </summary>
        public string priceavg;
    }
    /// <summary>
    /// 授权用户
    /// </summary>
    public class DayUserNum
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string createtime;
        /// <summary>
        /// 用户数量
        /// </summary>
        public string usernum;
    }
    /// <summary>
    /// 单日数据
    /// </summary>
    public class DayData
    {
        /// <summary>
        /// 时间
        /// </summary>
        public List<string> createtime;
        /// <summary>
        /// 值
        /// </summary>
        public List<string> value;
    }
}

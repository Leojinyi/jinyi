using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.LeadData
{
    /// <summary>
    /// 数据详情依赖实体
    /// </summary>
    public class Details
    {
        /// <summary>
        /// 记录数量
        /// </summary>
        public string Sum { get; set;}

        /// <summary>
        /// 销售总额
        /// </summary>
        public string Gross { get; set; }

        /// <summary>
        /// 毛利
        /// </summary>
        public string Profit { get; set; }

        /// <summary>
        /// 毛利率
        /// </summary>
        public string Profits { get; set; }

        /// <summary>
        /// 平均价
        /// </summary>
        public string Average { get; set; }
    }

    public class DetailsList
    {
        public List<Details> Lists { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.LeadData
{
    /// <summary>
    /// 分润依赖实体
    /// </summary>
    public class ShareProfit
    {
        public string Cashs { get; set; }
    }

    public class ShareProfitList
    {
        public List<ShareProfit> Lists { get; set; }
    }
        
}

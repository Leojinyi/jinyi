using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.LeadData
{
    /// <summary>
    /// 销售额相关依赖模型
    /// </summary>
    public class Saleroom
    {
        /// <summary>
        /// 销售额
        /// </summary>
        public string Limit { get; set; }
        
        /// <summary>
        /// 时间
        /// </summary>
        public string Date { get; set; }
    }
    public class SaleroomList
    {
        public List<Saleroom> Lists { get; set; }
    }

	/// <summary>
	/// 销售额相关依赖模型
	/// </summary>
	public class SaleroomTwo
	{
		/// <summary>
		/// 销售额
		/// </summary>
		public string Limit { get; set; }

		/// <summary>
		/// 时间
		/// </summary>
		public DateTime Date { get; set; }
	}
	public class SaleroomListTwo
	{
		public List<SaleroomTwo> Lists { get; set; }
	}
}

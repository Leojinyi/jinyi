using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.LeadResult
{
	/// <summary>
	/// 数据详情
	/// </summary>
	public class DetailsResult
	{

		/// <summary>
		/// 记录数量
		/// </summary>
		public string Sum { get; set; }

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

		/// <summary>
		/// 分润
		/// </summary>
		public string Cashs { get; set; }

		/// <summary>
		/// 记录数量对比率
		/// </summary>
		public string SumRate { get; set; }
		/// <summary>
		///  记录数量对比率趋势
		/// </summary>
		public bool SumTrend { get; set; }
		/// <summary>
		/// 销售总额对比率
		/// </summary>
		public string GrossRate { get; set; }
		/// <summary>
		///  销售总额对比率趋势
		/// </summary>
		public bool GrossTrend { get; set; }
		/// <summary>
		/// 毛利对比率
		/// </summary>
		public string ProfitRate { get; set; }
		/// <summary>
		///  毛利对比率趋势
		/// </summary>
		public bool ProfitTrend { get; set; }
		/// <summary>
		/// 毛利率对比率
		/// </summary>
		public string ProfitsRate { get; set; }
		/// <summary>
		///  毛利率对比率趋势
		/// </summary>
		public bool ProfitsTrend { get; set; }
		/// <summary>
		/// 平均价对比率
		/// </summary>
		public string AverageRate { get; set; }
		/// <summary>
		///  平均价对比率趋势
		/// </summary>
		public bool AverageTrend { get; set; }
		/// <summary>
		/// 分润对比率
		/// </summary>
		public string CashsRate { get; set; }
		/// <summary>
		///  分润对比率趋势
		/// </summary>
		public bool CashsTrend { get; set; }
		/// <summary>
		/// 开始时间
		/// </summary>
		public string StartTime { get; set; }

		/// <summary>
		/// 结束时间
		/// </summary>
		public string EndTime { get; set; }

		public string Quarter { get; set; }
	}
}

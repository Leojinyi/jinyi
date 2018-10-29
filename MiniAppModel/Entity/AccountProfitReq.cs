using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.Entity
{
	public	class AccountProfitReq
	{
		public int userid { get; set; }
		public String token { get; set; }
	}
	public class BDLeaderEntity
	{
		public string fid { get; set; }
		public string rname { get; set; }
		public string userid { get; set; }
		public string limit { get; set; }
		public DateTime date { get; set; }
	}
	public class BDLeader
	{
		/// <summary>
		/// 开始时间
		/// </summary>
		public string StartTime { get; set; }

		/// <summary>
		/// 结束时间
		/// </summary>
		public string EndTime { get; set; }
		/// <summary>
		/// 折线开始时间
		/// </summary>
		public string LineStartTime { get; set; }

		/// <summary>
		///折线结束时间
		/// </summary>
		public string LineEndTime { get; set; }
		/// <summary>
		/// 存储季度字段
		/// </summary>
		public string Quarter { get; set; }
		/// <summary>
		/// 折线数据
		/// </summary>
		public BDLeaderLineResult lineData { get; set; }
		/// <summary>
		/// 数据详情
		/// </summary>
		public List<BDLeaderInfoResult> infoData { get; set; }
	}
	/// <summary>
	/// bd统计曲线数据
	/// </summary>
	public class BDLeaderLineResult
	{
		/// <summary>
		///  时间["2018-09-05","2018-09-05","2018-09-05"]
		/// </summary>
		public string[] date;

		/// <summary>
		///  销售额["111","1111","1111"]
		/// </summary>
		public string[] limit;
	}
	/// <summary>
	/// bd统计详情数据
	/// </summary>
	public class BDLeaderInfoResult
	{
		/// <summary>
		/// bd名称
		/// </summary>
		public string name { get; set; }
		/// <summary>
		/// 记录数
		/// </summary>
		public string Sum { get; set; }
		/// <summary>
		/// 对比率
		/// </summary>
		public string SumRate { get; set; }
		/// <summary>
		///  对比率趋势
		/// </summary>
		public bool SumTrend { get; set; }

	}
}

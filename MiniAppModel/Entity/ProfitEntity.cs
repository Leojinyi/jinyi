using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.Entity
{
	/// <summary>
	/// rjy 2018年9月21日17:20:41 今日实时奖励（分润表）
	/// </summary>
	public partial class ProfitEntity
	{

		public ProfitEntity()
		{


		}
		/// <summary>
		/// Desc:编号
		/// Default:
		/// Nullable:False
		/// </summary>           
		public int id { get; set; }

		/// <summary>
		/// Desc:创建时间
		/// Default:DateTime.Now
		/// Nullable:False
		/// </summary>           
		public String create_time { get; set; }

		/// <summary>
		/// Desc:修改时间
		/// Default:DateTime.Now
		/// Nullable:False
		/// </summary>           
		public DateTime update_time { get; set; }

		/// <summary>
		/// Desc:用户id
		/// Default:
		/// Nullable:False
		/// </summary>           
		public int user_id { get; set; }

		/// <summary>
		/// Desc:账单id（account）
		/// Default:
		/// Nullable:False
		/// </summary>           
		public int account_id { get; set; }

		/// <summary>
		/// Desc:预估奖励金额
		/// Default:
		/// Nullable:False
		/// </summary>           
		public decimal cash { get; set; }

		/// <summary>
		/// Desc:状态 0：待分润；1：已分润；2：已取消
		/// Default:0
		/// Nullable:False
		/// </summary>           
		public byte status { get; set; }

		/// <summary>
		/// Desc:购买方C用户
		/// Default:
		/// Nullable:False
		/// </summary>           
		public int user_id_c { get; set; }

		/// <summary>
		/// Desc:支付金额
		/// Default:
		/// Nullable:False
		/// </summary>           
		public decimal payment { get; set; }

		/// <summary>
		/// Desc:订单号
		/// Default:
		/// Nullable:False
		/// </summary>           
		public string order_no { get; set; }

		/// <summary>
		/// Desc:渠道奖励比例 有地推推荐的用户0.4，自行注册用户0.3，地推奖励比例0.04
		/// Default:0
		/// Nullable:True
		/// </summary>           
		public decimal? profit_percentage { get; set; }

		/// <summary>
		/// Desc:
		/// Default:0
		/// Nullable:True
		/// </summary>           
		public decimal? profit_percentage_b { get; set; }


	}
}

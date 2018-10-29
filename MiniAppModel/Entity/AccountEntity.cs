using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.Entity
{
	/// <summary>
	/// rjy 2018年9月21日16:47:24 我的奖励统计返回类
	/// </summary>
	public partial class AccountEntity
	{
	
	}
	public partial class AccountEntity
	{
		public AccountEntity()
		{


		}

        public string accountId { get; set; }
        public string  openId { get; set; }
        /// <summary>
        /// Desc:剩余未提现奖励
        /// Default:
        /// Nullable:False
        /// </summary>           
        public decimal balance { get; set; }
		/// <summary>
		/// Desc:可提现金额
		/// Default:
		/// Nullable:False
		/// </summary>           
		public decimal cash { get; set; }
		/// <summary>
		/// Desc:已提现金额
		/// Default:
		/// Nullable:False
		/// </summary>
		public decimal toget { get; set; }

		/// <summary>
		/// Desc:未发放金额
		/// Default:
		/// Nullable:False
		/// </summary>
		public decimal wating_gain { get; set; }

		/// <summary>
		/// Desc:今日预估奖励
		/// Default:
		/// Nullable:False
		/// </summary>
		public decimal forecast_gain { get; set; }
		#region 暂时不用
		///// <summary>
		///// Desc:编号
		///// Default:
		///// Nullable:False
		///// </summary>           
		//public int id { get; set; }

		///// <summary>
		///// Desc:创建时间
		///// Default:DateTime.Now
		///// Nullable:False
		///// </summary>           
		//public DateTime create_time { get; set; }

		///// <summary>
		///// Desc:修改时间
		///// Default:DateTime.Now
		///// Nullable:False
		///// </summary>           
		//public DateTime update_time { get; set; }

		///// <summary>
		///// Desc:已提现金额
		///// Default:0
		///// Nullable:False
		///// </summary>           
		//public decimal has_gain { get; set; }

		///// <summary>
		///// Desc:冻结金额
		///// Default:
		///// Nullable:False
		///// </summary>           
		//public decimal freezing_amount { get; set; }

		///// <summary>
		///// Desc:用户id
		///// Default:
		///// Nullable:False
		///// </summary>           
		//public int user_id { get; set; }
		#endregion

	}

}

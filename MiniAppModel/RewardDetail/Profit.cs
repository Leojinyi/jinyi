using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.RewardDetail
{
    public class Profit
    {
        public int id { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public string create_time { get; set; }
        /// <summary>
        /// 最近一次修改时间
        /// </summary>
        public string update_time { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 账户ID
        /// </summary>
        public int account_id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal cash { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 购买方C用户 
        /// </summary>
        public int user_id_c { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal payment { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string order_no { get; set; }

        public decimal SumCash { get; set; }
    }
}

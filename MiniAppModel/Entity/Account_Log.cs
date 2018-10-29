namespace MiniAppModel.Entity
{
    public class Account_Log
    {
        public int id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string create_time { get; set; }

        /// <summary>
        /// 最近一次修改时间
        /// </summary>
        public string update_time { get; set; }
        /// <summary>
        /// 是否可提现 0：否；1：是
        /// </summary>
        public int can_cashing { get; set; }
        /// <summary>  
        /// 账单类型 0：分润；1：提现；
        /// </summary>
        public string bill_type { get; set; }

        /// <summary>
        /// 交易号
        /// </summary>
        public string pay_no { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string pay_way { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 账户信息
        /// </summary>
        public int account_id { get; set; }

        /// <summary>
        /// 是否冻结
        /// </summary>
        public int is_freezing { get; set; }

        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal freezing_amount { get; set; }
        /// <summary>
        /// 收款账户
        /// </summary>
        public string collection_account { get; set; }
        /// <summary>
        /// 支付账户
        /// </summary>
        public string pay_account { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal cash { get; set; }

    }
}

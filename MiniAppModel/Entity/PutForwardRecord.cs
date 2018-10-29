using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.Entity
{
    /// <summary>
    /// 提现记录
    /// </summary>
    public class PutForwardRecord
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createtime { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal amount { get; set; }
    }


    public class PutForwardRecordList {
        /// <summary>
        /// 提现总金额
        /// </summary>
        public string totalamount { get; set; }
        public List<PutForwardRecord> datas { get; set; }
    }
}

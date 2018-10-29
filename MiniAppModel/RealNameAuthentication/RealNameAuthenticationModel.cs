using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.RealNameAuthentication
{
   public class RealNameAuthenticationModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 用户user_id
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string real_name { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public int card_type { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string card_no { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime update_time { get; set; }
    }
}

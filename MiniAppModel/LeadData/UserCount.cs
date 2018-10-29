using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.LeadData
{
    /// <summary>
    /// 数据查询模型
    /// </summary>
    public class UserCount
    {
        public string num { get; set; }

        public string dates { get; set; }
    }

    /// <summary>
    /// 模型集合
    /// </summary>
    public class UserCountList
    {
        public List<UserCount> list;
    }
}

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
    public class BDtoCuserEntity
    {
        public string num { get; set; }
        public string dates { get; set; }
        public string name { get; set; }
        
    }

    /// <summary>
    ///模型集合 
    ///
    public class BDtoCuserList
    {
        public List<BDtoCuserEntity> list;
    }
}

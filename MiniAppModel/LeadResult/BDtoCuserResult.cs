using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.LeadResult
{
    public class BDtoCuserResult
    {
        public string[] data { get; set; }
        public string name { get; set; }

    }
    public class BDtoCuserResultList
    {
        public string[] date { get; set; }

        public List<BDtoCuserResult> list;
    }
}

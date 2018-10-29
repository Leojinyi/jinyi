using MiniAppModel.LeadData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.LeadResult
{
    public class ChannelSurvey
    {
        public TotalChannelArray details { get; set; }

        public List<BDData> bDData { get; set; }
    }
}

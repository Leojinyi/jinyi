using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.TotalChannel
{
   public class TotalChannelModel
    {
        /// <summary>
        /// 渠道数量
        /// </summary>
        public string channelCount { get; set; }
        /// <summary>
        /// 时间
        /// </summary>

        public string date { get; set; }
       
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
    }

    public class DataItem
    {
        /// <summary>
        /// 孔纯高
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string[] data { get; set; }
    }

    public class TotalChannelResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
    }
}

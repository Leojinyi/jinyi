using Dapper;
using MiniAppApis.MiniAppBLL;
using MiniAppBll.Time;
using MiniAppDal.TotalChannelDal;
using MiniAppModel.TotalChannel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static MiniAppModel.TotalChannel.TotalChannelModel;

namespace MiniAppBll.TotalChannelBll
{
   public class TotalChannelBll
    {
        TotalChanelDal totalChanelDal = new TotalChanelDal();
        /// <summary>
        /// 获取一段时间内地推下的所有渠道
        /// </summary>
        /// <param name="timeType">1:自然周，2:自然月,3:季度</param>
        /// <returns></returns>
        public TotalChannelResult TotalChannelResult(string timeType)
        {
            TotalChannelResult totalChannelResultList = new TotalChannelResult();
            string startTime = string.Empty;
            string endTime = string.Empty;
            List<string> newnames = null;
            string[] times = null;
            string[] num = null;
            int allcount = 0;
            switch (timeType)
            {
                case "1":
                    {
                        startTime = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
                        endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                        times = new string[7];
                        num = new string[7];
                        allcount = 7;
                        for (int i = 0; i < 7; i++)
                        {
                            times[i] = DateTime.Now.AddDays(+(i - 6)).ToString("yyyy-MM-dd");
                            num[i] = "0";
                        }
                    }
                    break;
                case "2":
                    {
                        startTime = DateTime.Now.AddDays(-29).ToString("yyyy-MM-dd");
                        endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                        times = new string[30];
                        num = new string[30];
                        allcount = 30;
                        for (int i = 0; i < 30; i++)
                        {
                            times[i] = DateTime.Now.AddDays(+(i - 29)).ToString("yyyy-MM-dd");
                            num[i] = "0";
                        }
                    }
                    break;
                case "3":
                    {
                        startTime = DateTime.Now.AddDays(-89).ToString("yyyy-MM-dd");
                        endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                        times = new string[90];
                        num = new string[90];
                        allcount = 90;
                        for (int i = 0; i < 90; i++)
                        {
                            times[i] = DateTime.Now.AddDays(+(i - 89)).ToString("yyyy-MM-dd");
                            num[i] = "0";
                        }
                    }
                    break;
                default:
                    break;
            }

            totalChannelResultList.time = times;
            for (int i = 0; i < times.Length; i++)
            {
                totalChannelResultList.time[i] = Convert.ToDateTime(times[i]).ToString("MM-dd");
            }
            List<DataItem> itemlist = new List<DataItem>();
            //查询所有地推下的所有渠道信息
            List<TotalChannelModel> totalChannelsList = totalChanelDal.FindAllChannelCount(startTime, endTime);
            List<TotalChannelModel> totalEarthPushNameList = totalChanelDal.FindAllEarthPushName().ToList();
            DataItem totalChannelResult = null;
            //获取所有的地推名称
            newnames = totalEarthPushNameList.Select(x => x.name).Distinct().ToList();
            foreach (var item in newnames)
            {
                //清空数组中的信息
                num = new string[allcount];
                times = new string[allcount];
                for (int i = 0; i < allcount; i++)
                {
                    num[i] = "0";
                    times[i] = DateTime.Now.AddDays(+(i - (allcount - 1))).ToString("yyyy-MM-dd");
                }
                totalChannelResult = new DataItem();
                totalChannelResult.name = item;
                //获取每个人对应的详细信息
                List<TotalChannelModel> channelList = totalChannelsList.Where(x => x.name == item).ToList();
                foreach (var items in channelList)
                {
                    //判断添加的的日期中是否包含查询到的日期
                    if (((IList)times).Contains(items.date))
                    {
                        //将统计的个数添加到对应的日期数组中
                        num[times.ToList().IndexOf(items.date)] = items.channelCount;
                    }
                }
                totalChannelResult.data = num;
                itemlist.Add(totalChannelResult);
            }
            totalChannelResultList.data = itemlist;
            return totalChannelResultList;
        }

    }
}

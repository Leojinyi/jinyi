using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniAppBll.Time;
using MiniAppDal.BDtoCuser;
using MiniAppModel;
using MiniAppModel.LeadData;
using MiniAppModel.LeadResult;

namespace MiniAppBll.BDtoCuser
{
    public class BDtoCuserBLL
    {
        #region private utility methods & constructors
        static BDtoCuserBLL _instance;
        static object _lock = new object();
        public static BDtoCuserBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new BDtoCuserBLL();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 获取地推下渠道发展C类用户
        /// </summary>
        /// <param name="timeType"></param>
        /// <returns></returns>
        public async Task<BDtoCuserResultList> GetBDtoCuserList(string timeType)
        {
            BDtoCuserList data = null;
            
            //BDtoCuserResult temps = null;
            BDtoCuserResultList result = new BDtoCuserResultList
            {
                list = new List<BDtoCuserResult>()
            };
            string startTime = string.Empty;
            string endTime = string.Empty;

            string[] times = null;
            string[] nums = null;
            string names = null;
            int counts = 0;
            #region new 
            switch (timeType)
            {
                /**
                 * 处理开始时间和和结束时间。
                 * addDays(+1)为between不包含结束当天数据,
                 * */
                case "1":
                    {
                        startTime = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
                        endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

                        times = new string[7];
                        nums = new string[7];
                        counts = 7;
                        //names = new string[7];
                        for (int i = 0; i < 7; i++)
                        {
                            times[i] = DateTime.Now.AddDays(+(i - 6)).ToString("yyyy-MM-dd");

                            nums[i] = "0";
                            //names[i] = "";
                        }
                    }
                    break;
                case "2":
                    {
                        startTime = DateTime.Now.AddDays(-29).ToString("yyyy-MM-dd");
                        endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                        times = new string[30];
                        nums = new string[30];
                        counts = 30;
                        //names = new string[30];
                        for (int i = 0; i < 30; i++)
                        {
                            times[i] = DateTime.Now.AddDays(+(i - 29)).ToString("yyyy-MM-dd");
                            nums[i] = "0";
                            //names[i] = "";
                        }
                    }
                    break;
                case "3":
                    {
                        startTime = DateTime.Now.AddDays(-89).ToString("yyyy-MM-dd");
                        endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                        int days = DateTimeExtensions.DateDiff() + 1;
                        times = new string[90];
                        nums = new string[90];
                        counts = 90;
                        //names = new string[90];
                        for (int i = 0; i < 90; i++)
                        {

                            times[i] = DateTime.Now.AddDays(+(i - 89)).ToString("yyyy-MM-dd");
                            nums[i] = "0";
                            //names[i] = "";
                        }
                    }
                    break;
                default:
                    break;
            }
            result.date = times;
            //时间
            for (int i = 0; i < times.Length; i++)
            {
                try
                {
                    result.date[i] = Convert.ToDateTime(times[i]).ToString("MM-dd");
                }
                catch { }
            }


            data = await BDtoCuserDal.Instance.GetBDtoCuserList(startTime, endTime);
            BDtoCuserList namelist1 = await BDtoCuserDal.Instance.GetBDtoCuserNameList();
            #region 将BD名称写入
            var namelist = namelist1.list.Select(c => c.name).Distinct().ToList();

            
            foreach (var item in namelist)
            {
                nums = new string[counts];
                times = new string[counts];
                for (int i = 0; i < counts; i++)
                {
                    nums[i] = "0";
                    times[i]= DateTime.Now.AddDays(+(i - (counts - 1))).ToString("yyyy-MM-dd");
                }
                if (item == null || item == "")
                {
                    names = "匿名";
                }
                else
                {

                    names = item.ToString();
                }

            //根据名字写入数量
            List<BDtoCuserEntity> numlist = data.list.Where(c => c.name == item).ToList();

            foreach (var items in numlist)
            {
                if (((IList)times).Contains(items.dates)) //判断那天有数据。
                {
                    //data中数据插入到数组中。
                    nums[times.ToList().IndexOf(items.dates)] = items.num;
                }
            }
            var temps = new BDtoCuserResult
                {
                    name = names,
                    data = nums
                };
               
                result.list.Add(temps);
            }
            #endregion
            #endregion
            return result;
        }

    }
}

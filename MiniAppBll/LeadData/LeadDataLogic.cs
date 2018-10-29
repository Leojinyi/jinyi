using MiniAppBll.Time;
using MiniAppCommon;
using MiniAppDal.LeadData;
using MiniAppModel.LeadData;
using MiniAppModel.LeadReault;
using MiniAppModel.LeadResult;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppBll.LeadData
{
    public class LeadDataLogic
    {

        #region private utility methods & constructors
        static LeadDataLogic _instance;
        static object _lock = new object();
        public static LeadDataLogic Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new LeadDataLogic();
                    }
                }
                return _instance;
            }
        }
		#endregion


		#region rjy 
		/// <summary>
		/// 用户七天总量变化
		/// </summary>
		/// <returns></returns>
		public async Task<UserCountResult> GetUserChangeCountAsync()
        {
            UserCountResult result = new UserCountResult();
            string[] strCount = new string[7];
            string[] strTime = new string[7];
            int count = 0;
            string time = string.Empty;
            for (int i = 0; i < 7; i++)
            {
				//rjy 2018年9月28日14:52:43 最近七天从早到晚 查询需要后一天 所在循环时 查询时间为当天后一天
				time = DateTime.Now.AddDays(+(i-5)).ToString("yyyy-MM-dd");
				strTime[i] = DateTime.Now.AddDays(+(i - 6)).ToString("yyyy-MM-dd");
				#region 旧版 注释
				//if (i == 0)
				//            {
				//                time = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd");
				//                strTime[i] = DateTime.Now.ToString("yyyy-MM-dd"); 
				//            }
				//            else
				//            {
				//                time = DateTime.Now.AddDays(-i + 1).ToString("yyyy-MM-dd");
				//                strTime[i] = DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd"); ;
				//            }
				#endregion
				count = await LeadDataDataAccess.Instance.GetUserCountAsync(time);
                strCount[i] = count.ToString();
            }
            for (int i = 0; i < strTime.Length; i++)
            {
                try
                {
                    strTime[i] = Convert.ToDateTime(strTime[i]).ToString("MM-dd");
                }
                catch{}
            }
            result.date = strTime;
            result.count = strCount;
            return result ?? null;
        }


		/// <summary>
		/// 获取某时间段每天的销售额。
		/// </summary>
		/// <param name="timeType">1:自然周，2:自然月,3:季度</param>
		/// <returns></returns>
		public async Task<SaleroomResult> GetSaleroomAsync(string timeType)
        {
            SaleroomList data = null;
            SaleroomResult result = new SaleroomResult();
            string startTime = string.Empty;
            string endTime = string.Empty;
            string[] times = null;
            string[] limits = null;
            switch (timeType)
            {
                case "1":
                    {
						//DateTimeExtensions.GetMondayDate().ToString("yyyy-MM-dd");
						// DateTimeExtensions.GetSundayDate().AddDays(+1).ToString("yyyy-MM-dd");
						// DateTimeExtensions.GetMondayDate().AddDays(+i).ToString("yyyy-MM-dd");
						startTime = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
                        endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
						
						times = new string[7];
                        limits = new string[7];
                        for (int i = 0; i < 7; i++)
                        {
							times[i] = DateTime.Now.AddDays(+(i-6)).ToString("yyyy-MM-dd");
						    

							limits[i] = "0.00";
                        }
                    }
                    break;
                case "2":
                    {
						//DateTimeExtensions.FirstDayOfMonth().ToString("yyyy-MM-dd");
						//DateTimeExtensions.LastDayOfMonth().AddDays(+1).ToString("yyyy-MM-dd");
						//DateTimeExtensions.FirstDayOfMonth().AddDays(+i).ToString("yyyy-MM-dd");
						startTime = DateTime.Now.AddDays(-29).ToString("yyyy-MM-dd");
						endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                        times = new string[30];
                        limits = new string[30];
                        for (int i = 0; i < 30; i++)
                        {
                            times[i] = DateTime.Now.AddDays(+(i - 29)).ToString("yyyy-MM-dd");
							limits[i] = "0.00";
                        }
                    }
                    break;
                case "3":
                    {
						//startTime = DateTimeExtensions.ToFirstDayOfSeason().ToString("yyyy-MM-dd");
						//endTime = DateTimeExtensions.ToLastDayOfSeason().AddDays(+1).ToString("yyyy-MM-dd");
						// times[i] = DateTimeExtensions.ToFirstDayOfSeason().AddDays(+i).ToString("yyyy-MM-dd");
						startTime = DateTime.Now.AddDays(-89).ToString("yyyy-MM-dd");
						endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
						int days = DateTimeExtensions.DateDiff() + 1;
                        times = new string[90];
                        limits = new string[90];
                        for (int i = 0; i < 90; i++)
                        {
							
							times[i] = DateTime.Now.AddDays(+(i - 89)).ToString("yyyy-MM-dd");
							limits[i] = "0.00";
                        }
                    }
                    break;
                default:
                    break;
            }
			data = await LeadDataDataAccess.Instance.GetSaleroomAsync(startTime, endTime);
			foreach (var item in data.Lists)
			{
				if (((IList)times).Contains(item.Date)) //判断那天有数据。
				{
					//data中数据插入到数组中。
					limits[times.ToList().IndexOf(item.Date)] = item.Limit;
				}
			}
			for (int i = 0; i < times.Length; i++)
			{
				try
				{
					times[i] = Convert.ToDateTime(times[i]).ToString("MM-dd");
				}
				catch { }
			}
			result.date = times;
            result.limit = limits;
            return result;
        }
		/// <summary>
		/// 获取某时间段每天的用户数。 rjy 2018年10月10日14:45:19
		/// </summary>
		/// <param name="timeType">1:周，2:月,3:季度</param>
		/// <returns></returns>
		public async Task<UserCountResult> GetNewUserChangeCountAsync(string timeType)
		{
			UserCountResult result = new UserCountResult();
			string[] strCount = null;
			string[] strTime = null;
			int count = 0;
			string time = string.Empty;
			switch (timeType)
			{

				case "1":
					{

						strTime = new string[7];
						strCount = new string[7];
						for (int i = 0; i < 7; i++)
						{
							time = DateTime.Now.AddDays(+(i - 5)).ToString("yyyy-MM-dd");
							strTime[i] = DateTime.Now.AddDays(+(i - 6)).ToString("MM-dd");

							count = await LeadDataDataAccess.Instance.GetUserCountAsync(time);
							strCount[i] = count.ToString();
						}
						break;
					}
				case "2":
					{
						strTime = new string[30];
						strCount = new string[30];
						for (int i = 0; i < 30; i++)
						{
							time = DateTime.Now.AddDays(+(i - 28)).ToString("yyyy-MM-dd");
							strTime[i] = DateTime.Now.AddDays(+(i - 29)).ToString("MM-dd");

							count = await LeadDataDataAccess.Instance.GetUserCountAsync(time);
							strCount[i] = count.ToString();
						}
						break;
					}
				case "3":
					{
						strTime = new string[90];
						strCount = new string[90];
						for (int i = 0; i < 90; i++)
						{
							time = DateTime.Now.AddDays(+(i - 88)).ToString("yyyy-MM-dd");
							strTime[i] = DateTime.Now.AddDays(+(i - 89)).ToString("MM-dd");

							count = await LeadDataDataAccess.Instance.GetUserCountAsync(time);
							strCount[i] = count.ToString();
						}
						break;
					}
			}
			result.date = strTime;
			result.count = strCount;
			return result ?? null;
		}
		/// <summary>
		/// 获取截止到统计日期的累计销售额。rjy 2018年10月10日14:45:07
		/// </summary>
		/// <param name="timeType">1:自然周，2:自然月,3:季度</param>
		/// <returns></returns>
		public async Task<SaleroomResult> GetNewSaleroomAsync(string timeType)
		{
			SaleroomListTwo data = await LeadDataDataAccess.Instance.GetNewSaleroomAsync(DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd")); ;
			SaleroomResult result = new SaleroomResult();
			string startTime = string.Empty;
			string endTime = string.Empty;
			string[] times = null;
			string[] limits = null;

			switch (timeType)
			{
				case "1":
					{
						times = new string[7];
						limits = new string[7];
						for (int i = 0; i < 7; i++)
						{
							times[i] = DateTime.Now.AddDays(+(i - 6)).ToString("MM-dd");
							endTime = DateTime.Now.AddDays(+(i-5)).ToString("yyyy-MM-dd");

							limits[i] = data.Lists.Where(p => p.Date < Convert.ToDateTime(endTime)).Sum(p => Convert.ToDecimal(p.Limit)).ToString();
						}
					}
					break;
				case "2":
					{

						times = new string[30];
						limits = new string[30];
						for (int i = 0; i < 30; i++)
						{
							times[i] = DateTime.Now.AddDays(+(i - 29)).ToString("MM-dd");
							endTime = DateTime.Now.AddDays(+(i - 28)).ToString("yyyy-MM-dd");

							limits[i] = data.Lists.Where(p => p.Date < Convert.ToDateTime(endTime)).Sum(p => Convert.ToDecimal(p.Limit)).ToString();
						}
					}
					break;
				case "3":
					{
						times = new string[90];
						limits = new string[90];
						for (int i = 0; i < 90; i++)
						{

							times[i] = DateTime.Now.AddDays(+(i - 89)).ToString("MM-dd");
							endTime = DateTime.Now.AddDays(+(i - 88)).ToString("yyyy-MM-dd");

							limits[i] = data.Lists.Where(p => p.Date < Convert.ToDateTime(endTime)).Sum(p => Convert.ToDecimal(p.Limit)).ToString();
						}
					}
					break;
				default:
					break;
			}

			result.date = times;
			result.limit = limits;
			return result;
		}


		/// <summary>
		/// 数据对比，rjy 时间计算修改
		/// </summary>
		/// <param name="time">前端传递时间，用于和服务器时间对比，判断自然周，自然月，自然季度</param>
		/// <param name="timeType">1:自然周，2:自然月,3:季度,4:天</param>
		/// <param name="upAndDown">0:当前, 1:前,2:后</param>
		/// <returns></returns>
		public async Task<DetailsResult> GetOrderDetailsAsync(DateTime time, string timeType, string upAndDown)
        {
            DetailsResult result = null;
            string startTime = string.Empty; //显示数据开始时间
            string endTime = string.Empty;  //显示数据结束时间
            string lastStartTime = string.Empty; //对比数据开始时间
            string lastEndTime = string.Empty; //对比数据结束时间
			string retStartTime = string.Empty;//返回的开始时间
			string retEndTime = string.Empty;//返回的结束时间
			String retQuarter = string.Empty;
			//不管时间是什么时间啊，原始数据始终需要和前一次的数据比较，找出当前时间段,和对比时间段的开始时间和结束时间
			switch (timeType)
            {
                case "1":
                    {
                        if (upAndDown == "0")
                        {
                            startTime = DateTimeExtensions.GetMondayDate(time).ToString("yyyy-MM-dd");
                            endTime = DateTimeExtensions.GetSundayDate(time).AddDays(+1).ToString("yyyy-MM-dd");

						}
                        if (upAndDown == "1")//上
                        {
                            startTime = DateTimeExtensions.GetMondayDate(DateTimeExtensions.GetMondayDate(time).AddDays(-1)).ToString("yyyy-MM-dd");
                            endTime = DateTimeExtensions.GetSundayDate(DateTime.Parse(startTime)).AddDays(+1).ToString("yyyy-MM-dd");
						}
                        if (upAndDown == "2")//下
                        {
                            startTime = DateTimeExtensions.GetMondayDate(DateTimeExtensions.GetSundayDate(time).AddDays(+1)).ToString("yyyy-MM-dd");
                            endTime = DateTimeExtensions.GetSundayDate(DateTime.Parse(startTime)).AddDays(+1).ToString("yyyy-MM-dd");
						}
						lastStartTime = DateTimeExtensions.GetMondayDate(DateTime.Parse(startTime).AddDays(-1)).ToString("yyyy-MM-dd");
						lastEndTime = startTime;
						retStartTime = startTime;
						retEndTime = DateTime.Parse(endTime).AddDays(-1).ToString("yyyy-MM-dd");
					}
                    break;
                case "2":
                    {
                        if (upAndDown == "0")
                        {
                            startTime = DateTimeExtensions.FirstDayOfMonth(time).ToString("yyyy-MM-dd");
                            endTime = DateTimeExtensions.LastDayOfMonth(time).AddDays(+1).ToString("yyyy-MM-dd");

						}
                        if (upAndDown == "1")//上
                        {
                            startTime = DateTimeExtensions.FirstDayOfMonth(time.AddMonths(-1)).ToString("yyyy-MM-dd");
                            endTime = DateTimeExtensions.LastDayOfMonth(DateTime.Parse(startTime)).AddDays(+1).ToString("yyyy-MM-dd");
						}
                        if (upAndDown == "2")//下
                        {
							//计算逻辑错误  比九月下一月应该是十月  十月应该和九月比较
                            startTime = DateTimeExtensions.FirstDayOfMonth(time.AddMonths(+1)).ToString("yyyy-MM-dd");
                            endTime = DateTimeExtensions.LastDayOfMonth(DateTime.Parse(startTime)).AddDays(+1).ToString("yyyy-MM-dd");
						}
						lastStartTime = DateTimeExtensions.FirstDayOfMonth(DateTime.Parse(startTime).AddMonths(-1)).ToString("yyyy-MM-dd");
						lastEndTime = startTime;
						retStartTime = DateTime.Parse(lastStartTime).ToString("yyyy-MM");
						retEndTime = DateTime.Parse(startTime).ToString("yyyy-MM");
					}
                    break;
                case "3":
                    {
                        if (upAndDown == "0")
                        {
                            startTime = DateTimeExtensions.TwoToFirstDayOfSeason(time).ToString("yyyy-MM-dd");
							endTime = DateTimeExtensions.TwoToLastDayOfSeason(DateTime.Parse(startTime)).AddDays(+1).ToString("yyyy-MM-dd");
						}
                        if (upAndDown == "1")//上
                        {
                            startTime = DateTimeExtensions.TwoToFirstDayOfSeason(DateTimeExtensions.TwoToFirstDayOfSeason(time).AddDays(-1)).ToString("yyyy-MM-dd");
							endTime= DateTimeExtensions.TwoToLastDayOfSeason(DateTime.Parse(startTime)).AddDays(+1).ToString("yyyy-MM-dd");

						}
                        if (upAndDown == "2")//下
                        {
							startTime = DateTimeExtensions.TwoToFirstDayOfSeason(DateTimeExtensions.TwoToLastDayOfSeason(time).AddDays(+1)).ToString("yyyy-MM-dd");
							endTime = DateTimeExtensions.TwoToLastDayOfSeason(DateTime.Parse(startTime)).AddDays(+1).ToString("yyyy-MM-dd");
						}
						lastStartTime = DateTimeExtensions.TwoToFirstDayOfSeason(DateTime.Parse(startTime).AddDays(-1)).ToString("yyyy-MM-dd");
						lastEndTime = startTime;
						retStartTime = lastStartTime;
						retEndTime = startTime;
						retQuarter = DateTimeExtensions.JudgeTimeIsToDiff(DateTime.Parse(startTime));
					}
                    break;
                case "4":
                    {
						int day = 0;
						if (upAndDown == "0")
						{
							day = 0;
						}
						if (upAndDown == "1")//上
						{
							day = -1;
						}
						if (upAndDown == "2")//下
						{
							day = 1;
						}
						startTime = time.AddDays(day).ToString("yyyy-MM-dd");
						endTime = time.AddDays(+(1+day)).ToString("yyyy-MM-dd");
						lastStartTime = time.AddDays(-(1-day)).ToString("yyyy-MM-dd");
						lastEndTime = time.AddDays(day).ToString("yyyy-MM-dd");
						retStartTime = lastStartTime;
						retEndTime = startTime;
					}
                    break;
                default:
                    break;

            }
            //显示的数据源
            Details showDetails = await LeadDataDataAccess.Instance.GetOrderDetailsAsync(startTime, endTime);
            //对比的数据源
            Details trastDetails = await LeadDataDataAccess.Instance.GetOrderDetailsAsync(lastStartTime, lastEndTime);

            ShareProfit showShare = await LeadDataDataAccess.Instance.GetShareProfitAsync(startTime, endTime);

            ShareProfit trastShare = await LeadDataDataAccess.Instance.GetShareProfitAsync(lastStartTime, lastEndTime);
			bool isSuccess = false;
            //(今天-昨天)÷昨天×100%
            result = new DetailsResult();
            {
                result.Sum = showDetails.Sum;
                result.Gross = showDetails.Gross;
                result.Profit = showDetails.Profit;
                result.Profits = showDetails.Profits;
                result.Average = showDetails.Average;
                result.Cashs = showShare.Cashs;
                result.SumRate = Contrast(showDetails.Sum, trastDetails.Sum,out isSuccess);
				result.SumTrend = isSuccess;
                result.GrossRate = Contrast(showDetails.Gross, trastDetails.Gross, out isSuccess);
				result.GrossTrend = isSuccess;
				result.ProfitRate= Contrast(showDetails.Profit, trastDetails.Profit, out isSuccess);
				result.ProfitTrend = isSuccess;
				result.ProfitsRate= Contrast(showDetails.Profits, trastDetails.Profits, out isSuccess);
				result.ProfitsTrend = isSuccess;
				result.AverageRate = Contrast(showDetails.Average, trastDetails.Average, out isSuccess);
				result.AverageTrend = isSuccess;
				result.CashsRate = Contrast(showShare.Cashs, trastShare.Cashs, out isSuccess);
				result.CashsTrend = isSuccess;
				result.StartTime = retStartTime;//lastStartTime;
				result.EndTime = retEndTime;//startTime;//(DateTime.Parse(endTime).AddDays(-1)).ToString("yyyy-MM-dd");
				result.Quarter = retQuarter;


			};
			return result;
        }

        /// <summary>
        /// 计算同比增长率么
        /// </summary>
        /// <param name="x">本</param>
        /// <param name="xx">上</param>
        /// <returns></returns>
        public string Contrast(string x, string xx,out bool issuccess)
        {
			issuccess = false;
            double dx = double.Parse(x);
            double dxx = double.Parse(xx);
            if (dxx == 0.00)
            {
				issuccess = true;
                return "0.00";
            }
			double retNum = ((dx - dxx) / dxx * 100);
			issuccess = retNum >= 0 ? true : false;
			return retNum>=0?retNum.ToString("F2"):retNum.ToString("F2").Substring(1);
        }
		#endregion

		/// <summary>
		/// 总渠道
		/// </summary>
		/// <returns></returns>
		public TotalChannelArray GetTotalChannel()
        {
            string startTime = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
            List<TotalChannel> GetTotalChannelList = LeadDataDataAccess.Instance.GetTotalChannel();
            List<string> createtime = new List<string>();
            List<string> num = new List<string>();
            DateTime dateTime = Convert.ToDateTime(startTime);
            while (true)
            {
                if (dateTime > DateTime.Now)
                    break;
                createtime.Add(dateTime.ToString("MM-dd"));
                num.Add(GetTotalChannelList.Where(c=>Convert.ToDateTime(c.createtime)<dateTime.AddDays(1)).Count().ToString());
                dateTime = dateTime.AddDays(1);

            }
            TotalChannelArray bDData = new TotalChannelArray();
            bDData.createtime = createtime;
            bDData.num = num;
            return bDData;
        }
        /// <summary>
        /// 地推每日获取人数
        /// </summary>
        /// <returns></returns>
        public List<BDData> GetBDDatas()
        {
            return LeadDataDataAccess.Instance.GetBDDatas();
        }

        /// <summary>
        /// 获取单日数据
        /// </summary>
        /// <param name="timeType">1:7天,2:30天,3:90天</param>
        /// <param name="getName">获取单日数据名称</param>
        /// <returns></returns>
        public DayData GetDayData(string timeType,string getName)
        {
            List<DayUserPriceAvg> UserPriceAvgList = new List<DayUserPriceAvg>();//单日平均客单价
            DayData dayData = new DayData();
            string startTime = string.Empty;
            string endTime = string.Empty;
            switch (timeType)
            {
                case "1":
                    startTime = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
                    endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    break;
                case "2":
                    startTime = DateTime.Now.AddDays(-29).ToString("yyyy-MM-dd");
                    endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    break;
                case "3":
                    startTime = DateTime.Now.AddDays(-89).ToString("yyyy-MM-dd");
                    endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    break;
                default:
                    break;
            }

            switch (getName)
            {
                case "GetDaySalesVolumes":
                    dayData=GetDaySalesVolumes(startTime, endTime);
                    break;
                case "GetDayOrderNums":
                    dayData = GetDayOrderNums(startTime, endTime);
                    break;
                case "GetDayUserNums":
                    dayData = GetDayUserNums(startTime, endTime);
                    break;
                case "GetUserPriceAvgs":
                    DayData dayDataSalesVolumes = GetDaySalesVolumes(startTime, endTime);
                    DayData dayOrderNums = GetDayOrderNums(startTime, endTime);
                    dayData = GetUserPriceAvgs(dayDataSalesVolumes, dayOrderNums);
                    break;
                default:
                    break;
            }
            return dayData;
        }

        /// <summary>
        /// 获取单日销售额
        /// </summary>
        /// <param name="timeType">1:7天,2:30天,3:90天</param>
        /// <returns></returns>
        public DayData GetDaySalesVolumes(string startTime,string endTime)
        {
            DayData DayDataList = new DayData();//单日销售额集合
            DayDataList.createtime = new List<string>();
            DayDataList.value = new List<string>();
            var DaySalesVolumes = LeadDataDataAccess.Instance.GetDaySalesVolumes(startTime, endTime);//单日销售额
            DateTime dateTime = Convert.ToDateTime(startTime);
            while (true)
            {
                if (dateTime > DateTime.Now)
                    break;
                #region 销售额
                var daySalesVolume = DaySalesVolumes.Where(c => Convert.ToDateTime(c.createtime) == dateTime).FirstOrDefault();
                if (daySalesVolume == null)
                {
                    DayDataList.createtime.Add(dateTime.ToString("MM-dd"));
                    DayDataList.value.Add("0.00");
                }
                else
                {
                    DayDataList.createtime.Add(Convert.ToDateTime(daySalesVolume.createtime).ToString("MM-dd"));
                    DayDataList.value.Add(daySalesVolume.pricetotal);
                }
                #endregion
                dateTime = dateTime.AddDays(1);
            }
            return DayDataList;
        }
        /// <summary>
        /// 获取单日订单数
        /// </summary>
        /// <param name="timeType">1:7天,2:30天,3:90天</param>
        /// <returns></returns>
        public DayData GetDayOrderNums(string startTime, string endTime)
        {
            DayData DayDataList = new DayData();//单日订单数集合
            DayDataList.createtime = new List<string>();
            DayDataList.value = new List<string>();
            var DayOrderNums = LeadDataDataAccess.Instance.GetDayOrderNums(startTime, endTime); //单日订单数
            DateTime dateTime = Convert.ToDateTime(startTime);
            while (true)
            {
                if (dateTime > DateTime.Now)
                    break;
                #region 订单数
                var dayOrderNum = DayOrderNums.Where(c => Convert.ToDateTime(c.createtime) == dateTime).FirstOrDefault();
                if (dayOrderNum == null)
                {
                    DayDataList.createtime.Add(dateTime.ToString("MM-dd"));
                    DayDataList.value.Add("0");
                }
                else
                {
                    DayDataList.createtime.Add(Convert.ToDateTime(dayOrderNum.createtime).ToString("MM-dd"));
                    DayDataList.value.Add(dayOrderNum.ordernum);
                }
                #endregion
                dateTime = dateTime.AddDays(1);
            }
            return DayDataList;
        }
        /// <summary>
        /// 获取授权用户
        /// </summary>
        /// <param name="timeType">1:7天,2:30天,3:90天</param>
        /// <returns></returns>
        public DayData GetDayUserNums(string startTime, string endTime)
        {
            DayData DayDataList = new DayData();//单日授权用户数
            DayDataList.createtime = new List<string>();
            DayDataList.value = new List<string>();
            var DayUserNums = LeadDataDataAccess.Instance.GetUserNums(startTime, endTime);//单日授权用户
            DateTime dateTime = Convert.ToDateTime(startTime);
            while (true)
            {
                if (dateTime > DateTime.Now)
                    break;
                #region 授权用户
                var dayUserNum = DayUserNums.Where(c => Convert.ToDateTime(c.createtime) == dateTime).FirstOrDefault();
                if (dayUserNum == null)
                {
                    DayDataList.createtime.Add(dateTime.ToString("MM-dd"));
                    DayDataList.value.Add("0");
                }
                else
                {
                    DayDataList.createtime.Add(Convert.ToDateTime(dayUserNum.createtime).ToString("MM-dd"));
                    DayDataList.value.Add(dayUserNum.usernum);
                }
                #endregion
                dateTime = dateTime.AddDays(1);
            }
            return DayDataList;
        }
        /// <summary>
        /// 平均客单价
        /// </summary>
        /// <param name="DaySalesVolumeList">销售额</param>
        /// <param name="DayOrderNumList">订单数</param>
        /// <returns></returns>
        public DayData GetUserPriceAvgs(DayData DaySalesVolumeList, DayData DayOrderNumList)
        {
            DayData DayDataList = new DayData();//平均客单价
            DayDataList.createtime = new List<string>();
            DayDataList.value = new List<string>();
            for (int i = 0; i < DaySalesVolumeList.createtime.Count; i++)
            {
                DayDataList.createtime.Add(Convert.ToDateTime(DaySalesVolumeList.createtime[i]).ToString("MM-dd"));
                DayDataList.value.Add(DataCommon.CheckDivision(DaySalesVolumeList.value[i], DayOrderNumList.value[i]).ToString("0.00"));
            }
            return DayDataList;
        }
    }
}

using System;

namespace MiniAppBll.Time
{
    /// <summary>
    /// 自然周，月，季度计算
    /// </summary>
    public static class DateTimeExtensions
    {

        /// <summary>
        /// 判断时间是否和服务器时间是一天
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public static bool JudgeTimeIsToDay(DateTime cs)
        {

            DateTime start = Convert.ToDateTime(cs.ToShortDateString());
            DateTime end = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan sp = end.Subtract(start);
            return sp.Days == 0;
        }
		/// <summary>
		/// 计算当前季度多少天
		/// </summary>
		/// <returns></returns>
		public static int DateDiff()
        {
            DateTime start = Convert.ToDateTime(ToFirstDayOfSeason().ToShortDateString());
            DateTime end = Convert.ToDateTime(ToLastDayOfSeason().ToShortDateString());
            TimeSpan sp = end.Subtract(start);

            return sp.Days;
        }

        /// <summary>
        /// 计算当前月有多少天
        /// </summary>
        /// <returns></returns>
        public static int GetMonthDays()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture.Calendar.GetDaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }

        /// <summary>   
        /// 计算本周的周一日期   
        /// </summary>   
        /// <returns></returns>   
        public static DateTime GetMondayDate()
        {
            return GetMondayDate(DateTime.Now);
        }

        /// <summary>   
        /// 计算本周周日的日期   
        /// </summary>   
        /// <returns></returns>   
        public static DateTime GetSundayDate()
        {
            return GetSundayDate(DateTime.Now);
        }

        /// <summary>
        /// 获取本月最后一天
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth()
        {
            return DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(1).AddDays(-1);
        }

        /// <summary>   
        /// 计算本月的第一天   
        /// </summary>   
        /// <returns></returns> 
        public static DateTime FirstDayOfMonth()
        {
            return DateTime.Now.AddDays(1 - DateTime.Now.Day);
        }

        /// <summary>
        ///  获取该时间所在季度的第一天
        /// </summary>
        /// <returns></returns>
        public static DateTime ToFirstDayOfSeason()
        {
            return ToFirstDayOfSeason(DateTime.Now);
        }

        /// <summary>
        /// 获取该时间所在季度的最后一天
        /// </summary>
        /// <returns></returns>
        public static DateTime ToLastDayOfSeason()
        {
            return ToLastDayOfSeason(DateTime.Now);
        }

        /// <summary>
        /// 获取该时间所在季度的第一天
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static DateTime ToFirstDayOfSeason(DateTime target)
        {
            int ThisMonth = DateTime.Now.Month;
            int FirstMonthOfSeason = ThisMonth - (ThisMonth % 3 == 0 ? 3 : (ThisMonth % 3)) + 1;
            target = target.AddMonths(FirstMonthOfSeason - ThisMonth);

            return Convert.ToDateTime(target.ToString("yyyy-MM-01 HH:mm:ss"));
        }

        /// <summary>
        /// 获取该时间所在季度的最后一天
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static DateTime ToLastDayOfSeason(DateTime target)
        {
            int ThisMonth = DateTime.Now.Month;
            int FirstMonthOfSeason = ThisMonth - (ThisMonth % 3 == 0 ? 3 : (ThisMonth % 3)) + 3;
            target = target.AddMonths(FirstMonthOfSeason - ThisMonth);

            return Convert.ToDateTime(target.AddMonths(1).ToString("yyyy-MM-01 HH:mm:ss")).AddDays(-1);
        }
	
		/// <summary>   
		/// 计算本月的第一天   
		/// </summary>   
		/// <returns></returns> 
		public static DateTime FirstDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day);
        }

        /// <summary>
        /// 获取本月最后一天
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }

        /// <summary>   
        /// 计算某日起始日期（礼拜一的日期）   
        /// </summary>   
        /// <param name="someDate">该周中任意一天</param>   
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns>   
        public static DateTime GetMondayDate(this DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。   
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }

        /// <summary>   
        /// 计算某日结束日期（礼拜日的日期）   
        /// </summary>   
        /// <param name="someDate">该周中任意一天</param>   
        /// <returns>返回礼拜日日期，后面的具体时、分、秒和传入值相等</returns>   
        public static DateTime GetSundayDate(this DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。   
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Add(ts);
        }

        public static DateTime GetSundayDate(this DateTime someDate, int hour, int minute, int second)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。   
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            var ret = someDate.Add(ts);

            ret = ret.AddHours(hour - ret.Hour);
            ret = ret.AddMinutes(minute - ret.Minute);
            ret = ret.AddSeconds(second - ret.Second);
            return ret;
        }

		#region rjy
		/// <summary>
		/// 获取该时间所在季度的最后一天 rjy 2018年9月27日13:52:24
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public static DateTime TwoToLastDayOfSeason(DateTime target)
		{
			return target.AddMonths(3).AddDays(-1);

		}
		/// <summary>
		/// 获取该时间所在季度的最后一天 rjy 2018年9月27日13:52:24
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public static DateTime TwoToFirstDayOfSeason(DateTime target)
		{
			return target.AddMonths(0 - (target.Month - 1) % 3).AddDays(1 - target.Day);

		}
		/// <summary>
		/// 计算所在季度是那个季度 rjy
		/// </summary>
		/// <param name="cs"></param>
		/// <returns></returns>
		public static String JudgeTimeIsToDiff(DateTime cs)
		{
			int c;
			if (cs.Month % 3 != 0) //百分号为求余号
			{
				c = cs.Month / 3 + 1;
			}
			else
			{
				c = cs.Month / 3;
			}
			return cs.Year.ToString() + "-Q" + c;
		}
		#endregion
	}
}
using Dapper;
using MiniAppApis.MiniAppBLL;
using MiniAppBll.Time;
using MiniAppDal;
using MiniAppModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppBll
{
	public partial class AccountProfitBLL
	{
		#region 配置
		static AccountProfitBLL _instance;
		static object _lock = new object();
		public static AccountProfitBLL Instance
		{

			get
			{
				if (_instance == null)
				{
					lock (_lock)
					{
						if (_instance == null)
							_instance = new AccountProfitBLL();
					}
				}
				return _instance;
			}
		}
		#endregion
		/// <summary>
		/// 获取我的奖励统计 rjy 2018年9月21日17:00:22
		/// </summary>
		/// <param name="UserId">用户id</param>
		/// <returns>返回结果类</returns>
		public AccountEntity GetAccountInfo(int UserId)
		{
			return AccountProfitDAL.Instance.GetAccountInfo(UserId);
		}

		/// <summary>
		/// 获取我的奖励中的今日实时奖励
		/// </summary>
		/// <returns></returns>
		public List<ProfitEntity> GetProfitsList(int UserId)
		{
			return AccountProfitDAL.Instance.GetProfitsList(UserId);
		}

		/// <summary>
		/// bd经理
		/// </summary>
		/// <param name="userid">操作人id</param>
		/// <param name="stype">1:销售额，2：渠道数，3：拉新用户数</param>
		/// <param name="timeType">1：7,2:30,3：90</param>
		/// <param name="infoTimeType">1:自然周，2:自然月,3:季度,4:天</param>
		/// <param name="time">当前显示时间</param>
		/// <param name="upAndDown">0：当前,1:向上,2:向下</param>
		public async Task<BDLeader> GetBdInfo(int userid, int stype, string timeType, string infoTimeType, DateTime time, string upAndDown)
		{
			BDLeader bDLeader = new BDLeader();
			bDLeader.lineData = new BDLeaderLineResult();
			IList<BDLeaderEntity> list = await AccountProfitDAL.Instance.GetBdInfo(userid, stype);
			string startTime = string.Empty;
			string endTime = string.Empty;
			string lastStartTime = string.Empty; //对比数据开始时间
			string lastEndTime = string.Empty; //对比数据结束时间
			string retStartTime = string.Empty;//返回的开始时间
			string retEndTime = string.Empty;//返回的结束时间
			String retQuarter = string.Empty;
			string[] times = null;
			string[] limits = null;
			#region 空数据构建
			switch (timeType)
			{
				case "1":
					{
						startTime = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
						endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

						times = new string[7];
						limits = new string[7];
						for (int i = 0; i < 7; i++)
						{
							times[i] = DateTime.Now.AddDays(+(i - 6)).ToString("yyyy-MM-dd");


							limits[i] = "0.00";
						}
					}
					break;
				case "2":
					{
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
			#endregion
			#region 折线数据处理
			for (int i = 0; i < times.Length; i++)
			{
				//销售额
				if (stype == 1)
				{
					limits[i] = list.Where(p => p.date < Convert.ToDateTime(times[i])).Sum(p => Convert.ToDecimal(p.limit)).ToString();
				}
				//渠道数和拉新数
				else
				{
					limits[i] = list.Where(p => p.date < Convert.ToDateTime(times[i])).Count().ToString();
				}
				times[i] = Convert.ToDateTime(times[i]).ToString("MM-dd");
			}
			bDLeader.lineData.date = times;
			bDLeader.lineData.limit = limits;
			bDLeader.LineStartTime = times[0];
			bDLeader.LineEndTime = times[times.Length - 1];
			#endregion
			//数据详情构建
			switch (infoTimeType)
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
							endTime = DateTimeExtensions.TwoToLastDayOfSeason(DateTime.Parse(startTime)).AddDays(+1).ToString("yyyy-MM-dd");

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
						endTime = time.AddDays(+(1 + day)).ToString("yyyy-MM-dd");
						lastStartTime = time.AddDays(-(1 - day)).ToString("yyyy-MM-dd");
						lastEndTime = time.AddDays(day).ToString("yyyy-MM-dd");
						retStartTime = lastStartTime;
						retEndTime = startTime;
					}
					break;
				default:
					break;

			}
			bDLeader.StartTime = retStartTime;
			bDLeader.EndTime = retEndTime;
			bDLeader.Quarter = retQuarter;
			IList<BDLeaderEntity> listinfo = await AccountProfitDAL.Instance.GetBdInfo(userid, 4);
			List<BDLeaderInfoResult> bDLeaderInfoResults = new List<BDLeaderInfoResult>();
			foreach (var item in listinfo)
			{
				BDLeaderInfoResult bDLeaderItem = new BDLeaderInfoResult();
				bDLeaderItem.name = item.rname;
				string limit = string.Empty;
				string climit = string.Empty;
				bool issuccess = false;
				//销售额
				if (stype == 1)
				{
					limit = list.Where(p => (p.date >= Convert.ToDateTime(startTime)) && (p.date < Convert.ToDateTime(endTime)) && (p.rname == item.rname)).Sum(p => Convert.ToDecimal(p.limit)).ToString();
					climit = list.Where(p => (p.date >= Convert.ToDateTime(lastStartTime)) && (p.date < Convert.ToDateTime(lastEndTime)) && (p.rname == item.rname)).Sum(p => Convert.ToDecimal(p.limit)).ToString();
				}
				//渠道数和拉新数
				else
				{
					limit = list.Where(p => (p.date >= Convert.ToDateTime(startTime)) && (p.date < Convert.ToDateTime(endTime)) && (p.rname == item.rname)).Count().ToString();
					climit = list.Where(p => (p.date >= Convert.ToDateTime(lastStartTime)) && (p.date < Convert.ToDateTime(lastEndTime)) && (p.rname == item.rname)).Sum(p => Convert.ToDecimal(p.limit)).ToString();
				}
				bDLeaderItem.Sum = limit;
				bDLeaderItem.SumRate = Contrast(limit, climit, out issuccess);
				bDLeaderItem.SumTrend = issuccess;
				bDLeaderInfoResults.Add(bDLeaderItem);
			}
			bDLeader.infoData = bDLeaderInfoResults;
			return bDLeader;
		}
		/// <summary>
		/// 计算同比增长率么
		/// </summary>
		/// <param name="x">本</param>
		/// <param name="xx">上</param>
		/// <returns></returns>
		public string Contrast(string x, string xx, out bool issuccess)
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
			return retNum >= 0 ? retNum.ToString("F2") : retNum.ToString("F2").Substring(1);
		}































		/// <summary>
		/// 获取我的提现记录
		/// </summary>
		/// <returns></returns>
		public List<PutForwardRecord> GetPutForwardRecordList(int userid)
        {
            return AccountProfitDAL.Instance.GetPutForwardRecordList(userid);
        }
    }
}

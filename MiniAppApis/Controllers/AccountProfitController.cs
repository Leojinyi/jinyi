using Common.ReturnResult;
using MiniAppApis.App_Start;
using MiniAppApis.Models;
using MiniAppApis.ParamEntity;
using MiniAppBll;
using MiniAppModel.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MiniAppApis.Controllers
{
	[AuthorizeFilter]
	public class AccountProfitController : ApiController
	{
		log4net.ILog log = log4net.LogManager.GetLogger("log4net");
		//public AccountProfitBLL Bll { get { return new AccountProfitBLL(); } }
		#region rjy 我的奖励
		[HttpPost]
		[Route("AccountProfit/GetBdInfo")]
		public async Task<ResultInfo<BDLeader>> GetAccountInfo(RequestParameter content)
		{
			ResultInfo<BDLeader> result = new ResultInfo<BDLeader>();
			dynamic data = content.conten;
			if ((string)data.timetype == null || (string)data.userid == null)
			{
				result.ResultCode = EmResultDescribe.缺少必要信息;
			}
			else
			{
				result.ResultData = await AccountProfitBLL.Instance.GetBdInfo((int)data.userid, (int)data.stype, (string)data.timetype, (string)data.infotimetype, (DateTime)data.time, (string)data.upanddown);
			}
			return result;

		}
		/// <summary>
		/// 我的奖励统计和实时奖励列表信息接口
		/// </summary>
		/// <param name="UserId">用户id</param>
		/// <returns></returns>
		[HttpPost]
		[Route("AccountProfit/GetAccountInfo")]
		public ReturnEntity GetAccountInfo(AccountProfitReq accountProfitReq)
		{
			AccountEntity accountEntity = null;
			List<ProfitEntity> profitList = null;
			try
			{
				accountEntity = AccountProfitBLL.Instance.GetAccountInfo(accountProfitReq.userid);
				profitList = AccountProfitBLL.Instance.GetProfitsList(accountProfitReq.userid);
				return GetResultInfo(true, "Success", accountEntity,profitList, profitList != null ? profitList.Sum(p => p.cash) : 0);
			}
			catch (Exception ex)
			{
				//异常处理  防止前台弹出信息
				//添加日志或写入日志表
				LogMessage("获取我的奖励统计接口api/AccountProfit/GetAccountInfo", JsonConvert.SerializeObject(accountProfitReq), JsonConvert.SerializeObject(accountEntity), ex.Message);
				return GetResultInfo(false, ex.Message, accountEntity, profitList, 0);
			}
		}
		#region 
		///// <summary>
		///// 获取我的奖励中的今日实时奖励
		///// </summary>
		///// <returns></returns>
		//[HttpGet]
		//[Route("AccountProfit/GetProfitsList")]
		//public ReturnEntity GetProfitsList(int UserId)
		//{
		//	List<ProfitEntity> profitList = null;
		//	try
		//	{
		//		profitList = Bll.GetProfitsList(UserId);
		//		return GetResultInfo(true, "Success", profitList, profitList != null ? profitList.Sum(p => p.cash) : 0);
		//	}
		//	catch (Exception ex)
		//	{
		//		//异常处理  防止前台弹出信息
		//		//添加日志或写入日志表
		//		LogMessage("获取我的奖励中的今日实时奖励api/AccountProfit/GetProfitsList", "UserId:" + UserId, JsonConvert.SerializeObject(profitList), ex.Message);
		//		return  GetResultInfo(false, ex.Message, profitList, 0);
		//	}
		//}
		#endregion
		/// <summary>
		/// 添加日志或写入日志表
		/// </summary>
		/// <param name="address">地址</param>
		/// <param name="param">参数</param>
		/// <param name="retMes">返回信息</param>
		/// <param name="mes">错误信息</param>
		private void LogMessage(String address, String param, String retMes, String mes)
		{

			log.ErrorFormat(@"接口地址：{0},参数：{1},返回结果{2},错误：{3}", address, param, retMes, mes);
		}
		///// <summary>
		///// 返回信息构建
		///// </summary>
		///// <param name="isSuccess">是否成功</param>
		///// <param name="msg">信息</param>
		///// <param name="data">返回数据</param>
		///// <returns></returns>
		private ReturnEntity GetResultInfo(bool isSuccess, String msg,AccountEntity Accountdata,List<ProfitEntity> profitlist ,decimal sumStatistics)
		{
			ReturnEntity resultInfo = new ReturnEntity();
			resultInfo.ResultCode = isSuccess ? EmResultDescribe.OK : EmResultDescribe.系统错误;
			resultInfo.Message = msg;
			resultInfo.AccountData = Accountdata;
			resultInfo.ProfitsData = profitlist;
			resultInfo.SumStatistics = sumStatistics;
			return resultInfo;
		}
        #endregion




















































        #region 刘嘉辉
        /// <summary>
        /// 获取我的提现记录
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AccountProfit/GetPutForwardRecordList")]
        public ResultInfo<PutForwardRecordList> GetPutForwardRecordList(PutForwardRecordEntity putForward)
        {
            ResultInfo<PutForwardRecordList> result = new ResultInfo<PutForwardRecordList>();
            try
            {
                PutForwardRecordList list = new PutForwardRecordList();
                list.datas = AccountProfitBLL.Instance.GetPutForwardRecordList(putForward.userid);
                list.totalamount = list.datas.Sum(c=>c.amount)==0?"0.00": list.datas.Sum(c => c.amount).ToString("F2");
                result.ResultData = list;
                result.ResultCode = EmResultDescribe.OK;
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogMessage("获取我的提现记录/AccountProfit/GetPutForwardRecordList", "putForward:" + JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }
        #endregion
    }
}

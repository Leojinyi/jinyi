using Common.ReturnResult;
using MiniAppApis.App_Start;
using MiniAppApis.ParamEntity;
using MiniAppBll.PutForward;
using MiniAppModel.Entity;
using MiniAppModel.RewardDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MiniAppApis.Controllers
{
    [AuthorizeFilter]
    [RoutePrefix("putforward")]
    /// <summary>
    /// 提现页面相关接口
    /// </summary>
    public class PutForwardController : ApiController
    {
        public NoAwardBLL noAwardBLL { get { return new NoAwardBLL(); } }
        [HttpPost]   
        [Route("OutMoney")]
        //提现
        public ResultInfo<string> OutMoney(PutForwardRecordEntity entity)
        {
            ResultInfo<string> resultInfo = new ResultInfo<string>();
            if (entity.userid == 0 || entity.money > 10000)
            {
                resultInfo.ResultCode = EmResultDescribe.参数错误;
                resultInfo.ResultData = "请输入有效金额";
            }
            //判断余额是否充足
            AccountEntity acc = noAwardBLL.GetAccountInfo(entity.userid);
            if (entity.money > acc.cash)
            {
                resultInfo.ResultCode = EmResultDescribe.参数错误;
                resultInfo.ResultData = "账户余额不足";
            }
            else
            {
                decimal TXmoney = entity.money * (decimal)0.2;
                SortedDictionary<string, object> resDic = DoOutMoney(TXmoney, acc.openId);
                if (resDic["result_code"].ToString() == "SUCCESS")
                {
                    var date = DateTime.Now.ToString();
                    Account_Log log = new Account_Log();
                    log.update_time = resDic["payment_time"].ToString();
                    log.pay_no = resDic["payment_no"].ToString();
                    log.pay_way = "公司商户";
                    log.user_id = entity.userid;
                    log.account_id = Convert.ToInt32(acc.accountId);
                    log.collection_account = "微信零钱";
                    log.cash = entity.money;
                    noAwardBLL.UpdateAccountInfo(log);
                    resultInfo.ResultCode = EmResultDescribe.正确返回结果;
                    resultInfo.ResultData = "提现成功";
                }
                else
                {
                    resultInfo.ResultCode = EmResultDescribe.缺少必要信息;
                    resultInfo.ResultData = resDic["return_msg"].ToString();
                }
            }
            return resultInfo;
        }    
        public SortedDictionary<string, object> DoOutMoney(decimal money, string openid)
        {
            WxPayData wxPayData = new WxPayData();
            int amount = (int)(money * 100);
            wxPayData.SetValue("amount", amount);
            wxPayData.SetValue("check_name", "NO_CHECK");// FORCE_CHECK 校验真实姓名 NO_CHECK：不校验真实姓名 
            wxPayData.SetValue("desc", "分润提现");
            wxPayData.SetValue("openid", openid);
            wxPayData.SetValue("partner_trade_no", "ZDMNo" + DateTime.Now.ToString("yyyymmddhhmmss"));
            wxPayData.SetValue("re_user_name", "");//check_name为FORCE_CHECK时，此参数必填
            wxPayData.SetValue("spbill_create_ip", "114.215.66.246");
            wxPayData.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));
            wxPayData.SetValue("mchid", WxPayConfig.Mchid);//商户号
            wxPayData.SetValue("mch_appid", WxPayConfig.Smch_Appid);//appidmch_appid
            wxPayData.SetValue("sign", wxPayData.MakeSign());
            string respose = wxPayData.PostWebRequest("https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers", wxPayData.ToXml(), Encoding.UTF8, true);
            WxPayData wxPay = new WxPayData();
            SortedDictionary<string, object> resDic = wxPay.FromXml(respose);
            return resDic;
        }

        [HttpPost]
        [Route("blaInfo")]
        /// <summary>
        /// 获取金额信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ResultInfo<AccountEntity> GetBalance(WithDrawCash drawCash)
        {
            ResultInfo<AccountEntity> resultInfo = new ResultInfo<AccountEntity>();
            if (drawCash.userid == 0)
            {
                resultInfo.ResultCode = EmResultDescribe.参数错误;
                resultInfo.ResultData = null;
                return resultInfo;
            }
            resultInfo.ResultCode = EmResultDescribe.OK;
            resultInfo.ResultData = noAwardBLL.GetAccountInfo(drawCash.userid);
            return resultInfo;
        }
        [HttpPost]
        [Route("noawardlist")]
        /// <summary>
        /// 暂不可提现列表
        /// </summary>
        /// <param name="userid"></param>
        public ResultInfo<List<ProfitInfoEntity>>GetProfitList(WithDrawCash drawCash)
        {
            ResultInfo<List<ProfitInfoEntity>> resultInfo = new ResultInfo<List<ProfitInfoEntity>>();
            if (drawCash.userid == 0)
            {
                resultInfo.ResultCode = EmResultDescribe.参数错误;
                resultInfo.ResultData = null;
                return resultInfo;
            }
            resultInfo.ResultCode = EmResultDescribe.OK;
            resultInfo.ResultData = noAwardBLL.GetProfitListNoWard(drawCash.userid);
            return resultInfo;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.ReturnResult;
using Common.Extend;
using MiniAppApis.ParamEntity;
using MiniAppApis.Common;
using MiniAppModel.LoginInfo;
using MiniAppBll.LoginInfo;
using MiniAppApis.Log;
using Newtonsoft.Json;

namespace MiniAppApis.Controllers
{
    [RoutePrefix("UserLogin")]
    public class UserLoginController : ApiController
    {
        public LoginInfoBll Bll { get { return new LoginInfoBll(); } }

        #region 刘嘉辉
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public ResultInfo<LoginInfoModel> Login(LoginEntity ent)
        {
            ResultInfo<LoginInfoModel> result = new ResultInfo<LoginInfoModel>();
            try
            {
                //验证手机号是否正确 或 手机号和验证码等于中大门顶级地推和123789（这是我们专门给顶级地推分发的特殊账号如果需要修改直接修改判断条件）
                if (Check.Checktel(ent.Tel) || (ent.Tel == "中大门顶级地推" && ent.CheckCode == "123789"))
                {
                    //验证手机号验证码是否正确 或 这个判断和上面一样
                    if (Cache.IsCheckCodeExists(ent.Tel, ent.CheckCode) || (ent.Tel == "中大门顶级地推" && ent.CheckCode == "123789"))
                    {
                        LoginInfoModel login = Bll.GetUserInfo(ent.Tel);//根据手机号获取用户信息
                        if (login != null)
                        {
                            string token = Guid.NewGuid().ToString();//生成令牌token
                            Cache.SetCheckTokenCache(login.userid, token);//存入缓存中 缓存有效期7天
                            login.token = token;
                            result.ResultData = login;
                        }
                        else
                        {
                            result.ResultCode = EmResultDescribe.账号未开通;
                        }
                    }
                    else
                    {
                        result.ResultCode = EmResultDescribe.验证码不正确或验证码已过期;
                    }
                }
                else
                {
                    result.ResultCode = EmResultDescribe.验证码手机号不合法;
                }
                LogInfo.InfoLogMessage("/UserLogin/Login", JsonConvert.SerializeObject(ent), JsonConvert.SerializeObject(result.ResultData));
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/UserLogin/Login", JsonConvert.SerializeObject(ent), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetCheckCode")]
        public ResultInfo<string> GetCheckCode(CheckCodeEntity ent)
        {
            ResultInfo<string> result = new ResultInfo<string>();
            try
            {
                //验证手机号是否正确
                if (Check.Checktel(ent.Tel))
                {
                    LoginInfoModel login = Bll.GetUserInfo(ent.Tel);//根据手机号获取用户信息
                    if (login != null)
                    {
                        string code = "";
                        string res = SmsMessage.SendCheckCode(System.Configuration.ConfigurationManager.AppSettings["SmsServiceUrl"], ent.Tel, ref code);//发送短信
                        ResultInfo<string> resCode = res.JsonDecode<ResultInfo<string>>();
                        //验证短信是否发送成功
                        if (resCode.ResultCode == EmResultDescribe.OK)
                        {
                            Cache.SetCheckCodeCache(ent.Tel, code);
                            result.ResultData = code;
                        }
                        else
                        {
                            result.ResultCode = EmResultDescribe.获取验证码过于频繁;
                            result.ResultData = JsonConvert.SerializeObject(resCode);
                        }
                    }
                    else
                    {
                        result.ResultCode = EmResultDescribe.账号未开通;
                    }

                }
                else
                {
                    result.ResultCode = EmResultDescribe.验证码手机号不合法;
                }
                LogInfo.InfoLogMessage("/UserLogin/GetCheckCode", JsonConvert.SerializeObject(ent), JsonConvert.SerializeObject(result.ResultData));
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/UserLogin/GetCheckCode", JsonConvert.SerializeObject(ent), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 获取token（停用）
        /// 换成redis后不可调用，如需要查看缓存请使用redis可视化工具查看
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetToken")]
        public List<CheckTokenEnt> GetToken()
        {
            return Cache.GetCheckTokenList();
        }

        /// <summary>
        /// 检查token
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckToken")]
        public ResultInfo<string> CheckToken(UserTokenEntity tokenEntity)
        {
            ResultInfo<string> result = new ResultInfo<string>();
            //验证token
            if (Cache.GetCheckTokenCache(tokenEntity.Userid, tokenEntity.Token))
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.OK;
            }
            else
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.会话过期;
            }
            return result;
        }
        #endregion

    }
}

using Common.ReturnResult;
using MiniAppApis.Common;
using MiniAppApis.Log;
using MiniAppApis.ParamEntity;
using MiniAppBll.RealNameAuthenticationBll;
using MiniAppModel.RealNameAuthentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http;

namespace MiniAppApis.Controllers
{
    [RoutePrefix("RealNameAuthentication")]
    public class RealNameAuthenticationController : ApiController
    {
        RealNameAuthenticationBll realNameBll = new RealNameAuthenticationBll();
        /// <summary>
        /// 添加实名认证信息
        /// </summary>
        /// <param name="realName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRealName")]
        public ResultInfo<int> AddRealName(RealNameEntity realName)
        {
            ResultInfo<int> result = new ResultInfo<int>();
            try
            {
                if (!string.IsNullOrEmpty(realName.user_real_name))
                {
                    if (!string.IsNullOrEmpty(realName.user_card_no))
                    {
                        //验证服务器证书回调自动验证
                        ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                        WebClient client = new WebClient();
                        client.Headers.Add("Content-Type", "multipart/form-data; boundary=--------------------------this is a boundary");
                        StringBuilder sbPostData = new StringBuilder();
                        sbPostData.Append("----------------------------this is a boundary\r\n");
                        sbPostData.Append("Content-Disposition: form-data; name=\"member_truename\"\r\n");
                        sbPostData.Append("\r\n");
                        sbPostData.Append(WebUtility.UrlEncode(realName.user_real_name) + "\r\n");
                        sbPostData.Append("----------------------------this is a boundary\r\n");
                        sbPostData.Append("Content-Disposition: form-data; name=\"identity_num\"\r\n");
                        sbPostData.Append("\r\n");
                        sbPostData.Append(realName.user_card_no + "\r\n");
                        sbPostData.Append("----------------------------this is a boundary--\r\n");
                        string st = sbPostData.ToString();
                        byte[] bresult = client.UploadData("https://newwww.zhongdamen.com/mobile/index.php?act=index_shop&op=shareidentity", System.Text.Encoding.UTF8.GetBytes(st));
                        string resultMes = Encoding.UTF8.GetString(bresult);
                        ValidateParameter parameter = JsonConvert.DeserializeObject<ValidateParameter>(resultMes);
                        if (parameter.code==1)
                        {
                            RealNameAuthenticationModel realNameModel = new RealNameAuthenticationModel();
                            realNameModel.user_id = realName.userid;
                            realNameModel.real_name = realName.user_real_name;
                            realNameModel.card_no = realName.user_card_no;
                            realNameModel.card_type = 1;
                            result.ResultData = realNameBll.AddRealName(realNameModel);
                            result.ResultCode = EmResultDescribe.OK;
                            LogInfo.InfoLogMessage("/RealNameAuthentication/AddRealName", JsonConvert.SerializeObject(realName), JsonConvert.SerializeObject(result.ResultData));
                        }
                        else
                        {
                            result.ResultCode = EmResultDescribe.验证码传入参数不合法;
                        }
                    }
                    else
                    {
                        result.ResultCode = EmResultDescribe.其他;
                    }
                }
                else
                {
                    result.ResultCode = EmResultDescribe.用户名为空;
                }

            }
            catch (Exception ex)
            {
                result.ResultData = 0;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/UserLogin/Login", JsonConvert.SerializeObject(realName), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受  
            return true;
        }

        /// <summary>
        /// 查询已经实名认证信息
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRealNameMes")]
        public ResultInfo<RealNameAuthenticationModel>GetRealNameMes(GetRealNameParameter parameter)
        {
            ResultInfo<RealNameAuthenticationModel> result = new ResultInfo<RealNameAuthenticationModel>();
            try
            {
                result.ResultData = realNameBll.GetRealName(parameter.user_id);
                result.ResultCode = EmResultDescribe.OK;
                LogInfo.InfoLogMessage("/RealNameAuthentication/GetRealNameMes", JsonConvert.SerializeObject(parameter), JsonConvert.SerializeObject(result.ResultData));
            }
            catch (Exception ex)
            {
                result.ResultData = null;
                result.ResultCode = EmResultDescribe.系统错误;
                LogInfo.ErrorLogMessage("/RealNameAuthentication/GetRealNameMes", JsonConvert.SerializeObject(parameter), JsonConvert.SerializeObject(result.ResultData), ex.Message);
            }
            return result;
        }


    }
}

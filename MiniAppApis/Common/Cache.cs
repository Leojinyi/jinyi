using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Redis;
using MiniAppApis.ParamEntity;
using Newtonsoft.Json;

namespace MiniAppApis.Common
{
    public static class Cache
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("log4net");
        //private static List<CheckCodeEnt> CheckCodeList = new List<CheckCodeEnt>();
        //private static List<CheckTokenEnt> CheckTokenList = new List<CheckTokenEnt>();
        /// <summary>
        /// 存入验证码
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="code"></param>
        public static void SetCheckCodeCache(string tel, string code)
        {
            CheckCodeEnt checkCodeEnt = new CheckCodeEnt();
            checkCodeEnt.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            checkCodeEnt.TelPlusCode = code;
            RedisHelper.StringSet(tel + "+" + code, JsonConvert.SerializeObject(checkCodeEnt), new TimeSpan(0, 10, 0));
        }

        /// <summary>
        /// 存入Token令牌（缓存时效7天）
        /// </summary>
        /// <param name="token"></param>
        public static void SetCheckTokenCache(string userid, string token)
        {
            CheckTokenEnt checkTokenEnt = new CheckTokenEnt();
            checkTokenEnt.dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            checkTokenEnt.userid = userid;
            checkTokenEnt.Token = token;
            var strvalue = RedisHelper.StringGet(userid);//获取缓存
            //验证是否等于空
            if (!string.IsNullOrEmpty(strvalue))
            {
                RedisHelper.KeyDelete(userid);
                RedisHelper.StringSet(userid, JsonConvert.SerializeObject(checkTokenEnt), new TimeSpan(168, 0, 0));
            }
            else
            {
                RedisHelper.StringSet(userid, JsonConvert.SerializeObject(checkTokenEnt), new TimeSpan(168, 0, 0));
            }
        }

        /// <summary>
        /// 查询Token令牌
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="token"></param>
        public static bool GetCheckTokenCache(string userid, string token)
        {
            log.Info("检查token");
            try
            {
                var strvalue = RedisHelper.StringGet(userid);//获取缓存信息
                if (!string.IsNullOrEmpty(strvalue))
                {
                    var checkTokenEnt = JsonConvert.DeserializeObject<CheckTokenEnt>(strvalue);//序列化获取到的json
                    //验证缓存中的token和现在使用的token 是否一致
                    if (checkTokenEnt.Token == token)
                    {
                        log.Info("请求token为：" + token);
                        return true;
                    }
                    else
                    {
                        log.Info(string.Format("token过期：原token：{0}，新token为：{1}", checkTokenEnt.Token, token));
                        return false;
                    }
                }
                else
                {
                    log.Info("token丢失");
                    return false;
                }
            }
            catch (Exception e)
            {
                log.Error("检查token出错：", e);
                return true;
            }
        }

        /// <summary>
        /// 检查验证码是否过期
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsCheckCodeExists(string tel, string code)
        {
            var strvalue = RedisHelper.StringGet(tel + "+" + code);//获取缓存信息
            if (!string.IsNullOrEmpty(strvalue))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取所有usertoken（停用）
        /// </summary>
        /// <returns></returns>
        public static List<CheckTokenEnt> GetCheckTokenList()
        {
            return null;
        }
    }
}

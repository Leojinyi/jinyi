using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MiniAppApis.Common
{
    public static class Config
    {
        public static string AppKey = System.Configuration.ConfigurationManager.AppSettings["APPKey"];
        public static string Secret = System.Configuration.ConfigurationManager.AppSettings["Secret"]; 
        public static string Appid = System.Configuration.ConfigurationManager.AppSettings["appid"];
    }
}
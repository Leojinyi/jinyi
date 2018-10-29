using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.RewardDetail
{
    public class ProfitInfoEntity
    {
        //select create_time,user_id,cash,status,order_no from WeChatServiceFlatform.dbo.profit WHERE user_id=;

        public string CreateTime { get; set; }
        public string UserID { get; set; }
        public string cash { get; set; }
        public string Status { get; set; }
        private string _OrderNO;
        public string OrderNO
        {
            get { return _OrderNO; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _OrderNO = "";
                }
                else
                {
                    _OrderNO = Commm.ReplaceWithSpecialChar(value);
                }
            }
        } 
        public string Year { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string WXName { get; set; }
        public string WXPicture { get; set; }
    }

    public class Commm
    {
        /// <summary>
        /// 字符中间字段替换成*
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startLen"></param>
        /// <param name="endLen"></param>
        /// <param name="specialChar"></param>
        /// <returns></returns>
        public static string ReplaceWithSpecialChar(string value, int startLen = 4, int endLen = 4, char specialChar = '*')
        {
            try
            {
                int lenth = value.Length - startLen - endLen;
                string replaceStr = value.Substring(startLen, lenth);
                string specialStr = string.Empty;
                for (int i = 0; i < replaceStr.Length; i++)
                {
                    specialStr += specialChar;
                }
                value = value.Replace(replaceStr, specialStr);
            }
            catch (Exception)
            {
                throw;
            }
            return value;
        }
    }

    public class Today_Profit
    {
        public decimal TodayProfit { get; set; }
    }
    /// <summary>
    /// 列表 实体
    /// </summary>
    public class ProfitListDateEntity
    {
        public string Date { get; set; }
        public string Count { get; set; }
        public List<ProfitInfoEntity> listProfit { get; set; }
    }
    /// <summary>
    /// 列表 实体
    /// </summary>
    public class ProfitListMouthEntity
    {
        public string Month { get; set; }
        public string Count { get; set; }
        public List<ProfitListDateEntity> listProfit { get; set; }
    }
    /// <summary>
    /// 列表 实体
    /// </summary>
    public class ProfitListYearEntity
    {
        public string Year { get; set; }
        public string Count { get; set; }
        public List<ProfitListMouthEntity> listProfit { get; set; }
    }
    public class ProfitResult
    {
        public List<ProfitListYearEntity> listAll { get; set; }
        public List<ProfitListYearEntity> listHad { get; set; }
        public List<ProfitListYearEntity> listNot { get; set; }
    }
    /// <summary>
    /// 返回值
    /// </summary>
    public class ProfitListEntityList
    {
        public decimal amount { get; set; }
        public string Mouth { get; set; }

        public List<ProfitInfoEntity> datas { get; set; }
    }
}

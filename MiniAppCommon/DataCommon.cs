using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppCommon
{
    public class DataCommon
    {
        /// <summary>
        /// 检查除法
        /// </summary>
        /// <returns></returns>
        public static double CheckDivision(object Division1, object Division2)
        {
            double D1 = Convert.ToDouble(Division1);
            double D2 = Convert.ToDouble(Division2);
            if (D1 != 0 && D2 != 0)
            {
                return D1 / D2;
            }
            else
            {
                return 0;
            }
        }
    }
}

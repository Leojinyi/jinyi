using Common.ReturnResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppModel.Entity
{
	public class ReturnEntity
	{
		
		
		public EmResultDescribe ResultCode { get; set; }
		public String Message { get; set; }
		public AccountEntity AccountData { get; set; }
		public List<ProfitEntity> ProfitsData { get; set; }
		public decimal SumStatistics { get; set; }
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniAppApis.Controllers;
using MiniAppBll;
using MiniAppModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppApis.Controllers.Tests
{
	[TestClass()]
	public class AccountProfitControllerTests
	{
		[TestMethod()]
		public async void GetAccountInfoTestAsync()
		{

			var dd = await AccountProfitBLL.Instance.GetBdInfo(2384, 1, "1", "3", DateTime.Now, "0");

		}

		[TestMethod()]
		public void GetAccountInfoTest()
		{

		}
	}
}
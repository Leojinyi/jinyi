using System;
using System.Collections.Generic;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniAppBll.PutForward;
using MiniAppModel.Entity;
using MiniAppModel.RewardDetail;

namespace MiniAppApis.Tests
{
    [TestClass]
    public class PutForward
    {
        public NoAwardBLL noAwardBLL { get { return new NoAwardBLL(); } }
        [TestMethod]
        public void GetInfo()
        {
            int userid = 164;
            AccountEntity acc = noAwardBLL.GetAccountInfo(userid);
            //List<ProfitInfoEntity> list = noAwardBLL.GetProfitListNoWard(userid);
        }
    }
}

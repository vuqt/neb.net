using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NebulasAPI.Models;

namespace NebulasAPI.Tests
{
    [TestClass]
    public class NebTest
    {
        [TestMethod]
        public void TestGetNebState()
        {
            Neb neb = new Neb();

            NebState result = neb.GetNebState();

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestGetAccountState()
        {
            Neb neb = new Neb();

            string strAddress = "n1Z6SbjLuAEXfhX1UJvXT6BB5osWYxVg3F3";
            AccountState result = neb.GetAccountState(strAddress);

            Assert.IsTrue(result.message == string.Empty);
        }
    }
}

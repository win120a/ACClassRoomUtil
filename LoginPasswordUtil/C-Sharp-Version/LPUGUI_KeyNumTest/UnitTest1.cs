using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPUGUIProvider;

namespace LPUGUI_KeyNumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGenerateDateOfWeekNumberInTools()
        {
            int num = Tools.GenerateDateOfWeekNumber();
            Assert.AreEqual(1, num); // Please change to correct time.
        }
    }
}

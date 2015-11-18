using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace TestUnitairesCore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatrix()
        {
            DemoMap dm = new DemoMap();
            Map m = new Map(dm);
        }
    }
}

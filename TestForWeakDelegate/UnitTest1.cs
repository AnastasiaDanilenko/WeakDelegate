using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeakDelegate;

namespace TestForWeakDelegate
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestObjectForWork()
        {
            string right = "Object created at " + DateTime.Now.ToString();
            string have = new ForUse().Info;
            StringAssert.Equals(right, have);

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeakDelegate;

namespace TestForWeakDelegate
{
    [TestClass]
    public class UnitTest1
    {
        private static ForUse FU = new ForUse();
        public delegate void someDelegate(params object[] some);
        public event someDelegate Completed;
        public Wrapper wr = null;

        [TestMethod]
        public void TestObjectForWork()
        {
            string right = "Object created at " + DateTime.Now.ToString();
            string have = new ForUse().Info;
            StringAssert.Equals(right, have);
        }

        [TestMethod]
        public void TestToCreateWeakDelegate()
        {
            wr = new Wrapper((Action<int>)FU.Handler);
            WeakReference wref += new Wrapper(FU.Handler).weakref;
        }
    }
}

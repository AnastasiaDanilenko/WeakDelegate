using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeakDelegate;

namespace TestForWeakDelegate
{
    [TestClass]
    public class UnitTest1
    {
        private static ForUse FU = new ForUse();
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
            Source source = new Source();
            source.OneArgument += (Action<int>)wr.someinf;
            bool correct = true;
            bool result = wr.weakref.IsAlive;
            Assert.AreEqual(correct, result);
        }

        [TestMethod]
        public void TestToCreateWeakDelegateWithMoreParameters()
        {
            wr = new Wrapper((Action<int, double>)FU.Handler);
            Source source = new Source();
            source.TwoArguments += (Action<int, double>)wr.someinf;
            bool correct = true;
            bool result = wr.weakref.IsAlive;
            Assert.AreEqual(correct, result);
        }
    }
}

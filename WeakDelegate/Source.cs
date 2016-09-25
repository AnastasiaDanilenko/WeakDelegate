using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakDelegate
{
    public class Source
    {

        public event Action<int> OneArgument;
        public event Action<int, double> TwoArguments;
        public event Action<int, double, int> ThreeArguments;
        public event Action<int, int, int, int> FourArguments;

        public int WhenCalled()
        {
            int Info =  DateTime.Now.Second;
            return Info;
        }

        public void Events()
        {
            if (OneArgument != null)
                OneArgument.Invoke(WhenCalled());
            if (TwoArguments != null)
                TwoArguments.Invoke(WhenCalled(), WhenCalled());
            if (ThreeArguments != null)
                ThreeArguments.Invoke(WhenCalled(), WhenCalled(), WhenCalled());
            if (FourArguments != null)
                FourArguments.Invoke(WhenCalled(), WhenCalled(), WhenCalled(), WhenCalled());
        }
    }
}

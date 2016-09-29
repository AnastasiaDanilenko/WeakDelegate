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

        public int WhenCalled()
        {
            int Info =  DateTime.Now.Second;
            return Info;
        }

        public void TryToSeeEvent()
        {
            if (OneArgument != null)
                OneArgument.Invoke(WhenCalled());
        }
    }
}

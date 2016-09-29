using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakDelegate
{
    public class ForUse
    {
        public string Info;


        public ForUse()
        {
            Info = "Object created at " + DateTime.Now.ToString();
        }

        public void Handler(int param1)
        {
            Console.WriteLine(Info);
            Console.WriteLine("Parameters:" + param1.ToString());
        }

        public void Handler(int param1, double param2)
        {
            Console.WriteLine(Info);
            Console.WriteLine("Parameters:" + param1.ToString() + param2.ToString());
        }

        public void Handler(int param1, double param2, int param3)
        {
            Console.WriteLine(Info);
            Console.WriteLine("Parameters:" + param1.ToString() + param2.ToString() + param3.ToString());
        }

    }
}

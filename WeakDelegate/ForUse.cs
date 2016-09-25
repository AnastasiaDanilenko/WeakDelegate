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

        public void Handler(params object[] someInt)
        {
            for (int i = 0; i < someInt.Count(); i++)
                Console.WriteLine(someInt[i]);
        }
    }
}

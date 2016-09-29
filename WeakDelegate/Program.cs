using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakDelegate
{
    public class Program
    {


        static void Main(string[] args)
        {
            Source source = new Source();
            ForUse foruse = new ForUse();
            Wrapper wd = new Wrapper((Action<int>)foruse.Handler);
            source.OneArgument += (Action<int>)wd.someinf;
            source.TryToSeeEvent();
            Console.Read();
        }
    }
}

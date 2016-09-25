﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace WeakDelegate
{
    public class Wrapper
    {
        public WeakReference weakref = null;
        public MethodInfo mi;

        public Wrapper(Delegate somedelegate)
        {
            weakref = new WeakReference(somedelegate.Target);
            mi = somedelegate.Method;
        }
    }
}

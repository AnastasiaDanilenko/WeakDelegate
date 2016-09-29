using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace WeakDelegate
{
    public class Wrapper
    {
        public WeakReference weakref = null;
        public MethodInfo mi;
        public Delegate someinf
        {
            get;
            private set;
        }

        public Wrapper(Delegate somedelegate)
        {
            weakref = new WeakReference(somedelegate.Target);
            mi = somedelegate.Method;
        }

        public void ReturnDelegate()
        {
            if (weakref.IsAlive)
                someinf = mi.CreateDelegate(mi.GetType());
        }

        public Delegate GetDelegate()
        {
            ParameterExpression[] paramArr = GetParametersExpression(mi);
            Expression targetObjectExpression = GetPropertyExpression(Expression.Constant(weakref), "Target", weakref.Target.GetType());
            Expression targetMethodInvoke = Expression.Call(targetObjectExpression, mi, paramArr);
            Expression conditionExpression = Expression.NotEqual(targetObjectExpression, Expression.Constant(null));
            Expression ifExpression = Expression.IfThen(conditionExpression, targetMethodInvoke);
            LambdaExpression labmda = Expression.Lambda(ifExpression, paramArr);
            return labmda.Compile();
        }

        private ParameterExpression[] GetParametersExpression(MethodInfo method)
        {
            ParameterInfo[] eventHandlerArgsInfo = method.GetParameters();
            ParameterExpression[] eventHandlerArgsExpressionMassive = new ParameterExpression[eventHandlerArgsInfo.Length];
            for (int i = 0; i < eventHandlerArgsInfo.Length; i++)
            {
                eventHandlerArgsExpressionMassive[i] = ParameterExpression.Parameter(eventHandlerArgsInfo[i].ParameterType);
            }
            return eventHandlerArgsExpressionMassive;
        }

        private Expression GetPropertyExpression(Expression declaryingObjectExpression, String propertyName, Type typeToCastProperty = null)
        {
            Type declaryingClassType = declaryingObjectExpression.Type;
            PropertyInfo targetPropertyInfo = declaryingClassType.GetProperty(propertyName);
            Expression targetObjectExpression = Expression.Property(declaryingObjectExpression, targetPropertyInfo);
            if (typeToCastProperty != null)
            {
                targetObjectExpression = Expression.Convert(targetObjectExpression, typeToCastProperty);
            }
            return targetObjectExpression;
        }
    }
}

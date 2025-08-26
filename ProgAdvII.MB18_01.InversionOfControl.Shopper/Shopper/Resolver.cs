using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper
{
    public class Resolver
    {
        private readonly Dictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();
        public Resolver() { }
        public T Resolve<T>()
        {
            var type = typeof(T);
            return (T)Resolve(type);
        }

        public void Register<TFrom, TTo>()
        {
            dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }

        private object Resolve(Type type)
        {
            if(dependencyMap.ContainsKey(type))
            {
                type = dependencyMap[type];
            }

            var firstCtor = type.GetConstructors()[0];
            var ctorParams = firstCtor.GetParameters();

            if (ctorParams.Length == 0)
            {
                return Activator.CreateInstance(type);
            }

            var parameters = new List<object>();
            foreach (var param in ctorParams)
            {
                var paramType = param.ParameterType;
                parameters.Add(Resolve(paramType));
            }

            return firstCtor.Invoke(parameters.ToArray());
        }
    }
}

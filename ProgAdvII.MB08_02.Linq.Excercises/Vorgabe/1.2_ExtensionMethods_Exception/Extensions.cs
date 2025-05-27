using System;
using System.Collections.Generic;

namespace _1._2_ExtensionMethods_Exceptions {
    public static class Extensions
    {
        public static Exception GetInnerstException(this Exception exception)
        {
            return exception.InnerException?.GetInnerstException() ?? exception.InnerException;
        }
        public static void ForEachException(this Exception exception, Action<Exception> action)
        {
            action(exception);
            exception.InnerException?.ForEachException(action);
        }
    }
}

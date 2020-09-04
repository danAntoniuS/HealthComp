using System;

namespace HealthComp.Common
{
    public static class Validator
    {
        public static T ThrowIfNull<T>(T obj, string name) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name);
            }

            return obj;
        }
    }
}

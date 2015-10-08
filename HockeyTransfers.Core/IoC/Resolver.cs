using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTransfers.Core.IoC
{
    public class Resolver
    {
        private static IResolver _resolver;

        public static void SetResolver(IResolver resolver)
        {
            _resolver = resolver;
        }

        public static T Resolve<T>()
        {
            if(_resolver == null)
            {
                throw new Exception("You have to call the SetResolver method before calling Resolve.");
            }

            return _resolver.Resolve<T>();
        }
    }
}

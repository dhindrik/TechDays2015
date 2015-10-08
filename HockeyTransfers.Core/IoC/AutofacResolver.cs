using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTransfers.Core.IoC
{
    public class AutofacResolver : IResolver
    {
        private IContainer _container;

        public AutofacResolver(IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

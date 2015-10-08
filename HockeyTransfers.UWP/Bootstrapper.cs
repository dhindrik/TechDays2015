using Autofac;
using HockeyTransfers.Core.IoC;
using HockeyTransfers.Core.ServiceAgents;
using HockeyTransfers.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTransfers.UWP
{
    public class Bootstrapper
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TransfersServiceAgent>().As<ITransfersServiceAgent>();

            builder.RegisterType<MainViewModel>();

            var container = builder.Build();

            Resolver.SetResolver(new AutofacResolver(container));
        }
    }
}

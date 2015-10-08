using Autofac;
using HockeyTransfers.Core.IoC;
using HockeyTransfers.Core.Networking;
using HockeyTransfers.Core.ServiceAgents;
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
            builder.RegisterType<RestClient>().As<IRestClient>();
            builder.RegisterType<TransfersServiceAgent>().As<ITransfersServiceAgent>();

            var container = builder.Build();

            Resolver.SetResolver(new AutofacResolver(container));
        }
    }
}

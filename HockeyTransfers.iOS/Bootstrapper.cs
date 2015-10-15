using Autofac;
using HockeyTransfers.Core.IoC;
using HockeyTransfers.Core.ServiceAgents;
using HockeyTransfers.Core.ViewModels;

namespace HockeyTransfers.iOS
{
    internal static class Bootstrapper
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

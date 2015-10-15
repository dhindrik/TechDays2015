using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using HockeyTransfers.Core.ServiceAgents;
using HockeyTransfers.Core.ViewModels;
using HockeyTransfers.Core.IoC;

namespace HockeyTransfers.Droid
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
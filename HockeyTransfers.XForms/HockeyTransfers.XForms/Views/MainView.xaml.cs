using HockeyTransfers.Core.IoC;
using HockeyTransfers.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HockeyTransfers.XForms.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();

            var viewModel = Resolver.Resolve<MainViewModel>();

            BindingContext = viewModel;

            viewModel.Initialize();
        }
    }
}

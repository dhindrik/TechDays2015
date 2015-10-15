using HockeyTransfers.Core.IoC;
using HockeyTransfers.XForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HockeyTransfers.XForms
{
    public class App : Application
    {
        public App()
        {
            Bootstrapper.Initialize();

            // The root page of your application
            MainPage = new NavigationPage(new MainView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

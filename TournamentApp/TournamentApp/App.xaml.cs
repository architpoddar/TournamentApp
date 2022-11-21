using DryIoc;
using System;
using TournamentApp.Utilities;
using TournamentApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TournamentApp
{
    public partial class App : Application
    {
        public static IContainer Container { get; set; }

        public App()
        {
            InitializeComponent();

            Container = new Container();

            DependencyRegistrar.Register();
            DependencyRegistrar.RegisterShellRoutes();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }
         
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

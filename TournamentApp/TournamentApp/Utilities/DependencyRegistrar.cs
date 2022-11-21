using DryIoc;
using System;
using System.Collections.Generic;
using System.Text;
using TournamentApp.Models;
using TournamentApp.Navigations;
using TournamentApp.Views;
using Xamarin.Forms;

namespace TournamentApp.Utilities
{
    public class DependencyRegistrar
    {
        public static void Register()
        {
            var container = App.Container;

            //Services
            //container.Register<INavigationService, NavigationService>(Reuse.Singleton);

            //View models
            //container.Register<MainPageViewModel>(Reuse.Singleton);
            //container.Register<BuildingDetailViewModel>();
        }

        public static void RegisterShellRoutes()
        {
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }
    }
}

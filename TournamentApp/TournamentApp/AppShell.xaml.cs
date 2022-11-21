using System;
using System.Collections.Generic;
using TournamentApp.ViewModels;
using TournamentApp.Views;
using Xamarin.Forms;

namespace TournamentApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

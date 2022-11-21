using System;
using System.ComponentModel;
using TournamentApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TournamentApp.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as DashboardViewModel;

            await vm.LoadPlayers();
        }
    }
}
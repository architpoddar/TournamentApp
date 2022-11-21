using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TournamentApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        bool isFirstLoad = true;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (isFirstLoad)
            {
                if (Preferences.ContainsKey("IsUserLoggedIn"))
                {
                    var isLoggedIn = Preferences.Get("IsUserLoggedIn", false);

                    if (isLoggedIn)
                    {
                        await Shell.Current.GoToAsync($"//Home");
                    }
                }

                isFirstLoad = false;
            }
        }
    }
}
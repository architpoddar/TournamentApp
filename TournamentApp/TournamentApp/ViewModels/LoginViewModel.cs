using DryIoc;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using TournamentApp.Navigations;
using TournamentApp.Services;
using TournamentApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace TournamentApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public IAuthService AuthService { get; private set; }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked); 
            AuthService = IoCContainer.Resolve<IAuthService>();

            Email = "archit.poddar@gmail.com";
            Password = "archit";
        }

        private string email;

        public string Email
        {
            get { return email; }
            set 
            { 
                SetProperty(ref email, value);
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                SetProperty(ref password, value);
            }
        }

        private async void OnLoginClicked(object obj)
        {
            // Validate the user
            var email = Email;
            var password = Password;

            var token = await AuthService.LoginWithEmailPassword(email, password);

            if (string.IsNullOrEmpty(token))
                return;

            Preferences.Set("IsUserLoggedIn", true);

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
             await Shell.Current.GoToAsync($"//Home");
        }
    }
}

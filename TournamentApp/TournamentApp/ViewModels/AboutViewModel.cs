using DryIoc;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TournamentApp.Models;
using TournamentApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TournamentApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public IAuthService AuthService { get; private set; }

        public DashboardViewModel()
        {
            AuthService = IoCContainer.Resolve<IAuthService>();

            Title = "Dashboard";
            
            OpenWebCommand = new Command(async () =>
            {
                var isLoggedOut = AuthService.SignOut();
                Preferences.Set("IsUserLoggedIn", false);
                await Shell.Current.GoToAsync("//LoginPage");
            });
        }

        public ICommand OpenWebCommand { get; }

        public async Task LoadPlayers()
        {
            try
            {
                FirebaseClient firebaseClient = new FirebaseClient("https://ypl8app-default-rtdb.asia-southeast1.firebasedatabase.app/");

                var players = new List<Player>();

                var getPlayers = (await firebaseClient
                               .Child("Players")
                               .OnceAsync<Player>()).Select(item => new Player
                               {
                                   Email = item.Object.Email,
                                   FullName = item.Object.FullName,
                                   Building = item.Object.Building,
                                   FlatNo = item.Object.FlatNo,
                                   MobileNo = item.Object.MobileNo,
                                   Age = item.Object.Age,
                                   Gender = item.Object.Gender,
                                   ShirtName = item.Object.ShirtName,
                                   ShirtSize = item.Object.ShirtSize,
                                   ShirtNumber = item.Object.ShirtNumber,
                                   PictureUrl = item.Object.PictureUrl,
                                   Expertise = item.Object.Expertise,
                                   Sports = item.Object.Sports,
                                   ExpectedPayment = item.Object.ExpectedPayment,
                                   AmountPaid = item.Object.AmountPaid,
                                   PaidTo = item.Object.PaidTo,
                                   IsMensCricket = item.Object.IsMensCricket,
                                   IsBoxCricket = item.Object.IsBoxCricket,
                                   IsLadiesCricket = item.Object.IsLadiesCricket,
                                   IsTeensCricket = item.Object.IsTeensCricket,
                                   IsU12BoysCricket = item.Object.IsU12BoysCricket,
                                   IsU13GirlsCricket = item.Object.IsU13GirlsCricket,
                                   IsFootball = item.Object.IsFootball,
                                   IsBadminton = item.Object.IsBadminton,
                                   IsVolleyball = item.Object.IsVolleyball
                               });

                foreach (var player in getPlayers)
                {
                    players.Add(player);
                }

                var mens = players.Count(x => x.IsMensCricket);
                var football = players.Count(x => x.IsFootball);

                var totalExpected = players.Sum(x => x.ExpectedPayment);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
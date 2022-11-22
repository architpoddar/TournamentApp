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

        private int totalCount;

        public int TotalCount
        {
            get { return totalCount; }
            set { SetProperty(ref totalCount, value); }
        }

        private int totalMalesCount;

        public int TotalMalesCount
        {
            get { return totalMalesCount; }
            set { SetProperty(ref totalMalesCount, value); }
        }

        private int totalFemalesCount;

        public int TotalFemalesCount
        {
            get { return totalFemalesCount; }
            set { SetProperty(ref totalFemalesCount, value); }
        }

        private int menCricketCount;

        public int MenCricketCount
        {
            get { return menCricketCount; }
            set { SetProperty(ref menCricketCount, value); }
        }

        private int boxCricketCount;

        public int BoxCricketCount
        {
            get { return boxCricketCount; }
            set { SetProperty(ref boxCricketCount, value); }
        }

        private int ladiesCricketCount;

        public int LadiesCricketCount
        {
            get { return ladiesCricketCount; }
            set { SetProperty(ref ladiesCricketCount, value); }
        }

        private int teensCricketCount;

        public int TeensCricketCount
        {
            get { return teensCricketCount; }
            set { SetProperty(ref teensCricketCount, value); }
        }

        private int u12boysCricketCount;

        public int U12boysCricketCount
        {
            get { return u12boysCricketCount; }
            set { SetProperty(ref u12boysCricketCount, value); }
        }

        private int u13girlsCricketCount;

        public int U13girlsCricketCount
        {
            get { return u13girlsCricketCount; }
            set { SetProperty(ref u13girlsCricketCount, value); }
        }

        private int footballCount;

        public int FootballCount
        {
            get { return footballCount; }
            set { SetProperty(ref footballCount, value); }
        }

        private int volleyballCount;

        public int VolleyballCount
        {
            get { return volleyballCount; }
            set { SetProperty(ref volleyballCount, value); }
        }

        private int badmintonCount;

        public int BadmintonCount
        {
            get { return badmintonCount; }
            set { SetProperty(ref badmintonCount, value); }
        }

        private int building1Count;

        public int Building1Count
        {
            get { return building1Count; }
            set { SetProperty(ref building1Count, value); }
        }

        private int building3Count;

        public int Building3Count
        {
            get { return building3Count; }
            set { SetProperty(ref building3Count, value); }
        }

        private int building4Count;

        public int Building4Count
        {
            get { return building4Count; }
            set { SetProperty(ref building4Count, value); }
        }

        private int building6Count;

        public int Building6Count
        {
            get { return building6Count; }
            set { SetProperty(ref building6Count, value); }
        }

        private int buildingXXCount;
        public int BuildingXXCount
        {
            get { return buildingXXCount; }
            set { SetProperty(ref buildingXXCount, value); }
        }

        private int buildingOthersCount;
        public int BuildingOthersCount
        {
            get { return buildingOthersCount; }
            set { SetProperty(ref buildingOthersCount, value); }
        }

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

                TotalCount = players.Count();

                TotalMalesCount = players.Count(x => x.Gender == "Male");
                TotalFemalesCount = players.Count(x => x.Gender == "Female");

                MenCricketCount = players.Count(x => x.IsMensCricket);
                BoxCricketCount = players.Count(x => x.IsBoxCricket);
                LadiesCricketCount = players.Count(x => x.IsLadiesCricket);
                U12boysCricketCount = players.Count(x => x.IsU12BoysCricket);
                U13girlsCricketCount = players.Count(x => x.IsU13GirlsCricket);
                TeensCricketCount = players.Count(x => x.IsTeensCricket);
                FootballCount = players.Count(x => x.IsFootball);
                VolleyballCount = players.Count(x => x.IsVolleyball);
                BadmintonCount = players.Count(x => x.IsBadminton);

                Building1Count = players.Count(x => x.Building == "Building 1");
                Building3Count = players.Count(x => x.Building == "Building 3");
                Building4Count = players.Count(x => x.Building == "Building 4");
                Building6Count = players.Count(x => x.Building == "Building 6");
                BuildingXXCount = players.Count(x => x.Building == "Xxclusive");
                BuildingOthersCount = players.Count() - (Building1Count + Building3Count + Building4Count + Building6Count + BuildingXXCount);

                var totalExpected = players.Sum(x => x.ExpectedPayment);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
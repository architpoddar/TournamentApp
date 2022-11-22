using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Models;
using TournamentApp.Views;
using Xamarin.Forms;

namespace TournamentApp.ViewModels
{
    public class PlayersListViewModel : ViewModelBase
    {
        public PlayersListViewModel()
        {
            Title = "Players";
        }
    }
}

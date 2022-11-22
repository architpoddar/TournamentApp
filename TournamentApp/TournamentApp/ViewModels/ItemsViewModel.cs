using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TournamentApp.Models;
using TournamentApp.Views;
using Xamarin.Forms;

namespace TournamentApp.ViewModels
{
    public class ItemsViewModel : ViewModelBase
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
        } 
    }
}
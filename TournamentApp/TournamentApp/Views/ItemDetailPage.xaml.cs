using System.ComponentModel;
using TournamentApp.ViewModels;
using Xamarin.Forms;

namespace TournamentApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
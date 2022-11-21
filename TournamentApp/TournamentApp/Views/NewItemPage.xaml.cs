using System;
using System.Collections.Generic;
using System.ComponentModel;
using TournamentApp.Models;
using TournamentApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TournamentApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
using DryIoc;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TournamentApp.Navigations;
using Xamarin.Forms;

namespace TournamentApp.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        //public INavigationService NavigationService { get; private set; }

        public Command GoBackCommand { get; set; }

        public DryIoc.IContainer IoCContainer { get; set; }

        //public ILogger Logger { get; set; }

        public ViewModelBase()
        {
            IoCContainer = App.Container;
            //NavigationService = IoCContainer.Resolve<INavigationService>();
            //Logger = IoCContainer.Resolve<ILogger>();
            GoBackCommand = new Command(PopPage);
        }

        private async void PopPage(object obj)
        {
            await Shell.Current.GoToAsync("..");
        }

        public virtual void ConfigureData(object data)
        {

        }
    }
}

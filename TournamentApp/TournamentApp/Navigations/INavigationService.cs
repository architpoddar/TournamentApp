using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.ViewModels;
using Xamarin.Forms;

namespace TournamentApp.Navigations
{
    public interface INavigationService
    {
        Task NavigateTo<T>(object parameter, bool enableAnimation = true) where T : ViewModelBase;

        Task GoBack(bool enableAnimation = true);

        AppShell InitAppShellAndSetMainPage(ContentPage page, ViewModelBase viewModel, object parameter);
    }
}

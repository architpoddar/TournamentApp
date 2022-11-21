//using DryIoc;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using TournamentApp.ViewModels;
//using Xamarin.Forms;

//namespace TournamentApp.Navigations
//{
//    public class NavigationService : INavigationService
//    {
//        private IContainer _container;

//       // public ILogger Logger { get; set; }

//        private const string context = "NavigationService";

//        public async Task NavigateTo<T>(object parameter, bool enableAnimation = true) where T : ViewModelBase
//        {
//            var viewModel = App.Container.Resolve<T>();
//            viewModel.ConfigureData(parameter);
//            var pageName = typeof(T).Name.Replace("ViewModel", "");
//            await Shell.Current.GoToAsync($"{pageName}", enableAnimation);

//            var currentPage = (Shell.Current?.CurrentItem?.CurrentItem as IShellSectionController)?.PresentedPage;

//            currentPage.BindingContext = viewModel;

//            //Logger.TrackPage(context, "Navigated to " + pageName);
//        }

//        public async Task GoBack(bool enableAnimation = true)
//        {
//            await Shell.Current.GoToAsync("..", enableAnimation);
//        }

//        public AppShell InitAppShellAndSetMainPage(ContentPage page, ViewModelBase viewModel, object parameter)
//        {
//            var serializedParameter = JsonConvert.SerializeObject(parameter);
//            AppShell appShell = new AppShell();
//            page.BindingContext = viewModel;
//            appShell.CurrentItem = new ShellContent { Content = page };
//            return appShell;
//        }
//    }
//}

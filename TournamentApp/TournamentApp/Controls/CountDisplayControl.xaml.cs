using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TournamentApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountDisplayControl : ContentView
    {
        public CountDisplayControl()
        {
            InitializeComponent();
        }

        #region Bindable Properties

        // Count, Category

        public static BindableProperty CountProperty = BindableProperty.Create
            (
                nameof(Count),
                typeof(int),
                typeof(CountDisplayControl),
                defaultValue: 0,
                defaultBindingMode: BindingMode.OneWay
            );
        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); OnPropertyChanged(); }
        }

        public static BindableProperty CategoryProperty = BindableProperty.Create
            (
                nameof(Category),
                typeof(string),
                typeof(CountDisplayControl),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.OneWay
            );
        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); OnPropertyChanged(); }
        }

        #endregion
    }
}
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using IsItJustMeOrServerCooties.Services;

namespace IsItJustMeOrServerCooties
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void UpdateStatus(Object sender, RoutedEventArgs e)
        {
            Root.DataContext = await StatusMonitor.GetCurrentStatus();
        }
    }
}
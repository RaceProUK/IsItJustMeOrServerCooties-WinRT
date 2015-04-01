using System;
using Windows.UI.Xaml;
using IsItJustMeOrServerCooties.Services;

namespace IsItJustMeOrServerCooties
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void UpdateStatus(Object sender, RoutedEventArgs e)
        {
            Root.DataContext = await StatusMonitor.GetCurrentStatus();
        }
    }
}
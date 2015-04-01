using System;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#if WINDOWS_PHONE_APP
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
#endif

namespace IsItJustMeOrServerCooties
{
    public sealed partial class App
    {
#if WINDOWS_PHONE_APP
        private TransitionCollection transitions;
#endif

        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (Debugger.IsAttached) DebugSettings.EnableFrameRateCounter = true;
#endif

            var rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame {CacheSize = 1};
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
#if WINDOWS_PHONE_APP
                if (rootFrame.ContentTransitions != null)
                {
                    transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                        transitions.Add(c);
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += RootFrame_FirstNavigated;
#endif
                if (!rootFrame.Navigate(typeof (MainPage), e.Arguments))
                    throw new Exception("Failed to create initial page");
            }

            Window.Current.Activate();
        }

#if WINDOWS_PHONE_APP
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            if (rootFrame == null) return;
            rootFrame.ContentTransitions = transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= RootFrame_FirstNavigated;
        }
#endif

        private static void OnSuspending(object sender, SuspendingEventArgs e)
        {
            e.SuspendingOperation.GetDeferral().Complete();
        }
    }
}
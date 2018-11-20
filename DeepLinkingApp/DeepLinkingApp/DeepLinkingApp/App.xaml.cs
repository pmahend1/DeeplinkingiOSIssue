using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeepLinkingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            string appDomain = "http://deeplinkingapp";
            if (!uri.ToString().ToLowerInvariant().StartsWith(appDomain, StringComparison.Ordinal))
            {
                return;
            }

            string pageUrl = uri.ToString().Replace(appDomain, string.Empty).Trim();
            var parts = pageUrl.Split('=');
            string sentText = parts[1];

            MainPage = new NavigationPage(new ResultPage(sentText));
          

            base.OnAppLinkRequestReceived(uri);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using Xamarin.Forms;

namespace DeepLinkingApp
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel { get; set; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            ViewModel.AppLinks = SetAppLinks();
           
            BindingContext = ViewModel;

        }
        public MainPage(string text)
        {
            InitializeComponent();
            BindingContext = ViewModel;
           // ViewModel.AppLinks = SetAppLinks();
            ShowText(text);
        }

        public ObservableCollection<AppLinkEntry> SetAppLinks()
        {
            return new ObservableCollection<AppLinkEntry>()
            {
                CreateAppLink(1,"applink1"),
                CreateAppLink(2,"applink2"),
                CreateAppLink(3,"applink3"),
                CreateAppLink(4,"applink4"),
                CreateAppLink(5,"applink5")
            };
        }

        public static AppLinkEntry CreateAppLink(int id, string text)
        {


            var pageLink = new AppLinkEntry
            {
                Title = string.Format("Applink {0}", id),
                Description = string.Format("Applink {0} Description", id),
                AppLinkUri = new Uri(string.Format("http://{0}/key={1}", "deeplinkingapp", WebUtility.UrlEncode(text)), UriKind.RelativeOrAbsolute),
                IsLinkActive = true,
            };


            pageLink.KeyValues.Add("appName", "DeepLinkingApp");

           

            return pageLink;
        }

        private async void ShowText(string text)
        {
            await DisplayAlert("App", text, "Ok");
        }

        public void RegisterLinks(AppLinkEntry link)
        {

               
       
        
        }

        private async void ListViewAppLinks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var link = e.Item as AppLinkEntry;
            try
            {
                Application.Current.AppLinks.RegisterLink(link);
                await DisplayAlert("Applink", link.Title + " registered", "Ok");
            }
            catch (Exception e1)
            {

                Debug.WriteLine(e1.Message);
            }
            listViewAppLinks.SelectedItem = null;
            
        }
    }
}

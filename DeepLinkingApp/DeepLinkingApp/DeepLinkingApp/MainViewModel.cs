using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace DeepLinkingApp
{
    public class MainViewModel
    {
        private ObservableCollection<AppLinkEntry> _appLinks = new ObservableCollection<AppLinkEntry>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<AppLinkEntry> AppLinks
        {
            get
            {
                return _appLinks;
            }

            set
            {
                if (!value.Equals(_appLinks))
                {
                    _appLinks = value;
                    OnPropertyChanged(nameof(AppLinks));
                }
                
            }
        }

    }
}

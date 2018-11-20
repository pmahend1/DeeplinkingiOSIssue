using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeepLinkingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{
		public ResultPage ()
		{
			InitializeComponent ();
		}
        public ResultPage(string result)
        {
            InitializeComponent();
            label.Text = "Text sent via app link :" + result;
        }
    }
}
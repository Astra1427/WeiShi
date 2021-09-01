using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeiShi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Support_Tapped(object sender, EventArgs e)
        {
            BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new SupportPage(),null));
        }

        private void LicenseAgreement_Tapped(object sender, EventArgs e)
        {
            BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new LicenseAgreement(), null));

        }
    }
}
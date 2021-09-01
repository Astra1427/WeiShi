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
    public partial class BackTitleViewPage : ContentPage
    {
        public ContentPage cPage { get; set; }
        public static bool IsShown = false;
        public string img { get; set; }
        public static BackTitleViewPage This { get; set; }
        public BackTitleViewPage(ContentPage cp,string img)
        {
            InitializeComponent();
            cPage = cp;
            this.img = img;
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            This = this;
            IsShown = true;
        }

        protected override bool OnBackButtonPressed()
        {
            IsShown = false;
            return base.OnBackButtonPressed();

        }
        private void back_Clicked(object sender, EventArgs e)
        {
            IsShown = false;
            this.Navigation.PopModalAsync();
        }
    }
}
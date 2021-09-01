using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeiShi
{
    public partial class MainPage : MyTabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.White;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.CurrentPageChanged += TabbedPage_CurrentPageChanged;
        }

        private void NavigationPage_Focused(object sender, FocusEventArgs e)
        {
            
        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            
        }
    }
}

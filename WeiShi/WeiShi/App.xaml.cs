using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeiShi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.White };
            //MainPage = new MainPage();
            MainPage = new ShellAPP() ;

            //var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
            //statusbar.SetStatusBarColor(Color.White);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }


    public interface IStatusBarPlatformSpecific
    {
        void SetStatusBarColor(Color color);
    }
}

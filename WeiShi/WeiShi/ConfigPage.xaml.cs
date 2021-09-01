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
    public partial class ConfigPage : ContentPage
    {
        public ConfigPage()
        {
            InitializeComponent();
            lUserName.Text = FileHelper.ReadFile(FileHelper.UserNameFile);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //raed user name
            lUserName.Text = FileHelper.ReadFile(FileHelper.UserNameFile);
        }

        private void AppRecommend_Tapped(object sender, EventArgs e)
        {
            if (BackTitleViewPage.This != null && BackTitleViewPage.IsShown)
            {
                BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new AppRecommendPage() { Title = "应用推荐" }, null));

                return;
            }
            this.Navigation.PushModalAsync(new BackTitleViewPage(new AppRecommendPage() { Title = "应用推荐" }, null));
        }

        private void AppStore_Tapped(object sender, EventArgs e)
        {
            var page = new AppStorePage() { Title = "应用商店" };
            var titleView = new Grid();
            var backButton = new ImageButton() { Source = "black_back_22.png", HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, Aspect = Aspect.AspectFit, BackgroundColor = Color.Transparent };
            backButton.Clicked += (backs, backe) => {
                page.Navigation.PopModalAsync(); 
            };
            var pageTitle = new Label() { Text = page.Title, TextColor = Color.Black, FontSize = 25, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            var iconButton = new ImageButton() { Source = "down_load.png", BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.End, Margin = new Thickness(0, 0, 10, 0) };
            titleView.Children.Add(backButton);
            titleView.Children.Add(pageTitle);
            //titleView.Children.Add(iconButton);

            NavigationPage.SetTitleView(page, titleView);
            var npage = new NavigationPage(page) { BarBackgroundColor = Color.White };

            //new BackTitleViewPage(new AppStorePage(), "down_load.png");
            if (BackTitleViewPage.This != null && BackTitleViewPage.IsShown)
            {
                BackTitleViewPage.This.Navigation.PushModalAsync(npage);
                return;
            }
            this.Navigation.PushModalAsync(npage);
        }

        private void Message_Tapped(object sender, EventArgs e)
        {
            if (BackTitleViewPage.This != null && BackTitleViewPage.IsShown)
            {
                BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new MessagePage() { Title = "消息" }, null));
                return;

            }
            this.Navigation.PushModalAsync(new BackTitleViewPage(new MessagePage() { Title = "消息" }, null));

        }

        private void PolicyMessage_Tapped(object sender, EventArgs e)
        {
            if (BackTitleViewPage.This != null && BackTitleViewPage.IsShown)
            {
                BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new PolicyMessagePage(), null));
                return;
            }
            this.Navigation.PushModalAsync(new BackTitleViewPage(new PolicyMessagePage() , null));

        }

        private void AccountSecurity_Tapped(object sender, EventArgs e)
        {
            if (BackTitleViewPage.This != null && BackTitleViewPage.IsShown)
            {
                BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new AccountSecurityPage(), null));
                return;
            }
            this.Navigation.PushModalAsync(new BackTitleViewPage(new AccountSecurityPage(), null));

        }

        private void VPN_Tapped(object sender, EventArgs e)
        {
            if (BackTitleViewPage.This != null && BackTitleViewPage.IsShown)
            {
                BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new VPNPage(), null));
                return;
            }
            this.Navigation.PushModalAsync(new BackTitleViewPage(new VPNPage(), null));
        }

        private void Help_Tapped(object sender, EventArgs e)
        {
            if (BackTitleViewPage.This != null && BackTitleViewPage.IsShown)
            {
                BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new ContentPage() { Title="帮助"}, null));
                return;
            }
            this.Navigation.PushModalAsync(new BackTitleViewPage(new ContentPage() { Title = "帮助" }, null));
        }

        private void About_Tapped(object sender, EventArgs e)
        {
            if (BackTitleViewPage.This != null && BackTitleViewPage.IsShown)
            {
                BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new AboutPage(), null));
                return;
            }
            this.Navigation.PushModalAsync(new BackTitleViewPage(new AboutPage() , null));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeiShi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkbenchPage : ContentPage
    {
        public WorkbenchPage()
        {
            InitializeComponent();

            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Read grid width
            try
            {
                string strw = FileHelper.ReadFile(FileHelper.GridWidth);
                if (strw == null || strw == "")
                {
                    return;
                }
                double w = double.Parse(strw);

                for (int i = 0; i < flPanel.Children.Count; i++)
                {
                    if (flPanel.Children[i] is Grid g)
                    {
                        g.WidthRequest = w;
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void Store_Clicked(object sender, EventArgs e)
        {
            /*
             <ImageButton Source="black_back_22.png" HorizontalOptions="Start" Aspect="AspectFit" VerticalOptions="Center" BackgroundColor="Transparent" Clicked="back_Clicked"/>
            <Label Text="应用详情" TextColor="Black" FontSize="Title" HorizontalOptions="Center" VerticalOptions="Center"/>
            <ImageButton Source="down_load.png" BackgroundColor="Transparent" HorizontalOptions="End" Margin="0,0,10,0"/>
             */
            var page = new AppStorePage() { Title = "应用商店" };
            var titleView = new Grid();
            var backButton = new ImageButton() { Source = "app_images_black_back_44.png", HorizontalOptions = LayoutOptions.Start,HeightRequest = 17.6,VerticalOptions = LayoutOptions.Center,Aspect = Aspect.AspectFit ,BackgroundColor = Color.Transparent };
            backButton.Clicked += (backs,backe) => {
                page.Navigation.PopModalAsync();
            };
            var pageTitle = new Label() {Text = page.Title,TextColor = Color.Black,FontSize = 25,HorizontalOptions = LayoutOptions.Center,VerticalOptions = LayoutOptions.Center };
            var iconButton = new ImageButton() { Source = "app_images_appstore_download_icon_58.png", HeightRequest = 21, Aspect = Aspect.AspectFit, BackgroundColor = Color.Transparent,HorizontalOptions = LayoutOptions.End,Margin = new Thickness(0,0,10,0) };
            iconButton.Clicked += (iconBtnSender,iconBtnEvent) => { this.Navigation.PushModalAsync(new BackTitleViewPage(new DownLoadCenterPage(),null)); };
            var line = new BoxView() { HeightRequest = 1,BackgroundColor = Color.LightGray,VerticalOptions = LayoutOptions.End ,HorizontalOptions = LayoutOptions.Fill,Margin= new Thickness(-20,5,-50,0)};
            titleView.Children.Add(backButton);
            titleView.Children.Add(pageTitle);
            //titleView.Children.Add(line);
            titleView.Children.Add(iconButton);

            NavigationPage.SetTitleView(page, titleView);
            var npage = new NavigationPage(page) { BarBackgroundColor = Color.White};

            //new BackTitleViewPage(new AppStorePage(), "down_load.png");
            this.Navigation.PushModalAsync(npage);
            
        }

        private void Message_Clicked(object sender, EventArgs e)
        {

            this.Navigation.PushModalAsync(new BackTitleViewPage(new MessagePage() { Title = "消息" },null));
        }

        private void Config_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new BackTitleViewPage(new ConfigPage() { Title = "设置" },null));

        }

        private void Sougou_Tapped(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new AppDetailPage(new AppModel()
            {
                ID = 2,
                img = "Sougou_lock.png",
                img_big = "Sougou_lock.png",
                Name = "搜狗输入法",
                AppDetail = "必安",
                Developer = "--",
                AppType = "公共应用",
                UpdateTime = "2019-07-28",
                Version = "8.35.2",
                AppSize = "48.9MB",
                MinAndroidVersion = "兼容Android 4.4及以上设备",
                UpdateLogs = new ObservableCollection<AppUpdateLogModel> {
                    new AppUpdateLogModel{
                        ID = 1,
                        AppID = 2,
                        Version = "10.2.1",
                        UpdateTime = "2020-01-04 20:33:25"
                    }
                }
            }));
        }

        private void Weishi_Tapped(object sender, EventArgs e)
        {

            this.Navigation.PushModalAsync(
                new AppDetailPage(
                    new AppModel()
                    {
                        ID = 1,
                        img = "WeiShi_logo_1.png",
                        img_big = "WeiShi_logo_1.png",
                        Name = "卫士",
                        AppDetail = "必安",
                        Developer = "--",
                        AppType = "企业应用",
                        UpdateTime = "2020-01-09",
                        Version = "1.5.0",
                        AppSize = "1.1MB",
                        MinAndroidVersion = "兼容Android 4.4及以上设备"
                    }
            ));

        }
    }
}
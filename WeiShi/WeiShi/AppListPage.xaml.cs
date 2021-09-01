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
    public partial class AppListPage : ContentPage
    {
        public ObservableCollection<AppModel> appModels { get; set; }
        public AppListPage()
        {
            InitializeComponent();
            //Init data and controls
            appModels = new ObservableCollection<AppModel>();
            appModels.Add(new AppModel() { ID = 1, img = "WeiShi_logo_1.png", img_big = "WeiShi_logo_1.png", Name = "卫士", AppDetail = "必安", Developer = "--", AppType = "企业应用", UpdateTime = "2020-01-09", Version = "1.5.0", AppSize = "1.1MB", MinAndroidVersion = "兼容Android 4.4及以上设备" });
            appModels.Add(new AppModel()
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
            });
            lvDatas.ItemsSource = appModels;
        }
        private async void App_Tapped(object sender, EventArgs e)
        {
            var grid = sender as Grid;
            var label = grid.Children[1] as Label;
            var name = label.FormattedText.Spans[0].Text;
            var model = appModels.Where(a => a.Name == name).FirstOrDefault();

            await BackTitleViewPage.This.Navigation.PushModalAsync(new AppDetailPage(model));
        }
    }
}
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
    public partial class AlloverPage : ContentPage
    {
        public AlloverPage()
        {
            InitializeComponent();
            //Init data and controls
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
            }) ;
            lvDatas.ItemsSource = appModels;
        }
        ObservableCollection<AppModel> appModels = new ObservableCollection<AppModel>();
        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }

        private async void App_Tapped(object sender, EventArgs e)
        {
            var grid = sender as Grid;
            var label = grid.Children[1] as Label;
            var name = label.FormattedText.Spans[0].Text;
            var model = appModels.Where(a=>a.Name == name).FirstOrDefault();
            
            await this.Navigation.PushModalAsync(new AppDetailPage(model));
        }
    }

    public class AppModel
    {
        public int ID { get; set; }
        public string img { get; set; }
        public string img_big { get; set; }
        public string Name { get; set; }
        public string AppDetail { get; set; }
        public string Developer { get; set; }
        public string AppType { get; set; }
        public string UpdateTime { get; set; }
        public string Version { get; set; }
        public string AppSize { get; set; }
        public string MinAndroidVersion { get; set; }
        public ObservableCollection<AppUpdateLogModel> UpdateLogs { get; set; }
    }

    public class AppUpdateLogModel
    {
        public int ID { get; set; }
        public int AppID  { get; set; }
        public string Version { get; set; }
        public string UpdateTime { get; set; }
    }
}
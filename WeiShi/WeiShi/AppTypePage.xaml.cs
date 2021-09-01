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
    public partial class AppTypePage : ContentPage
    {
        public ObservableCollection<string> AppTypes = new ObservableCollection<string>();

        public AppTypePage()
        {
            InitializeComponent();
            AppTypes.Add("必安");
            AppTypeList.ItemsSource = AppTypes;
        }

        private void AppType_tapped(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new BackTitleViewPage(new AppListPage() { Title = "必安"},null));
        }
    }
}
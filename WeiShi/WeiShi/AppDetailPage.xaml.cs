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
    public partial class AppDetailPage : ContentPage
    {
        public AppModel appModel { get; set; }
        public AppDetailPage(AppModel appmodel)
        {
            InitializeComponent();
            appModel = appmodel;
            BindingContext = this;
            
            if (appModel.UpdateLogs == null || appmodel.UpdateLogs.Count == 0)
            {
                lVersionLog.IsVisible = false;
            }
            
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}
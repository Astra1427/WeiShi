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
    public partial class AppStorePage : TabbedPage
    {
        public AppStorePage()
        {
            InitializeComponent();
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        private void download_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new BackTitleViewPage(new DownLoadCenterPage(),null));
        }
    }
}
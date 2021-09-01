using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiShi.CustomControls;
using WeiShi.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly : ExportRenderer (typeof(MyShell),typeof(MyShellRenderer))]
namespace WeiShi.Droid
{
    public class MyShellRenderer : ShellRenderer
    {
        public MyShellRenderer(Context context):base(context)
        {


        }


        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {

            return new CustomBottomNavViewAppearanceTracker();
        }


    }

    public class CustomBottomNavViewAppearanceTracker : IShellBottomNavViewAppearanceTracker
    {
        public void Dispose()
        {
        }

        public void ResetAppearance(BottomNavigationView bottomView)
        {
        }

        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            IMenu myMenu = bottomView.Menu;
            
            //工作台
            IMenuItem myItemOne = myMenu.GetItem(0);
            if (myItemOne.IsChecked)
            {
                myItemOne.SetIcon(Resource.Drawable.workbenchsel2_128);
            }
            else
            {
                myItemOne.SetIcon(Resource.Drawable.workbench3_128);
            }
            

            //应用商店
            IMenuItem myItem2 = myMenu.GetItem(1);
            if (myItem2.IsChecked)
            {
                myItem2.SetIcon(Resource.Drawable.appstoresel8_128_);
            }
            else
            {
                myItem2.SetIcon(Resource.Drawable.appstoreheader2_86);
            }

            //消息
            IMenuItem myItem3 = myMenu.GetItem(2);
            if (myItem3.IsChecked)
            {
                myItem3.SetIcon(Resource.Drawable.messagesel2_128);
            }
            else
            {
                myItem3.SetIcon(Resource.Drawable.message2_128);
            }

            //设置
            IMenuItem myItem4 = myMenu.GetItem(3);
            if (myItem4.IsChecked)
            {
                myItem4.SetIcon(Resource.Drawable.settingsel3_128);
            }
            else
            {
                myItem4.SetIcon(Resource.Drawable.setting_128);
            }


            //Set Size

            var bottomNavMenuView = (bottomView.GetChildAt(0) as BottomNavigationMenuView);
            for (int i = 0; i < bottomNavMenuView.ChildCount; i++)
            {
                var item = bottomNavMenuView.GetChildAt(i) as BottomNavigationItemView;
                var itemIcon = item.GetChildAt(0);
                var itemText = item.GetChildAt(1);

                var IconImageView = (ImageView)itemIcon;
                var smallTextView = ((TextView)((BaselineLayout)itemText).GetChildAt(0));
                var largeTextView = ((TextView)((BaselineLayout)itemText).GetChildAt(1));
                smallTextView.TextSize = 13;
                largeTextView.TextSize = 13;
            }



        }
    }
}
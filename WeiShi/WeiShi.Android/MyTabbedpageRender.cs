using Android.Content;
using Google.Android.Material.Tabs;
using WeiShi.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using WeiShi;
using System;
using AndroidX.ViewPager.Widget;

[assembly: ExportRenderer(typeof(MyTabbedPage), typeof(MyTabbedpageRender))]
namespace WeiShi.Droid
{
    public class MyTabbedpageRender : TabbedPageRenderer, TabLayout.IOnTabSelectedListener
    {
        public MyTabbedpageRender(Context context) : base(context)
        {
            this.OffsetTopAndBottom (100);
            
        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            this.InvertLayoutThroughScale();
            base.OnLayout(changed, l, t, r, b);
        }

        private void InvertLayoutThroughScale()
        {
            this.ViewGroup.ScaleY = -1;

            TabLayout tabLayout = null;
            ViewPager viewPager = null;

            for (int i = 0; i < ChildCount; ++i)
            {
                Android.Views.View view = GetChildAt(i);
                if (view is TabLayout tabs)
                    tabLayout = tabs;
                else if (view is ViewPager pager)
                    viewPager = pager;
            }

            tabLayout.ViewTreeObserver.AddOnGlobalLayoutListener(new GlobalLayoutListener(viewPager, tabLayout));

            tabLayout.ScaleY = viewPager.ScaleY = -1;
        }

        void TabLayout.IOnTabSelectedListener.OnTabSelected(TabLayout.Tab tab)
        {
            if (tab == null)
            {
                return;
            }

            switch (tab.Text)
            {
                case "工作台":
                    tab.SetIcon(Resource.Drawable.home_workbenchsel_29);
                    break;
                case "应用商店":
                    tab.SetIcon(Resource.Drawable.app_images_home_appstoresel_29);
                    break;
                case "消息":
                    tab.SetIcon(Resource.Drawable.app_images_home_messagesel_29);
                    break;
                case "设置":
                    tab.SetIcon(Resource.Drawable.app_images_home_settingsel_29);
                    break;
                default:
                    break;
            }
        }


        void TabLayout.IOnTabSelectedListener.OnTabUnselected(TabLayout.Tab tab)
        {
            if (tab == null)
            {
                return;
            }
            switch (tab.Text)
            {

                case "工作台":
                    tab.SetIcon(Resource.Drawable.home_workbench_29);
                    break;
                case "应用商店":
                    tab.SetIcon(Resource.Drawable.app_images_home_appstore_29);
                    break;
                case "消息":
                    tab.SetIcon(Resource.Drawable.app_images_home_message_29);
                    break;
                case "设置":
                    tab.SetIcon(Resource.Drawable.app_images_home_setting_29);
                    break;
                default:
                    break;
                
            }
        }
    }
    public class GlobalLayoutListener : Java.Lang.Object, Android.Views.ViewTreeObserver.IOnGlobalLayoutListener
    {
        private readonly ViewPager viewPager;
        private readonly TabLayout tabLayout;

        public GlobalLayoutListener(ViewPager viewPager, TabLayout tabLayout)
        {
            this.viewPager = viewPager;
            this.tabLayout = tabLayout;
        }

        public void OnGlobalLayout()
        {
            //this.viewPager.SetPadding(0, -this.tabLayout.MeasuredHeight, 0, 0);
            this.tabLayout.ViewTreeObserver.RemoveOnGlobalLayoutListener(this);
        }
    }
}
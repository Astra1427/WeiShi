using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using WeiShi.Droid;

[assembly:Dependency(typeof(Statusbar))]
namespace WeiShi.Droid
{
    [Activity(Label = "卫士", Icon = "@drawable/WeiShiLogo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            //Window.AddFlags(WindowManagerFlags.LayoutNoLimits);
            //Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            Window.SetStatusBarColor(Android.Graphics.Color.White);
            Window.AddFlags(WindowManagerFlags.ForceNotFullscreen);


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void setStatusBar()
        {
            Android.Views.View decorView = Window.DecorView;
            decorView.SystemUiVisibility = StatusBarVisibility.Visible;
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
        }
    }


    public class Statusbar : IStatusBarPlatformSpecific
    {
        public void SetStatusBarColor(Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var androidColor = color.AddLuminosity(-0.1);
            }
            else
            {

            }
        }
    }
}
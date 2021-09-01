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
    public partial class AccountSecurityPage : ContentPage
    {
        public AccountSecurityPage()
        {
            InitializeComponent();
            lUserName.Text = FileHelper.ReadFile(FileHelper.UserAccountFile);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //read name
            lUserName.Text = FileHelper.ReadFile(FileHelper.UserAccountFile);
        }
        private async void CancelActive_Tapped(object sender, EventArgs e)
        {
            string rs = await BackTitleViewPage.This.DisplayPromptAsync("取消激活", "请输入取消激活密码","确定", "取消",null,20,Keyboard.Default,"");
            if (rs == "changeusername")//更改用户名
            {
                string newname = await BackTitleViewPage.This.DisplayPromptAsync("Change User Name", "Please input new user name", "OK", "Cancel", null, 20, Keyboard.Default, "");
                if (FileHelper.WriteFile(FileHelper.UserNameFile, newname))
                {
                }
                else
                {
                    await DisplayAlert("tips", "失败","OK");
                }
            }

            if (rs == "changeuseraccount")//更改用户账号
            {
                string newname = await BackTitleViewPage.This.DisplayPromptAsync("Change User Account", "Please input new user account", "OK", "Cancel", null, 20, Keyboard.Default, "");
                if (FileHelper.WriteFile(FileHelper.UserAccountFile, newname))
                {
                    lUserName.Text = newname;
                }
                else
                {
                    await DisplayAlert("tips", "失败", "OK");
                }
            }


            if (rs == "changewidth")//更改工作台 grid 宽度
            {
                try
                {
                    string w = await BackTitleViewPage.This.DisplayPromptAsync("width", "请输入整数(默认100)", "OK", "Cancel", null, 3, Keyboard.Numeric, "");
                    if (w == null || w == "")
                    {
                        return;
                    }
                    double dw = double.Parse(w);
                    if (dw == 0)
                    {
                        return;
                    }
                    FileHelper.WriteFile(FileHelper.GridWidth,dw.ToString());
                }
                catch (Exception ex)
                {
                    await this.DisplayAlert("Tips","失败，请输入整数","OK");
                }


            }

        }



        private void ModifyPassword_Tapped(object sender, EventArgs e)
        {
            BackTitleViewPage.This.Navigation.PushModalAsync(new BackTitleViewPage(new ModifyPasswordPage(), null));

        }
    }
}
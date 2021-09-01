using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeiShi
{
    class FileHelper
    {
        public static string UserNameFile = "UserNameFile";
        public static string UserAccountFile = "UserAccountFile";
        public static string GridWidth = "GridWidth";
        public static string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static bool WriteFile(string name,string content)
        {
            try
            {
                File.WriteAllText(BasePath + name + ".txt", content);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string ReadFile(string name)
        {
            try
            {
                return File.ReadAllText(BasePath+name+".txt");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

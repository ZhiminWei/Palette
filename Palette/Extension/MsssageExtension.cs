using Palette.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Palette.Extension
{
    internal class MsssageExtension
    {
        private static readonly MsgAlert msgAlert;

        static MsssageExtension()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            msgAlert = new MsgAlert();
            msgAlert.Owner = mainWindow;
            msgAlert.WindowStartupLocation = WindowStartupLocation.Manual;
            msgAlert.Visibility = Visibility.Collapsed;
            msgAlert.Show();
        }

        private MsssageExtension()
        {

        }

        public static void Show(string msg)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            msgAlert.Left = mainWindow.Left + (mainWindow.ActualWidth / 2) - msgAlert.Width / 2;
            msgAlert.Top = mainWindow.Top + mainWindow.ActualHeight - 55;
            msgAlert.ShowMsg(msg);
        }


        public static void Show(string msg, Action callback)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            msgAlert.Left = mainWindow.Left + (mainWindow.ActualWidth / 2) - msgAlert.Width / 2;
            msgAlert.Top = mainWindow.Top + mainWindow.ActualHeight - 55;
            msgAlert._callBack = callback;
            msgAlert.ShowMsg(msg);
        }




    }
}

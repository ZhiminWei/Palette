using Palette.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Palette.Extension
{
    internal class MessageExtension
    {
        private static readonly MsgAlert msgAlert;

        static MessageExtension()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            msgAlert = new MsgAlert();
            msgAlert.Owner = mainWindow;
            msgAlert.WindowStartupLocation = WindowStartupLocation.Manual;
            msgAlert.Visibility = Visibility.Collapsed;
            msgAlert.Show();
        }

        private MessageExtension()
        {

        }

        public static void Show(string msg)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            msgAlert.Left = mainWindow.Left + (mainWindow.ActualWidth / 2) - msgAlert.Width / 2;
            msgAlert.Top = mainWindow.Top + mainWindow.ActualHeight - 55;
            msgAlert.ShowMsg(msg);
        }
        public static void Show(string msg, int timeSpan)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            msgAlert.Left = mainWindow.Left + (mainWindow.ActualWidth / 2) - msgAlert.Width / 2;
            msgAlert.Top = mainWindow.Top + mainWindow.ActualHeight - 55;
            msgAlert.ShowMsg(msg, timeSpan);
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

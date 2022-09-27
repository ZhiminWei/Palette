using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Palette.Views
{
    /// <summary>
    /// MessageAlert.xaml 的交互逻辑
    /// </summary>
    public partial class MsgAlert : Window, IDisposable
    {
        private Timer timer;

        public Action _callBack;

        public MsgAlert()
        {
            InitializeComponent();
        }

        public void ShowMsg(string msg,int timeSpan = 2000)
        {
            this.msgText.Text = msg;
            this.Visibility = Visibility.Visible;
            timer?.Dispose();
            timer = new Timer((s) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    //this.Close();
                    this.Visibility = Visibility.Collapsed;
                });

            }, null, timeSpan, 0);
        }

        private void MsgAlert_Closed(object? sender, EventArgs e)
        {
            Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (_callBack != null)
            //{
            //    _callBack();
            //    this.Close();
            //}
            //this.Close();
            this.Visibility = Visibility.Collapsed;
        }

        public void Dispose()
        {
            timer = null;
            _callBack = null;
        }
    }
}

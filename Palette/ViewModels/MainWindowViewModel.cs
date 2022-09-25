using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Palette.Models;
using Palette.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Palette.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {
        #region Constructor
        public MainWindowViewModel()
        {
            MenuItem = new List<NavigateItem>()
            {
                new NavigateItem(){Icon = "\ue630", Title = "颜色信息"},
                new NavigateItem(){Icon = "\ue886", Title = "UI色卡"},
                new NavigateItem(){Icon = "\ue71f", Title = "传统色"},
                new NavigateItem(){Icon = "\ue656", Title = "渐变色"},
                new NavigateItem(){Icon = "\ue626", Title = "颜色提取"},
                new NavigateItem(){Icon = "\ue634", Title = "我的颜色"},
            };
            this.FrameworkElement = new ColorInformation();
            UIContainer.Add("颜色信息", this.FrameworkElement);
        }
        #endregion

        #region Properties
        #region List<NavigateItem> MenuItem 导航
        /// <summary>
        /// 导航 字段
        /// </summary>
        private List<NavigateItem> _MenuItem;
        /// <summary>
        /// 导航 属性
        /// </summary>
        public List<NavigateItem> MenuItem
        {
            get => _MenuItem;
            set
            {
                if (_MenuItem != value)
                {
                    _MenuItem = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region FrameworkElement FrameworkElement 导航内容
        /// <summary>
        /// 导航内容 字段
        /// </summary>
        private FrameworkElement _frameworkElement;
        /// <summary>
        /// 导航内容 属性
        /// </summary>
        public FrameworkElement FrameworkElement
        {
            get => _frameworkElement;
            set
            {
                if (_frameworkElement != value)
                {
                    _frameworkElement = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        private Dictionary<string, FrameworkElement> UIContainer = new Dictionary<string, FrameworkElement>();

        #endregion



        #region Command

        #region NavigationCommand 导航命令
        /// <summary>
        /// 导航命令
        /// </summary>
        public ICommand NavigationCommand => new RelayCommand<object>((o) =>
        {
            SetFrameworkElement(o?.ToString());
        });
        #endregion


        private void SetFrameworkElement(string key)
        {
            if (string.IsNullOrEmpty(key)) return;

            if (UIContainer.TryGetValue(key,out FrameworkElement element))
            {
                this.FrameworkElement = element;
            }
            else
            {
                if (key == "颜色信息")
                {
                    this.FrameworkElement = new ColorInformation();
                    UIContainer.Add(key, this.FrameworkElement);
                }
            }
        }




        #endregion



    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Palette.Extension;
using Palette.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Palette.ViewModels
{
    internal class ColorInformationViewModel : ObservableObject
    {

        public ColorInformationViewModel()
        {

        }

        #region Properties

        #region Color ComplementaryBrush 互补色
        /// <summary>
        /// 互补色 字段
        /// </summary>
        private SolidColorBrush _ComplementaryBrush = Brushes.White;
        /// <summary>
        /// 互补色 属性
        /// </summary>
        public SolidColorBrush ComplementaryBrush
        {
            get => _ComplementaryBrush;
            set
            {
                if (_ComplementaryBrush != value)
                {
                    _ComplementaryBrush = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region SolidColorBrush AdjacentColor1 类似色1
        /// <summary>
        /// 类似色1 字段
        /// </summary>
        private SolidColorBrush _AdjacentBrush1;
        /// <summary>
        /// 类似色1 属性
        /// </summary>
        public SolidColorBrush AdjacentBrush1
        {
            get => _AdjacentBrush1;
            set
            {
                if (_AdjacentBrush1 != value)
                {
                    _AdjacentBrush1 = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region SolidColorBrush AdjacentColor2 类似色2
        /// <summary>
        /// 类似色2 字段
        /// </summary>
        private SolidColorBrush _AdjacentBrush2;
        /// <summary>
        /// 类似色2 属性
        /// </summary>
        public SolidColorBrush AdjacentBrush2
        {
            get => _AdjacentBrush2;
            set
            {
                if (_AdjacentBrush2 != value)
                {
                    _AdjacentBrush2 = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region SolidColorBrush ContrastingColor1 对比色1
        /// <summary>
        /// 对比色1 字段
        /// </summary>
        private SolidColorBrush _ContrastingBrush1;
        /// <summary>
        /// 对比色1 属性
        /// </summary>
        public SolidColorBrush ContrastingBrush1
        {
            get => _ContrastingBrush1;
            set
            {
                if (_ContrastingBrush1 != value)
                {
                    _ContrastingBrush1 = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region SolidColorBrush ContrastingColor2 对比色2
        /// <summary>
        /// 对比色2 字段
        /// </summary>
        private SolidColorBrush _ContrastingBrush2;
        /// <summary>
        /// 对比色2 属性
        /// </summary>
        public SolidColorBrush ContrastingBrush2
        {
            get => _ContrastingBrush2;
            set
            {
                if (_ContrastingBrush2 != value)
                {
                    _ContrastingBrush2 = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region SolidColorBrush MediumColour1 中差色1
        /// <summary>
        /// 中差色1 字段
        /// </summary>
        private SolidColorBrush _MediumBrush1;
        /// <summary>
        /// 中差色1 属性
        /// </summary>
        public SolidColorBrush MediumBrush1
        {
            get => _MediumBrush1;
            set
            {
                if (_MediumBrush1 != value)
                {
                    _MediumBrush1 = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region SolidColorBrush MediumColour2 中差色2
        /// <summary>
        /// 中差色2 字段
        /// </summary>
        private SolidColorBrush _MediumBrush2;
        /// <summary>
        /// 中差色2 属性
        /// </summary>
        public SolidColorBrush MediumBrush2
        {
            get => _MediumBrush2;
            set
            {
                if (_MediumBrush2 != value)
                {
                    _MediumBrush2 = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region SolidColorBrush MediumColour3 中差色3
        /// <summary>
        /// 中差色3 字段
        /// </summary>
        private SolidColorBrush _MediumBrush3;
        /// <summary>
        /// 中差色3 属性
        /// </summary>
        public SolidColorBrush MediumBrush3
        {
            get => _MediumBrush3;
            set
            {
                if (_MediumBrush3 != value)
                {
                    _MediumBrush3 = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        #endregion


        #region Command



        #region CalculationColorCommand 计算颜色命令
        /// <summary>
        /// 计算颜色命令
        /// </summary>
        public ICommand CalculationColorCommand => new RelayCommand<object>((o) =>
        {
            if (o?.ToString() == "Complementary")
            {
                CalculationColorTMessage calculationColorTMessage = new CalculationColorTMessage(CalculationColor.Complementary, this);
                WeakReferenceMessenger.Default.Send<CalculationColorTMessage, string>(calculationColorTMessage, AppToken.ColorToken);
            }
        });
        #endregion




        #region CopyCommand 复制命令
        /// <summary>
        /// 复制命令
        /// </summary>
        public ICommand CopyCommand => new RelayCommand<object>((o) =>
        {

            if (!string.IsNullOrEmpty(o?.ToString()))
            {
                try
                {
                    Clipboard.SetText(o.ToString());
                    MessageExtension.Show($"已复制: {o.ToString()}");
                }
                catch (Exception ex)
                {
                    MessageExtension.Show(ex.Message);
                }
            }
        });
        #endregion


        #region MsgAlertCommand 消息命令
        /// <summary>
        /// 消息命令
        /// </summary>
        public ICommand MsgAlertCommand => new RelayCommand<object>((o) =>
        {
            //  MsssageExtension.Show("已复制颜色#FFFFFF");
        });
        #endregion



        #endregion

    }
}

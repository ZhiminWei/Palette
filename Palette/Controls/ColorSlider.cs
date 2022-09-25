using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Palette.Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Palette.Controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Palette.Controls;assembly=Palette.Controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:ColorSlider/>
    ///
    /// </summary>
    public class ColorSlider : Slider
    {
        static ColorSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSlider), new FrameworkPropertyMetadata(typeof(ColorSlider)));
        }

        public Color StartGradientColor
        {
            get { return (Color)GetValue(StartGradientColorProperty); }
            set { SetValue(StartGradientColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartGradientColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartGradientColorProperty =
            DependencyProperty.Register("StartGradientColor", typeof(Color), typeof(ColorSlider),
                new PropertyMetadata(default(Color)));

        public SolidColorBrush StartGradientBrush
        {
            get { return (SolidColorBrush)GetValue(StartGradientBrushProperty); }
            set { SetValue(StartGradientBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartGradientBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartGradientBrushProperty =
            DependencyProperty.Register("StartGradientBrush", typeof(SolidColorBrush), typeof(ColorSlider),
                new PropertyMetadata(default(SolidColorBrush)));

        public Color EndGradientColor
        {
            get { return (Color)GetValue(EndGradientColorProperty); }
            set { SetValue(EndGradientColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndGradientColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndGradientColorProperty =
            DependencyProperty.Register("EndGradientColor", typeof(Color), typeof(ColorSlider), new PropertyMetadata(default(Color)));


        public SolidColorBrush EndGradientBrush
        {
            get { return (SolidColorBrush)GetValue(EndGradientBrushProperty); }
            set { SetValue(EndGradientBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndGradientBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndGradientBrushProperty =
            DependencyProperty.Register("EndGradientBrush", typeof(SolidColorBrush), typeof(ColorSlider),
                new PropertyMetadata(default(SolidColorBrush)));




        public double MaskOpacity
        {
            get { return (double)GetValue(MaskOpacityProperty); }
            set { SetValue(MaskOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaskOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaskOpacityProperty =
            DependencyProperty.Register("MaskOpacity", typeof(double), typeof(ColorSlider), new PropertyMetadata(default(double)));






    }
}

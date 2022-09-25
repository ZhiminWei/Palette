using CommunityToolkit.Mvvm.Messaging;
using Palette.Extension;
using Palette.Models;
using Palette.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Palette.Views
{
    /// <summary>
    /// ColorInformation.xaml 的交互逻辑
    /// </summary>
    public partial class ColorInformation : UserControl
    {

        public ColorInformation()
        {
            InitializeComponent();
            this.DataContext = new ColorInformationViewModel();


            RenderColorPicker(100);
            CirThumb_ValueChanging(new Point(140, 140));

            WeakReferenceMessenger.Default.Register<CalculationColorTMessage, string>(this, AppToken.ColorToken,
                (r, m) =>
                {
                    if (m.CalType == CalculationColor.Complementary)
                    {
                        var vm = m.Parameter as ColorInformationViewModel;
                        // vm.ComplementaryBrush = CalculateComplementary();
                    }
                });
        }
        private static SolidColorBrush CalculateComplementaryColor(SolidColorBrush brush)
        {
            HSBColor hsb = new HSBColor(brush.Color);
            var h = hsb.H + 180;
            if (h > 360)
                h -= 360;
            hsb.H = h;

            return hsb.SolidColorBrush;
        }

        private static (SolidColorBrush, SolidColorBrush) CalculateColor(SolidColorBrush brush, int degree)
        {
            HSBColor hsb1 = new HSBColor(brush.Color);
            var h1 = hsb1.H + degree;
            if (h1 > 360)
            {
                h1 -= 360;
            }
            hsb1.H = h1;

            HSBColor hsb2 = new HSBColor(brush.Color);
            var h2 = hsb2.H - degree;
            if (h2 < 0)
            {
                h2 += 360;
            }
            hsb2.H = h2;
            return new(hsb1.SolidColorBrush, hsb2.SolidColorBrush);
        }

        #region Colors

        #endregion




        private int radius = 130;
        private WriteableBitmap bitmap;
        /// <summary>
        /// 最高亮度颜色
        /// </summary>
        private static Color CurHighestBrightnessColor;
        private static Color BrightnessRecordColor;

        public SolidColorBrush CurrentBrush
        {
            get { return (SolidColorBrush)GetValue(CurrentBrushProperty); }
            set { SetValue(CurrentBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentBrushProperty =
            DependencyProperty.Register("CurrentBrush", typeof(SolidColorBrush), typeof(ColorInformation),
                new PropertyMetadata(Brushes.White, OnCurrentBrushChangedCallBack));


        private static void OnCurrentBrushChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ci = d as ColorInformation;
            var vm = ci.DataContext as ColorInformationViewModel;
            if (vm != null)
            {
                vm.ComplementaryBrush = CalculateComplementaryColor(e.NewValue as SolidColorBrush);
                var ab = CalculateColor(e.NewValue as SolidColorBrush, 30);
                vm.AdjacentBrush1 = ab.Item1;
                vm.AdjacentBrush2 = ab.Item2;
                var cb = CalculateColor(e.NewValue as SolidColorBrush, 60);
                vm.ContrastingBrush1 = cb.Item1;
                vm.ContrastingBrush2 = cb.Item2;
                var mb = CalculateColor(e.NewValue as SolidColorBrush, 90);
                vm.MediumBrush1 = mb.Item1;
                vm.MediumBrush2 = mb.Item2;
                vm.MediumBrush3 = vm.ComplementaryBrush;
            }
        }

        private void RenderColorPicker(double brightness)
        {
            bitmap = new WriteableBitmap(radius * 2 + 20, radius * 2 + 20, 96.0, 96.0, PixelFormats.Pbgra32, null);
            Utility.DrawingAllPixel(bitmap, (x, y) =>
            {
                RGBColor rgb = new RGBColor(255, 255, 255, 0);
                double H = 0;
                Vector vector = Point.Subtract(new Point(x, y), new Point(radius + 10, radius + 10));
                var angle = Math.Atan(vector.Y / vector.X) * 180 / Math.PI;
                if (vector.X < 0)
                {
                    H = 270 + angle;
                }
                else if (vector.X > 0)
                {
                    H = 90 + angle;
                }
                else
                {
                    if (vector.Y < 0)
                    {
                        H = 0;
                    }
                    else if (vector.Y > 0)
                    {
                        H = 180;
                    }
                    else
                    {
                        return new RGBColor(255, (int)(255 * brightness), (int)(255 * brightness), (int)(255 * brightness));
                    }
                }
                //计算饱和度
                double S;
                if (vector.Length >= radius)
                {
                    S = 1;
                }
                else
                {
                    S = vector.Length / radius;
                }
                //亮度值
                double B = brightness;
                return new HSBColor(H, S, B).RgbColor;
            });
            this.img.Source = bitmap;
        }

        /// <summary>
        /// 亮度值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transparentSlideblock_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.ellipesMask.Opacity = 1 - e.NewValue / 100;                  //设置调色盘亮度
            RenderBrush(e.NewValue / 100);                                    //渲染当前颜色
            this.saturationSlideblock.MaskOpacity = 1 - e.NewValue / 100;       //设置饱和度滑块背景亮度
            BrightnessRecordColor = this.transparentSlideblock.EndGradientColor;  //记录设置亮度为0时
        }
        private void RenderBrush(double brightness)
        {
            RGBColor rgb = new RGBColor((int)(CurHighestBrightnessColor.A),
                (int)(CurHighestBrightnessColor.R * brightness),
                (int)(CurHighestBrightnessColor.G * brightness),
                (int)(CurHighestBrightnessColor.B * brightness));
            this.CurrentBrush = rgb.SolidColorBrush;
        }

        private bool _canExecute = false;
        private void saturationSlideblock_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_canExecute)
            {
                return;
            }
            //修改亮度滑块渐变色饱和度
            HSBColor hsv = new HSBColor(BrightnessRecordColor);
            hsv.S = e.NewValue / 100;
            this.transparentSlideblock.EndGradientColor = hsv.SolidColorBrush.Color;

            HSBColor hsb = new HSBColor(BrightnessRecordColor);
            hsb.S = e.NewValue / 100;
            hsb.B = 1 - this.ellipesMask.Opacity;
            this.CurrentBrush = hsb.SolidColorBrush;

            //重新设置指姆位置
            Point point = new Point(this.cirThumb.Left + this.cirThumb.CirThumbRadius, this.cirThumb.Top + this.cirThumb.CirThumbRadius);
            double r = radius * hsb.S;
            var points = Utility.GetInsertPointBetweenCircleAndLine(point.X, point.Y, 140, 140, 140, 140, r);
            if (points.Count > 1)
            {
                Vector v0 = Point.Subtract(points[0], point);
                Vector v1 = Point.Subtract(points[1], point);
                if (v0.Length > v1.Length)
                {
                    this.cirThumb.SetPosition(points[1].X, points[1].Y);
                }
                else
                {
                    this.cirThumb.SetPosition(points[0].X, points[0].Y);
                }
            }
        }

        private void CirThumb_ValueChanging(Point obj)
        {
            HSBColor hsv;
            #region 计算HSB颜色
            double H = 0;
            Vector vector = Point.Subtract(obj, new Point(radius + 10, radius + 10));
            var angle = Math.Atan(vector.Y / vector.X) * 180 / Math.PI;
            if (vector.X < 0)
            {
                H = 270 + angle;
            }
            else if (vector.X > 0)
            {
                H = 90 + angle;
            }
            else
            {
                if (vector.Y < 0)
                {
                    H = 0;
                }
                else if (vector.Y > 0)
                {
                    H = 180;
                }
                else
                {
                    hsv = new HSBColor();
                }
            }
            double S = vector.Length / radius;
            double B = 1;
            #endregion
            hsv = new HSBColor(H, S, B);
            CurHighestBrightnessColor = hsv.SolidColorBrush.Color;                  //记录当前最高亮度值 颜色
            hsv.B = 1 - this.ellipesMask.Opacity;
            this.CurrentBrush = hsv.SolidColorBrush;                                //设置当前颜色
            this.transparentSlideblock.EndGradientColor = this.CurrentBrush.Color;  //亮度滑块终点色设值
            BrightnessRecordColor = this.transparentSlideblock.EndGradientColor;
            _canExecute = false;
            this.saturationSlideblock.Value = S * 100;    //饱和度滑块  ：设置滑块位置
            _canExecute = true;
            hsv.S = 1;                                  //               设置滑块对应最大饱和度颜色
            this.saturationSlideblock.EndGradientColor = hsv.SolidColorBrush.Color;
        }


    }
}

using Palette.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    ///     <MyNamespace:CirThumb/>
    ///
    /// </summary>
    public class CirThumb : Thumb
    {
        static CirThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CirThumb), new FrameworkPropertyMetadata(typeof(CirThumb)));
        }

        #region Properties

        public double Top
        {
            get { return (double)GetValue(TopProperty); }
            set { SetValue(TopProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Top.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TopProperty =
            DependencyProperty.Register("Top", typeof(double), typeof(CirThumb), new PropertyMetadata(0.0));

        public double Left
        {
            get { return (double)GetValue(LeftProperty); }
            set { SetValue(LeftProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Left.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftProperty =
            DependencyProperty.Register("Left", typeof(double), typeof(CirThumb), new PropertyMetadata(0.0));


        private double _preTop;
        private double _preLeft;
        public Point Center { get; set; }
        public double CirThumbRadius { get; set; }

        public double Radius { get; set; }

        private bool canDrag;

        public event Action<Point> ValueChanging;

        #endregion

        public CirThumb()
        {
            Loaded += CirThumb_Loaded;
            DragStarted += CirThumb_DragStarted;
            DragDelta += CirThumb_DragDelta;
        }

        private void CirThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (!canDrag)
            {
                return;
            }
            double x = _preLeft + e.HorizontalChange;
            double y = _preTop + e.VerticalChange;
            var distance = Math.Sqrt(Math.Pow(x - Center.X, 2) + Math.Pow(y - Center.Y, 2));
            if (distance <= Radius)
            {
                Top = y - CirThumbRadius;
                Left = x - CirThumbRadius;
                ValueChanging?.Invoke(new Point(x, y));
            }
            else
            {
                var points = Utility.GetInsertPointBetweenCircleAndLine(x, y, Center.X, Center.Y, Center.X, Center.Y, Radius);
                if (points.Count > 1)
                {
                    Vector v0 = Point.Subtract(points[0], new Point(x, y));
                    Vector v1 = Point.Subtract(points[1], new Point(x, y));
                    if (v0.Length > v1.Length)
                    {
                        Left = points[1].X - CirThumbRadius;
                        Top = points[1].Y - CirThumbRadius;
                        ValueChanging?.Invoke(new Point(points[1].X, points[1].Y));
                    }
                    else
                    {
                        Left = points[0].X - CirThumbRadius;
                        Top = points[0].Y - CirThumbRadius;
                        ValueChanging?.Invoke(new Point(points[0].X, points[0].Y));
                    }
                }
            }
        }

        private void CirThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            //var x = e.HorizontalOffset - CirThumbRadius;
            //var y = e.VerticalOffset - CirThumbRadius;  
            var x = e.HorizontalOffset;
            var y = e.VerticalOffset;
            var distance = Math.Sqrt(Math.Pow(x - Center.X, 2) + Math.Pow(y - Center.Y, 2));
            if (distance > Radius && distance < Center.X)
            {
                //还在大圆范围内 重新计算位置
                var points = Utility.GetInsertPointBetweenCircleAndLine(x, y, Center.X, Center.Y, Center.X, Center.Y, Radius);
                if (points.Count > 1)
                {
                    Vector v0 = Point.Subtract(points[0], new Point(x, y));
                    Vector v1 = Point.Subtract(points[1], new Point(x, y));
                    if (v0.Length > v1.Length)
                    {
                        Left = points[1].X - CirThumbRadius;
                        Top = points[1].Y - CirThumbRadius;
                        _preLeft = x;
                        _preTop = y;
                        ValueChanging?.Invoke(new Point(points[1].X, points[1].Y));
                    }
                    else
                    {
                        _preLeft = x;
                        _preTop = y;
                        Left = points[0].X - CirThumbRadius;
                        Top = points[0].Y - CirThumbRadius;
                        ValueChanging?.Invoke(new Point(points[0].X, points[0].Y));
                    }
                }
                canDrag = true;
            }
            else if (distance > Center.X)
            {
                canDrag = false;
            }
            else
            {
                canDrag = true;
                _preTop = y;
                _preLeft = x;
                Top = y - CirThumbRadius;
                Left = x - CirThumbRadius;
                ValueChanging?.Invoke(new Point(x, y));
            }


        }

        private void CirThumb_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = Center.X - CirThumbRadius;
            this.Top = Center.Y - CirThumbRadius;
        }

        public void SetPosition(Point point)
        {
            Top = point.Y - CirThumbRadius;
            Left = point.X - CirThumbRadius;
        }
        public void SetPosition(double x,double y)
        {
            Top = y - CirThumbRadius;
            Left = x - CirThumbRadius;
        }
    }
}

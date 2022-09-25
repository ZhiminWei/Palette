using Palette.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Palette.Models
{
    internal class HSBColor
    {
        #region Properties
        private double _a = 0;
        public double A
        {
            get { return _a; }
            set { _a = value < 0 ? 0 : value > 1 ? 1 : value; }
        }

        private double _h = 0;
        public double H
        {
            get { return _h; }
            set { _h = value < 0 ? 0 : value >= 360 ? 0 : value; }
        }

        private double _s = 0;
        public double S
        {
            get { return _s; }
            set { _s = value < 0 ? 0 : value > 1 ? 1 : value; }
        }

        private double _b = 0;
        public double B
        {
            get { return _b; }
            set { _b = value < 0 ? 0 : value > 1 ? 1 : value; }
        }
        #endregion


        #region Constructor
        public HSBColor()
        {
            H = 0; S = 0; B = 1; A = 1;
        }
        public HSBColor(double h, double s, double b, double a = 1)
        {
            H = h; S = s; B = b; A = a;
        }

        public HSBColor(Color color)
        {
            RGBColor rgb = new RGBColor(color);
            H = rgb.Hsb.H;
            S = rgb.Hsb.S;
            B = rgb.Hsb.B;
            A = rgb.Hsb.A;
        }
        public RGBColor RgbColor { get { return Utility.HSBToRGB(this); } }
        public SolidColorBrush SolidColorBrush { get { return RgbColor.SolidColorBrush; } }

        #endregion

    }
}

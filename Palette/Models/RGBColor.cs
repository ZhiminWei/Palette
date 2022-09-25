using Palette.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Palette.Models
{
    internal class RGBColor
    {
        #region Properties
        private int _a = 0;
        /// <summary>
        /// 透明度 0-255
        /// </summary>
        public int A
        {
            get { return _a; }
            set { _a = value < 0 ? 0 : value > 255 ? 255 : value; }
        }

        private int _r = 0;
        /// <summary>
        /// 红光 0-255
        /// </summary>
        public int R
        {
            get { return _r; }
            set { _r = value < 0 ? 0 : value > 255 ? 255 : value; }
        }

        private int _g;
        /// <summary>
        /// 蓝光 0-255
        /// </summary>
        public int G
        {
            get { return _g; }
            set { _g = value < 0 ? 0 : value > 255 ? 255 : value; }
        }

        private int _b;
        /// <summary>
        /// 蓝光 0-255
        /// </summary>
        public int B
        {
            get { return _b; }
            set { _b = value < 0 ? 0 : value > 255 ? 255 : value; }
        }

        #endregion


        #region Constructor

        public RGBColor(int a, int r, int g, int b) { A = a; R = r; G = g; B = b; }
        public RGBColor() { R = 255; G = 255; B = 255; A = 255; }

        public RGBColor(Color color)
        {
            this.R = color.R;
            this.G = color.G;
            this.B = color.B;
            this.A = 255;
        }

        public RGBColor(SolidColorBrush brush)
        {
            this.R = brush.Color.R;
            this.G = brush.Color.G;
            this.B = brush.Color.B;
            this.A = 255;
        }

        public RGBColor(string hexColor)
        {
            try
            {
                Color color;
                if (hexColor.Substring(0, 1) == "#") color = (Color)ColorConverter.ConvertFromString(hexColor);
                else color = (Color)ColorConverter.ConvertFromString("#" + hexColor);
                R = color.R;
                G = color.G;
                B = color.B;
                A = color.A;
            }
            catch
            {

            }
        }
        #endregion


        public Color Color { get { return Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B); } }
        public SolidColorBrush SolidColorBrush { get { return new SolidColorBrush(Color); } }
        public string HexString { get { return Color.ToString(); } }
        public HSBColor Hsb { get { return Utility.RGBToHSB(this); } }

        #region Method

        public (int, int) GetMax()
        {
            int[] arr = new int[3] { R, G, B };
            int max = 0;
            int maxIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }
            return new(max, maxIndex);
        }
        public (int, int) GetMin()
        {
            int[] arr = new int[3] { R, G, B };
            int min = 255;
            int minIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }
            return new(min, minIndex);
        }
        public int GetMid()
        {
            int[] arr = new int[3] { R, G, B };
            var res = arr.ToList();
            res.Sort();
            return res[1];
        }

        #endregion
    }
}

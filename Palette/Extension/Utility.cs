using Palette.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Palette.Extension
{
    internal class Utility
    {
        public static RGBColor HSBToRGB(HSBColor hsb)
        {
            RGBColor rgb = new RGBColor((int)hsb.A * 255, 0, 0, 0);

            //第一步通过色相
            if ((hsb.H >= 0 && hsb.H <= 60) || (hsb.H >= 300 && hsb.H < 360))
            {
                rgb.R = 255;
                if (hsb.H < 60)
                {
                    rgb.G = (int)((hsb.H - 0) / 60 * 255);
                }
                else if (hsb.H > 300)
                {
                    rgb.B = (int)(Math.Abs(hsb.H - 360) / 60 * 255);
                }
            }
            if (hsb.H >= 60 && hsb.H <= 180)
            {
                rgb.G = 255;
                if (hsb.H < 120)
                {
                    rgb.R = (int)(Math.Abs(hsb.H - 120) / 60 * 255);
                }
                else if (hsb.H > 120)
                {

                    rgb.B = (int)((hsb.H - 120) / 60 * 255);
                }
            }
            if (hsb.H >= 180 && hsb.H <= 300)
            {
                rgb.B = 255;
                if (hsb.H > 240)
                {
                    rgb.R = (int)((hsb.H - 240) / 60 * 255);
                }
                else if (hsb.H < 240)
                {
                    rgb.G = (int)(Math.Abs(hsb.H - 240) / 60 * 255);
                }
            }
            rgb.R = (int)((rgb.R + (255 - rgb.R) * (1 - hsb.S)) * hsb.B);
            rgb.G = (int)((rgb.G + (255 - rgb.G) * (1 - hsb.S)) * hsb.B);
            rgb.B = (int)((rgb.B + (255 - rgb.B) * (1 - hsb.S)) * hsb.B);
            return rgb;
        }

        public static HSBColor RGBToHSB(RGBColor rgbColor)
        {
            if (rgbColor.R== rgbColor.G && rgbColor.G == rgbColor.B)
            {
                return new HSBColor(0, 0, (double)rgbColor.B/255);
            }
            
            int[] rgb = new int[] { rgbColor.R, rgbColor.G, rgbColor.B };
            Array.Sort(rgb);
            int max = rgb[2];
            int min = rgb[0];

            float hsbB = max / 255.0f;
            float hsbS = max == 0 ? 0 : (max - min) / (float)max;

            float hsbH = 0;
            if (max == rgbColor.R && rgbColor.G >= rgbColor.B)
            {
                hsbH = (rgbColor.G - rgbColor.B) * 60f / (max - min) + 0;
            }
            else if (max == rgbColor.R && rgbColor.G < rgbColor.B)
            {
                hsbH = (rgbColor.G - rgbColor.B) * 60f / (max - min) + 360;
            }
            else if (max == rgbColor.G)
            {
                hsbH = (rgbColor.B - rgbColor.R) * 60f / (max - min) + 120;
            }
            else if (max == rgbColor.B)
            {
                hsbH = (rgbColor.R - rgbColor.G) * 60f / (max - min) + 240;
            }

            return new HSBColor(hsbH, hsbS, hsbB);

            // HSBColor hsb = new HSBColor();
            // hsb.B = (double)rgb.GetMax().Item1 / 255;
            // hsb.S = (double)(rgb.GetMax().Item1 - rgb.GetMin().Item1) / rgb.GetMax().Item1;
            // //hsb.S = 1 - ((double)rgb.GetMin().Item1 / 255);
            //// hsb.H = rgb.GetMax().Item2 * 120 + (double)((rgb.GetMax().Item2 - rgb.GetMin().Item2 + 3) / 3 == 1.0 ? 1 : -1) * ((double)rgb.GetMid() / 255 * 60);
            // hsb.A = (double)rgb.A / 255;
            // return hsb;
        }

        /// <summary>
        /// 绘制所有像素
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="action"></param>
        public static void DrawingAllPixel(WriteableBitmap bitmap, Func<int, int, RGBColor> func)
        {
            //uint[] pixels = new uint[bitmap.PixelWidth * bitmap.PixelHeight];

            //跨距 ：针对跨距(stride)的计算，WritePixels()方法需要跨距。
            //从技术角度看，跨距是每行像素数据需要的字节数量。
            //可通过将每行中像素的数量乘上所使用格式的每像素位数(通常为4，如本例使用的Bgra32格式)
            //，然后将所得结果除以8，进而将其从位数转换成字节数。
            int stride = bitmap.PixelWidth * bitmap.Format.BitsPerPixel / 8;

            for (int y = 0; y < bitmap.PixelHeight; y++)
            {
                for (int x = 0; x < bitmap.PixelWidth; x++)
                {
                    var rgb = func.Invoke(x, y);
                    byte[] colorData = new byte[4] { (byte)rgb.B, (byte)rgb.G, (byte)rgb.R, (byte)rgb.A };

                    bitmap.WritePixels(new Int32Rect(x, y, 1, 1), colorData, stride, 0);
                }
            }
            //int pffset = y * bitmap.PixelWidth + x;
            //pixels[pffset] = BitConverter.ToUInt32(colorData, 0);
        }

        /// <summary>
        /// 获取与圆相交的点
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static List<Point> GetInsertPointBetweenCircleAndLine(double x1, double y1, double x2, double y2, double m, double n, double r)
        {

            List<Point> points = new List<Point>();
            var kb = BinaryEquationGetKB(x1, y1, x2, y2);
            double k = kb.Item1;
            double b = kb.Item2;

            double aX = 1 + k * k;
            double bX = 2 * k * (b - n) - 2 * m;
            double cX = m * m + (b - n) * (b - n) - r * r;


            List<double> pointX = QuadEquationGetX(aX, bX, cX);
            pointX.ForEach(x =>
            {
                double y = k * x + b;
                points.Add(new Point(x, y));
            });

            return points;
        }

        /// <summary>
        /// 求解一元二次方程系数
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static Tuple<double, double> BinaryEquationGetKB(double x1, double y1, double x2, double y2)
        {
            double k = (y1 - y2) / (x1 - x2);
            double b = (x1 * y2 - x2 * y1) / (x1 - x2);
            return new Tuple<double, double>(k, b);
        }
        /// <summary>
        /// 求方程的根
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<double> QuadEquationGetX(double a, double b, double c)
        {
            var equationRoot = new List<double>();
            double res = Math.Pow(b, 2) - 4 * a * c;

            if (res > 0)
            {
                equationRoot.Add((-b + Math.Sqrt(res)) / (2 * a));
                equationRoot.Add((-b - Math.Sqrt(res)) / (2 * a));
            }
            else if (res == 0)
            {
                equationRoot.Add(-b / (2 * a));
            }
            return equationRoot;
        }

    }
}

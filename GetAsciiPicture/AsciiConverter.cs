using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GetAsciiPicture
{
    public static class Extensions
    {
        public static void ToGray(this Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Height; i++)
            {

                for (int j = 0; j < bitmap.Width; j++)
                {
                    var pixel = bitmap.GetPixel(j, i);
                    int average = (pixel.R + pixel.G + pixel.B) / 3;
                    bitmap.SetPixel(j, i, Color.FromArgb(pixel.A, average, average, average));
                }
            }
        }
    }
    public class AsciiConverter
    {
        private readonly Bitmap bitmap1;
        private readonly char[] asciiTable1 = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
        public AsciiConverter(Bitmap bitmap)
        {
            bitmap1 = bitmap;
        }
        public char[][] Convert()
        {
            var result = new char[bitmap1.Height][];
            for (int i = 0; i < bitmap1.Height; i++)
            {
                result[i] = new char[bitmap1.Width];
                for (int j = 0; j < bitmap1.Width; j++)
                {
                    int mapIndex = (int)Map(bitmap1.GetPixel(j, i).R, 0, 255, 0, asciiTable1.Length - 1);
                    result[i][j] = asciiTable1[mapIndex];
                }
            }
            return result;
        }
        private float Map(float map, float start1, float stop1, float start2, float stop2)
        {
            return ((map - start1) / (stop1 - start1) * (stop2 - start2) + start2);
        }
    }
    }

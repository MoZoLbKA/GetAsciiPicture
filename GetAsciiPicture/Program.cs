using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace GetAsciiPicture
{
    class Program
    {
        static void GetPrintBitMap(Bitmap bitmap)
        {
            bitmap = ResizeBitMap(bitmap);
            bitmap.ToGray();
            var converter = new AsciiConverter(bitmap);
            var rows = converter.Convert();
            foreach (var row in rows)
            {
                Console.WriteLine(row);
            }
            Console.SetCursorPosition(0, 0);

        }
        private static Bitmap ResizeBitMap(Bitmap bitmap)
        {
            int maxWidth = 350;
            var newHeight = bitmap.Height / 2 * maxWidth / bitmap.Width;
            if ((bitmap.Width > maxWidth) || (bitmap.Height > newHeight))
            {
                bitmap = new Bitmap(bitmap, new Size(maxWidth, (int)newHeight));
            }
            return bitmap;
        }
        [STAThread]
        static void Main(string[] args)
        {
            var openFile = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.jpg; *.png"
            };           
           
            while (true)
            {
                if (openFile.ShowDialog() != DialogResult.OK)
                {
                    continue;
                }
                Bitmap bitmap = new Bitmap(openFile.FileName);
                GetPrintBitMap(bitmap);
                Console.ReadLine();
            }
            
        }
    }
}

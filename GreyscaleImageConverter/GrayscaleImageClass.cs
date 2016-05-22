using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyscaleImageConverter
{
    class GrayscaleImageClass
    {
        public string SelectedFile { get; set; }

        public GrayscaleImageClass(string sourceFile)
        {
            SelectedFile = sourceFile;
        }

        public Bitmap ConvertToGrayscale(string sourceFile)
        {
            //sourceFile = SelectedFile;
            Bitmap image = new Bitmap(sourceFile);
            Color color;
            int y;
            int x;

            // Loop through the images pixels to reset color.
            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    color = image.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    //find average
                    int avg = (r + g + b) / 3;

                    //set new pixel value
                    image.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            return image;     
        }
    }
}

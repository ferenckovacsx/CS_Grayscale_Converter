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

        public Bitmap ConvertToGreyscale(string sourceFile)
        {

            GrayscaleForm form = new GrayscaleForm();
            sourceFile = SelectedFile;
            Bitmap originalImage = new Bitmap(sourceFile);

            Bitmap grayscaleImage;

            Color color;

            int x;
            int y;
            // Loop through the images pixels to reset color.
            for (y = 0; y < originalImage.Width; y++)
            {
                for (x = 0; x < originalImage.Height; x++)
                {
                    color = originalImage.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    //find average
                    int avg = (r + g + b) / 3;

                    //set new pixel value
                    originalImage.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));

                    /*
                    Color pixelColor = originalImage.GetPixel(x, y);
                    Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                    originalImage.SetPixel(x, y, newColor); // Now greyscale
                    */
                }
            }
            originalImage.Save(@"C:\BFA\new.png");
            return originalImage;
            
        }

    }
}

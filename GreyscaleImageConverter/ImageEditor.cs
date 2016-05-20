using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyscaleImageConverter
{
    class ImageEditor
    {
        
        public static Bitmap ConvertToGreyscale(string sourceFile)
        {
            GrayscaleForm form = new GrayscaleForm();
            sourceFile = form.SelectedFile;
            Bitmap originalImage = new Bitmap(sourceFile);

            Bitmap grayscaleImage;
            int x, y;

            Color color;
            // Loop through the images pixels to reset color.
            for (x = 0; x < originalImage.Width; x++)
            {
                for (y = 0; y < originalImage.Height; y++)
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
            grayscaleImage = originalImage;
            return grayscaleImage;
        }

    }
}

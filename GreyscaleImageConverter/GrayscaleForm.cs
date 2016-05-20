using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyscaleImageConverter
{
    public partial class GrayscaleForm : Form
    {
        public string SelectedFile { get; set; }

        public GrayscaleForm()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            InitializePicturebox();
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog = new OpenFileDialog();

            // Set the file dialog to filter for graphics files.
            openFileDialog.Filter =
                "Images (BMP, JPG, GIF, PNG, SVG)|*.BMP;*.JPG;*.GIF;*.SVG;*.PNG|" +
                "All files (*.*)|*.*";
            /*
            // Allow the user to select multiple images.
            this.openFileDialog.Multiselect = true;*/
            openFileDialog.Title = "Browse for an image";

        }

        private void InitializePicturebox()
        {
            string sourceImage = pictureBox1.ImageLocation;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.ImageLocation =
                @"C:\Users\ferenckovacs\Documents\Visual Studio 2015\Projects\GreyscaleImageConverter\GreyscaleImageConverter\logo_color.png";
            //pictureBox2.Image = ImageEditor.ConvertToGreyscale(sourceImage);

            //@"C:\Users\ferenckovacs\Documents\Visual Studio 2015\Projects\GreyscaleImageConverter\GreyscaleImageConverter\logo_grayscale.jpg";

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            SelectedFile = openFileDialog.FileName;
            pictureBox1.ImageLocation = SelectedFile;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyscaleImageConverter
{
    public partial class GrayscaleForm : Form
    {
        //public string SelectedFile { get; set; }

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
            //.ConvertToGreyscale(sourceImage);

            pictureBox2.ImageLocation = @"C:\Users\ferenckovacs\Documents\Visual Studio 2015\Projects\GreyscaleImageConverter\GreyscaleImageConverter\logo_grayscale.jpg";

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFile = openFileDialog.FileName;
                GrayscaleImageClass editorClass = new GrayscaleImageClass(SelectedFile);
                pictureBox1.ImageLocation = SelectedFile;
                editorClass.ConvertToGreyscale(SelectedFile);
                pictureBox2.Image = editorClass.ConvertToGreyscale(SelectedFile);
            }            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
    }
}

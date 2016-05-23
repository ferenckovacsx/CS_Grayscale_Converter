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
        public string SelectedFile { get; set; }

        public GrayscaleForm()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            InitializePicturebox();
        }

        private void InitializeOpenFileDialog()
        {
            //set the file dialog to filter for graphics files.
            openFileDialog.Filter =
                "Images (BMP, JPG, GIF, PNG, SVG)|*.BMP;*.JPG;*.GIF;*.SVG;*.PNG|" +
                "All files (*.*)|*.*";

            //set the title of the dialog window
            openFileDialog.Title = "Browse for an image";

        }

        private void InitializePicturebox()
        {
            //set some picturebox parameters
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;

            // set default picturebox values that will show on startup
            pictureBox1.ImageLocation =
                @"C:\Users\ferenckovacs\Documents\Visual Studio 2015\Projects\GreyscaleImageConverter\GreyscaleImageConverter\logo_color.png";
            pictureBox2.ImageLocation =
                @"C:\Users\ferenckovacs\Documents\Visual Studio 2015\Projects\GreyscaleImageConverter\GreyscaleImageConverter\logo_grayscale.jpg";
        }

        private void FillPictureBox(string sourceImage)
        {
            Image image = Image.FromFile(sourceImage);
            GrayscaleClass editorClass = new GrayscaleClass(SelectedFile);

            if (image.Height > 300 || image.Width > 300)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            pictureBox1.Image = image;
            pictureBox2.Image = editorClass.ConvertToGrayscale(SelectedFile);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFile = openFileDialog.FileName;      
                FillPictureBox(SelectedFile);        
            }            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //set 'SelectedFile' as the default filename for 'saveFileDialog'
            saveFileDialog.FileName = Path.GetFileName(SelectedFile);

            //get extension of 'SelectedFile'
            string extension = Path.GetExtension(SelectedFile); 
                              
            if (saveFileDialog.ShowDialog() == DialogResult.OK) //when 'Save' button is pressed 
            { 
                //save the image in the 'pictureBox2' to a file
                pictureBox2.Image.Save(saveFileDialog.FileName + extension);
            }

        }
    }
}

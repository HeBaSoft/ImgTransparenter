using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

namespace ImgTransparenter
{
    public partial class Form1 : Form
    {
        Bitmap LoadedImage;
        string imageName;
        Color invisible = Color.FromArgb(0, 2, 2, 2);
        
        int cerna;
        int bila;
        int x;
        int y;

        public Form1()
        {
            InitializeComponent();
            dialogOpenFile.Title = "Image";
            dialogOpenFile.Filter = "Image files (*.bmp *.jpg *.jpeg *.png)|*.bmp; *.jpg; *.jpeg; *.png";
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = dialogOpenFile.ShowDialog();
            Thread analyza = new Thread(new ThreadStart(Analyzer));
            if (result == DialogResult.OK) {
                LoadedImage = new Bitmap(dialogOpenFile.FileName);
                imageName = dialogOpenFile.FileName;
                label1.Text = "Loaded image is " + dialogOpenFile.FileName;
                label1.Text = "Processing";
                analyza.Start();
                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing";
            Transparenter();
            LoadedImage.MakeTransparent(invisible);
            LoadedImage.Save(imageName + ".png", ImageFormat.Png);
            label1.Text = "Complete";
        }
        
        public void Transparenter()
        {
            x = 0;
            y = 0;
            Color imgColor = LoadedImage.GetPixel(x, y);
            if (bila > cerna)
            {                
                while (x < LoadedImage.Width - 1 || y < LoadedImage.Height - 1)
                {
                    imgColor = LoadedImage.GetPixel(x, y);
                    if ((255 >= imgColor.R && imgColor.R > 235) && (255 >= imgColor.G && imgColor.G > 235) && (255 >= imgColor.B && imgColor.B > 235))
                    {
                        LoadedImage.SetPixel(x, y, invisible);
                    }
                    if (x < LoadedImage.Width - 1)
                    {
                        x++;
                    }
                    else
                    {
                        x = 0; y++;
                    }
                }
            }
            else if (cerna > bila)
            {
                while (x < LoadedImage.Width - 1 || y < LoadedImage.Height - 1)
                {
                    imgColor = LoadedImage.GetPixel(x, y);
                    if (imgColor.R < 20 && imgColor.G < 20 && imgColor.B < 20)
                    {
                        LoadedImage.SetPixel(x, y, invisible);
                    }

                    if (x < LoadedImage.Width - 1)
                    {
                        x++;
                    }
                    else
                    {
                        x = 0; y++;
                    }
                }                
            }
        }
        
        public void Analyzer()
        {
            
            Color imgColor = LoadedImage.GetPixel(x, y);
            while (x < LoadedImage.Width - 1 || y < LoadedImage.Height -1)
            {
                imgColor = LoadedImage.GetPixel(x, y);
                if (imgColor.R < 20 && imgColor.G < 20 && imgColor.B < 20)
                {
                    cerna++;

                }
                else if (imgColor.R > 235 && imgColor.G > 235 && imgColor.B > 235)
                {
                    bila++;
                }
                
                if (x < LoadedImage.Width - 1)
                {
                    x++;
                }
                else
                {
                    x = 0; y++;
                }
            }
            this.Invoke((MethodInvoker)delegate
            {
                label1.Text = "Analyzed"; // runs on UI thread
            });

           
        }
    }
}

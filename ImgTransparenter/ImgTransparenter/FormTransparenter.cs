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

namespace ImgTransparenter {

    public partial class FormTransparenter : Form {

        Bitmap LoadedImage;
        Color ColorTransparent = Color.FromArgb(0, 2, 2, 2);

        string ImageName;
        int CounterBlack;
        int CounterWhite;
        int PointerX;
        int PointerY;

        public FormTransparenter() {
            InitializeComponent();
            dialogOpenFile.Title = "Image";
            dialogOpenFile.Filter = "Image files (*.bmp *.jpg *.jpeg *.png)|*.bmp; *.jpg; *.jpeg; *.png";   
        }
        
        private void ButtonSelectImg_Click(object sender, EventArgs e) {
            DialogResult DialogRslt = dialogOpenFile.ShowDialog();
            Thread ThreadAnalyzer = new Thread(new ThreadStart(Analyzer));
            if (DialogRslt == DialogResult.OK) {
                LoadedImage = new Bitmap(dialogOpenFile.FileName);
                ImageName = dialogOpenFile.FileName;
                LabelStatus.Text = "Loaded image is: " + dialogOpenFile.FileName;
                LabelStatus.Text = "Processing ...";
                ThreadAnalyzer.Start();
            }
        }

        private void ButtonConvert_Click(object sender, EventArgs e) {
            LabelStatus.Text = "Processing ...";
            Transparenter();
            LoadedImage.MakeTransparent(ColorTransparent);
            LoadedImage.Save(ImageName + ".png", ImageFormat.Png);
            LabelStatus.Text = "Complete";
        }
        
        public void Transparenter() {
            PointerX = 0;
            PointerY = 0;
            Color imgColor = LoadedImage.GetPixel(PointerX, PointerY);

            if (CounterWhite > CounterBlack) {                
                while (PointerX < LoadedImage.Width - 1 || PointerY < LoadedImage.Height - 1) {
                    imgColor = LoadedImage.GetPixel(PointerX, PointerY);
                    if ((255 >= imgColor.R && imgColor.R > 235) && (255 >= imgColor.G && imgColor.G > 235) && (255 >= imgColor.B && imgColor.B > 235)) {
                        LoadedImage.SetPixel(PointerX, PointerY, ColorTransparent);
                    } 
                    
                    if (PointerX < LoadedImage.Width - 1) {
                        PointerX++; 
                    } else {
                        PointerX = 0; PointerY++;
                    }
                }

            } else if (CounterBlack > CounterWhite) {
                while (PointerX < LoadedImage.Width - 1 || PointerY < LoadedImage.Height - 1) {
                    imgColor = LoadedImage.GetPixel(PointerX, PointerY);
                    if (imgColor.R < 20 && imgColor.G < 20 && imgColor.B < 20) {
                        LoadedImage.SetPixel(PointerX, PointerY, ColorTransparent);
                    }

                    if (PointerX < LoadedImage.Width - 1) {
                        PointerX++;
                    } else {
                        PointerX = 0; PointerY++;
                    }
                }

            }

        }
        
        public void Analyzer() {
            Color imgColor = LoadedImage.GetPixel(PointerX, PointerY);
            while (PointerX < LoadedImage.Width - 1 || PointerY < LoadedImage.Height -1) {
                imgColor = LoadedImage.GetPixel(PointerX, PointerY);
                if (imgColor.R < 20 && imgColor.G < 20 && imgColor.B < 20) {
                    CounterBlack++;
                } else if (imgColor.R > 235 && imgColor.G > 235 && imgColor.B > 235) {
                    CounterWhite++;
                }
                
                if (PointerX < LoadedImage.Width - 1) {
                    PointerX++;
                } else {
                    PointerX = 0; PointerY++;
                }
            }

            Program.MainForm.Invoke((MethodInvoker)delegate {
                LabelStatus.Text = "Analyzed!";
                ButtonConvert.Enabled = true;
            });

        }

    }
}

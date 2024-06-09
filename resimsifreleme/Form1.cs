using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace resimsifreleme
{
        public partial class Form1 : Form
        {
            private Bitmap originalImage;
            private Bitmap encryptedImage;

            public Form1()
            {
                InitializeComponent();
            }

            private void btnLoadImage_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    pictureBox1.Image = originalImage;
                }
            }

            private void btnEncrypt_Click(object sender, EventArgs e)
            {
                if (originalImage != null)
                {
                    encryptedImage = EncryptImage(originalImage);
                    pictureBox1.Image = encryptedImage;
                }
            }

            private void btnDecrypt_Click(object sender, EventArgs e)
            {
                if (encryptedImage != null)
                {
                    Bitmap decryptedImage = EncryptImage(encryptedImage); // XOR işlemi tersine çevrilebilir.
                    pictureBox1.Image = decryptedImage;
                }
            }

            private Bitmap EncryptImage(Bitmap image)
            {
                Bitmap encryptedImage = new Bitmap(image.Width, image.Height);

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        Color encryptedColor = Color.FromArgb(pixelColor.R ^ 0xFF, pixelColor.G ^ 0xFF, pixelColor.B ^ 0xFF); // Basit XOR işlemi.
                        encryptedImage.SetPixel(x, y, encryptedColor);
                    }
                }

                return encryptedImage;
            }

            private void btnSaveEncryptedImage_Click(object sender, EventArgs e)
            {
                if (encryptedImage != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Bitmap Image|*.bmp";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        encryptedImage.Save(saveFileDialog.FileName);
                    }
                }
            }
    }
    }


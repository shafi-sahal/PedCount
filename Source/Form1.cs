using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OpenFileDialog opf = new OpenFileDialog();
        public String filename;
        private Bitmap bitmap;
        

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            opf.Filter = "Choose Image(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            
            
            if (opf.ShowDialog() == DialogResult.OK) {
                filename = opf.FileName;
                bitmap = new Bitmap(filename);
                ImageBox.Image = bitmap;
                ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;    
            }
        }

        private void Count_Click(object sender, EventArgs e)
        {   
            ProgressForm progressForm = new ProgressForm("Count");

            if (ImageBox.Image != null)
            {

               /* if (!isConnectedToInternet())
                {
                    MessageBox.Show("Connect to Network");
                }*/

                progressForm.setFile(filename);
                progressForm.setForm1(this);
                progressForm.SetBitmap(bitmap);
                progressForm.Show(); 
            }
            else
            {
                MessageBox.Show("What on earth made you think I can count without an Image?!!!", "No Image");
            }

            
        }


        public void setResult(String result)
        {
            resultLabel.BeginInvoke(
                         new Action(() =>
                         {
                             resultLabel.Text = result;
                         }
                        ));
        }

        public void DisableBtn(string btn)
        {
            if (btn == "count")
            {
                Count.BeginInvoke(
                    new Action(() =>
                    {
                        Count.Enabled = false;
                    }
                    ));
            }
            else if (btn == "status")
            {
                BtnStatus.BeginInvoke(
                   new Action(() =>
                   {
                       BtnStatus.Enabled = false;
                   }
                   ));
            }
            else
            {
                Btn_Train.BeginInvoke(
                    new Action(() =>
                    {
                        Btn_Train.Enabled = false;
                    }
                    ));
            }
        }

        public void EnableBtn(string btn)
        {
            if (btn == "count")
            {
                Count.BeginInvoke(
                    new Action(() =>
                    {
                        Count.Enabled = true;
                    }
                    ));
            }
            else if (btn == "status")
            {
                BtnStatus.BeginInvoke(
                   new Action(() =>
                   {
                       BtnStatus.Enabled = true;
                   }
                   ));
            }
            else
            {
                Btn_Train.BeginInvoke(
                    new Action(() =>
                    {
                        Btn_Train.Enabled = true;
                    }
                    ));
            }
        }
        

        public Form GetForm()
        {
            return this;
        }

        private void BtnTrain_Click(object sender, EventArgs e)
        { 
            if (bitmap != null)
            {
                PictureViewer pictureViewer = new PictureViewer("train", bitmap);
                pictureViewer.SetBitmap(bitmap);
                pictureViewer.Show();
            } else
            {
                MessageBox.Show("Buddy, No Image to train. Please add an Image", "No Image");
            }
        }

       

        public bool isConnectedToInternet()
        {
            string host = "http://www.c-sharpcorner.com";
            bool result = false;
            Ping p = new Ping();

            try
            {
                PingReply reply = p.Send(host, 3000);

                if (reply.Status == IPStatus.Success)
                    return true;

            }
            catch { }
            return result;
        }

        private void Btn_Train_Click(object sender, EventArgs e)
        {
            ProgressForm progressForm = new ProgressForm("Copy");
            progressForm.setForm1(this);
            progressForm.Show();
        }

        private void BtnStatus_Click(object sender, EventArgs e)
        {
            ProgressForm progressForm = new ProgressForm("Status");
            progressForm.setForm1(this);
            progressForm.Show();
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PictureViewer : Form
    {
        private Bitmap bitmap;
        private Point startPos, currentPos;
        private Point newStartPos, newCurrentPos;
        private int resultCount;
        private int fileCount;
        private bool drawing;
        private int newHeight, newWidth;
        private int oldHeight, oldWidth;
        private int topX, topY;
        private int bottomX, bottomY;
        private int newTopx, newTopy;
        private int newBottomX, newBottomY;
        private string result;
        private string type;
        private string directory;
        List<Rectangle> myRectangles = new List<Rectangle>();
        List<Rectangle> resultRects = new List<Rectangle>();
        public PictureViewer(string type, Bitmap bitmap)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.DoubleBuffered = true;
            this.type = type;
            this.bitmap = bitmap;
            LblResult.Hide();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            oldHeight = ImageBox.Height;
            oldWidth = ImageBox.Width;
            ImageBox.Image = bitmap;
            ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            directory = Directory.GetCurrentDirectory();

            if (type == "result")
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MinimumSize = Size.Empty;
                this.MinimizeBox = this.MaximizeBox = true;
                BtnDone.Hide();
                BtnReset.Hide();
                LblResult.Show();
                ImageBox.Width = this.Width = bitmap.Width;
                ImageBox.Height = this.Height = bitmap.Height;
                ImageBox.Dock = DockStyle.None;
                ImageBox.Anchor = AnchorStyles.None;
                //  ImageBox.Width = bitmap.Width;
                //ImageBox.Height = bitmap.Height;

                Console.WriteLine("scalebitmap" + ImageBox.Width.ToString() + "x" + ImageBox.Height.ToString());
            }
        }

        private Rectangle GetRectangle()
        {
            topX = Math.Min(startPos.X, currentPos.X);
            topY = Math.Min(startPos.Y, currentPos.Y);
            bottomX = Math.Abs(startPos.X - currentPos.X);
            bottomY = Math.Abs(startPos.Y - currentPos.Y);
            Rectangle rect = new Rectangle(topX, topY, bottomX, bottomY);
            return rect;
        }

        private void ImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPos = startPos = e.Location;
                drawing = true;
                ImageBox.Invalidate();
            }
        }

        private void ImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                Rectangle rectangle = GetRectangle();
                if (rectangle.Width > 0 && rectangle.Height > 0) myRectangles.Add(rectangle);
                ImageBox.Invalidate();
            }
        }

        private void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) ImageBox.Invalidate();
        }

        private void ImageBox_Resize(object sender, EventArgs e)
        {

        }

        private void PictureViewer_Load(object sender, EventArgs e)
        {
            if (type == "result")
            {
                ShowResult();
            }
        }

        private void ImageBox_Click(object sender, EventArgs e)
        {

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            myRectangles.Clear();
            ImageBox.Invalidate();
        }

        private void ImageBox_Paint(object sender, PaintEventArgs e)
        {
            if (type == "train")
            {
                if (myRectangles.Count > 0) e.Graphics.DrawRectangles(Pens.Red, myRectangles.ToArray());
                if (drawing) e.Graphics.DrawRectangle(Pens.Red, GetRectangle());
            }
            else
            {
                if (resultRects.Count > 0) e.Graphics.DrawRectangles(Pens.Red, resultRects.ToArray());
            }
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            try
            {
                saveImage();
                saveAnnotation();
                MessageBox.Show("Image Ready for training", "Report");
                this.Dispose();
            }catch(Exception error)
            {
                Console.WriteLine(error.StackTrace);
                MessageBox.Show("Sorry buddy, Something not working. Try again", "Error");
            }
        }

        private void saveImage()
        {
            Bitmap bitmap = new Bitmap(ImageBox.Image);
            int width = ImageBox.Width;
            int height = ImageBox.Height;
            Console.WriteLine(width.ToString() + "x" + height.ToString());
            Bitmap resized = new Bitmap(bitmap, new Size(width, height));
            string destiny = directory + @"\nanonets-pedestrian-detection\images\";
            DirectoryInfo dir = new DirectoryInfo(destiny);
            fileCount = dir.GetFiles().Length;
            resized.Save(destiny + fileCount.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void saveAnnotation()
        {
            string destiny = directory + @"\nanonets-pedestrian-detection\annotations\json\";
            string annotbegin = "[";
            StringBuilder annotMiddle = new StringBuilder("", 50);
            string annotEnd = "]";
            string json;
            string ymax, xmax, ymin, xmin;
            int count = 0;


            foreach (Rectangle rect in myRectangles)
            {
                count++;

                ymax = rect.Bottom.ToString();
                xmax = rect.Right.ToString();
                ymin = rect.Top.ToString();
                xmin = rect.Left.ToString();
                annotMiddle.Append("{" + (char)34 + "bndbox" + (char)34 + ": " + "{" + (char)34 + "ymax" + (char)34 + ": " + ymax + ", " + (char)34 + "xmax" + (char)34 + ": " + xmax + ", " + (char)34 + "ymin" + (char)34 + ": " + ymin + ", " + (char)34 + "xmin" + (char)34 + ": " + xmin + "}, " + (char)34 + "name" + (char)34 + ": " + (char)34 + "pedestrian" + (char)34 + "}");

                if (count == myRectangles.Count)
                {
                    annotMiddle.Append(annotEnd);
                }
                else
                {
                    annotMiddle.Append(", ");
                }
            }

            using (StreamWriter writer = new StreamWriter(destiny + fileCount.ToString() + ".json"))
            {
                writer.WriteLine(annotbegin + annotMiddle);
                writer.Close();
            }
        }

        public void SetBitmap(Bitmap bitmap)
        {
           /* this.bitmap = bitmap;
            ImageBox.Size = this.Size;
            ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ImageBox.Image = bitmap;*/
        }

        public void setResult(string result)
        {
            this.result = result;

        }

        public void SetResultCount(int resultCount)
        {
            this.resultCount = resultCount;
        }

        private void ShowResult()
        {
            int x, y, width, height;
            CrowdJson crowdJson = JsonConvert.DeserializeObject<CrowdJson>(result);

            for (int i = 0; i < crowdJson.result[0].prediction.Count; i++)
            {
                x = crowdJson.result[0].prediction[i].xmin;
                y = crowdJson.result[0].prediction[i].ymin;
                width = Math.Abs(crowdJson.result[0].prediction[i].xmax - x);
                height = Math.Abs(crowdJson.result[0].prediction[i].ymax - y);

                resultRects.Add(new Rectangle(x, y, width, height));
            }
            LblResult.Text = "Crowd Count: " + resultCount.ToString();
        }
    }
}

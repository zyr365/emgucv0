using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.Util;
using System.Diagnostics;


namespace WindowsFormsApplication13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Mat img1 = null;
        Mat img2 = null;
        Mat img3 = null;
        Stopwatch sw = new Stopwatch();

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog lvse = new OpenFileDialog();
            lvse.Title = "选择图片";
            lvse.InitialDirectory = "";
            lvse.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            lvse.FilterIndex = 1;

            if (lvse.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = null;

                sw.Restart();

              // img1 = CvInvoke.Imread(lvse.FileName, Emgu.CV.CvEnum.LoadImageType.AnyColor);

                img1 = CvInvoke.Imread(lvse.FileName);


                imageBox1.Width = img1.Width / 6;
                imageBox1.Height = img1.Height / 6;
                imageBox1.Image = img1;

                sw.Stop();
                textBox1.Text = sw.ElapsedMilliseconds.ToString();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (img1 != null)
            {
                img2 = new Mat(img1.Rows, img1.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                textBox2.Text = null;
                sw.Reset();
                sw.Start();

                CvInvoke.CvtColor(img1, img2, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                imageBox2.Width = img2.Width / 6;
                imageBox2.Height = img2.Height / 6;
                imageBox2.Image = img2;

                sw.Stop();
                textBox2.Text = sw.ElapsedMilliseconds.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            OpenFileDialog lvse = new OpenFileDialog();
            lvse.Title = "选择图片";
            lvse.InitialDirectory = "";
            lvse.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            lvse.FilterIndex = 1;
            if (lvse.ShowDialog() == DialogResult.OK)
            {
                sw.Reset();
                sw.Start();

               // img3 = CvInvoke.Imread(lvse.FileName, Emgu.CV.CvEnum.LoadImageType.Grayscale);
                img3 = CvInvoke.Imread(lvse.FileName, Emgu.CV.CvEnum.ImreadModes.Grayscale);
                imageBox3.Width = img3.Width / 6;
                imageBox3.Height = img3.Height / 6;
                imageBox3.Image = img3;

                sw.Stop();
                textBox3.Text = sw.ElapsedMilliseconds.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            img1 = null;
            img2 = null;
            img3 = null;
            imageBox1.Image = null;
            imageBox2.Image = null;
            imageBox3.Image = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace circle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //原始大小(半徑3750) * 10%
            int x;
            int y;
            int left = 20, top = 20;
            int right = 770, bot = 770;   


            //circle
            int len = (right - left) / 2;  //radius 3750
            int len2 = (bot - top) / 2;    //radius 3750
            int centerX = left + len, centerY = top + len2;


            for (double i = 0.033; i <= 360; i += 0.033)   //1 pixel = 0.04 millimeters (0.033 deg)
            {
                double degrees = i;
                double radians = 1 * degrees * (Math.PI / 180);


                x = centerX + (int)(len * Math.Cos(radians));
                y = centerY + (int)(len2 * Math.Sin(radians));

               //pictureBox1原始大小(9000 x 8000) * 10%
                pictureBox1.Width = 900;
                pictureBox1.Height = 800;

               
                e.Graphics.FillRectangle(Brushes.White, x, y, 1, 1); // single pixel drawing  
            }
        }
       

        public static Bitmap PercentImage(Image srcImage, double percent)
        {
            int newH = int.Parse(Math.Round(srcImage.Height * percent).ToString());
            int newW = int.Parse(Math.Round(srcImage.Width * percent).ToString());

            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                g.InterpolationMode = InterpolationMode.Default;
                g.DrawImage(srcImage, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }


            catch (Exception)
            {
                return null;
            }
        }

        
    }
}

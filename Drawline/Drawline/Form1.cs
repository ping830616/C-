using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bitmap_graphics_imageprocessing
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox.ClientSize.Width,
                                pictureBox.ClientSize.Height,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        Point p1 = new Point();
        Point p2 = new Point();
        Pen pen = new Pen(Color.Magenta, 10);

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p1 = e.Location;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                p2 = e.Location;
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawLine(pen, p1, p2);
                pictureBox.Invalidate();
                g.Dispose();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            pictureBox.BackColor = Color.Aqua;
            e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
        }
    }
}

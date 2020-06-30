using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            Bitmap drawingSurface = new Bitmap(1000, 1000);
            Graphics GFX = Graphics.FromImage(drawingSurface);

            GFX.FillEllipse(Brushes.Red, 0, 0, 1000, 1000);
            GFX.FillEllipse(Brushes.White, 100, 100, 800, 800);
            GFX.FillEllipse(Brushes.Red, 200, 200, 600, 600);
            GFX.FillEllipse(Brushes.White, 300, 300, 400, 400);
            GFX.FillEllipse(Brushes.Red, 400, 400, 200, 200);

            pictureBox1.Image = drawingSurface;
        }
    }
}

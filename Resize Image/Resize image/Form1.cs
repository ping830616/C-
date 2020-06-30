﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        Image img;
        string[] exten = { " .PNG", " .JPEG", " .JPG", " .GIF", " .BMP" };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < exten.Length; i++)
                comboBox.Items.Add(exten[i]);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images | *.png;*.jpg;*.jpeg;*.gif; *.bmp";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                txtSelect.Text = ofd.FileName;
                img = Image.FromFile(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                txtSave.Text = fbd.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int w = Convert.ToInt32(txtW.Text), h = Convert.ToInt32(txtH.Text);
            img = Resize(img, w, h);
            ((Button)sender).Enabled = false;
            MessageBox.Show("image resized");
        }


        Image Resize(Image image, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);
            Graphics graphic = Graphics.FromImage(bmp);
            graphic.DrawImage(image, 0, 0, w, h);
            graphic.Dispose();

            return bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int dot = 0, slash = 0;
            for (int j = txtSelect.Text.Length - 1; j >= 0; j--)
                if (txtSelect.Text[j] == '.')
                    dot = j;
                else if (txtSelect.Text[j] == '\\')
                {
                    slash = j;
                    break;
                }

            img.Save(txtSave.Text + "\\" + txtSelect.Text.Substring(slash + 1, dot - slash - 1) + exten[comboBox.SelectedIndex]);
            ((Button)sender).Enabled = false;
            MessageBox.Show("image saved");
        }
    }
}

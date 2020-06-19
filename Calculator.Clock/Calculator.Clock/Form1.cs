using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication17
{
    public partial class Form1 : Form
    {

        public string mathematical, beforeValue;
        public Form1()  
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button buttonNumber = sender as Button;

            if (textBox1.Text == "0")
            {
                textBox1.Text = buttonNumber.Text;
            }
            else
            {
                textBox1.Text += buttonNumber.Text;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button buttonMathematical = sender as Button;
            mathematical = buttonMathematical.Text;
            beforeValue = textBox1.Text;
            textBox1.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Double GetBeforeValue = Double.Parse(beforeValue);
            Double GetAfterValue = Double.Parse(textBox1.Text);
            Double Result = 0;


            switch (mathematical)
            {
                case "+":
                    Result = GetBeforeValue + GetAfterValue;
                    break;
                case "-":
                    Result = GetBeforeValue - GetAfterValue;
                    break;
                case "*":
                    Result = GetBeforeValue * GetAfterValue;
                    break;
                case "/":
                    Result = GetBeforeValue / GetAfterValue;
                    break;
            }

            textBox1.Text = Result.ToString();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString("yyyy");
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;           
            label1.Text = String.Format("{0:00}:{1:00}:{2:00}", t.Hour, t.Minute, t.Second);
        }
    }
}

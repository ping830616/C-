using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arithmetic_calculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Class1.Cal myCal;
        Class1.CalAdd myCalAdd = new Class1.CalAdd();
        Class1.CalSub myCalSub = new Class1.CalSub();
        Class1.CalMul myCalMul = new Class1.CalMul();
        Class1.CalDiv myCalDiv = new Class1.CalDiv();

        private void Form1_Load(object sender, EventArgs e)
        {
            myCal = myCalAdd; // myCalAdd is taken as reference to myCal
            txtResult.ReadOnly = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            myCal = myCalAdd; // myCalAdd is taken as reference to myCal
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            myCal = myCalSub; // myCalSub is taken as reference to myCal
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            myCal = myCalMul; // myCalMul is taken as reference to myCal
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            myCal = myCalDiv; // myCalDiv is taken as reference to myCal
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myCal.X = int.Parse(textX.Text);
                myCal.Y = int.Parse(textY.Text);
                // execute the result value based on the calculation of addition, substraction, multiplication, and division
                // the result will be shown on the textbox
                txtResult.Text = myCal.Answer().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

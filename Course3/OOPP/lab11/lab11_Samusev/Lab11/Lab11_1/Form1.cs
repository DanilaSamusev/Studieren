using System;
using System.Windows.Forms;

namespace Lab11_1
{
    public partial class Form1 : Form
    {
        private double a;
        private double b;
        private double c;

        public Form1()
        {
            InitializeComponent();
        }

        public void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out a))
            {
                textBox1.Text = string.Empty;
            }
        }

        public void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            if (!double.TryParse(textBox2.Text, out b))
            {
                textBox1.Text = string.Empty;
            }
        }

        public void textBox3_TextChanged(object sender, System.EventArgs e)
        {
            if (!double.TryParse(textBox3.Text, out c))
            {
                textBox1.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            double D = Math.Pow(b, 2) - 4 * a * c;

            label5.Text = "Y1 = " + ((-b - Math.Sqrt(D)) / (2 * a)).ToString();
            label6.Text = "Y2 = " + ((+b + Math.Sqrt(D)) / (2 * a)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;

            label5.Text = string.Empty;
            label6.Text = string.Empty;

            a = 0;
            b = 0;
            c = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

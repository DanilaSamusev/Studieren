using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab11_2
{
    public partial class Form1 : Form
    {
        public Dictionary<string, double> dictionary = new Dictionary<string, double>();

        public Form1()
        {
            InitializeComponent();

            dictionary.Add("Фут", 400);
            dictionary.Add("Пуд", 16380);
            dictionary.Add("Унция", 28.35);
            dictionary.Add("Драхм", 448);
            dictionary.Add("Гран", 437.5);

            checkedListBox1.Items.AddRange(dictionary.Select(i => i.Key).ToArray());
        }

        public void CheckBox3_Checked(object sender, EventArgs e)
        {
            checkedListBox1.ForeColor = System.Drawing.Color.Red;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = radioButton2.Checked;
            label5.Visible = radioButton2.Checked;
            label6.Visible = radioButton2.Checked;
            textBox3.Visible = radioButton2.Checked;
            textBox4.Visible = radioButton2.Checked;
            textBox5.Visible = radioButton2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dictionary.TryGetValue(checkedListBox1.CheckedItems[0].ToString(), out double result);
                textBox2.Text = (double.Parse(textBox1.Text) * result).ToString();
            }
            else
            {
                double i = double.Parse(textBox5.Text);

                for (; i <= double.Parse(textBox4.Text); i += double.Parse(textBox3.Text))
                {
                    dictionary.TryGetValue(checkedListBox1.CheckedItems[0].ToString(), out double result);
                    string item = (i * result).ToString();
                    richTextBox1.Text += $"{item} \n";
                }
            }
        }
    }
}

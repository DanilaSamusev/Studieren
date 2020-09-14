using System;
using System.IO;
using System.Windows.Forms;

namespace Lab11_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            ToolStripMenuItem editItem = new ToolStripMenuItem("Редактировать");

            editItem.DropDownItems.Add(new ToolStripMenuItem("Вставить"));
            editItem.DropDownItems.Add(new ToolStripMenuItem("Удалить"));

            editItem.DropDownItems[0].Click += Insert_Click;
            editItem.DropDownItems[1].Click += Delete_Click;

            fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить"));
            fileItem.DropDownItems.Add(new ToolStripMenuItem("Открыть"));
            fileItem.DropDownItems.Add(new ToolStripMenuItem("Выход"));

            fileItem.DropDownItems[0].Click += Save_Click;
            fileItem.DropDownItems[1].Click += Load_Click;
            fileItem.DropDownItems[2].Click += Exit_Click;

            menuStrip1.Items.Add(fileItem);
            menuStrip1.Items.Add(editItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
            listBox1.Items.Add(label1.Text);
        }

        private void Save_Click(object sender, EventArgs e)
        {           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, listBox1.Text);
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            string filename = openFileDialog1.FileName;
            
            string fileText = File.ReadAllText(filename);
            listBox1.Items.Add(fileText);           
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}

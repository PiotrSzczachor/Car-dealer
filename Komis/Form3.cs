using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komis
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Komis\Komis\Images\AddPhoto.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {   
                MessageBox.Show("You need to fill all text boxes",
                                "Fill all text boxes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information); 
            }
            if(pictureBox1.ImageLocation == @"C:\Users\Piotr\source\repos\Komis\Komis\Images\AddPhoto.jpg")
            {
                MessageBox.Show("You need to add car photo",
                                "Add car photo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
                textBox5.Text != "")
            {
                Console.WriteLine(textBox5.Text);
                string engine = textBox3.Text.Replace(".", "").Replace(" ", "");
                string filename = textBox1.Text + textBox2.Text + textBox4.Text + engine + ".jpg";
                File.Copy(textBox5.Text, @"C:\Users\piotr\source\repos\Komis\Komis\Images\" + filename, true);
                label5.Visible = true;
                string car = textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text;
                car = car.Replace("\n", "").Replace("\r", "");
                TextWriter tsw = new StreamWriter(@"C:\Users\piotr\source\repos\Komis\Komis\database.txt", true);
                tsw.WriteLine(car);
                tsw.Close();
                button2.Enabled = false;
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    pictureBox1.Image = Image.FromFile(fileNames[0]);
                    textBox5.Text = fileNames[0];
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files(*.jpg, *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *bmp;";
            if(open.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            pictureBox1.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Komis\Komis\Images\AddPhoto.jpg");
            button2.Enabled = true;
            label5.Visible = false;
        }
    }
}


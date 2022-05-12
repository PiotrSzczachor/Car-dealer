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
            SellCar sellCar = new SellCar();
            sellCar.saveCar(textBox1, textBox2, textBox3, textBox4, textBox5, pictureBox1, button2, label5);
            
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
            SellCar sellCar = new SellCar();
            sellCar.addPhoto(textBox5, pictureBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellCar sellCar = new SellCar();
            sellCar.reset(textBox1, textBox2, textBox3, textBox4, textBox5, pictureBox1, button2, label5);
        }
    }
}


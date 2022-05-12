using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komis
{
    internal class SellCar
    {
        public void reset(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, PictureBox pictureBox1, Button button2, Label label5)
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

        public void addPhoto(TextBox textBox5, PictureBox pictureBox1)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files(*.jpg, *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        public void saveCar(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, PictureBox pictureBox1, Button button2, Label label5)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("You need to fill all text boxes",
                                "Fill all text boxes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            if (pictureBox1.ImageLocation == @"C:\Users\Piotr\source\repos\Komis\Komis\Images\AddPhoto.jpg")
            {
                MessageBox.Show("You need to add car photo",
                                "Add car photo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
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
    }
}

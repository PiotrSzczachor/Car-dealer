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
    public partial class Form2 : Form

    {
        string selectedCar;
        public Form2()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Visible = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\database.txt");
            string[] carsInfo = readText.Split('\n');
            foreach (string line in carsInfo)
            {
                string[] parts = line.Split(',');
                if (!comboBox1.Items.Contains(parts[0]))
                {
                    comboBox1.Items.Add(parts[0]);
                }
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string engine = comboBox3.Text.Replace(".", "").Replace(" ", "");
            string name = comboBox1.Text + comboBox2.Text + comboBox4.Text + engine + ".jpg";
            string filename = name.Replace("\n", "").Replace("\r", "");
            pictureBox1.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Komis\Komis\Images\" + filename);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            selectedCar = comboBox1.SelectedItem.ToString() + "," + comboBox2.SelectedItem.ToString() +
                        "," + comboBox3.SelectedItem.ToString() + "," + comboBox4.SelectedItem.ToString();
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox4.Items.Clear();
            comboBox4.Text = "";
            button2.Visible = true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\database.txt");
            string[] carsInfo = readText.Split('\n');
            foreach (string line in carsInfo)
            {
                if (line.Contains(','))
                {
                    string[] parts = line.Split(',');
                    if (!comboBox2.Items.Contains(parts[1]) && parts[0] == comboBox1.SelectedItem.ToString())
                    {
                        comboBox2.Items.Add(parts[1]);
                    }
                }
                
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\database.txt");
            string[] carsInfo = readText.Split('\n');
            foreach (string line in carsInfo)
            {
                if (line.Contains(','))
                {
                    string[] parts = line.Split(',');
                    if (!comboBox3.Items.Contains(parts[2]) && (parts[0] == comboBox1.SelectedItem.ToString() &&
                       parts[1] == comboBox2.SelectedItem.ToString()))
                    {
                        comboBox3.Items.Add(parts[2]);
                    }
                }

            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
            comboBox4.Items.Clear();
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\database.txt");
            string[] carsInfo = readText.Split('\n');
            foreach (string line in carsInfo)
            {
                if (line.Contains(','))
                {
                    string[] parts = line.Split(',');
                    if (!comboBox4.Items.Contains(parts[3]) && (parts[0] == comboBox1.SelectedItem.ToString() &&
                       parts[1] == comboBox2.SelectedItem.ToString() && parts[2] == comboBox3.SelectedItem.ToString()))
                    {
                        comboBox4.Items.Add(parts[3]);
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool carInFavorites = false;
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\favorites.txt");
            string[] carsInfo = readText.Split('\n');
            foreach(string s in carsInfo)
            {
                string ss = s.Replace("/n", "").Replace("\r", "");
                string car = selectedCar.Replace("\n", "").Replace("\r", "");
                if (ss == car)
                {
                    carInFavorites = true;
                }
            }
            if (!carInFavorites)
            {
                TextWriter tsw = new StreamWriter(@"C:\Users\piotr\source\repos\Komis\Komis\favorites.txt", true);
                tsw.WriteLine(selectedCar.Replace("\n", "").Replace("\r", ""));
                tsw.Close();
            }
            button2.Visible = false;
            
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }
    }
}

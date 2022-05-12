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
    internal class SearchCar
    {
        public void getBrandsNames(ComboBox comboBox1)
        {
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

        public void getModelsNames(ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3, ComboBox comboBox4)
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

        public void getEnginesTypes(ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3, ComboBox comboBox4)
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

        public void getCarColors(ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3, ComboBox comboBox4)
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

        public string getCar(PictureBox pictureBox1, ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3, ComboBox comboBox4, string selectedCar, Button button2)
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

            return selectedCar;
        }

        public void addCarToFavorites(string selectedCar, Button button2)
        {
            bool carInFavorites = false;
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\favorites.txt");
            string[] carsInfo = readText.Split('\n');
            foreach (string s in carsInfo)
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
    }
}

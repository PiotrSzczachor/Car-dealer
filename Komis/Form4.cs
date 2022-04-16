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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            button2.Enabled = false;
            button1.Enabled = false;
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\favorites.txt");
            string[] carsInfo = readText.Split('\n');
            foreach (string line in carsInfo)
            {
                listBox1.Items.Add(line);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string car = listBox1.GetItemText(listBox1.SelectedItem);
            string[] parts = car.Split(',');
            string brand = parts[0];
            string model = parts[1];
            string engine = parts[2].Replace(".", "").Replace(" ", "");
            string color = parts[3].Replace("\r", "");
            string filename = brand + model + color + engine + ".jpg";
            Console.WriteLine(car);
            pictureBox1.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Komis\Komis\Images\" + filename);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            button2.Enabled = true;
            button1.Enabled = true;
            listBox2.Items.Clear();
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\testdrives.txt");
            string[] carsInfo = readText.Split('\n');
            foreach (string line in carsInfo)
            {
                if (line.Contains(car.Replace("\n", "").Replace("\r", "")))
                {
                    string[] parts_ = line.Split(',');
                    listBox2.Items.Add(parts_[4]);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string carToRemove = listBox1.SelectedItems[0].ToString().Replace("\n", "").Replace("\r", "");
            Console.WriteLine(carToRemove);
            string fileName = @"C:\Users\piotr\source\repos\Komis\Komis\favorites.txt";
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(fileName).Where(l => l != carToRemove);
            File.WriteAllLines(tempFile, linesToKeep);
            File.Delete(fileName);
            File.Move(tempFile, fileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string car  = listBox1.SelectedItems[0].ToString().Replace("\n", "").Replace("\r", "");
            string date = monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy").Replace("\n", "").Replace("\r", "");
            string writeToFile = car + "," + date;
            bool isReserved = false;
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\testdrives.txt");
            string[] carsInfo = readText.Split('\n');
            foreach (string line in carsInfo)
            {
                if (line.Contains(writeToFile.Replace("\n", "").Replace("\r", "")))
                {
                    isReserved = true;
                }

            }
            if (isReserved)
            {
                MessageBox.Show("This date is not available for this car. You need to choose another one",
                                "Date is not available",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                TextWriter tsw = new StreamWriter(@"C:\Users\piotr\source\repos\Komis\Komis\testdrives.txt", true);
                tsw.WriteLine(writeToFile.Replace("\n", "").Replace("\r", ""));
                tsw.Close();
                listBox2.Items.Clear();
                string readText_ = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\testdrives.txt");
                string[] carsInfo_ = readText_.Split('\n');
                foreach (string line in carsInfo_)
                {
                    if (line.Contains(car.Replace("\n", "").Replace("\r", "")))
                    {
                        string[] parts_ = line.Split(',');
                        listBox2.Items.Add(parts_[4]);
                    }

                }
            }
        }
    }
}

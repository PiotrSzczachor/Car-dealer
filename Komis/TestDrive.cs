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
    internal class TestDrive
    {
        public void bookTestDrive(ListBox listBox1, MonthCalendar monthCalendar1, ListBox listBox2)
        {
            string car = listBox1.SelectedItems[0].ToString().Replace("\n", "").Replace("\r", "");
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

        public void deleteFromFavorites(ListBox listBox1)
        {
            string carToRemove = listBox1.SelectedItems[0].ToString().Replace("\n", "").Replace("\r", "");
            Console.WriteLine(carToRemove);
            string fileName = @"C:\Users\piotr\source\repos\Komis\Komis\favorites.txt";
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(fileName).Where(l => l != carToRemove);
            File.WriteAllLines(tempFile, linesToKeep);
            File.Delete(fileName);
            File.Move(tempFile, fileName);
            listBox1.Items.Clear();
            string readText = File.ReadAllText(@"C:\Users\piotr\source\repos\Komis\Komis\favorites.txt");
            string[] carsInfo = readText.Split('\n');
            foreach (string line in carsInfo)
            {
                listBox1.Items.Add(line);
            }
        }


        public void changeCurrentlyWatchingCar(ListBox listBox1, PictureBox pictureBox1, Button button1, Button button2, ListBox listBox2)
        {
            string car = listBox1.GetItemText(listBox1.SelectedItem);
            if (car.Contains(","))
            {
                string[] parts = car.Split(',');
                string brand = parts[0];
                string model = parts[1];
                string engine = parts[2].Replace(".", "").Replace(" ", "");
                string color = parts[3].Replace("\r", "");
                string filename = brand + model + color + engine + ".jpg";
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
        }
    }
}

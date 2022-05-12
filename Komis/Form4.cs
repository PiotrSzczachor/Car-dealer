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
            TestDrive testDrive = new TestDrive();
            testDrive.changeCurrentlyWatchingCar(listBox1, pictureBox1, button1, button2, listBox2);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestDrive testDrive = new TestDrive();
            testDrive.deleteFromFavorites(listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestDrive testDrive = new TestDrive();
            testDrive.bookTestDrive(listBox1, monthCalendar1, listBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog(); ;
            this.Close();
        }
    }
}

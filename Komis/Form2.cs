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
            SearchCar searchCar = new SearchCar();
            button1.Enabled = false;
            button2.Visible = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            searchCar.getBrandsNames(comboBox1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchCar searchCar = new SearchCar();
            selectedCar = searchCar.getCar(pictureBox1, comboBox1, comboBox2, comboBox3, comboBox4, selectedCar, button2);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchCar searchCar = new SearchCar();
            searchCar.getModelsNames(comboBox1, comboBox2, comboBox3, comboBox4);
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchCar searchCar = new SearchCar();
            searchCar.getEnginesTypes(comboBox1, comboBox2, comboBox3, comboBox4);
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchCar searchCar = new SearchCar();
            searchCar.getCarColors(comboBox1, comboBox2, comboBox3, comboBox4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchCar searchCar = new SearchCar();
            searchCar.addCarToFavorites(selectedCar, button2);
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

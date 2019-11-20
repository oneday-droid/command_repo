using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunP
{
    public partial class WeatherForm : Form
    {
        
    
        public WeatherForm()
        {
            InitializeComponent();

            cityComboBox.Items.Add("Perm");
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            IWeather weather = new OpenMapWeather();
            resultTextBox.Text= weather.GetWeather("Perm");
        }        
    }
}

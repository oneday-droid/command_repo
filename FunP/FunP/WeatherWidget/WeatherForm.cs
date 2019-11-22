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
    public partial class WeatherForm : Form, IView
    {
        WeatherPresenter presenter;

        public WeatherForm()
        {
            presenter = new WeatherPresenter();
            presenter.AttachView(this);

            InitializeComponent();
            InitializeFields();
        }

        public void InitializeFields()
        {
            cityComboBox.Items.Clear();

            cityComboBox.Items.Add("Perm");
            cityComboBox.Items.Add("Moscow");
            cityComboBox.Items.Add("Novisibirsk");            
        }

        public void OnError(string message)
        {
            MessageBox.Show(message, "Error");
        }

        public void OnRequestResults(object message)
        {
            resultTextBox.Text = (string)message;
        }

        void getButton_Click(object sender, EventArgs e)
        {
            presenter.GetForecastForCity((string)cityComboBox.SelectedItem);
        }
    }
}

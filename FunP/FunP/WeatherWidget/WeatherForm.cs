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
        BasePresenter presenter;

        public WeatherForm()
        {
            presenter = new WeatherPresenter();
            //presenter.AttachView(this);

            InitializeComponent();

            cityComboBox.Items.Add("Perm");
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            presenter.SendRequest((string)cityComboBox.SelectedItem);
        }     
   
        public void OnRequest(string message)
        {
            resultTextBox.Text = message;
        }
    }
}

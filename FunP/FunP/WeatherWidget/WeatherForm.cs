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
            IList<string> list = presenter.GetValues();
            cityComboBox.Items.AddRange(list.ToArray());
        }

        

        public void OnError(string message)
        {
            MessageBox.Show(message, "Error");
        }

        public void OnRequestResults(object message)
        {
            resultTextBox.Text = (string)message;
        }

        public void SetPresenter(Presenter presenter)
        {
            throw new NotImplementedException();
        }

        void getButton_Click(object sender, EventArgs e)
        {
            presenter.GetForecastForCity((string)cityComboBox.SelectedItem);
        }
    }
}

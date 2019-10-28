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
    public partial class FunP : Form
    {
        public FunP()
        {
            InitializeComponent();
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //здесь надо вытягивать список полей из презентера или модели
            List<string> list = new List<string>();
            list.Add("name");
            list.Add("age");
            list.Add("faculty");
            DataDialog dialog = new DataDialog();
            dialog.Text = "Add data";
            dialog.SetDataLabels(list);
            dialog.ShowDialog();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }
    }
}

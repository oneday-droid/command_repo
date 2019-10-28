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
    public partial class DataDialog : Form, IDialogView
    {
        public DataDialog()
        {
            InitializeComponent();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    
        public void SetDataLabels(List<string> list)
        {
            int count = list.Count;
            TextBox[] textBoxes = new TextBox[count];
            Label[] labels = new Label[count];

            for (int k = 0; k < count; k++)
            {
                labels[k] = new Label();
                labels[k].Text = list[k];
                flowLayoutPanel.Controls.Add(labels[k]);

                textBoxes[k] = new TextBox();
                flowLayoutPanel.Controls.Add(textBoxes[k]);                
            }
        }
    }
}

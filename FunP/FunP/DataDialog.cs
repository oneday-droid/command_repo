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
	TextBox[] textBoxesArr;
	Label[] labelsArr;
	int count;

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
    
        public void SetDataLabels(ITableLine labels)
        {
            count = labels.Count;
            textBoxesArr = new TextBox[count];
            labelsArr = new Label[count];

            for (int k = 0; k < count; k++)
            {
                labelsArr[k] = new Label();
                labelsArr[k].Text = labels[k].GetName();
                flowLayoutPanel.Controls.Add(labelsArr[k]);

                textBoxesArr[k] = new TextBox();
		textBoxesArr[k].Text = labels[k].GetValue();
                flowLayoutPanel.Controls.Add(textBoxesArr[k]);                
            }
        }

	public ITableLine GetData()
	{
            ITableLine list;

            for (int k = 0; k < count; k++)
                list.Add(new Pair(labelsArr[k].Text, textBoxesArr[k].Text));                
            
	    return list;
	}
    }
}

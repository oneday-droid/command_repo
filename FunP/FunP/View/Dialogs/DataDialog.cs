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
        private TextBox[] textBoxes;
        private Label[] labels;
        private TableValuesLine tableLine;
        private ITableDesc tableDesc;
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
    
        public void SetDataLabels(TableValuesLine tableLine, ITableDesc tableDesc)
        {
            this.tableLine = tableLine;
            this.tableDesc = tableDesc;

            var colNames = tableDesc.GetColNames(); //.GetColumnNames();
            var count = tableDesc.GetColsCount();

            textBoxes = new TextBox[count];
            labels = new Label[count];

            for (int k = 1; k < count; k++)
            {
                labels[k] = new Label();
                labels[k].Text = colNames[k];
                flowLayoutPanel.Controls.Add(labels[k]);

                textBoxes[k] = new TextBox();
                if(tableLine != null)
                {
                    textBoxes[k].Text = tableLine[k].ToString(); 
                }
                
                flowLayoutPanel.Controls.Add(textBoxes[k]);                
            }
        }

        public TableValuesLine GetDataLabels()
        {
            TableValuesLine newLine = new TableValuesLine();

            var count = tableDesc.GetColsCount();

            int ID = -1;

            if (tableLine != null)
                ID = (int)tableLine[0];

         
            newLine.Add(ID);
            

            for (int i=1; i < count; i++)
            {
                
                object value;
                Type type = tableDesc.GetColType(i);

                if (type == typeof(Int32) )
                {
                    value = Convert.ToInt32(textBoxes[i].Text);
                }
                else if(type == typeof(double))
                {
                    value = Convert.ToDouble(textBoxes[i].Text);
                }
                else //string
                {
                    value = Convert.ToString(textBoxes[i].Text);
                }

                newLine.Add(value);
            }

            return newLine;
        }
    }
}

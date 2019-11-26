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
        private BaseTableStruct tableStruct;

        public DataDialog()
        {
            InitializeComponent();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            int ID = -1;
            if (tableLine != null)
                ID = (int)tableLine[0];

            //set new values to tableLine if user clicked accept
            //otherwise GetData() returns not changed tableLine
            tableLine = new TableValuesLine();
            tableLine.Add(ID);

            var count = tableDesc.GetColsCount();
            for (int i = 1; i < count; i++)
            {
                object value;
                Type type = tableDesc.GetColType(i);

                if (type == typeof(Int32))
                {
                    value = Convert.ToInt32(textBoxes[i].Text);
                }
                else if (type == typeof(double))
                {
                    value = Convert.ToDouble(textBoxes[i].Text);
                }
                else //string
                {
                    value = Convert.ToString(textBoxes[i].Text);
                }

                tableLine.Add(value);
            }
        }
    
        public void SetData(TableValuesLine tableLine, BaseTableStruct tableStruct)
        {
            this.tableLine = tableLine;
            this.tableStruct = tableStruct;

            var colCount = tableStruct.GetColCount();

            textBoxes = new TextBox[colCount];
            labels = new Label[colCount];

            for (int k = 1; k < colCount; k++)
            {
                labels[k] = new Label();
                labels[k].Text = tableStruct.GetColName(k);
                flowLayoutPanel.Controls.Add(labels[k]);

                textBoxes[k] = new TextBox();
                if(tableLine != null)
                {
                    textBoxes[k].Text = tableLine[k].ToString(); 
                }
                
                flowLayoutPanel.Controls.Add(textBoxes[k]);                
            }
        }

        public TableValuesLine GetData()
        {
            TableValuesLine newLine = new TableValuesLine();

            var colCount = tableStruct.GetColCount();

            int ID = -1;

            //TODO то есть, после new может быть null?
            if (tableLine != null)
                ID = (int)tableLine[0];

            //TODO а если ID не нулевой столбец?
            newLine.Add(ID);
            
            //заполнение тоже переделать
            for (int i=1; i < colCount; i++)
            {
                object value;
                Type type = tableStruct.GetColType(i);

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
            return tableLine;
        }
    }
}

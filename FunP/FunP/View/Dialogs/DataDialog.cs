using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace FunP
{
    public partial class DataDialog : Form, IDialogView
    {
        private TextBox[] textBoxes;
        private Label[] labels;
        private TableValuesLine tableLine;
        private BaseTableStruct tableStruct;
        private int idColIndex;
        public DataDialog()
        {
            InitializeComponent();

            idColIndex = 0;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    
        public void SetDataLabels(TableValuesLine tableLine, BaseTableStruct tableStruct)
        {
            this.tableLine = tableLine;
            this.tableStruct = tableStruct;

            var colCount = tableStruct.GetColCount();

            textBoxes = new TextBox[colCount];
            labels = new Label[colCount];

            for (int k = 0; k < colCount; k++)
            {
                if (tableStruct.GetColName(k) == BaseTableStruct.IDColName)
                {
                    idColIndex = k;
                    continue;
                }
                    
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

        public TableValuesLine GetDataLabels()
        {
            TableValuesLine newLine = new TableValuesLine();
            if(tableLine == null)
            {
                //exception
                throw new ArgumentException();
            }

            var colCount = tableStruct.GetColCount();

            int ID = (int)tableLine[idColIndex];
            newLine.Add(ID);
            
            for (int i=0; i < colCount; i++)
            {
                if (i == idColIndex)
                    continue;

                var type = tableStruct.GetColType(i);
                var converter = TypeDescriptor.GetConverter(type);
                object value = converter.ConvertFromString(null, CultureInfo.CurrentCulture, textBoxes[i].Text);
                
                newLine.Add(value);
            }

            return newLine;
        }
    }
}

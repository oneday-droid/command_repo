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

        private int count;
        private string tableName;
        private ITableLine tableLine;
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
    
        public void SetData(ITableLine tableLine)
        {
            this.tableLine = tableLine;
            var colNames = tableLine.GetColumnNames();
            count = colNames.Count;
            tableName = tableLine.GetTableName();

            textBoxes = new TextBox[count];
            labels = new Label[count];

            for (int k = 1; k < count; k++)
            {
                labels[k] = new Label();
                labels[k].Text = colNames[k];
                flowLayoutPanel.Controls.Add(labels[k]);

                textBoxes[k] = new TextBox();
                textBoxes[k].Text = tableLine.GetValue(colNames[k]).ToString();
                flowLayoutPanel.Controls.Add(textBoxes[k]);                
            }
        }

        public ITableLine GetData()
        {
            ITableLine newLine;

            if (tableName == "Students")
            {
                newLine = new StudentLine();
            }
            else if (tableName == "Faculties")
            {
                newLine = new FacultyLine();
            }
            else //if (tableName == "University")
            {
                newLine = new UniversityLine();
            }

            for (int i=1; i < count; i++)
            {
                //TODO как-то проверять введенные значения?
                object value;
                Type type = tableLine.GetValueType(labels[i].Text);

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

                newLine.SetValue(labels[i].Text, value);
            }

            return newLine;
        }
    }
}

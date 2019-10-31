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
    
        public void SetDataLabels(ITableLine tableLine)
        { 
            var colNames = tableLine.GetColumnNames();
            count = colNames.Count;
            tableName = tableLine.GetTableName();

            textBoxes = new TextBox[count];
            labels = new Label[count];

            for (int k = 0; k < count; k++)
            {
                labels[k] = new Label();
                labels[k].Text = colNames[k];
                flowLayoutPanel.Controls.Add(labels[k]);

                textBoxes[k] = new TextBox();
                textBoxes[k].Text = tableLine.GetValue(colNames[k]);
                flowLayoutPanel.Controls.Add(textBoxes[k]);                
            }
        }

        public ITableLine GetDataLabels()
        {
            ITableLine newLine;

            if (tableName == "Student")
            {
                newLine = new StudentLine();
            }
            else if (tableName == "Faculty")
            {
                newLine = new FacultyLine();
            }
            else //(tableName == "University")
            {
                newLine = new UniversityLine();
            }

            for (int i=0; i < count; i++)
            {
                //TODO как-то проверять введенные значения?
                newLine.SetValue(labels[i].Text, textBoxes[i].Text);
            }

            return newLine;
        }
    }
}

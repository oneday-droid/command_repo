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
    public partial class FunP : Form, IView
    {
        private IPresenter presenter;

        public FunP()
        {
            InitializeComponent();
        }

        public void SetPresenter(IPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void InitializeFields()
        {
            firstIndexText.Text = "0";
            lastIndexText.Text = "50";
            SetRequestSheet();
            SetNewLineTypeSheet();
        }

        private void SetRequestSheet()
        {
            requestSheetList.Items.Clear();

            var sheet = presenter.GetRequestSheet();

            foreach(var value in sheet)
            {
                requestSheetList.Items.Add(value);
            }
        }

        private void SetNewLineTypeSheet()
        {
            newLineTypeList.Items.Clear();

            newLineTypeList.Items.Add("University");
            newLineTypeList.Items.Add("Faculty");
            newLineTypeList.Items.Add("Student");
        }

        public void OnError(string message)
        {
            MessageBox.Show(message, "Ошибка");
        }

        public void OnRequestResults(List<ITableLine> table)
        {            
            if (table.Count != 0)
            {
                List<string> labels = table[0].GetColumnNames();
                dataGridView.ColumnCount = labels.Count;
                for (int k = 0; k < labels.Count; k++)
                    dataGridView.Columns[k].Name = labels[k];

                for (int k = 0; k < table.Count; k++)
                {
                    string [] row = new string [labels.Count];
                    for (int f = 0; f < labels.Count; f++)
                        row[f] = table[k].GetValue(labels[f]);

                    dataGridView.Rows.Add(row);
                }
            }
        }

        public void OnLineAdd(ITableLine lineToAdd)
        {
            //TODO добавлять строку в listBox??
        }

        public void OnLineEdit(ITableLine lineToEdit, ITableLine newState)
        {
            //TODO редактировать строку в listBox??
        }

        public void OnLineDelete(ITableLine lineToDelete)
        {
            //TODO удалять строку в listBox??
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {
            if (requestSheetList.SelectedIndex == -1)
            {
                //TODO сообщение "не выбран запрос"
                return;
            }

            var firstIndex = Convert.ToInt32(firstIndexText.Text);
            var lastIndex = Convert.ToInt32(lastIndexText.Text);

            var pairs = new List<Pair>();
            pairs.Add(new Pair("Возраст", "26"));
            pairs.Add(new Pair("Оценка", "4.5"));

            var request = requestSheetList.SelectedItem.ToString();

            presenter.SendRequest(request, firstIndex, lastIndex, pairs);
        }

        private List<string> GetColumnsName()
        {
            List<string> labels = new List<string>();
            for (int k = 0; k  < dataGridView.Columns.Count; k++)        
                labels.Add(dataGridView.Columns[k].Name);
            return labels;
        }

        private TableLine SelectedRowToTableLine(DataGridViewCellCollection row)
        {
            List<string> labels = GetColumnsName();
            List<Pair> list = new List<Pair>();
            
            for (int k = 0; k < row.Count; k++)
                list.Add(new Pair(labels[k], row[k].Value.ToString()));

            TableLine line = new TableLine(list);

            return line;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var rows = dataGridView.SelectedRows;
            
            if (rows.Count == 0)
            {
                //TODO сообщение "выберите строку значений для редактирования"
                return;
            }

            var row = rows[0].Cells;
            TableLine line = SelectedRowToTableLine(row);
            if (line.GetTableName() == "CustomTable")
            {
                //TODO подумать, как редактировать бд используя нетипизированные выходные данные, а пока return
               // return;
            }

            DataDialog dialog = new DataDialog();
            dialog.Text = "Edit data";
            dialog.SetData(line);
             
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var newLine = dialog.GetData();
                presenter.SQLLineEdit(line, newLine);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var rows = dataGridView.SelectedRows;

            if (rows.Count == 0)
            {
                //TODO сообщение "выберите строку значений для редактирования"
                return;
            }
                       
            var row = rows[0].Cells;
            TableLine line = SelectedRowToTableLine(row);
            if (line.GetTableName() == "CustomTable")
            {
                //TODO подумать, как редактировать бд используя нетипизированные выходные данные, а пока return
                // return;
            }

            presenter.SQLLineDelete(line);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(newLineTypeList.SelectedIndex < 0)
            {
                //TODO сообщение "выберите строку значений для редактирования"
                return;
            }

            var line = newLineTypeList.SelectedItem.ToString();
            ITableLine tableLine;

            if(line == "Student")
            {
                tableLine = new StudentLine();
            }
            else if(line == "Faculty")
            {
                tableLine = new FacultyLine();
            }
            else if(line == "University")
            {
                tableLine = new UniversityLine();
            }
            else
            {
                //TODO не то пальто. Вообще, enum был запилить в TableLine, но tableName - string.
                return;
            }

            DataDialog dialog = new DataDialog();
            dialog.Text = "Add data";
            dialog.SetData(tableLine);
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var lineToAdd = dialog.GetData();
                presenter.SQLLineAdd(lineToAdd);
            }
        }


        private void FunP_Load(object sender, EventArgs e)
        {

        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML document (*.xml)|*.xml|PDF files (*.pdf)|*.pdf|HTML document (*.html)|*.html|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            if ( saveFileDialog.ShowDialog() == DialogResult.OK )
                presenter.SaveAs(saveFileDialog.FileName);
        }
    }
}

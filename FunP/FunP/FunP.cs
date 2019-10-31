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

        public void OnRequestResults(List<ITableLine> table)
        {
            reqResultsList.Items.Clear();

            var columnNames = table[0].GetColumnNames();
            var colCount = columnNames.Count;
            var maxColLen = new List<int>();

            //базовая длина = длине заголовка колонки
            for (int i = 0; i < colCount; i++)
            {
                maxColLen.Add(0);
                var value = Convert.ToInt32(columnNames[i].Length);
                if (value > maxColLen[i])
                {
                    maxColLen[i] = value;
                }
            }

            //поиск максимальной длины из значений по каждой колонке 
            foreach (var line in table)
            {
                for (int i = 0; i < colCount; i++)
                {
                    var value = Convert.ToInt32(line.GetValue(columnNames[i]).Length);
                    if (value > maxColLen[i])
                    {
                        maxColLen[i] = value;
                    }
                }
            }

            //добавление заголовка
            var edge = " | ";
            string lineToAdd = "";
            for (int i = 0; i < colCount; i++)
            {
                var value = columnNames[i];
                var valueSpaces = maxColLen[i] - value.Length;

                lineToAdd += value;
                for (int j = 0; j < valueSpaces; j++)
                {
                    lineToAdd += " ";
                }
                if (i != colCount - 1)
                {
                    lineToAdd += edge;
                }
            }
            reqResultsList.Items.Add(lineToAdd);

            //подсчет максимальной длины строки и добавление разделителя заголовка
            int lineSize = 0;
            foreach (var value in maxColLen)
            {
                lineSize += value;
            }
            lineSize += (colCount - 1) * edge.Length;

            lineToAdd = "";
            for (int i = 0; i < lineSize; i++)
            {
                lineToAdd += "-";
            }
            reqResultsList.Items.Add(lineToAdd);

            //добавление строк значений
            foreach (var line in table)
            {
                lineToAdd = "";
                for (int i = 0; i < colCount; i++)
                {
                    var value = line.GetValue(columnNames[i]);
                    var valueSpaces = maxColLen[i] - value.Length;

                    lineToAdd += value;
                    for (int j = 0; j < valueSpaces; j++)
                    {
                        lineToAdd += " ";
                    }

                    if (i != colCount - 1)
                    {
                        lineToAdd += edge;
                    }
                }

                reqResultsList.Items.Add(lineToAdd);
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

            var request = (string)requestSheetList.SelectedItem;

            presenter.SendRequest(request, firstIndex, lastIndex, pairs);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var index = reqResultsList.SelectedIndex;
            index -= 2;                                     //смещение индекса, тк в первых двух строках заголовок и разделитель

            if (index < 0)
            {
                //TODO сообщение "выберите строку значений для редактирования"
                return;
            }

            var line = presenter.GetRequestResultLine(index);

            if (line.GetTableName() == "CustomTable")
            {
                //TODO подумать, как редактировать бд используя нетипизированные выходные данные, а пока return
                return;
            }

            DataDialog dialog = new DataDialog();
            dialog.Text = "Edit data";
            dialog.SetDataLabels(line);
            var dialRes = dialog.ShowDialog();
            if(dialRes == DialogResult.OK)
            {
                var newLine = dialog.GetDataLabels();
                presenter.SQLLineEdit(line, newLine);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var index = reqResultsList.SelectedIndex;
            index -= 2;                                     //смещение индекса, тк в первых двух строках заголовок и разделитель

            if (index < 0)
            {
                //TODO сообщение "выберите строку значений для редактирования"
                return;
            }

            var line = presenter.GetRequestResultLine(index);

            if (line.GetTableName() == "CustomTable")
            {
                //TODO подумать, как редактировать бд используя нетипизированные выходные данные, а пока return
                return;
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

            var line = (string)newLineTypeList.SelectedItem;
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
            dialog.SetDataLabels(tableLine);
            var dialRes = dialog.ShowDialog();
            if (dialRes == DialogResult.OK)
            {
                var lineToAdd = dialog.GetDataLabels();
                presenter.SQLLineAdd(lineToAdd);
            }
        }


        private void FunP_Load(object sender, EventArgs e)
        {

        }
    }
}

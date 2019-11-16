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

        public void OnRequestResults(ITable table)
        {
            reqResultsList.Items.Clear();

            var columnNames = table.GetColNames();
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

            var rows = table.GetRowsCount();
            var cols = table.GetColsCount();
            //поиск максимальной длины из значений по каждой колонке 
            for (int i=0; i<table.GetRowsCount(); i++)
            {
                for(int j=0;j<table.GetColsCount(); j++)
                {
                    var valueLen = table[i][j].ToString().Length;
                    if (valueLen > maxColLen[j])
                    {
                        maxColLen[j] = valueLen;
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
            for (int i = 0; i < table.GetRowsCount(); i++)
            {
                lineToAdd = "";
                for (int j = 0; j < table.GetColsCount(); j++)
                {
                    var value = table[i][j].ToString();
                    var valueSpaces = maxColLen[j] - value.Length;

                    lineToAdd += value;

                    for (var k = 0; k < valueSpaces; k++)
                    {
                        lineToAdd += " ";
                    }

                    if (j != colCount - 1)
                    {
                        lineToAdd += edge;
                    }
                }

                reqResultsList.Items.Add(lineToAdd);
            }
        }

        public void OnLineAdd(TableValuesLine lineToAdd)
        {
            //TODO добавлять строку в listBox??
        }

        public void OnLineEdit(TableValuesLine lineToEdit, TableValuesLine newState)
        {
            //TODO редактировать строку в listBox??
        }

        public void OnLineDelete(TableValuesLine lineToDelete)
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

            var reqParams = new List<object>();

            int age = 26;
            double avgGrade = 4.5;

            reqParams.Add(age);
            reqParams.Add(avgGrade);

            var request = (string)requestSheetList.SelectedItem;

            presenter.SendRequest(request, firstIndex, lastIndex, reqParams);
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

            var tableName = presenter.GetRequestResultTableName();
            var line = presenter.GetRequestResultLine(index);
            TableDesc tableDesc;

            
            
            if(tableName == "Students")
            {
                tableDesc = new StudentTableDesc();
            }
            else if (tableName == "Faculties")
            {
                tableDesc = new FacultyTableDesc();
            }
            else if (tableName == "Universities")
            {
                tableDesc = new UniversityTableDesc();
            }
            else
            {
                //TODO подумать, как редактировать бд используя нетипизированные выходные данные, а пока return
                return;
            }

            DataDialog dialog = new DataDialog();
            dialog.Text = "Edit data";
            dialog.SetDataLabels(line, tableDesc);
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

            var tableName = presenter.GetRequestResultTableName();
            var line = presenter.GetRequestResultLine(index);

            if (tableName == "Default")
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

            var tableName = (string)newLineTypeList.SelectedItem;
            ITableDesc tableDesc;

            if(tableName == "Student")
            {
                tableDesc = new StudentTableDesc();
            }
            else if(tableName == "Faculty")
            {
                tableDesc = new FacultyTableDesc();
            }
            else if(tableName == "University")
            {
                tableDesc = new UniversityTableDesc();
            }
            else
            {
                //TODO не то пальто. Вообще, enum был запилить в TableLine, но tableName - string.
                return;
            }

            DataDialog dialog = new DataDialog();
            dialog.Text = "Add data";
            dialog.SetDataLabels(null, tableDesc);
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

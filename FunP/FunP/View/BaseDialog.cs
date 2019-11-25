using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{
    public partial class FunP : Form, IView
    {
        private Presenter presenter;

        public FunP()
        {
            InitializeComponent();
        }

        public void SetPresenter(Presenter presenter)
        {
            this.presenter = presenter;
        }

        public void InitializeFields()
        {
            firstIndexText.Text = "0";
            lastIndexText.Text = "50";
            SetRequestSheet();
            SetNewLineSheet();
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

        private void SetNewLineSheet()
        {
            newLineTypeList.Items.Clear();

            var sheet = presenter.GetDBTableNames();

            foreach (var value in sheet)
            {
                newLineTypeList.Items.Add(value);
            }
        }

        public void OnRequestResults(ITable table)
        {
            reqResultsList.Items.Clear();

            if (table == null)
            {
                reqResultsList.Items.Add("Запрос не вернул результатов.");
                return;
            }

            var columnNames = table.TableStruct.GetColNamesList();
            var rowCount = table.GetRowCount();
            var colCount = table.TableStruct.GetColCount();
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
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
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
            for (int i = 0; i < rowCount; i++)
            {
                lineToAdd = "";
                for (int j = 0; j < colCount; j++)
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
            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    var cmd = new SqlCommand();
            //    cmd.Connection = connection;
            //    cmd.CommandText = $"UPDATE Universities SET @Nam=@Value1 WHERE ID=8"; //, @Name2=@Value2, [@Name3]=@Value3

            //    var sqlParameter = new SqlParameter("@Value1", "qqq");
            //    cmd.Parameters.Add(sqlParameter);
            //    sqlParameter = new SqlParameter("@Value2", "www");
            //    cmd.Parameters.Add(sqlParameter);
            //    sqlParameter = new SqlParameter("@Value3", "235436");
            //    cmd.Parameters.Add(sqlParameter);

            //    sqlParameter = new SqlParameter("@Name1", "University name");
            //    cmd.Parameters.Add(sqlParameter);
            //    sqlParameter = new SqlParameter("@Name2", "City");
            //    cmd.Parameters.Add(sqlParameter);
            //    sqlParameter = new SqlParameter("@Name3", "[Year of foundation]");
            //    cmd.Parameters.Add(sqlParameter);

            //    if (cmd.ExecuteNonQuery() > 0)
            //    {
            //        string streg = "";
            //    }

            //}

            //return;



            if (requestSheetList.SelectedIndex == -1)
            {
                //TODO сообщение "не выбран запрос"
                return;
            }

            var firstIndex = Convert.ToInt32(firstIndexText.Text);
            var lastIndex = Convert.ToInt32(lastIndexText.Text);

            var request = (string)requestSheetList.SelectedItem;

            presenter.SendRequest(request, firstIndex, lastIndex, null);
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
            var tableStruct = presenter.GetTableStructByName(tableName);
            var line = presenter.GetRequestResultLine(index);

            //TODO подумать, как редактировать бд используя нетипизированные выходные данные, а пока return
            if (tableName == "Default")
                return;

            DataDialog dialog = new DataDialog();
            dialog.Text = "Edit data";
            dialog.SetDataLabels(line, tableStruct);
            var dialRes = dialog.ShowDialog();
            if(dialRes == DialogResult.OK)
            {
                var newLine = dialog.GetDataLabels();
                presenter.DBLineEdit(tableStruct, line, newLine);
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
            var tableStruct = presenter.GetTableStructByName(tableName);
            var line = presenter.GetRequestResultLine(index);

            //TODO подумать, как редактировать бд используя нетипизированные выходные данные, а пока return
            if (tableName == "Default")   
                return;

            presenter.DBLineDelete(tableStruct, line);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var index = newLineTypeList.SelectedIndex;
            if (index < 0)
            {
                //TODO сообщение "выберите строку значений для редактирования"
                return;
            }

            //повторно получает список (считается по-умолчанию, что вью не удаляет и не изменяет порядок в списке), но может изменить текст
            var dbTableNames = presenter.GetDBTableNames();
            //извлекает нужное имя по индексу
            var tableName = dbTableNames[index];
            //получает структуру строки для добавления
            var tableStruct = presenter.GetTableStructByName(tableName);    

            DataDialog dialog = new DataDialog();
            dialog.Text = "Add data";
            dialog.SetDataLabels(null, tableStruct);
            var dialRes = dialog.ShowDialog();
            if (dialRes == DialogResult.OK)
            {
                var lineToAdd = dialog.GetDataLabels();
                presenter.DBLineAdd(tableStruct, lineToAdd);
            }
        }


        private void FunP_Load(object sender, EventArgs e)
        {

        }
    }
}

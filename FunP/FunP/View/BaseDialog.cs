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
using System.Threading;

using FunP.View;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{
    public partial class FunP : Form, ITableView
    {
        private Presenter presenter;
        private ITranslator translator;

        private LanguageType language;

        private const string GetButtonDefaultText = "Get data";
        private const string EditButtonDefaultText = "Edit row";
        private const string RemoveButtonDefaultText = "Remove row";
        private const string AddButtonDefaultText = "Add row";
        private const string SaveButtonDefaultText = "Save as";
        private const string EditGroupDefaultText = "Edit";
        private const string AddGroupDefaultText = "Add";
        private const string RequestGroupDefaultText = "Request results";
        private const string FirstLineLabelDefaultText = "From";
        private const string LastLineLabelDefaultText = "to";
        private const string LanguageLabelDefaultText = "Choose language";
        private const string WeatherButtonDefaultText = "Weather";

        private const string ErrorText = "Error";
        private const string UniversityText = "University";
        private const string FacultyText = "Faculty";
        private const string StudentText = "Student";

        public FunP()
        {
            InitializeComponent();

            translator = new YandexTranslator();
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

            Dictionary<string, LanguageType> langDict = new Dictionary<string, LanguageType>();
            
            for (int k = 0; k < 2; k++)
            {
                LanguageType lang = (LanguageType)k;
                langDict.Add(Translator.GetLangName(lang), lang);
            }

            langComboBox.DataSource = new BindingSource(langDict, null);
            SetRequestSheet();

            weatherButton.Text = translator.Translate(WeatherButtonDefaultText, language);
        }

        private void TranslateView()
        {
            try
            {
                getDataButton.Text = translator.Translate(GetButtonDefaultText, language);
                editButton.Text = translator.Translate(EditButtonDefaultText, language);
                removeButton.Text = translator.Translate(RemoveButtonDefaultText, language);
                addButton.Text = translator.Translate(AddButtonDefaultText, language);
                saveAsButton.Text = translator.Translate(SaveButtonDefaultText, language);
                GetGroup.Text = translator.Translate(EditGroupDefaultText, language);
                AddGroup.Text = translator.Translate(AddGroupDefaultText, language);
                RequestGroup.Text = translator.Translate(RequestGroupDefaultText, language);
                label1.Text = translator.Translate(FirstLineLabelDefaultText, language);
                label2.Text = translator.Translate(LastLineLabelDefaultText, language);
                label3.Text = translator.Translate(LanguageLabelDefaultText, language);

                SetNewLineSheet();
                SetRequestSheet();

                int colCount = dataGridView.ColumnCount;
                for (int k = 0; k < colCount; k++)
                    dataGridView.Columns[k].Name = translator.Translate(dataGridView.Columns[k].Name, language);

                weatherButton.Text = translator.Translate(WeatherButtonDefaultText, language);
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
            }
        }

        private void SetRequestSheet()
        {
            requestSheetList.Items.Clear();

            var sheet = presenter.GetRequestSheet();

            foreach(var value in sheet)
            {
                requestSheetList.Items.Add(translator.Translate(value, language));
            }
        }

        private void SetNewLineSheet()
        {
            newLineTypeList.Items.Clear();

            var sheet = presenter.GetDBTableNames();

            foreach (var value in sheet)
            {
                newLineTypeList.Items.Add(translator.Translate(value, language));
            }
        }

        public void OnError(string message)
        {
            string title = translator.Translate(ErrorText, language);
            message = translator.Translate(message, language);
            MessageBox.Show(message, title);
        }

        public void OnRequestResults(object results)
		{
            if (results == null)
            {
                OnError("Request returns empty list.");
                return;
            }
        
            dataGridView.Rows.Clear();
            dataGridView.Refresh();

            ITable table = (ITable)results;
            var columnNames = table.TableStruct.GetColNamesList();
            int rowCount = table.GetRowCount();
            int colCount = table.TableStruct.GetColCount();

            dataGridView.ColumnCount = colCount;
            dataGridView.AutoResizeColumns();

            for (int k = 0; k < colCount; k++)
            {
                dataGridView.Columns[k].Name = translator.Translate(columnNames[k], language);
                dataGridView.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < rowCount; i++)
            {
                string[] row = new string[colCount];
                for (int j = 0; j < colCount; j++)
                {
                    row[j] = table[i][j].ToString();
                }
                dataGridView.Rows.Add(row);
            }            
        }

        public void OnLineAdd(TableValuesLine line)
        {
            int colCount = dataGridView.ColumnCount;
            string[] row = new string[colCount];
            for (int k = 0; k < colCount; k++)
            {
                row[k] = line[k].ToString();
            }
            dataGridView.Rows.Add(row);
        }

        public void OnLineEdit(TableValuesLine lineToEdit, TableValuesLine newLine)
        {
            //TODO Возможно стоит проверять эта ли строка заменяется
            var index = dataGridView.CurrentCell.RowIndex;

            int colCount = dataGridView.ColumnCount;
            string[] row = new string[colCount];
            for (int k = 0; k < colCount; k++)
            {
                row[k] = newLine[k].ToString();
            }

            dataGridView.Rows.RemoveAt(index);
            dataGridView.Rows.Insert(index, row);
        }

        public void OnLineDelete(TableValuesLine lineToDelete)
        {
            //TODO Возможно стоит проверять эта ли строка удаляется
            var index = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows.RemoveAt(index);
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {
            var index = requestSheetList.SelectedIndex;

            if (index == -1)
            {
                //TODO сообщение "не выбран запрос"
                return;
            }

            var requestSheet = presenter.GetRequestSheet();
            var firstIndex = Convert.ToInt32(firstIndexText.Text);
            var lastIndex = Convert.ToInt32(lastIndexText.Text);
            var request = requestSheet[index];

            presenter.SendRequest(request, firstIndex, lastIndex, null);
        }

        private List<string> GetColumnsName()
        {
            List<string> labels = new List<string>();
            for (int k = 0; k  < dataGridView.Columns.Count; k++)        
                labels.Add(dataGridView.Columns[k].Name);
            return labels;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if( dataGridView.CurrentCell == null)
            {
                //report table is empty
                return;
            }

            var tableName = presenter.GetRequestResultTableName();            

            if (tableName == "Default")
                return;

            var tableStruct = presenter.GetTableStructByName(tableName);
            var index = dataGridView.CurrentCell.RowIndex;
            var line = presenter.GetRequestResultLine(index);

            DataDialog dialog = new DataDialog();
            dialog.Text = translator.Translate(EditGroupDefaultText, language);
            dialog.SetData(line, tableStruct);
             
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var newLine = dialog.GetData();
                presenter.DBLineEdit(tableStruct, line, newLine);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell == null)
            {
                //report table is empty
                return;
            }

            var tableName = presenter.GetRequestResultTableName();
            var tableStruct = presenter.GetTableStructByName(tableName);
            var index = dataGridView.CurrentCell.RowIndex;
            var line = presenter.GetRequestResultLine(index);
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
            dialog.Text = translator.Translate(AddGroupDefaultText, language);
            dialog.SetData(null, tableStruct);
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var lineToAdd = dialog.GetData();
                presenter.DBLineAdd(tableStruct, lineToAdd);
            }
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

        private void langComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            language = ((KeyValuePair<string, LanguageType>)langComboBox.SelectedItem).Value;
            TranslateView();
        }

        private void weatherButton_Click(object sender, EventArgs e)
        {
            WeatherForm form = new WeatherForm();
            form.ShowDialog();
        }
    }
}

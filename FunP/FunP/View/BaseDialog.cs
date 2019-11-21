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

using FunP.View;

namespace FunP
{
    public partial class FunP : Form, IView
    {
        private IPresenter presenter;
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

            Dictionary<string, LanguageType> langDict = new Dictionary<string, LanguageType>();
            for (int k = 0; k < 2; k++)
            {
                LanguageType lang = (LanguageType)k;
                langDict.Add(Translator.GetLangName(lang), lang);
            }

            langComboBox.DataSource = new BindingSource(langDict, null);
        }

        private void TranslateView()
        {
            getDataButton.Text = translator.Translate(GetButtonDefaultText, language);
            editButton.Text = translator.Translate(EditButtonDefaultText, language);
            removeButton.Text = translator.Translate(RemoveButtonDefaultText, language);
            addButton.Text = translator.Translate(AddButtonDefaultText , language);
            saveAsButton.Text = translator.Translate(SaveButtonDefaultText, language);
            GetGroup.Text = translator.Translate(EditGroupDefaultText, language);
            AddGroup.Text = translator.Translate(AddGroupDefaultText, language);
            RequestGroup.Text = translator.Translate(RequestGroupDefaultText, language);
            label1.Text = translator.Translate(FirstLineLabelDefaultText, language);
            label2.Text = translator.Translate(LastLineLabelDefaultText, language);
            label3.Text = translator.Translate(LanguageLabelDefaultText, language);

            SetNewLineTypeSheet();

            weatherButton.Text = translator.Translate(WeatherButtonDefaultText, language);
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

        private void SetNewLineTypeSheet()
        {
            newLineTypeList.Items.Clear();

            newLineTypeList.Items.Add(translator.Translate(UniversityText, language));
            newLineTypeList.Items.Add(translator.Translate(FacultyText, language));
            newLineTypeList.Items.Add(translator.Translate(StudentText, language));
        }

        public void OnError(string message)
        {
            string title = translator.Translate(ErrorText, language);
            message = translator.Translate(message, language);
            MessageBox.Show(message, title);
        }

        public void OnRequestResults(ITable table)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();

            var columnNames = table.GetColNames();
            var colCount = columnNames.Count;

            dataGridView.ColumnCount = colCount;
            for (int k = 0; k < colCount; k++)
                dataGridView.Columns[k].Name = translator.Translate(columnNames[k], language);

            var rows = table.GetRowsCount();
            var cols = table.GetColsCount();
            
            for (int i = 0; i < rows; i++)
            {
                string[] row = new string[cols];
                for(int j=0;j<cols; j++)
                {
                    row[j] = table.GetData(i, j).ToString();
                }
                dataGridView.Rows.Add(row);
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
            var byteLines = new List<byte[]>();
            var byteLinesReaden = new List<byte[]>();

            string path = @".\students.txt";
            var formatter = new BinaryFormatter();
            var students = new List<TableValuesLine>();
            var studentsReaden = new List<TableValuesLine>();

            students.Add(new TableValuesLine(1, 2, "s1", "n1", "p1", 24, 2008, 4.7));
            students.Add(new TableValuesLine(2, 3, "s2", "n2", "p2", 25, 2009, 4.8));

            foreach (var student in students)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    formatter.Serialize(ms, student);
                    byteLines.Add(ms.GetBuffer()); 
                }
            }

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
            }

            foreach (var line in byteLines)
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Seek(0, SeekOrigin.End);

                    var lineLen = line.Length;
                    var lineLenInByteFormat = BitConverter.GetBytes(lineLen);
                    fs.Write(lineLenInByteFormat, 0, lineLenInByteFormat.Length);
                    fs.Write(line, 0, lineLen);
                }
            }

            var dataLenInByteFormat = new byte[sizeof(int)];

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                while( fs.Read(dataLenInByteFormat, 0, sizeof(int)) != 0)
                {
                    var dataLen = BitConverter.ToInt32(dataLenInByteFormat, 0);
                    var data = new byte[dataLen];
                    if( dataLen == fs.Read(data, 0, dataLen))
                    {
                        byteLinesReaden.Add(data);
                    }
                }
            }

            foreach(var line in byteLinesReaden)
            {
                using (MemoryStream ms = new MemoryStream(line))
                {
                    studentsReaden.Add((TableValuesLine)formatter.Deserialize(ms));
                }
            }

            return;

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

        private List<string> GetColumnsName()
        {
            List<string> labels = new List<string>();
            for (int k = 0; k  < dataGridView.Columns.Count; k++)        
                labels.Add(dataGridView.Columns[k].Name);
            return labels;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var rows = dataGridView.SelectedRows;
            
            if (rows.Count == 0)
            {
                //TODO сообщение "выберите строку значений для редактирования"
                return;
            }

            var tableName = presenter.GetRequestResultTableName();
            var line = presenter.GetRequestResultLine(dataGridView.CurrentCell.RowIndex);
            ITableDesc tableDesc = new BaseTableDesc("Custom");            
            
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
               // return;
            }

            DataDialog dialog = new DataDialog();
            dialog.Text = translator.Translate(EditGroupDefaultText, language);
            dialog.SetData(line, tableDesc);
             
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

            var tableName = presenter.GetRequestResultTableName();
            var line = presenter.GetRequestResultLine(dataGridView.CurrentCell.RowIndex);

            if (tableName == "Default")
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

            var tableName = newLineTypeList.SelectedItem.ToString();
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
            dialog.Text = translator.Translate(AddGroupDefaultText, language);
           // dialog.SetData(tableDesc);
            
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

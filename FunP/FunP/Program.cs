using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunP
{
    public enum DBType { SQL = 0, File };

    public static class SQLtoFileDBConverter
    {
        public static void Convert()
        {
            var dbRequestRepository = new DBRequestRepository();
            var dbBasicFunc = new FileBasicFunc();
            dbRequestRepository.AddReqToSheet("Request all universities", new SqlReqUniversities());
            dbRequestRepository.AddReqToSheet("Request all faculties", new SqlReqFaculties());
            dbRequestRepository.AddReqToSheet("Request all students", new SqlReqStudents());

            var table = dbRequestRepository.GetDataFromBase("1Request all students", 0, 0, null);
            for (int i = 0; i < table.GetRowCount(); i++)
            {
                dbBasicFunc.LineAdd(new StudentTableStruct(), table[i]);
            }

            table = dbRequestRepository.GetDataFromBase("1Request all faculties", 0, 0, null);
            for (int i = 0; i < table.GetRowCount(); i++)
            {
                dbBasicFunc.LineAdd(new FacultyTableStruct(), table[i]);
            }

            table = dbRequestRepository.GetDataFromBase("1Request all universities", 0, 0, null);
            for (int i = 0; i < table.GetRowCount(); i++)
            {
                dbBasicFunc.LineAdd(new UniversityTableStruct(), table[i]);
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //создание диалога программы
            var basicDialog = new FunP();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            DBType dbType = DBType.SQL;

            //создания описаний таблиц БД
            var dbStruct = new DBStruct();
            dbStruct.AddTableStruct(new StudentTableStruct());
            dbStruct.AddTableStruct(new FacultyTableStruct());
            dbStruct.AddTableStruct(new UniversityTableStruct());

            //инициализация репозитория запросов к БД
            var dbRequestRepository = new DBRequestRepository();

            //инициализация базовых функций работы с БД
            IDBBasicFunc dbBasicFunc;

            switch(dbType)
            {
                case DBType.File:
                    dbBasicFunc = new FileBasicFunc();
                    dbRequestRepository.AddReqToSheet("Request all universities", new FileReqUniversities());
                    dbRequestRepository.AddReqToSheet("Request all faculties", new FileReqFaculties());
                    dbRequestRepository.AddReqToSheet("Request all students", new FileReqStudents());
                    break;

                case DBType.SQL:
                default:
                    dbBasicFunc = new SQLBasicFunc();
                    dbRequestRepository.AddReqToSheet("Request all universities", new SqlReqUniversities());
                    dbRequestRepository.AddReqToSheet("Request all faculties", new SqlReqFaculties());
                    dbRequestRepository.AddReqToSheet("Request all students", new SqlReqStudents());
                    dbRequestRepository.AddReqToSheet("Request students in faculty \"Aero\"", new SqlReqStudByFacultyAero());
                    break;
            }

            //создание презентера
            var presenter = new Presenter(basicDialog, dbStruct, dbBasicFunc, dbRequestRepository);
            //передача презентера во view
            basicDialog.SetPresenter(presenter);
            //инициализация элементов формы
            basicDialog.InitializeFields();
            //запуск программы
            Application.Run(basicDialog);
        }
    }
}

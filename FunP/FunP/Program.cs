using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FunP
{

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

            //создания описаний таблиц БД
            var dbStruct = new DBStruct();
            dbStruct.AddTableStruct(new StudentTableStruct());
            dbStruct.AddTableStruct(new FacultyTableStruct());
            dbStruct.AddTableStruct(new UniversityTableStruct());

            //инициализация базовых функций работы с БД
            var sqlBasicFunc = new SQLBasicFunc();
            var fileBasicFunc = new FileBasicFunc();

            //инициализация запросов к БД
            var dbRequestRepository = new DBRequestRepository();
            //dbRequestRepository.AddReqToSheet("Request all universities", new FileReqUniversities());
            //dbRequestRepository.AddReqToSheet("Request all faculties", new FileReqFaculties());
            //dbRequestRepository.AddReqToSheet("Request all students", new FileReqStudents());
            dbRequestRepository.AddReqToSheet("1Request all universities", new SqlReqUniversities());
            dbRequestRepository.AddReqToSheet("1Request all faculties", new SqlReqFaculties());
            dbRequestRepository.AddReqToSheet("1Request all students", new SqlReqStudents());
            //dbRequestRepository.AddReqToSheet("Request students in faculty \"Aero\"", new SqlReqStudByFacultyAero());

            //var table = dbRequestRepository.GetDataFromBase("1Request all students", 0, 0, null);
            //for (int i = 0; i < table.GetRowCount(); i++)
            //{
            //    fileBasicFunc.LineAdd(new StudentTableStruct(), table[i]);
            //}

            //table = dbRequestRepository.GetDataFromBase("1Request all faculties", 0, 0, null);
            //for (int i = 0; i < table.GetRowCount(); i++)
            //{
            //    fileBasicFunc.LineAdd(new FacultyTableStruct(), table[i]);
            //}

            //table = dbRequestRepository.GetDataFromBase("1Request all universities", 0, 0, null);
            //for (int i = 0; i < table.GetRowCount(); i++)
            //{
            //    fileBasicFunc.LineAdd(new UniversityTableStruct(), table[i]);
            //}




            //создание презентера
            var presenter = new Presenter(basicDialog, dbStruct, sqlBasicFunc, dbRequestRepository);
            //передача презентера во view
            basicDialog.SetPresenter(presenter);
            //инициализация элементов формы
            basicDialog.InitializeFields();
            //запуск программы
            Application.Run(basicDialog);
        }
    }
}

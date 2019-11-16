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

            //создания описаний таблиц БД
            var dbTableInfo = new DBTableInfo();
            dbTableInfo.AddTableDesc(new StudentTableDesc());
            dbTableInfo.AddTableDesc(new FacultyTableDesc());
            dbTableInfo.AddTableDesc(new UniversityTableDesc());

            //инициализация базовых функций работы с БД
            var sqlBasicTableFunc = new SQLTable(dbTableInfo);

            //инициализация запросов к БД
            var dbWork = new DBWork();
            dbWork.AddReqToSheet("ReqUniversities", new ReqUniversities());
            dbWork.AddReqToSheet("ReqFaculties", new ReqFaculties());
            dbWork.AddReqToSheet("ReqStudents", new ReqStudents());
            dbWork.AddReqToSheet("ReqStudByMark", new ReqStudByMark());
            
            //создание презентера
            var presenter = new Presenter(dbWork, sqlBasicTableFunc, basicDialog);
            //передача презентера во view
            basicDialog.SetPresenter(presenter);
            //инициализация элементов формы
            basicDialog.InitializeFields();
            //запуск программы
            Application.Run(basicDialog);
        }
    }
}

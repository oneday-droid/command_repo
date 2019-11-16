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
            var sqlTableInfo = new SqlTableInfo();
            sqlTableInfo.AddTableDesc(new StudentTableDesc());
            sqlTableInfo.AddTableDesc(new FacultyTableDesc());
            sqlTableInfo.AddTableDesc(new UniversityTableDesc());

            //инициализация базовых функций работы с БД
            var sqlBasicTableFunc = new SQLTable(sqlTableInfo);

            //инициализация запросов к БД
            var sqlWork = new SQLWork();
            sqlWork.AddReqToSheet("ReqUniversities", new ReqUniversities());
            sqlWork.AddReqToSheet("ReqFaculties", new ReqFaculties());
            sqlWork.AddReqToSheet("ReqStudents", new ReqStudents());
            sqlWork.AddReqToSheet("ReqStudByMark", new ReqStudByMark());
            
            //создание презентера
            var presenter = new Presenter(sqlWork, sqlBasicTableFunc, basicDialog);
            //передача презентера во view
            basicDialog.SetPresenter(presenter);
            //инициализация элементов формы
            basicDialog.InitializeFields();
            //запуск программы
            Application.Run(basicDialog);
        }
    }
}

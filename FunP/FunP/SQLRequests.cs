using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class ReqStudByMark : ISQLRequest                //имплементирует интерфейс запроса
    {
        //TODO Андрей здесь раскомментируй и замени "SQLClass" на класс объекта работы с БД
        //private SQLClass sqlObject;

        //public SQLWork(ISQLClass sqlObject)
        //{
        //    this.sqlObject = sqlObject;
        //}

        public List<ITableLine> SendRequest(List<Pair> paramPairs)
        {
            //====================================

            //TODO реализация запроса в базу данных через объект sqlClass

            //====================================

            int lineCount = 1;                              //TODO заменить 1 на количество строк результата запроса
            int lineSize = 2;                               //TODO заменить 2 на длину строки результата запроса
            var result = new List<ITableLine>();
            
            //заполнение нетипизированной таблицы
            for(int line = 0; line < lineCount; line++)
            {
                var pairs = new List<Pair>();

                for (int column = 0; column < lineSize; column++)
                {
                    pairs.Add(new Pair("name", "value") );           //вместо name и value - обращение к результатам запроса, где name - заголовок столбца column, а value - значение в столбце column текущей строки line
                }

                result.Add(new TableLine(pairs));
            }

            return result;
        }
    }


    //====================================================================================
    //============================================тестовые запрос без бд==================
    //====================================================================================
    public class ReqUniversities : ISQLRequest              //запрос всех строк таблицы университета
    {
        public List<ITableLine> SendRequest(List<Pair> paramPairs)
        {
            var result1 = new List<ITableLine>();

            result1.Add(new UniversityLine());
            result1.Add(new UniversityLine());
            result1.Add(new UniversityLine());
            result1.Add(new UniversityLine());
            result1.Add(new UniversityLine());
            result1.Add(new UniversityLine());

            result1[0].SetValue("Название", "Пед");
            result1[0].SetValue("Город", "Пермь");
            result1[0].SetValue("Год основания", "1970");

            result1[1].SetValue("Название", "Мед");
            result1[1].SetValue("Город", "Пермь");
            result1[1].SetValue("Год основания", "1950");

            result1[2].SetValue("Название", "Политех");
            result1[2].SetValue("Город", "Пермь");
            result1[2].SetValue("Год основания", "1930");

            result1[3].SetValue("Название", "Политех");
            result1[3].SetValue("Город", "Екатеринбург");
            result1[3].SetValue("Год основания", "1954");

            result1[4].SetValue("Название", "Мед");
            result1[4].SetValue("Город", "Екатеринбург");
            result1[4].SetValue("Год основания", "1989");

            result1[5].SetValue("Название", "Пед");
            result1[5].SetValue("Город", "Казань");
            result1[5].SetValue("Год основания", "1943");

            int lineCount = 6;
            int lineSize = 3;
            var cols = result1[0].GetColumnNames();
            var result = new List<ITableLine>();

            //заполнение типизированной таблицы
            for (int line = 0; line < lineCount; line++)
            {
                result.Add(new UniversityLine());

                for (int column = 0; column < lineSize; column++)
                {
                    var name = cols[column];
                    result[line].SetValue(name, result1[line].GetValue(name));
                }
            }

            return result;
        }
            
    }


    
    public class ReqTest : ISQLRequest
    {
        public List<ITableLine> SendRequest(List<Pair> paramPairs)
        {
            var result1 = new List<ITableLine>();

            var lineBase = new List<Pair>();
            lineBase.Add(new Pair("Фамилия", "Петров"));
            lineBase.Add(new Pair("Имя", "Петр"));
            lineBase.Add(new Pair("Отчество", "Петрович"));
            lineBase.Add(new Pair("Факультет", "Физики"));
            lineBase.Add(new Pair("Университет", "Политех"));
            lineBase.Add(new Pair("Оценка", "4.65"));

            result1.Add(new TableLine(lineBase));

            lineBase = new List<Pair>();
            lineBase.Add(new Pair("Фамилия", "Иванов"));
            lineBase.Add(new Pair("Имя", "Иван"));
            lineBase.Add(new Pair("Отчество", "Иванович"));
            lineBase.Add(new Pair("Факультет", "Математики"));
            lineBase.Add(new Pair("Университет", "Политех"));
            lineBase.Add(new Pair("Оценка", "4.77"));

            result1.Add(new TableLine(lineBase));

            lineBase = new List<Pair>();
            lineBase.Add(new Pair("Фамилия", "Сидоров"));
            lineBase.Add(new Pair("Имя", "Сидор"));
            lineBase.Add(new Pair("Отчество", "Сидорович"));
            lineBase.Add(new Pair("Факультет", "Геологии"));
            lineBase.Add(new Pair("Университет", "Универ"));
            lineBase.Add(new Pair("Оценка", "4.83"));

            result1.Add(new TableLine(lineBase));

            lineBase = new List<Pair>();
            lineBase.Add(new Pair("Фамилия", "Андреев"));
            lineBase.Add(new Pair("Имя", "Андрей"));
            lineBase.Add(new Pair("Отчество", "Андреевич"));
            lineBase.Add(new Pair("Факультет", "Стоматологии"));
            lineBase.Add(new Pair("Университет", "Мед"));
            lineBase.Add(new Pair("Оценка", "4.61"));

            result1.Add(new TableLine(lineBase));

            lineBase = new List<Pair>();
            lineBase.Add(new Pair("Фамилия", "Александров"));
            lineBase.Add(new Pair("Имя", "Александр"));
            lineBase.Add(new Pair("Отчество", "Александрович"));
            lineBase.Add(new Pair("Факультет", "Физкультуры"));
            lineBase.Add(new Pair("Университет", "Пед"));
            lineBase.Add(new Pair("Оценка", "4.99"));

            result1.Add(new TableLine(lineBase));

            int lineCount = 5;
            int lineSize = 6;
            var cols = result1[0].GetColumnNames();
            var result = new List<ITableLine>();

            //заполнение
            for (int line = 0; line < lineCount; line++)
            {
                var pairs = new List<Pair>();

                for (int column = 0; column < lineSize; column++)
                {
                    var name = cols[column];
                    pairs.Add(new Pair(name, result1[line].GetValue(name)));
                }

                result.Add(new TableLine(pairs));
            }

            return result;
        }
    }
}

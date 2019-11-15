using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class TableLine : ITableLine                         //имплементирует ITableLine, описывая строку нетипизированной таблицы (с произвольными колонками)
    {
        protected List<Pair> dataPairs = new List<Pair>();
        protected string        tableName;

        public TableLine(List<Pair> initPairs)      //конструктор, инициализирующий структуру данных dataPairs значениями извне (для TableLine)
        {
            InitTableName();

            if(initPairs == null)                   
            {
                //в наследуемых классах предполагается, что заранее предопределено количество пар значений, 
                //поэтому при инициализации наследуемого класса под заранее определенную структуру таблицы требуется:
                //переопределить виртуальный InitTableName() для добавления стандартных для определяемой таблицы пар
                //передать null в конструктор базового TableLine для вызова переопределенного InitTableName()

                InitDataPairs();
            }
            else
            {
                //для базового TableLine нужно определять строку кастомизированным набором пар извне, которые добавляются с помощью перегруженного InitDataPairs(List<Pair> initPairs)
                //если в конструктор передать null, то есть не инициализировать, то вызовется виртуальный InitDataPairs() с выдачей exception
                InitDataPairs(initPairs);
            }
        }

        protected virtual void InitTableName()
        {
            tableName = "CustomTable";
        }
        protected virtual void InitDataPairs()                  //инициализатор для наследуемых классов
        {
            throw new ArgumentNullException();                  //базовый класс TableLine нельзя инициализировать пустым списком параметров
        }
        protected void InitDataPairs(List<Pair> initPairs)      //инициализатор для базового класса 
        {
            foreach(var dataPair in initPairs)
            {
                this.dataPairs.Add(dataPair);
            }
        }

        //public static ITableLine

        public void     SetValue(string valueNameToSet, object value)
        {
            bool exist = false;

            foreach (var dataPair in dataPairs)
            {
                if (dataPair.Name == valueNameToSet)
                {
                    if(dataPair.ValueType == value.GetType())
                    {
                        dataPair.Value = value;
                        exist = true;
                    }
                    else
                        throw new ArgumentException("Тип аргумента с именем {pair.Name} не совпадает с типом параметра value");
                }
            }

            if (exist == false)
                throw new ArgumentException("Аргумент с именем {pair.Name} не является членом таблицы");
        }

        public object   GetValue(string name)
        {
            foreach (var dataPair in dataPairs)
            {
                if (dataPair.Name == name)
                {
                    return dataPair.Value;
                }
            }

            throw new ArgumentException("Аргумент с именем {pair.Name} не является членом таблицы");
        }

        public object GetValue(int index)
        {
            return dataPairs[index].Value;
        }

        public Type GetValueType(string name)
        {
            foreach (var dataPair in dataPairs)
            {
                if (dataPair.Name == name)
                {
                    return dataPair.ValueType;
                }
            }

            throw new ArgumentException("Аргумент с именем {pair.Name} не является членом таблицы");
        }

        public Type GetValueType(int index)
        {
            return dataPairs[index].ValueType;
        }

        public List<string> GetColumnNames()
        {
            var result = new List<string>();

            foreach(var pair in dataPairs)
            {
                result.Add(pair.Name);
            }

            return result;
        }

        public int      GetSize()
        {
            return dataPairs.Count;
        }

        public string   GetTableName()
        {
            return tableName;
        }

        
    }
}

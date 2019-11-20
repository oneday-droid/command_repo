using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{
    class DBTableInfo : IDBTableInfo
    {
        private List<ITableDesc> tableDescList = new List<ITableDesc>();            //список описаний таблиц базы

        public ITableDesc this[int index]
        {
            get { return tableDescList[index]; }
        }
        public void AddTableDesc(ITableDesc tableDesc)
        {
            tableDescList.Add(tableDesc);
        }
        public int GetTableDescCount()
        {
            return tableDescList.Count;
        }
        public int CheckLine(TableValuesLine line)
        {
            bool fEquals = false;
            int result = -1;
            int count = -1;

            foreach (var tableDesc in tableDescList)
            {
                count++;

                if (tableDesc.GetColsCount() == line.GetColCount())
                {
                    fEquals = true;

                    for (int i = 0; i < tableDesc.GetColsCount(); i++)
                    {
                        if (line[i].GetType() != tableDesc.GetColType(i))
                        {
                            fEquals = false;
                            break;
                        }
                    }
                }

                if (fEquals)        //прерывание обхода, если совпадение найдено
                {
                    result = count;
                    break;
                }
            }

            return result;
        }
    }
}

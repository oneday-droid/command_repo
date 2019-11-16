using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class TableValuesLine                           //
    {
        private List<object>  data = new List<object>();

        public object this[int index]
        {
            get
            {
                return data[index];
            }

            set
            {
                data[index] = value;
            }
        }      

        public void Add(object element)
        {
            data.Add(element);
        }

        public int GetColCount()
        {
            return data.Count;
        }
    }
}

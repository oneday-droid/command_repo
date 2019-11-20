using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{

    [Serializable]
    public class TableValuesLine                           //
    {
        private List<object>  data;

        public TableValuesLine(params object[] data)
        {
            this.data = new List<object>();
            int length = data.Length;
            
            for (int i=0; i< length && length > 0; i++)
            {
                this.data.Add(data[i]);
            }
        }

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

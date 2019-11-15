using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    //public class Pair                   //класс описывае пару значений, где Name - имя столбца, а Value - значение
    //{
    //    public string Name { get; set; }
    //    public string Value { get; set; }

    //    public Pair()
    //    {

    //    }
    //    public Pair(string name, string value)
    //    {
    //        Name = name;
    //        Value = value;
    //    }
    //}

    public class Pair
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public Type ValueType { get; set; }

        public Pair(string name, object value, Type valueType)  
        {
            Name = name;
            Value = value;
            ValueType = valueType;
        }

        public Pair()
        {

        }
    }
}

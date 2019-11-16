using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class ColDescPair                          //задает имя и типизирует колонку данных таблицы
    {
        public string Name { get; set; }
        public Type Type { get; set; }

        public ColDescPair(string name, Type type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}

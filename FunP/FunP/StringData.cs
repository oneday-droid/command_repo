using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class StrDataLine
    {
        private List<string> line = new List<string>();

        public void AddValue(string value)
        {
            line.Add(value);
        }

        public string GetValue(int index)
        {
            if (index < 0 || index >= line.Count)
            {
                throw new System.ArgumentOutOfRangeException();
            }

            return line[index];
        }

        public List<string> GetLine()
        {
            return line;
        }

        public void Clear()
        {
            line.Clear();
        }
    }

    public class StringDataTable
    {
        private List<StrDataLine> table = new List<StrDataLine>();

        public void AddLine(StrDataLine dataLine)
        {
            if(dataLine != null)
                table.Add(dataLine);
        }
        public StrDataLine GetLine(int index)
        {
            if (index < 0 || index >= table.Count)
            {
                throw new System.ArgumentOutOfRangeException();
            }

            return table[index];
        }

        public void Clear()
        {
            table.Clear();
        }

    }
}

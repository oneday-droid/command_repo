﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class Pair
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Pair()
        {

        }
        public Pair(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}

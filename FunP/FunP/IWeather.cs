﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    interface IWeather
    {
        string GetWeather(string city);
    }

    abstract class AbstractWeatherResponse
    {    }
}
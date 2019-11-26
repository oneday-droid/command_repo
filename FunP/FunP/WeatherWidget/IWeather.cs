using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    interface IWeather
    {
        AbstractWeatherResponse GetWeather(string city);
        IList<string> GetAvailableCity();
    }

    abstract class AbstractWeatherResponse
    {    }
}
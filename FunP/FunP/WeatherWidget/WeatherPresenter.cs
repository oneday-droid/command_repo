using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class WeatherPresenter : BasePresenter
    {
        IWeather weather;
        IView view;

        public WeatherPresenter()
        {
            IWeather weather = new WeatherWidget.DarkSkyWeather();
        }

        
        override public void SendRequest(string request)
        {            
            WeatherWidget.DarkSkyWeatherResponse resp = (WeatherWidget.DarkSkyWeatherResponse)weather.GetWeather(request);
            
        }
    }
}

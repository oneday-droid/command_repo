using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FunP
{
    class WeatherPresenter : BasePresenter
    {
        IWeather weather;
        string city;
        
        const string forecastString = "Current forecast for {0}\nTemperature {1}\nWind speed {2}\nHumidity {3}\nSummary {4}";

        public WeatherPresenter()
        {
            weather = new WeatherWidget.DarkSkyWeather();
        }

        public List<string> GetValues()
        {
            return weather.GetAvailableCity();
        }

        public void GetForecastForCity(string cityName)
        {
            city = cityName;
            SendRequest();
        }
        
        void SendRequest()
        {
            try
            {
                WeatherWidget.DarkSkyWeatherResponse resp = (WeatherWidget.DarkSkyWeatherResponse)weather.GetWeather(city);
                string result = String.Format(forecastString, city, Convert.ToString(resp.currently.temperature), Convert.ToString(resp.currently.windSpeed),
                                              Convert.ToString(resp.currently.humidity), resp.currently.summary);
                view.OnRequestResults(result);
            }
            catch (Exception ex)
            {
                view.OnError(ex.Message);
            }
        }
    }
}

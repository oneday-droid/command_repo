using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using Newtonsoft.Json;

namespace FunP
{
    class OpenMapWeather : IWeather
    {
        private string Address = "api.openweathermap.org/data/2.5/weather?q=";

        public AbstractWeatherResponse GetWeather(string city)
        {
            OpenMapWeatherResponse responseString = null;
            string result = "";
            if (city.Length != 0)
            {
                string stringRequest = String.Format("{0}{1}", Address, city);

                WebRequest request = WebRequest.Create(stringRequest);
                WebResponse response = request.GetResponse();

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;

                    if ((line = stream.ReadLine()) != null)
                    {
                        responseString = JsonConvert.DeserializeObject<OpenMapWeatherResponse>(line);

                        result = responseString.Main;
                    }
                }
            }

            return responseString;
        }
    }

    class OpenMapWeatherResponse : AbstractWeatherResponse
    {
        public string Cod { get; set; }
        public string City { get; set; }
        public string Id { get; set; }
        public string Dt { get; set; }
        public string Visibility { get; set; }
        public string Base { get; set; }
        public string[] Weather { get; set; }
        public string Coord { get; set; }
        public string Main { get; set; }
        public string Wind { get; set; }
        public string Clouds { get; set; }
    }
}

//{"coord":{"lon":-0.13,"lat":51.51},
// "weather":[{"id":300,"main":"Drizzle","description":"light intensity drizzle","icon":"09d"}],
// "base":"stations",
// "main":{"temp":280.32,"pressure":1012,"humidity":81,"temp_min":279.15,"temp_max":281.15},
// "visibility":10000,
// "wind":{"speed":4.1,"deg":80},
// "clouds":{"all":90},
// "dt":1485789600,
// "sys":{"type":1,"id":5091,"message":0.0103,"country":"GB","sunrise":1485762037,"sunset":1485794875},
// "id":2643743,
// "name":"London",
// "cod":200}
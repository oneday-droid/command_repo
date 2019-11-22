using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using Newtonsoft.Json;


namespace FunP.WeatherWidget
{
    class DarkSkyWeather : IWeather
    {
        private const string CurrentForecastUrl = "https://api.darksky.net/forecast/{0}/{1},{2}?units=si";
        private const string ApiKey = "11a91bd56266b5c0f8391eff62e42d00";

        Dictionary<string, string> cityToCoordinates;

        public DarkSkyWeather()
        {
            cityToCoordinates = new Dictionary<string, string>();
            cityToCoordinates.Add("Perm", "58.99;56.27");
            cityToCoordinates.Add("Moscow", "55.75;37.62");
            cityToCoordinates.Add("Novosibirsk", "55.04;82.93");
        }

        bool CityToCoordinates(string city, out string latitude, out string longitude)
        {
            string coordinates;
            bool res = cityToCoordinates.TryGetValue(city, out coordinates);

            latitude = "";
            longitude = "";

            if (res)
            {
                string[] list = coordinates.Split(';');
                latitude = list[0];
                longitude = list[1];
            }
            
            return res;
        }

        public AbstractWeatherResponse GetWeather(string city)
        {
            DarkSkyWeatherResponse result = null;

            try
            {
                string latitude;
                string longitude;

                CityToCoordinates(city, out latitude, out longitude);
                var uri = string.Format(CurrentForecastUrl, ApiKey, latitude, longitude);


                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                request.Headers.Add("Content-Encoding", "gzip");
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.ContentType = "application/json";

                var response = (HttpWebResponse)request.GetResponse();
                
                using (Stream responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    var jsonOut = reader.ReadToEnd();
                    reader.Close();
                    result = JsonConvert.DeserializeObject<DarkSkyWeatherResponse>(jsonOut);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}

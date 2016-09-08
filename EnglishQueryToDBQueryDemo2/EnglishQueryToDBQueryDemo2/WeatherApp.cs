using Microsoft.Cognitive.LUIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;


//http://openweathermap.org/current
//api key 1c5103f70702a49331623fbe7d6a55c0
//http://api.openweathermap.org/data/2.5/forecast/city?id=524901&appid=1c5103f70702a49331623fbe7d6a55c0
//http://api.openweathermap.org/data/2.5/weather?q=london,uk&appid=1c5103f70702a49331623fbe7d6a55c0

namespace EnglishQueryToDBQueryDemo2
{
    public class WeatherApp
    {

        private string _apiKey = "1c5103f70702a49331623fbe7d6a55c0";
        private WeatherReport __weatherReport;

        [IntentHandler(0, Name = "GetWeather")]
        public async static Task<bool> display(LuisResult res, object weatherObj)
        {
            var city = string.Empty;
            res.Entities.ToList().ForEach(x => city = x.Value.ToString());

            //call weather service
            var obj = (WeatherApp)weatherObj;
            Task<WeatherReport> weatherReportTask = obj.GetWeatherByCity(city);
            weatherReportTask.Wait();
            var result = weatherReportTask.Result;

            Console.WriteLine("Top Scoring Intent " + res.TopScoringIntent.Name);
            return await Task.FromResult<bool>(true);
        }

        public async Task<WeatherReport> GetWeatherByCity(string cityName)
        {
            var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName},uk&appid={_apiKey}";
            return await weatherURL.GetJsonAsync<WeatherReport>();

        }


    }
}

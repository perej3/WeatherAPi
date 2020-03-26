using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class DarkSkyController : Controller
    {
       
        
        
        private DarkSkyEndpoint darkSkyEndpoint;


        public DarkSkyController() : base()
        {
            darkSkyEndpoint = new DarkSkyEndpoint();
        }


        public List<DarkSkyForecast> getForecast(string cityName, EndpointType endpoint)
        {
            List<DarkSkyForecast> forecastList = new List<DarkSkyForecast>();

            AccuWeatherController accuweatherController = new AccuWeatherController();

            List<float> coordinates = accuweatherController.getCoordinates(cityName);

            restClient.endpoint = darkSkyEndpoint.getByCityNameEndpointForecast(coordinates[0],coordinates[1],EndpointType.FORECAST);
            string response = restClient.makeRequest();

            JSONParser <DarkSkyForecastModel> jsonParser = new JSONParser  <DarkSkyForecastModel>();

            var deserialisedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (DailyForecastDaily model in deserialisedAccuWeatherModel.daily.data)
            {
                forecastList.Add(new DarkSkyForecast(model.temperatureHigh, model.temperatureLow));
            }

            return forecastList;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class Weather2020Controller : Controller
    {
       
        
        
        private Weather2020Endpoint weather2020Endpoint;


        public Weather2020Controller() : base()
        {
            weather2020Endpoint = new Weather2020Endpoint();
        }


        public List<Weather2020Forecast> getForecast(string cityName, EndpointType endpoint)
        {
            List<Weather2020Forecast> forecastList = new List<Weather2020Forecast>();

            AccuWeatherController accuweatherController = new AccuWeatherController();

            List<float> coordinates = accuweatherController.getCoordinates(cityName);

            restClient.endpoint = weather2020Endpoint.getByCityNameEndpointForecast(coordinates[0],coordinates[1],EndpointType.FORECAST);
            string response = restClient.makeRequest();

            JSONParser <List<Weather2020ForecastModel>> jsonParser = new JSONParser <List <Weather2020ForecastModel>>();

            var deserialisedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (Weather2020ForecastModel model in deserialisedAccuWeatherModel)
            {
                forecastList.Add(new Weather2020Forecast(model.temperatureHighCelcius, model.temperatureLowCelcius));
            }

            return forecastList;
        }
        
    }
}

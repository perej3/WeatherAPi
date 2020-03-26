using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class ClimaCellController : Controller
    {
       
        
        
        private ClimaCellEndpoint climaCellEndpoint;


        public ClimaCellController() : base()
        {
            climaCellEndpoint = new ClimaCellEndpoint();
        }

        public float getCurrentWeather(string cityName, EndpointType endpoint)
        {
            AccuWeatherController accuweatherController = new AccuWeatherController();
            
            List<float> coordinates = accuweatherController.getCoordinates(cityName);


           

            float temperature = 0f;

            restClient.endpoint = climaCellEndpoint.getByCityNameEndpoint(coordinates[0], coordinates[1], EndpointType.CURRENT);
            string response = restClient.makeRequest();

            JSONParser<ClimaCellWeatherModel> jsonParser = new JSONParser<ClimaCellWeatherModel>();

            ClimaCellWeatherModel deserialisedClimaCellModel = new ClimaCellWeatherModel();

            deserialisedClimaCellModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            temperature = deserialisedClimaCellModel.temp.value;

            climaCellEndpoint.getByCityNameEndpointForecast(coordinates[0], coordinates[1], EndpointType.FORECAST);

            return temperature;
        }

        public List<ClimaCellForecast> getForecast(string cityName, EndpointType endpoint)
        {
            List<ClimaCellForecast> forecastList = new List<ClimaCellForecast>();

            AccuWeatherController accuweatherController = new AccuWeatherController();

            List<float> coordinates = accuweatherController.getCoordinates(cityName);

            restClient.endpoint = climaCellEndpoint.getByCityNameEndpointForecast(coordinates[0],coordinates[1],EndpointType.FORECAST);
            string response = restClient.makeRequest();

            JSONParser <List<ClimaCellForecastModel>> jsonParser = new JSONParser <List <ClimaCellForecastModel>>();

            var deserialisedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (ClimaCellForecastModel model in deserialisedAccuWeatherModel)
            {
                forecastList.Add(new ClimaCellForecast(model.temp[0].min.value, model.temp[1].max.value));
            }

            return forecastList;
        }
        
    }
}

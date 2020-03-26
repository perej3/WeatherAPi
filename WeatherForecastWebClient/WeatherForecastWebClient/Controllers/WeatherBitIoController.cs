using System;
using System.Collections.Generic;
using System.Text;

using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.WeatherForecastModel;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;
using WeatherForecastWebClient.CurrentModel;


namespace WeatherForecastWebClient.Controllers
{
    class WeatherBitIoController : Controller
    {
        private WeatherBitIoEndpoint weatherBitIoEndpoint;

        public WeatherBitIoController() : base()
        {
            this.weatherBitIoEndpoint = new WeatherBitIoEndpoint();
        }

        public List<WeatherBitIoMapCurrent> getCurrentTemperature(string city, EndpointType endpoint)
        {

            List<WeatherBitIoMapCurrent> currentWeatherList = new List<WeatherBitIoMapCurrent>();

            restClient.endpoint = weatherBitIoEndpoint.getByCityNameEndpoint(city, endpoint);
            string response = restClient.makeRequest();

            JSONParser<WeatherBitIoMapCurrentModel> jsonParser = new JSONParser<WeatherBitIoMapCurrentModel>();

            WeatherBitIoMapCurrentModel deserialisedWeatherBitIoMapModel = new WeatherBitIoMapCurrentModel();
            deserialisedWeatherBitIoMapModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (Data currentMain in deserialisedWeatherBitIoMapModel.data)
            {
                currentWeatherList.Add(new WeatherBitIoMapCurrent(currentMain.datetime, currentMain.temp));

            }
            return currentWeatherList;
        }

        public List<WeatherBitIoMapForecast> getForecastList(string city, EndpointType endpoint)
        {
            List<WeatherBitIoMapForecast> forecastList = new List<WeatherBitIoMapForecast>();

            restClient.endpoint = weatherBitIoEndpoint.getByCityNameEndpoint(city, endpoint);
            string response = restClient.makeRequest();

            JSONParser<WeatherBitIoMapForecastModel> jsonParser = new JSONParser<WeatherBitIoMapForecastModel>();

            WeatherBitIoMapForecastModel deserialisedWeatherBitIoMapModel = new WeatherBitIoMapForecastModel();
            deserialisedWeatherBitIoMapModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (DataForecast forecastMain in deserialisedWeatherBitIoMapModel.data)
            {
                forecastList.Add(new WeatherBitIoMapForecast(forecastMain.datetime,forecastMain.temp));
            }
            return forecastList;
        }

    }
}

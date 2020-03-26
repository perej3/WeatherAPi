using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class DarkSkyEndpoint : Endpoint
    {
        public DarkSkyEndpoint() :
                    base("0537a80e6a805441086f3fe0a869bb48",
                        "https://api.darksky.net",
                        new Dictionary<EndpointType, string>{
                            {EndpointType.FORECAST,"forecast"}
                        },"si")
        { }

        //https://api.darksky.net/forecast/[key]/[latitude],[longitude]?units=si
        public string getByCityNameEndpointForecast(float latitude, float longitude, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append($"/{apiKey}");
            stringBuilder.Append($"/{latitude}");
            stringBuilder.Append($",{longitude}");
            stringBuilder.Append($",{longitude}");
            stringBuilder.Append($"?units={units}");
            return stringBuilder.ToString();
        }

        
    }
}

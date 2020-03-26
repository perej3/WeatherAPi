using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class WeatherBitIoEndpoint : Endpoint
    {
        public WeatherBitIoEndpoint() :
                    base("c74c871e18674065bea599574ef4756e",
                        "https://api.weatherbit.io",
                        new Dictionary<EndpointType, string>{
                            {EndpointType.CURRENT,"current" },
                            {EndpointType.FORECAST,"forecast/daily"}
                        },
                        "v2.0")
        { }

        
        public string getByCityNameEndpoint(string cityName, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?city=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&key=");
            stringBuilder.Append(apiKey);
            return stringBuilder.ToString();
        }

        
    }
}

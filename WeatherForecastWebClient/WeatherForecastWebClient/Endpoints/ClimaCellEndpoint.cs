using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
 

    class ClimaCellEndpoint : Endpoint
    {
        public ClimaCellEndpoint() :
             base("Ph5BS3KokuE4hpdn3n9SqRplLE1TOMZe",
                 "https://api.climacell.co",
                 new Dictionary<EndpointType, string>{
                            {EndpointType.CURRENT,"realtime" },
                            {EndpointType.FORECAST,"forecast"}
                 },
                 "v3",
                 "temp:C")
        { }


        public string getByCityNameEndpoint(float latitude, float longitude, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append("/weather");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append($"&lat={latitude}");
            stringBuilder.Append($"&lon={longitude}");
            stringBuilder.Append("&fields=");
            stringBuilder.Append(units);
            return stringBuilder.ToString();
        }

        public string getByCityNameEndpointForecast(float latitude, float longitude, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append("/weather");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("/daily");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append($"&lat={latitude}");
            stringBuilder.Append($"&lon={longitude}");
            stringBuilder.Append("&start_time=now");
            stringBuilder.Append($"&end_time={DateTime.UtcNow.AddDays(14).ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            stringBuilder.Append("&fields=");
            stringBuilder.Append(units);
            return stringBuilder.ToString();
        }

    }
}

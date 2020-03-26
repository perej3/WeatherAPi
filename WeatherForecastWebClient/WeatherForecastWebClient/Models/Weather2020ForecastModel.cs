using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class Weather2020ForecastModel
    {
        [DataMember]
        public float temperatureHighCelcius { get; set; }
        [DataMember]
        public float temperatureLowCelcius { get; set; }
    }

    
}


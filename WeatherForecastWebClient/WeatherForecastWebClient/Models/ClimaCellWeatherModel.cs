using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class ClimaCellWeatherModel
    {
        [DataMember]
        public TempWeather temp { get; set; }
    }

    [DataContract]
    class TempWeather
    {
        [DataMember]
        public float value { get; set; }

        [DataMember]
        public string units { get; set; }

    }
}


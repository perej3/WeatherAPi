using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class DarkSkyForecastModel
    {

        [DataMember]
        public DailyForecastSky daily { get; set; }

    }
    [DataContract]
    class DailyForecastSky
    {

        public List<DailyForecastDaily> data { get; set; }

      
    }

    [DataContract]
    class DailyForecastDaily
    {
        [DataMember]
        public float temperatureHigh { get; set; }
        [DataMember]
        public float temperatureLow { get; set; }
        
        
    }
}




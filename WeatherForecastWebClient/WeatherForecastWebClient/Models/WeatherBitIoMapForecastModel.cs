using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.WeatherForecastModel
{
    [DataContract]
    class WeatherBitIoMapForecastModel
    {
        [DataMember]
        public List<DataForecast> data { get; set; }

    }
    [DataContract]
    class DataForecast
    {
        [DataMember]
        public float temp { get; set; }
        [DataMember]
        public string datetime { get; set; }
        [DataMember]
        public float app_temp { get; set; }
        [DataMember]
        public float min_temp { get; set; }
        [DataMember]
        public float max_temp { get; set; }
        [DataMember]
        public float app_min_temp { get; set; }
        [DataMember]
        public float app_max_temp { get; set; }
        [DataMember]
        public string wind_cdir_full { get; set; }
        [DataMember]
        public float pres { get; set; }
        [DataMember]
        public float slp { get; set; }
        [DataMember]
        public float rh { get; set; }
    }
}




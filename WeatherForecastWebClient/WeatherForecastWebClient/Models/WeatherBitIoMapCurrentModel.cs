using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.CurrentModel
{
    [DataContract]
    class WeatherBitIoMapCurrentModel
    {
        [DataMember]
        public List<Data> data { get; set; }

    }
    [DataContract]
    class Data
    {
        [DataMember]
        public float temp { get; set; }
        [DataMember]
        public string datetime { get; set; }
        [DataMember]
        public float app_temp { get; set; }
        [DataMember]
        public float uv { get; set; }
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


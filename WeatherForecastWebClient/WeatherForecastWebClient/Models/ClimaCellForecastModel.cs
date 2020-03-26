using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class ClimaCellForecastModel
    {
        [DataMember]
        public List<Temp> temp { get; set; }
    }

    [DataContract]
    class Temp
    {
        [DataMember]
        public TempInside min { get; set; }

        [DataMember]
        public TempInside max { get; set; }

        [DataMember]
        public string observation_time { get; set; }

    }

    [DataContract]
    class TempInside
    {
        [DataMember]
        public float value { get; set; }

        [DataMember]
        public string units { get; set; }

    }
}


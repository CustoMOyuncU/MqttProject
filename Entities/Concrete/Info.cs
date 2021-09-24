using Core.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Info:IEntity
    {
        public Info(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jInfo = jObject["object"];
            Humidity = (string)jInfo["humidity"];
            Temperature = (string)jInfo["temperature"];
            JToken jInfoRx = jObject["rxInfo"][0];
            Time = (string)jInfoRx["time"];
        }

        public string Humidity { get; set; }
        public string Temperature { get; set; }
        public string Time { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebServiceApp.Models
{
  
  


    [Serializable()]
    public class WeatherXML_Linq
    {

        public string City { get; set; }

        public string Temp { get; set; }

        public string Temp_Min { get; set; }

        public string Temp_Max { get; set; }

        public string Description { get; set; }
    }

}

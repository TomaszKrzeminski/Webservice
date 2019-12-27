using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebServiceApp.Models.Xml2
{
    [XmlRoot(ElementName = "location")]
    public class Location
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "timezone")]
        public string Timezone { get; set; }

        [XmlElement(ElementName = "location")]
        public Location2 location2 { get; set; }

       
    }

    [XmlRoot(ElementName = "location")]
    public class Location2
    {
       
        [XmlAttribute(AttributeName = "altitude")]
        public string Altitude { get; set; }
        [XmlAttribute(AttributeName = "latitude")]
        public string Latitude { get; set; }
        [XmlAttribute(AttributeName = "longitude")]
        public string Longitude { get; set; }
        [XmlAttribute(AttributeName = "geobase")]
        public string Geobase { get; set; }
        [XmlAttribute(AttributeName = "geobaseid")]
        public string Geobaseid { get; set; }
    }
             

    [XmlRoot(ElementName = "weatherdata")]
    public class Weatherdata
    {
        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }
       
    }


}

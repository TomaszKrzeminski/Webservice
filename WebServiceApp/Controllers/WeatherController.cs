using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebServiceApp.Models;
using WebServiceApp.Models.Xml;
using WebServiceApp.Models.Xml2;

namespace WebServiceApp.Controllers
{
    public class WeatherController : Controller
    {

        public IActionResult Home()
        {
            return View();
        }




        public async Task<IActionResult> Panel()
        {
            var httpClient = new HttpClient();
            var url = "http://api.openweathermap.org/data/2.5/weather?q=Świecie,pl&units=metric&APPID=41270c91174b3fd8bdae41229160b95d";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            string responseBody = await response.Content.ReadAsStringAsync();
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(responseBody);


            return View(rootObject);
        }


        public async Task<IActionResult> Panel_JSON_LINQ()
        {
            var httpClient = new HttpClient();
            var url = "http://api.openweathermap.org/data/2.5/weather?q=Świecie,pl&units=metric&APPID=41270c91174b3fd8bdae41229160b95d";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject o = JObject.Parse(responseBody);

            Weather_JSON_LINQ weather = new Weather_JSON_LINQ();
            weather.City = (string)o["name"];
            weather.Temp = (double)o["main"]["temp"];
            weather.Temp_Min = (double)o["main"]["temp_min"];
            weather.Temp_Max = (double)o["main"]["temp_max"];
            weather.Description = (string)o["weather"][0]["description"];


            return View(weather);
        }

        public async Task<IActionResult> PanelXML()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Świecie,pl&mode=xml&units=metric&APPID=41270c91174b3fd8bdae41229160b95d";

            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(url);

            string data = await response.Content.ReadAsStringAsync();


            var ser = new System.Xml.Serialization.XmlSerializer(typeof(Current));

            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            Current reply = (Current)ser.Deserialize(stream);





            return View(reply);
        }


        public IActionResult Panel_XML_LINQ()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Świecie,pl&mode=xml&units=metric&APPID=41270c91174b3fd8bdae41229160b95d";
            XDocument document = XDocument.Load(url);
           

            WeatherXML_Linq weather = new WeatherXML_Linq();           
            weather.City = document.Element("current").Element("city").Attribute("name").Value;
            weather.Temp = document.Element("current").Element("temperature").Attribute("value").Value;
            weather.Temp_Min = document.Element("current").Element("temperature").Attribute("min").Value;
            weather.Temp_Max = document.Element("current").Element("temperature").Attribute("max").Value;
            weather.Description = document.Element("current").Element("weather").Attribute("value").Value;




            return View(weather);
        }


        public async Task<IActionResult> PanelXML2()
        {
            string url = "http://api.openweathermap.org/data/2.5/forecast?q=Świecie,pl&mode=xml&APPID=41270c91174b3fd8bdae41229160b95d";

            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(url);

            string data = await response.Content.ReadAsStringAsync();


            var ser = new System.Xml.Serialization.XmlSerializer(typeof(Weatherdata));

            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            Weatherdata reply = (Weatherdata)ser.Deserialize(stream);





            return View(reply);
        }





    }
}
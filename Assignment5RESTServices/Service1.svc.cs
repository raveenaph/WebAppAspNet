using Assignment5RESTServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace Assignment5RESTServices
{


    //All the classes needed to deserialize the air quality

    //"attributions":[{"url":"http://pima.gov/","name":"Pima County Department of Environmental Quality Air","logo":"US-PimaCounty.png"},
    //                {"url":"http://www.airnow.gov/","name":"Air Now - US EPA"},
    //                {"url":"https://waqi.info/","name":"World Air Quality Index Project"} ],
    public class Attribution
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    //"city":{"geo":[32.380816,-111.127157],"name":"Coachline, Pima County, USA","url":"https://aqicn.org/city/usa/pima-county/coachline","location":""},
    public class City
    {
        public IList<double> geo { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string location { get; set; }
    }


    /// ////////////////////////////////////////////////////////////////////////
    //Objects in Iaqi
    public class Co
    {
        public double v { get; set; }
    }

    public class No2
    {
        public double v { get; set; }
    }

    public class O3
    {
        public double v { get; set; }
    }

    public class Pm25
    {
        public int v { get; set; }
    }

    public class Pm10
    {
        public int v { get; set; }
    }

    public class H
    {
        public double v { get; set; }
    }

    public class P
    {
        public double v { get; set; }
    }

    public class T
    {
        public double v { get; set; }
    }

    public class W
    {
        public double v { get; set; }
    }
    //"so2":{"v":0.3}
    public class So2
    {
        public double v { get; set; }
    }
    public class Wg
    {
        public double v { get; set; }
    }
    /// ////////////////////////////////////////////////////////////////////////////

    //"iaqi":{"co":{"v":2.1},"h":{"v":52.5},"no2":{"v":1.7},"o3":{"v":26.4},"p":{"v":1009.9},"pm10":{"v":19},"pm25":{"v":13},"so2":{"v":0.3},"t":{"v":22.2},"w":{"v":2.8},"wg":{"v":10.5}},
    public class Iaqi
    {
        public Co co { get; set; }
        public H h { get; set; }
        public No2 no2 { get; set; }
        public O3 o3 { get; set; }
        public P p { get; set; }
        public Pm10 pm10 { get; set; }
        public Pm25 pm25 { get; set; }
        public So2 so2 { get; set; }
        public T t { get; set; }
        public W w { get; set; }
        public Wg wg { get; set; }
    }

    //"time":{"s":"2024-10-18 08:00:00","tz":"-07:00","v":1729238400,"iso":"2024-10-18T08:00:00-07:00"},
    public class Time
    {
        public string s { get; set; }
        public string tz { get; set; }
        public int v { get; set; }
        public string iso { get; set; }
    }

    //"data":{
    //"aqi":26,
    //"idx":5962,
    //"attributions":[{"url":"http://pima.gov/","name":"Pima County Department of Environmental Quality Air","logo":"US-PimaCounty.png"},{"url":"http://www.airnow.gov/","name":"Air Now - US EPA"},{"url":"https://waqi.info/","name":"World Air Quality Index Project"}],
    //"city":{"geo":[32.380816,-111.127157],"name":"Coachline, Pima County, USA","url":"https://aqicn.org/city/usa/pima-county/coachline","location":""},
    //"dominentpol":"o3",
    //"iaqi":{"co":{"v":2.1},"h":{"v":52.5},"no2":{"v":1.7},"o3":{"v":26.4},"p":{"v":1009.9},"pm10":{"v":19},"pm25":{"v":13},"so2":{"v":0.3},"t":{"v":22.2},"w":{"v":2.8},"wg":{"v":10.5}},
    //"time":{"s":"2024-10-18 08:00:00","tz":"-07:00","v":1729238400,"iso":"2024-10-18T08:00:00-07:00"},
    public class Data
    {
        public int aqi { get; set; }
        public int idx { get; set; }
        public IList<Attribution> attributions { get; set; }
        public City city { get; set; }
        public string dominentpol { get; set; }
        public Iaqi iaqi { get; set; }
        public Time time { get; set; }
    }

    //{"status":"ok",
    //"data":{"aqi":26,"idx":5962,"attributions":[{"url":"http://pima.gov/","name":"Pima County Department of Environmental Quality Air",
    //"logo":"US-PimaCounty.png"},{"url":"http://www.airnow.gov/","name":"Air Now - US EPA"},{"url":"https://waqi.info/","name":"World Air Quality Index Project"}],
    //"city":{"geo":[32.380816,-111.127157],"name":"Coachline, Pima County, USA","url":"https://aqicn.org/city/usa/pima-county/coachline","location":""},
    //"dominentpol":"o3",
    //"iaqi":{"co":{"v":2.1},"h":{"v":52.5},"no2":{"v":1.7},"o3":{"v":26.4},"p":{"v":1009.9},"pm10":{"v":19},"pm25":{"v":13},"so2":{"v":0.3},"t":{"v":22.2},"w":{"v":2.8},"wg":{"v":10.5}},
    //"time":{"s":"2024-10-18 08:00:00","tz":"-07:00","v":1729238400,"iso":"2024-10-18T08:00:00-07:00"},
    //"forecast":{"daily":{"o3":[{"avg":11,"day":"2024-10-16","max":20,"min":5},{"avg":12,"day":"2024-10-17","max":20,"min":5},{"avg":16,"day":"2024-10-18","max":20,"min":12},{"avg":16,"day":"2024-10-19","max":21,"min":11},
    //{"avg":14,"day":"2024-10-20","max":22,"min":11},{"avg":13,"day":"2024-10-21","max":29,"min":8},{"avg":12,"day":"2024-10-22","max":32,"min":8}],"pm10":[{"avg":9,"day":"2024-10-16","max":13,"min":3},
    //{"avg":7,"day":"2024-10-17","max":9,"min":3},{"avg":24,"day":"2024-10-18","max":57,"min":5},{"avg":20,"day":"2024-10-19","max":32,"min":10},{"avg":11,"day":"2024-10-20","max":18,"min":7},
    //{"avg":12,"day":"2024-10-21","max":19,"min":8},{"avg":17,"day":"2024-10-22","max":25,"min":11}],"pm25":[{"avg":16,"day":"2024-10-16","max":25,"min":5},{"avg":11,"day":"2024-10-17","max":16,"min":4},
    //{"avg":19,"day":"2024-10-18","max":42,"min":6},{"avg":23,"day":"2024-10-19","max":34,"min":13},{"avg":23,"day":"2024-10-20","max":45,"min":10},{"avg":25,"day":"2024-10-21","max":47,"min":14},
    //{"avg":38,"day":"2024-10-22","max":55,"min":18}],"uvi":[{"avg":0,"day":"2024-10-17","max":0,"min":0},{"avg":1,"day":"2024-10-18","max":5,"min":0},{"avg":1,"day":"2024-10-19","max":5,"min":0},
    //{"avg":1,"day":"2024-10-20","max":6,"min":0},{"avg":1,"day":"2024-10-21","max":7,"min":0},{"avg":2,"day":"2024-10-22","max":7,"min":0}]}},"debug":{"sync":"2024-10-19T00:25:41+09:00"}}}
    public class AQ
    {
        public string status { get; set; }
        public Data data { get; set; }
    }



    public class Service1 : IService1
    {

        //Return quality of air based on metrics from aqicn.org
        //0-50 : Good
        //50-100: Moderate
        //100-150 : Unhealthy for sensitive groups
        //150-300 : Unhealthy
        //200-300 : Very unhealthy
        //300-500 : Hazardous
        public string getAirQuality(decimal latitude, decimal longitude)
        {

            string baseUrl = "https://api.waqi.info/feed/geo:";
            string api_key = "f38bc48120ae1e2f8fe3d0f014c76110114e55f8";
            string latString = latitude.ToString();
            string lonString = longitude.ToString();
            string airQuality = "Unknown";

            string fullUrl = baseUrl + latString + ";" + lonString + "/?token=" + api_key;
            WebClient webClient = new WebClient();

            try
            {
                String response = webClient.DownloadString(fullUrl);
                AQ aq = JsonConvert.DeserializeObject<AQ>(response);
                int aqNum = aq.data.aqi;

                if (aqNum <= 50)
                    airQuality = aqNum + " :Good";

                if (aqNum > 50 && aqNum <= 100)
                    airQuality = aqNum + " :Unhealthy for sensitive groups";

                if (aqNum > 100 && aqNum <= 150)
                    airQuality = aqNum + " :Unhealthy";

                if (aqNum > 150 && aqNum <= 300)
                    airQuality = aqNum + " :Very Unhealthy";

                if (aqNum > 300)
                    airQuality = aqNum + " :Hazardous";
            }
            catch (Exception e)
            {
                airQuality = e.Message.ToString();
            }

            return airQuality;

        }

    }
}

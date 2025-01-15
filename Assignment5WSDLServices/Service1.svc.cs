using Assignment5WSDLServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;


namespace Assignment5WSDLServices
{

    //Deseieralize the timezone for zipcode service
    public class Timezone
    {
        public string timezone_identifier { get; set; }
        public string timezone_abbr { get; set; }
        public int utc_offset_sec { get; set; }
        public string is_dst { get; set; }
    }

    //Deserialize the location for the zipcode service
    public class Location
    {
        public string zip_code { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public Timezone timezone { get; set; }
        public IList<object> acceptable_city_names { get; set; }
    }



    //Deserialize weather forecast response
    //{"Headline":{"EffectiveDate":"2024-10-19T13:00:00-07:00","EffectiveEpochDate":1729368000,"Severity":7,"Text":"Cool this afternoon",
    //"Category":"cold","EndDate":"2024-10-19T19:00:00-07:00","EndEpochDate":1729389600,"MobileLink":"http://www.accuweather.com/en/us/chandler-az/85225/daily-weather-forecast/326856?lang=en-us",
    //"Link":"http://www.accuweather.com/en/us/chandler-az/85225/daily-weather-forecast/326856?lang=en-us"},
    //"DailyForecasts":[{"Date":"2024-10-19T07:00:00-07:00","EpochDate":1729346400,
    //"Temperature":{"Minimum":{"Value":51.0,"Unit":"F","UnitType":18},
    //"Maximum":{ "Value":72.0,"Unit":"F","UnitType":18}},
    //"Day":{ "Icon":14,"IconPhrase":"Partly sunny w/ showers","HasPrecipitation":true,"PrecipitationType":"Rain","PrecipitationIntensity":"Light"},
    //"Night":{ "Icon":33,"IconPhrase":"Clear","HasPrecipitation":false},
    //"Sources":["AccuWeather"],
    //"MobileLink":"http://www.accuweather.com/en/us/chandler-az/85225/daily-weather-forecast/326856?day=1&lang=en-us",
    //"Link":"http://www.accuweather.com/en/us/chandler-az/85225/daily-weather-forecast/326856?day=1&lang=en-us"}]}


    //"Night":{ "Icon":33,"IconPhrase":"Clear","HasPrecipitation":false},
    public class Night
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
    }

    //"Day":{ "Icon":14,"IconPhrase":"Partly sunny w/ showers","HasPrecipitation":true,"PrecipitationType":"Rain","PrecipitationIntensity":"Light"},
    public class Day
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
    }


    //"Temperature":{"Minimum":{"Value":51.0,"Unit":"F","UnitType":18}, "Maximum":{ "Value":72.0,"Unit":"F","UnitType":18}},
    public class Temperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    //"Maximum":{ "Value":72.0,"Unit":"F","UnitType":18}},
    public class Maximum
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }


    //"Minimum":{"Value":51.0,"Unit":"F","UnitType":18},
    public class Minimum
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    //"DailyForecasts":[{"Date":"2024-10-19T07:00:00-07:00","EpochDate":1729346400,
    //"Temperature":{"Minimum":{"Value":51.0,"Unit":"F","UnitType":18},
    //"Maximum":{ "Value":72.0,"Unit":"F","UnitType":18}},
    //"Day":{ "Icon":14,"IconPhrase":"Partly sunny w/ showers","HasPrecipitation":true,"PrecipitationType":"Rain","PrecipitationIntensity":"Light"},
    //"Night":{ "Icon":33,"IconPhrase":"Clear","HasPrecipitation":false},
    //"Sources":["AccuWeather"],
    //"MobileLink":"http://www.accuweather.com/en/us/chandler-az/85225/daily-weather-forecast/326856?day=1&lang=en-us",
    //"Link":"http://www.accuweather.com/en/us/chandler-az/85225/daily-weather-forecast/326856?day=1&lang=en-us"}]}
    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        public IList<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    //{"Headline":{"EffectiveDate":"2024-10-19T13:00:00-07:00","EffectiveEpochDate":1729368000,"Severity":7,
    //"Text":"Cool this afternoon","Category":"cold",
    //"EndDate":"2024-10-19T19:00:00-07:00",
    //"EndEpochDate":1729389600,
    //"MobileLink":"http://www.accuweather.com/en/us/chandler-az/85225/daily-weather-forecast/326856?lang=en-us",
    //"Link":"http://www.accuweather.com/en/us/chandler-az/85225/daily-weather-forecast/326856?lang=en-us"},
    public class Headline
    {
        public DateTime EffectiveDate { get; set; }
        public int EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public object EndDate { get; set; }
        public object EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class DailyForecastArray
    {
        public Headline Headline { get; set; }
        public IList<DailyForecast> DailyForecasts { get; set; }
    }


    public class Service1 : IService1
    {

        //Elective service #1
        //Sevice 15: Weather Service
        //Description : Create a 5-day forecast service of a zipcode location based on the search for free wether serives

        public List<List<string>> Weather5day(string zipcode)
        {
            //list to be returned

            string baseURL = "http://dataservice.accuweather.com/locations/v1/postalcodes/US/search?";

            //add our api key and the zipcode to the url
            //this api call will take in the zipcode and return location key
            string fullURL = baseURL + "apikey=IQXMZGGHqmwul6DTqmGnittMvKdrKuUK&" + "q=" + zipcode;
            WebClient wc = new WebClient();
            string locationKey = "";

            List<List<string>> forecastarr = new List<List<string>>();

            try
            {
                string response = wc.DownloadString(fullURL);
                //api returns JSON array, we have to parse the location key

                JArray j = JArray.Parse(response);

                foreach (JObject obj in j.Children())
                {
                    locationKey = (string)(obj["Key"]);
                }

                //now we have location key, we can use another api to give us the weather
                string weatherURL = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/" + locationKey
                    + "?apikey=IQXMZGGHqmwul6DTqmGnittMvKdrKuUK";

                string forecastResp = wc.DownloadString(weatherURL);

                //Store the response into an objects using the classes created above
                DailyForecastArray dailyForecastArrayObject = JsonConvert.DeserializeObject<DailyForecastArray>(forecastResp);

                //Now extract the min and max temp for each day from the above deserialized object
                for (int i = 0; i < dailyForecastArrayObject.DailyForecasts.Count; i++)
                {
                    List<String> forecastList = new List<string>();
                    forecastList.Add((dailyForecastArrayObject.DailyForecasts[i].Date).ToString());
                    forecastList.Add((dailyForecastArrayObject.DailyForecasts[i].Temperature.Minimum.Value).ToString());
                    forecastList.Add((dailyForecastArrayObject.DailyForecasts[i].Temperature.Maximum.Value).ToString());
                    forecastarr.Add(forecastList);

                }

            }
            catch (Exception ex)
            {
                List<string> errMsg = new List<string>();
                errMsg.Add(ex.Message.ToString());
                forecastarr.Add(errMsg);
            }

            return forecastarr;
        }

        //Required Service #1
        //return the average wind speed in the year range for a given position
        public decimal WindIntensity(decimal latitude, decimal longitude)
        {
            WebClient wc = new WebClient();

            string startyr = "2001";
            string endyr = "2020";
            string param = "WS10M_RANGE_AVG";
            string latString = latitude.ToString();
            string lonString = longitude.ToString();

            try
            {
                string windURL = "https://power.larc.nasa.gov/api/temporal/monthly/point?";
                windURL += "start=" + startyr + "&end=" + endyr + "&latitude=" + latString
                    + "&longitude=" + lonString + "&community=ag&parameters=" + param + "&format=json&header=true";

                string windspeeds = wc.DownloadString(windURL);

                JObject h = JObject.Parse(windspeeds);
                var windspeedsarr = h["properties"]["parameter"]["WS10M_RANGE_AVG"].ToObject<Dictionary<string, double>>();

                //The API returns average windspeed of each month
                //To average it over all the months, sum it and divide by the number of months
                double sum = 0;
                foreach (var speed in windspeedsarr.Values)
                {
                    sum += speed;
                }
                decimal average = (decimal)(sum / windspeedsarr.Count);

                return average;
            }
            catch (Exception e)
            {
                return -1;
                //return e.Message.ToString();

            }
        }

        //Required Service #2
        //return the average sunshine index of a given location
        public decimal SolarIntensity(decimal latitude, decimal longitude)
        {
            WebClient wc = new WebClient();

            //Use 20 year data to average 
            string startyr = "2001";
            string endyr = "2020";
            string param = "ALLSKY_SFC_SW_DWN";
            string latString = latitude.ToString();
            string lonString = longitude.ToString();
            string baseURL = "https://power.larc.nasa.gov/api/temporal/monthly/point?";

            string fullURL = baseURL + "start=" + startyr + "&end=" + endyr + "&latitude=" + latString
                   + "&longitude=" + lonString + "&community=ag&parameters=" + param + "&format=json&header=true";

            try
            {

                string solarIntensities = wc.DownloadString(fullURL);

                JObject h = JObject.Parse(solarIntensities);
                var solarIntensityArr = h["properties"]["parameter"]["ALLSKY_SFC_SW_DWN"].ToObject<Dictionary<string, double>>();

                //The API returns average windspeed of each month
                //To average it over all the months, sum it and divide by the number of months
                double sum = 0;
                foreach (var speed in solarIntensityArr.Values)
                {
                    sum += speed;
                }
                decimal average = (decimal)(sum / solarIntensityArr.Count);

                return average;
            }
            catch (Exception e)
            {
                return -1;
                //return e.Message.ToString();

            }

        }



        //Call webservice at zipcodeapi to convert zipcode to lat long
        //This maybe needed for the final application, leaving it in here
        public string getLatLng(string zipcode)
        {
            string latLong = "";

            string fullURL = "https://www.zipcodeapi.com/rest/qVyoKYn20EQ9BqBevL5royhx5T0JyD92vCtxVlleTKZ0yfee6vU1WfYh05xCPgYn/info.json/" + zipcode + "/degrees";

            try
            {
                WebClient webClient = new WebClient();
                String response = webClient.DownloadString(fullURL);

                Location locationObject = JsonConvert.DeserializeObject<Location>(response);
                latLong = locationObject.lat.ToString() + "," + locationObject.lng.ToString();
            }
            catch (Exception e)
            {
                latLong = e.Message.ToString();
            }

            return latLong;
        }

        //Required Service #3
        //return the amount of Natural Disaster type within range of (latitude, longitude).
        public string[] NaturalHazardData(string type, string lat, string lon)
        {
            string[] res = new string[2];
            try
            {
                //type of natural disaster
                string naturalInput = "";
                if (type == "Tornado")
                {
                    naturalInput = "nx3tvs";
                }
                else if (type == "Mesocyclone")
                {
                    naturalInput = "nx3meso";
                }
                else if (type == "Hail")
                {
                    naturalInput = "nx3hail";
                }
                else
                {
                    naturalInput = "nx3structure";
                }

                string Url = "https://www.ncdc.noaa.gov/swdiws/json/" + naturalInput + "/20060505?bbox=" + lat + "," + lon;
                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(Url);
                rq.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)rq.GetResponse();
                Stream streamTxt = response.GetResponseStream();
                StreamReader readStreamTxt = new StreamReader(streamTxt, Encoding.UTF8);
                string data = readStreamTxt.ReadToEnd();

                dynamic ret = JsonConvert.DeserializeObject<dynamic>(data);
                Console.WriteLine(data);
                res[0] = ret.summary.count;
                return res;
            }
            catch (Exception ex)
            {
                res[0] = "error occurs";
                res[1] = ex.Message;
                return res;
            }

        }

    }
}

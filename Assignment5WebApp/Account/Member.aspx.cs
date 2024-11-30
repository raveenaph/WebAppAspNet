using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace Assignment5.Member
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["Name"] == ""))
            {
                lblWelcomeMsg.Text = "Welcome, Guest";
            } else
            {
                lblWelcomeMsg.Text = "Welcome, " + myCookies["Name"];
            }
        }

        protected void ButtonGetWindSpeed_Click(object sender, EventArgs e)
        {
            LabelWindOutput.Text = "Getting Wind Intensity. Please be patient";

            mySvcRef.Service1Client myService = new mySvcRef.Service1Client();
            decimal lat = Convert.ToDecimal(TextBoxLatWind.Text);
            decimal lon = Convert.ToDecimal(TextBoxLongWind.Text);

            decimal windSpeed = myService.WindIntensity(lat, lon);
            LabelWindOutput.Text = windSpeed.ToString();
        }

        protected void ButtonGetSolarIntensity_Click(object sender, EventArgs e)
        {
            mySvcRef.Service1Client myService = new mySvcRef.Service1Client();
            decimal lat = Convert.ToDecimal(TextBoxLatSolar.Text);
            decimal lon = Convert.ToDecimal(TextBoxLongSolar.Text);

            LabelSolarOutput.Text = "Getting Solar Intensity. Please be patient";

            decimal solarIntensity = myService.SolarIntensity(lat, lon);
            LabelSolarOutput.Text = solarIntensity.ToString();
        }

        protected void ButtonGetForecast_Click(object sender, EventArgs e)
        {
            mySvcRef.Service1Client myService = new mySvcRef.Service1Client();

            //Empty out the zipcode when button clicked
            labelWS.Text = "";

            //Get the zipcode
            string zipcode = txtZipcode.Text.ToString();

            try
            {
                string[][] response = myService.Weather5day(zipcode);

                //Create a HTML table to show weather forecast
                labelWS.Text += "<table>";

                labelWS.Text += "<tr>";
                labelWS.Text += "&nbsp;<td style=\"padding-right:15px\">";
                labelWS.Text += "Day&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspMin&nbspMax";
                labelWS.Text += "</td>&nbsp;";

                for (int i = 0; i < response.Length; i++)
                {
                    labelWS.Text += "<tr>";
                    for (int j = 0; j < response[i].Length; j++)
                    {
                        labelWS.Text += "&nbsp;<td style=\"padding-right:15px\">";
                        labelWS.Text += response[i][j];
                        labelWS.Text += "</td>&nbsp;";
                    }
                    labelWS.Text += "</tr>";
                }
                labelWS.Text += "</table>";
            }
            catch (Exception ex)
            {
                labelWS.Text = ex.Message.ToString();
            }
        }

        protected void ButtonGetDisaster_Click(object sender, EventArgs e)
        {
            resultLbl.Visible = false;
            mySvcRef.Service1Client myService = new mySvcRef.Service1Client();
            try
            {
                string radioValue = RadioButtonListType.SelectedValue;
                string[] result = myService.NaturalHazardData(radioValue, LatTxt.Text, LonTxt.Text);

                if (result[0] != "error occurs")
                {
                    resultLbl.Visible = true;
                    resultLbl.Text = "The amount of " + radioValue + " is " + result[0];
                }
                else
                {
                    resultLbl.Visible = false;
                    resultLbl.Text = result[1];
                }
            }
            catch (Exception err)
            {
                resultLbl.Text = err.Message.ToString();
            }
            finally
            {
                //radiotest.Text = RadioButtonList1.SelectedValue;
            }
        }
    }
}
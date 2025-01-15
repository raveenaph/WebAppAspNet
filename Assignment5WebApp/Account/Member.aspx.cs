using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Text.Json;

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
            }
            else
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

        protected void btnCalculate_Click(object sender, EventArgs e)
        {

                lblEstimatedPrice.Text = "Calculating estimated price. Please wait...";

                try
                {
                    // Collect input values
                    string address = txtAddress.Text.Trim();
                    string propertyType = rblPropertyType.SelectedValue; // Get selected property type
                    int bedrooms = int.TryParse(txtBedrooms.Text.Trim(), out var b) ? b : 0;
                    int bathrooms = int.TryParse(txtBathrooms.Text.Trim(), out var bath) ? bath : 0;
                    int squareFootage = int.TryParse(txtSquareFootage.Text.Trim(), out var sqft) ? sqft : 0;
                    int compCount = int.TryParse(txtCompCount.Text.Trim(), out var comp) ? comp : 0;

                    // Validate input
                    if (string.IsNullOrWhiteSpace(address) || bedrooms <= 0 || bathrooms <= 0 || squareFootage <= 0 || compCount <= 0)
                    {
                        lblEstimatedPrice.Text = "Please provide valid inputs for all fields.";
                        return;
                    }

                    // Create a service client instance
                    using (var client = new PropertyData.Service1Client()) // Use the generated client class
                    {
                        // Call the WCF service method
                        string estimatedPrice = client.GetPropertyData(address, propertyType, bedrooms, bathrooms, squareFootage, compCount);

                        //Get just price from json
                        var jsonObject = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(estimatedPrice);

                        // Extract the "price" property
                        if (jsonObject.TryGetProperty("price", out JsonElement priceElement))
                        {
                            int price = priceElement.GetInt32();
                            //Console.WriteLine($"Price: {price}");
                            // Display the estimated price
                            lblEstimatedPrice.Text = !string.IsNullOrEmpty(estimatedPrice) ? price.ToString() : "No data found.";
                        }
                        else
                        {
                            Console.WriteLine("Price not found in the JSON.");
                        }

                        // Display the estimated price
                        //lblEstimatedPrice.Text = !string.IsNullOrEmpty(estimatedPrice) ? price : "No data found.";


                    }
                }
                catch (Exception ex)
                {
                    // Handle errors gracefully
                    lblEstimatedPrice.Text = $"Error: {ex.Message}";
                }

            }   // end of rent


        //Calculate Rent
    }

}
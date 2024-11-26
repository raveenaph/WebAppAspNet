using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class ServicesTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonWindService_Click(object sender, EventArgs e)
        {
            LabelWindOutput.Text = "Getting Wind Intensity. Please be patient";

            mySvcRef.Service1Client myService = new mySvcRef.Service1Client();
            decimal lat = Convert.ToDecimal(TextBoxLatWind.Text);
            decimal lon = Convert.ToDecimal(TextBoxLongWind.Text);

            decimal windSpeed = myService.WindIntensity(lat, lon);
            LabelWindOutput.Text = windSpeed.ToString();
        }
    }
}
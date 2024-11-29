using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class ImageVerifier : System.Web.UI.UserControl
    {

        public string generatedstr = string.Empty;

        protected void changeImage()
        {
            ImageVerifierSvc.ServiceClient imgPxy = new ImageVerifierSvc.ServiceClient();

            Session["userLength"] = "4";
            string myStr = imgPxy.GetVerifierString("4");
            Session["generatedString"] = myStr;

            btnShowImage.Text = "Show Me another Image string";
            Image1.Visible = true;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/imageProcess.aspx";
            //changeImage();
            Image1.Visible = false;

        }

        protected void btnShowImage_Click(object sender, EventArgs e)
        {
            changeImage();
            btnShowImage.Text = "Show me another image";
        }
    }
}
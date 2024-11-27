using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;


namespace Assignment5
{
    public partial class imageProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            ImageVerifierSvc.ServiceClient imgPxy = new ImageVerifierSvc.ServiceClient();
            string myStr, userLen;

            if (Session["userLength"] == null)
                userLen = "4";
            else
                userLen = Session["userLength"].ToString();

            if (Session["generatedString"] == null)
            {
                myStr = imgPxy.GetVerifierString(userLen);
                Session["generatedString"] = myStr;
            }
            else
            {
                myStr = Session["generatedString"].ToString();
            }
           
            Stream myStream = imgPxy.GetImage(myStr);
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
            Response.ContentType = "image/jpeg";
            myImage.Save(Response.OutputStream, ImageFormat.Jpeg); 

        }
    }
}
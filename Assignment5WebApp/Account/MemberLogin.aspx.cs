using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.PeerResolvers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using HashFunctions;
using System.Net;


namespace Assignment5
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Save username in a session variable
            Session["name"] = txtLogin.Text;

            Response.Redirect("Member/Member.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string filepath = HttpRuntime.AppDomainAppPath +
                @"\Account\App_Data\Members.xml";

            //Get user input and encrypted password
            string user = txtLogin.Text;
            string password = txtPassword.Text;
            //Hash entered password using the HashFunctions DLL
            string pwdEncrypt = hashPassword.HashPassword(password);

            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filepath);

            XmlElement rootElement = myDoc.DocumentElement;

            //Search through the XML file to find match of username and password matches
            foreach (XmlNode node in rootElement.ChildNodes)
            {
                if (node["name"].InnerText == user)
                {
                    if (node["pwd"].InnerText == pwdEncrypt)
                    {
                        //username and password matched
                        //Save username in a session variable so that it can be displayed through user control
                        Session["name"] = txtLogin.Text;

                        //Save username in a cookie
                        HttpCookie myCookies = new HttpCookie("myCookieId");
                        myCookies["Name"] = user;
                        myCookies.Expires = DateTime.Now.AddMinutes(30);
                        Response.Cookies.Add(myCookies);

                        //Go to main app page
                        Response.Redirect("Member.aspx");
                        return;
                    }
                    else
                    {
                        //Either username or password didnt' match
                        lblError.Text = "Error: either username or password is incorrect";
                        return;
                    }
                }
            }
            lblError.Text = "Error: either username or password is incorrect";
            return;
        }


    }
}
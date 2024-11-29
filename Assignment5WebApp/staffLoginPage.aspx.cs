using HashFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Assignment5
{
    public partial class staffLoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        bool myAuthenticate(string username, string password)
        {

            string filepath = HttpRuntime.AppDomainAppPath +
                @"App_Data\Staff.xml";

            //Get user input and encrypted password
            //Hash entered password using the HashFunctions DLL
            string pwdEncrypt = hashPassword.HashPassword(password);

            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filepath);

            XmlElement rootElement = myDoc.DocumentElement;

            //Search through the XML file to find match of username and password matches
            foreach (XmlNode node in rootElement.ChildNodes)
            {
                if (node["name"].InnerText == username)
                    if (node["pwd"].InnerText == pwdEncrypt)
                        return true;
            }

            return false;
        }


        //Staff login
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (myAuthenticate(txtUserName.Text, txtPassword.Text))
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
            else
                Output.Text = "Invalid Login";
        }

    }
   
}
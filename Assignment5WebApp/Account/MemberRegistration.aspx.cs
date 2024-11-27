using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashFunctions;
using System.Xml;
using System.IO;


namespace Assignment5.Member
{
    public partial class MemberRegistration : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            //Clear out the error messages
            lblPasswordError.Text = "";
            lblUserNameError.Text = "";
            lblHashed.Text = "";
        
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            //Image verfication 
            if (Session["generatedString"].Equals(txtUserIp.Text))
            {
                //Validate user name and password
                string filepath = HttpRuntime.AppDomainAppPath +
                    @"\Account\App_Data\Members.xml";
                string user = txtUserName.Text;
                string password = txtPassword.Text;
                string pwdEncrypt = "";

                //Basic input validation check
                if (user == "")
                {
                    lblUserNameError.Text = "Username cannot be empty !!";
                    return;
                }
                if (password == "")
                {
                    lblPasswordError.Text = "Password cannot be empty !!";
                }

                //Encrypt the password using the hashing DLL
                string s = txtPassword.Text;
                try
                {
                    pwdEncrypt = hashPassword.HashPassword(s);
                    lblHashed.Text = pwdEncrypt;
                }
                catch (Exception ex)
                {
                    lblHashed.Text = ex.Message;
                }

                XmlDocument myDoc = new XmlDocument();
                myDoc.Load(filepath);
                XmlElement rootElement = myDoc.DocumentElement;

                //Check if the username is not registered already
                foreach (XmlNode node in rootElement.ChildNodes)
                {
                    if (node["name"].InnerText == user)
                    {
                        lblUserNameError.Text = String.Format
                            ("Account with username {0} already exists", user);
                        return;
                    }
                }

                //Add new credential into XML file

                //Add <member></member> to root
                XmlElement myMember = myDoc.CreateElement("member", rootElement.NamespaceURI);
                rootElement.AppendChild(myMember);

                //Add <name>"myUser"</name> to <member>
                XmlElement myUser = myDoc.CreateElement("name", rootElement.NamespaceURI);
                myMember.AppendChild(myUser);
                myUser.InnerText = user;

                //Add <pwd>"myPwd"<\pwd> to <member>
                XmlElement myPwd = myDoc.CreateElement("pwd", rootElement.NamespaceURI);
                myMember.AppendChild(myPwd);
                myPwd.InnerText = pwdEncrypt;

                myDoc.Save(filepath);
                Response.Redirect("MemberLogin.aspx");
            }
            else
            {
                lblImgError.Text = "Sorry, the string that you entered does not match the image. Try, again!";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtUserIp.Text = "";
            }

        }


       

    }
}
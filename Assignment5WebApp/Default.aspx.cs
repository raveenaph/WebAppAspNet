using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace Assignment5
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSessionCount.Text = Application["SessionCounter"].ToString();
        }

        protected void btnMember_Click(object sender, EventArgs e)
        {
            //Check whether cookie exists to show that user has logged in
            //If he has, then go to the member page directly.
            //Otherwise, go to the login page
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["Name"] == ""))
                Response.Redirect("Account/MemberLogin.aspx");
            else
                Response.Redirect("Account/Member.aspx");
        }

        protected void btnMemberReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account/MemberRegistration.aspx");
        }

        protected void btnStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("Protected/Staff.aspx");
        }

        protected void btnStaffLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("staffLoginPage.aspx");

        }

    }
}
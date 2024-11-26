using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace Assignment5
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {

        public delegate void CommandEventHandler(object sender, CommandEventArgs e);

        public event CommandEventHandler CommandSent;

     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"].ToString() == "")
                Session["name"] = "Guest";

            lblUsername.Text = Session["name"].ToString();
        }

       
    }
}
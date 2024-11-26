using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class GlobalTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSessionCount.Text = Application["SessionCounter"].ToString();
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            Int32 count = (Int32)Application["SessionCounter"];
            count++;
            Application["SessionCounter"] = count;
        }
    }
}
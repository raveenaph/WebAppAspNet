using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashFunctions;

namespace Assignment5
{
    public partial class DllTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHashIt_Click(object sender, EventArgs e)
        {
            string s = txtHash.Text;
            try
            {
                lblHashed.Text = hashPassword.HashPassword(s);
            }
            catch (Exception ex)
            {
                lblHashed.Text = ex.Message;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class ImageVerifierTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["generatedString"].Equals(txtInput.Text))
            {
                lblError.Text = "Success, you entered the correct text!";
            }
            else
            {
                lblError.Text = "Sorry, you entered the incorrect text. Try again!";
            }
        }



    }
}


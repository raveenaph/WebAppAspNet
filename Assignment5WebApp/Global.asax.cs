using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Assignment5
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            Application["SessionCounter"] = 0;

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_End(object sender, EventArgs e)
        {
            //Code that runs on application shutdown
            Response.Write("<hr />The Website was last visited on " + DateTime.Now.ToString());
        }

        void Session_Start(object sender, EventArgs e)
        {
            Int32 count = (Int32)Application["SessionCounter"];
            count++;
            Application["SessionCounter"] = count;

            Session["name"] = "Guest";

        }

        void Session_end(object sender, EventArgs e)
        {
            //Code that runs when session ends
            //The session_end event is raised only when the session state mode is set to InProc
            //in the web.config file. If session mode is set to StateServe or SQLServer, the event is not raised
            Int32 count = (Int32)Application["SessionCounter"];
            count--;
            Application["SessionCounter"] = count;
            Session["name"] = "Guest";

        }

    }
}
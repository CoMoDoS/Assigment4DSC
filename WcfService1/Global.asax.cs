using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Wcf.App
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }
        void Application_BeginRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var response = context.Response;

            // enable CORS
            response.AddHeader("Access-Control-Allow-Origin", "*");

            if (context.Request.HttpMethod == "OPTIONS")
            {
                response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                
                response.End();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
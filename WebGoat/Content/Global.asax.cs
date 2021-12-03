using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace DotNetGoat
{
	public class Global : System.Web.HttpApplication
	{
		
		protected virtual void Application_Start (Object sender, EventArgs e)
		{
		}

		protected virtual void Session_Start(Object sender, EventArgs e)
		{
			//if (Response.Cookies.Count > 0)
			//	foreach (string s in Response.Cookies.AllKeys)
			//		if (s == System.Web.Security.FormsAuthentication.FormsCookieName || s.ToLower().Equals("asp.net_sessionid"))
			//			Response.Cookies[s].HttpOnly = false;
			if (Response.Cookies.Count > 0)
			{
				foreach (string s in Response.Cookies.AllKeys)
				{
					Response.Cookies[s].HttpOnly = false;
				}
			}
		}
		
		protected virtual void Application_BeginRequest (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Application_EndRequest (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Application_AuthenticateRequest (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Application_Error (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Session_End (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Application_End (Object sender, EventArgs e)
		{
		}
	}
}


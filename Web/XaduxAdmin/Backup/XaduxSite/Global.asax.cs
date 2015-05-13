using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.DynamicData;
using System.Web.Routing;

namespace XaduxSite
{
	public class Global : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.MapPageRoute(
				"banda-detail",
				"{nomeBanda}",
				"~/banda.aspx");
			routes.MapPageRoute(
				"usuario-detail",
				"usuarios/{emailUsuario}",
				"~/usuario.aspx");
			routes.MapPageRoute(
				"estiloMusical-detail",
				"portal/{nomeEstilo}",
				"~/portal.aspx");
			routes.MapPageRoute(
				"banda-restrito-detail",
				"restrito/{nomeBanda}/{action}.aspx",
				"~/restrito/{action}.aspx");
			//routes.Add(new DynamicDataRoute("restrito/{nomeBanda}/{action}.aspx")
			//{
			//    Constraints = new RouteValueDictionary(new { action = "Banda" }),
			//    Url = "~/restrito/{action}.aspx",
			//});
		}

		void Application_Start(object sender, EventArgs e)
		{
			RegisterRoutes(RouteTable.Routes);
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

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
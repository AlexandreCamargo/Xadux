using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace XaduxSite.Restrito
{
	/// <summary>
	/// Summary description for IntegranteAutoComplete
	/// </summary>
	[WebService(Namespace = "http://www.xadux.com.br/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class IntegranteAutoComplete : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			string busca = context.Request.QueryString["q"];
			context.Response.ContentType = "text/plain";

			if (busca.Length >= 5)
			{
				foreach (XaduxClassLibrary.Usuario user in XaduxClassLibrary.Usuario.Buscar(5, busca))
				{
					context.Response.Write(user.Login + Environment.NewLine);
				}
			}
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}
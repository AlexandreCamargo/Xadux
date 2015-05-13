using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class paginaPrincipal : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnBanda_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect("Pre-Cadastro.aspx");
		}

		protected void btnFaMusica_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect("Cadastre-se.aspx");
		}
	}
}
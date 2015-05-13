using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class Parent : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
				LoadControls();
		}

		protected void ButtonCommand_Click(object sender, EventArgs e)
		{
			WebControl bto = (WebControl)sender;
			string pagina = SiteSupport.CommandRedirect(bto);

			if (pagina != string.Empty)
				Response.Redirect(pagina);
		}

		protected void link_logout_Click(object sender, EventArgs e)
		{
			System.Web.Security.FormsAuthentication.SignOut();
			Session.Clear();
			LoadControls();
			Response.Redirect("~/default.aspx");
		}

		protected void LoadControls()
		{
			if (Session["Xadux_UsuarioLogado"] == null)
				li_login.Visible = true;
			else
			{
				li_login.Visible = false;
				if (lbl_login.Text == string.Empty)
					lbl_login.Text = "Olá " + ((XaduxClassLibrary.Usuario)Session["Xadux_UsuarioLogado"]).Login + "!";
			}

			li_logged.Visible = !li_login.Visible;
		}

		protected void link_login_Click(object sender, EventArgs e)
		{
			System.Web.Security.FormsAuthentication.RedirectToLoginPage(Page.ClientQueryString);
			//~/Login.aspx
		}

		protected void img_busca_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect("~/busca.aspx?busca=" + txt_busca.Text);
		}
	}
}
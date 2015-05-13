using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void login_acesso_Authenticate(object sender, AuthenticateEventArgs e)
		{
			XaduxClassLibrary.Usuario user = XaduxClassLibrary.Usuario.ValidarAcessoSite(
				login_acesso.UserName,
				login_acesso.Password);
			if (user != null)
			{
				e.Authenticated = true;
				Session["Xadux_UsuarioLogado"] = user;
				//SiteSupport.LogIn(Session, user);

				if (user.Banda.Count > 1)
					Session["CurrentBandaId"] = user.Banda.First().Id;
			}
			else
				e.Authenticated = false;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxAdmin
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void login_usuario_Authenticate(object sender, AuthenticateEventArgs e)
		{
            XaduxClassLibrary.Usuario user = XaduxClassLibrary.Usuario.ValidarAcessoAdministrativo(login_usuario.UserName, login_usuario.Password);

			e.Authenticated = (user != null);
			if (e.Authenticated)
			{
				Session["Site_UsuarioOnline"] = user;
			}
		}
	}
}
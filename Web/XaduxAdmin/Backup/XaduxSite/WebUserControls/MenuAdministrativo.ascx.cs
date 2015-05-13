using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite.WebUserControls
{
	public partial class MenuAdministrativo : System.Web.UI.UserControl
	{
		private XaduxClassLibrary.Usuario usuario
		{
			get
			{
				return (XaduxClassLibrary.Usuario)Session["Xadux_UsuarioLogado"];
			}
		}
		private XaduxClassLibrary.Banda banda
		{
			get
			{
				int bandaId = 0;
				if (Session["CurrentBandaId"] != null)
					if (int.TryParse(Session["CurrentBandaId"].ToString(), out bandaId))
						return XaduxClassLibrary.Banda.Consultar(bandaId);
				return null;
			}
			set
			{
				if (value != null)
					Session["CurrentBandaId"] = value.Id;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (usuario == null)
			{
				System.Web.Security.FormsAuthentication.RedirectToLoginPage(Page.ClientQueryString);
				return;
			}

			if (!IsPostBack)
			{
				rept_bandasUsuario.DataSource = usuario.Banda;
				rept_bandasUsuario.DataBind();

				if (Page.RouteData.Values["nomeBanda"] != null)
				{
					XaduxClassLibrary.Banda bandaAux = XaduxClassLibrary.Banda.Consultar(Page.RouteData.Values["nomeBanda"].ToString());

					if (bandaAux != null)
					{
						//Verifica se a banda passada realmente foi criada pelo usuário logado
						if (bandaAux.Usuario != usuario)
						{
							Response.Redirect("~/default.aspx");
							return;
						}
						else
							banda = bandaAux;
					}
				}

				if (banda != null)
				{
					lbl_nomeBanda.Text = banda.Nome;
					div_menu.Visible = true;
				}
				else
					div_menu.Visible = false;
			}
		}

		protected void ButtonCommand_Click(object sender, EventArgs e)
		{
			LinkButton bto = (LinkButton)sender;
			int id = 0;

			if (int.TryParse(bto.CommandArgument, out id) && id != 0)
				Session["CurrentBandaId"] = id;
			else
				Session["CurrentBandaId"] = null;

			Response.Redirect("~/restrito/banda.aspx");
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class Restrita : System.Web.UI.MasterPage
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
				if (banda != null)
				{
					lbl_nomeBanda.Text = banda.Nome;
					link_urlBanda.Text = banda.Site;
					link_urlBanda.NavigateUrl = banda.Site;
				}
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
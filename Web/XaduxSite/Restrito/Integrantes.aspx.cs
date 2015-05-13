using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite.Restrito
{
	public partial class Integrantes : System.Web.UI.Page
	{
		private XaduxClassLibrary.Banda _banda;
		private XaduxClassLibrary.Banda banda
		{
			get
			{
				if (_banda == null)
				{
					int bandaId = 0;
					if (Session["CurrentBandaId"] != null)
						if (int.TryParse(Session["CurrentBandaId"].ToString(), out bandaId))
							_banda = XaduxClassLibrary.Banda.Consultar(bandaId);
				}
				return (XaduxClassLibrary.Banda)_banda;
			}
			set
			{
				_banda = value;
				if (value != null)
					Session["CurrentBandaId"] = value.Id;
			}
		}
		private XaduxClassLibrary.Usuario usuario
		{
			get
			{
				return (XaduxClassLibrary.Usuario)Session["Xadux_UsuarioLogado"];
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack && banda != null)
			{
				rept_integrantes_DataBind();
			}
		}

		protected void bto_buscar_Click(object sender, EventArgs e)
		{
			if (txt_usuario.Text.Count() < 5)
			{
				lbl_msg.Text = "Preencha no mínimo 5 caracteres.";
				return;
			}
			else
				lbl_msg.Text = string.Empty;

			rept_usuarios.DataSource = XaduxClassLibrary.Usuario.Buscar(txt_usuario.Text);
			rept_usuarios.DataBind();
		}

		protected void bto_adicionar_Click(object sender, EventArgs e)
		{
			int id = 0;
			Button bto_adicionar = (Button)sender;

			if (bto_adicionar != null)
				if (int.TryParse(bto_adicionar.CommandArgument, out id) && id != 0)
				{
					XaduxClassLibrary.Usuario uAux = XaduxClassLibrary.Usuario.Consultar(id);

					if (uAux != null)
					{
						banda.UsuarioIntegrante.Add(uAux);
						rept_integrantes_DataBind();
					}
				}
		}

		protected void bto_remover_Click(object sender, EventArgs e)
		{
			int id = 0;
			Button bto_remover = (Button)sender;

			if (bto_remover != null)
				if (int.TryParse(bto_remover.CommandArgument, out id) && id != 0)
				{
					XaduxClassLibrary.Usuario uAux = XaduxClassLibrary.Usuario.Consultar(id);

					if (uAux != null)
					{
						banda.UsuarioIntegrante.Remove(uAux);
						rept_integrantes_DataBind();
					}
				}
		}

		protected void rept_integrantes_DataBind()
		{
			rept_integrantes.DataSource = banda.UsuarioIntegrante;
			rept_integrantes.DataBind();
		}
	}
}
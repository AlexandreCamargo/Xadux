using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite.Restrito
{
	public partial class Noticias : System.Web.UI.Page
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
			if (!IsPostBack)
			{
				if (banda != null)
				{
					rept_noticias_DataBind();
				}
			}
		}

		protected void rept_noticias_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			int id = 0;
			XaduxClassLibrary.NoticiaBanda noticia = null;

			if (int.TryParse(e.CommandArgument.ToString(), out id))
				noticia = XaduxClassLibrary.NoticiaBanda.Consultar(id);

			if (noticia != null)
			{
				switch (e.CommandName.ToLower())
				{
					case "editar":
						div_noticia.Visible = true;
						txt_nomeNoticia.Text = noticia.Nome;
						hid_noticiaId.Value = noticia.Id.ToString();

						break;
					case "excluir":
						XaduxClassLibrary.NoticiaBanda.Excluir(noticia.Id);

						rept_noticias_DataBind();
						break;
				}
			}
		}

		protected void rept_noticias_DataBind()
		{
			rept_noticias.DataSource = XaduxClassLibrary.NoticiaBanda.Listar(banda.Id);
			rept_noticias.DataBind();
		}

		protected void link_novaNoticia_Click(object sender, EventArgs e)
		{
			div_noticia.Visible = true;

			txt_nomeNoticia.Text = string.Empty;
			hid_noticiaId.Value = string.Empty;
		}

		protected void bto_atualizar_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				int noticiaId = 0;
				XaduxClassLibrary.NoticiaBanda noticia = null;

				if (int.TryParse(hid_noticiaId.Value, out noticiaId) && noticiaId != 0)
				{
					noticia = XaduxClassLibrary.NoticiaBanda.Consultar(noticiaId);
					noticia.Nome = txt_nomeNoticia.Text;
					XaduxClassLibrary.NoticiaBanda.Atualizar(noticia);
				}
				else
				{
					noticia = XaduxClassLibrary.NoticiaBanda.CreateNoticiaBanda(
						0,
						txt_nomeNoticia.Text,
						string.Empty,
						DateTime.Now,
						usuario.Id,
						banda.Id);

					XaduxClassLibrary.NoticiaBanda.Inserir(noticia);
				}

				div_noticia.Visible = false;
				rept_noticias_DataBind();
			}
		}
	}
}
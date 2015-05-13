using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class Usuario : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				try
				{
					string emailUsuario = string.Empty;

					if (Page.RouteData.Values["emailUsuario"] == null)
						return;

					emailUsuario = Page.RouteData.Values["emailUsuario"].ToString();

					XaduxClassLibrary.Usuario usuario = XaduxClassLibrary.Usuario.Consultar(emailUsuario);

					if (usuario != null)
					{
						img_usuario.ImageUrl = usuario.CaminhoImagem;
						img_usuario.AlternateText = usuario.Nome;

						//Dados contato
						lbl_nomeUsuario1.Text = usuario.Nome;

						rept_estilosMusicaisUsuario.DataSource = usuario.EstiloMusical;
						rept_estilosMusicaisUsuario.DataBind();

						rept_instrumentosMusicaisUsuario.DataSource = usuario.InstrumentoMusical;
						rept_instrumentosMusicaisUsuario.DataBind();

						BandasList_minhasBandas.DataSource = usuario.BandaIntegrante;
						BandasList_minhasBandas.DataBind();

						BandasList_quemEuOuco.DataSource = usuario.BandaFa;
						BandasList_quemEuOuco.DataBind();
						lbl_qtdeBandasQuemEuOuco.Text = usuario.BandaFa.ToList().Count.ToString();

						lbl_nomeUsuario2.Text = usuario.Nome;
						lit_descricaoUsuario.Text = usuario.Descricao;

						NoticiasList_banda.DataSource = XaduxClassLibrary.NoticiaBanda.ListarNoticiasComUsuario(usuario.Id);
						NoticiasList_banda.DataBind();

						//rept_integrantes.DataSource = usuario.UsuarioIntegrante;
						//rept_integrantes.DataBind();
						//bto_virarFa.Visible = true;
						//bto_deixarDeSerFa.Visible = !bto_virarFa.Visible;

						//rept_fotos.DataSource = usuario.FotoUsuario;
						//rept_fotos.DataBind();
					}
				}
				catch (Exception erro)
				{
					//throw erro;
				}
			}
		}

		protected void ButtonCommand_Click(object sender, EventArgs e)
		{
			WebControl bto = (WebControl)sender;
			string pagina = SiteSupport.CommandRedirect(bto);

			if (pagina != string.Empty)
				Response.Redirect(pagina);
		}
	}
}
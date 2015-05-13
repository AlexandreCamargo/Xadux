using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class Portal : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string nomeEstilo = string.Empty;

				if (Page.RouteData.Values["nomeEstilo"] == null)
					return;

				nomeEstilo = Page.RouteData.Values["nomeEstilo"].ToString();

				XaduxClassLibrary.EstiloMusical estilo = XaduxClassLibrary.EstiloMusical.Consultar(nomeEstilo.Replace('-', ' '));

				if (estilo != null)
				{
					lbl_estiloMusical.Text = estilo.Nome;
					foreach (XaduxClassLibrary.Banda banda in XaduxClassLibrary.Banda.BuscarAleatorias(1, estilo.Id))
					{
						img_bandaDestaque.ImageUrl = banda.CaminhoImagem;
						img_bandaDestaque.AlternateText = banda.Nome;
						img_bandaDestaque.CommandArgument = banda.Nome;

						break;
					}

					TopBandas_topBandas.DataSource = XaduxClassLibrary.Banda.ListarMaisAcessadas(5, estilo.Id);
					TopBandas_topBandas.DataBind();

					EventosList_topEventos.DataSource = XaduxClassLibrary.Evento.Listar(estilo.Id);
					EventosList_topEventos.DataBind();

					NoticiasList_topNews.DataSource = XaduxClassLibrary.NoticiaBanda.ListarMaisRecentes(3, estilo.Id);
					NoticiasList_topNews.DataBind();

					TopMusicas_topMusicas.DataSource = XaduxClassLibrary.MusicaBanda.ListarMaisAcessadas(3, estilo.Id);
					TopMusicas_topMusicas.DataBind();
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
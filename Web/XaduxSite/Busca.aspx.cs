using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class Busca : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{	
			if (!IsPostBack)
			{
				string busca = Request["busca"];
				string estiloMusical = Request["estiloMusical"];

				if (!string.IsNullOrEmpty(busca))
				{
					//txt_busca.Text = busca;
					rept_musicas_DataBind(busca, 0);
					rept_bandas_DataBind(busca, 0);
				}
				else if (!string.IsNullOrEmpty(estiloMusical))
				{
					XaduxClassLibrary.EstiloMusical estilo = XaduxClassLibrary.EstiloMusical.Consultar(estiloMusical.Replace('-', ' '));

					if (estilo != null)
					{
						rept_musicas_DataBind(string.Empty, estilo.Id);
						rept_bandas_DataBind(string.Empty, estilo.Id);
					}
				}
			}
		}

		protected void rept_musicas_DataBind(string busca, int idEstiloMusical)
		{
			List<XaduxClassLibrary.MusicaBanda> lista = null;
			
			if (busca != string.Empty)
				lista = XaduxClassLibrary.MusicaBanda.Buscar(0, busca);
			else
				lista = XaduxClassLibrary.MusicaBanda.Buscar(0, idEstiloMusical);

			lbl_music.Visible = lista.Count > 0;
			rept_musicas.DataSource = lista;
			rept_musicas.DataBind();
		}

		protected void rept_bandas_DataBind(string busca, int idEstiloMusical)
		{
			List<XaduxClassLibrary.Banda> lista = null;

			if (busca != string.Empty)
				lista = XaduxClassLibrary.Banda.Buscar(0, busca);
			else
				lista = XaduxClassLibrary.Banda.Buscar(0, idEstiloMusical);

			lbl_bandas.Visible = lista.Count > 0;
			rept_bandas.DataSource = lista;
			rept_bandas.DataBind();
		}

		protected void bto_busca_Click(object sender, EventArgs e)
		{
			//rept_musicas_DataBind(txt_busca.Text, 0);
			//rept_bandas_DataBind(txt_busca.Text, 0);
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
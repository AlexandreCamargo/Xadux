using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class _default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            //Response.Redirect("paginaPrincipal.aspx");
            //Response.Redirect("http://xadux.blogspot.com.br/");

			if (!IsPostBack)
			{
				TopBandas_topBandas.DataSource = XaduxClassLibrary.Banda.ListarMaisAcessadas(5);
				TopBandas_topBandas.DataBind();

				EventosList_topEventos.DataSource = XaduxClassLibrary.Evento.Consultar();
				EventosList_topEventos.DataBind();

				NoticiasList_topNews.DataSource = XaduxClassLibrary.NoticiaBanda.ListarMaisRecentes(3);
				NoticiasList_topNews.DataBind();

				TopMusicas_topMusicas.DataSource = XaduxClassLibrary.MusicaBanda.ListarMaisAcessadas(3);
				TopMusicas_topMusicas.DataBind();
			} 
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite.WebUserControls
{
	public partial class NoticiasList : System.Web.UI.UserControl
	{
		public object DataSource
		{
			get 
			{
				return ViewState["CurrentBandaId"]; 
			}
			set 
			{
				ViewState["CurrentBandaId"] = value;
				rept_noticias.DataSource = value; 
			}
		}

		public bool _showRespostas = true;
		public bool ShowRespostas
		{
			get { return _showRespostas; }
			set { _showRespostas = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void rept_noticias_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			XaduxClassLibrary.Usuario user = (XaduxClassLibrary.Usuario)Session["Xadux_UsuarioLogado"];
			Repeater rept_respostas = (Repeater)e.Item.FindControl("rept_respostas");
			System.Web.UI.HtmlControls.HtmlTableRow tr_newComentario = (System.Web.UI.HtmlControls.HtmlTableRow)e.Item.FindControl("tr_newComentario");
			XaduxClassLibrary.NoticiaBanda linhaNoticia = (XaduxClassLibrary.NoticiaBanda)e.Item.DataItem;

			if (ShowRespostas)
			{
				rept_respostas.DataSource = linhaNoticia.RespostaNoticiaBanda.OrderByDescending(a => a.DataCadastro);
				rept_respostas.DataBind();
			}

			tr_newComentario.Visible = ShowRespostas && (user != null);
			rept_respostas.Visible = ShowRespostas;
		}

		public void DataBind()
		{
			if (rept_noticias.DataSource == null)
				rept_noticias.DataSource = DataSource;
			rept_noticias.DataBind();
		}

		protected void ButtonCommand_Click(object sender, EventArgs e)
		{
			WebControl bto = (WebControl)sender;
			string pagina = SiteSupport.CommandRedirect(bto);

			if (pagina != string.Empty)
				Response.Redirect(pagina);
		}

		protected void rept_noticias_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			XaduxClassLibrary.Usuario user = (XaduxClassLibrary.Usuario)Session["Xadux_UsuarioLogado"];

			if (user == null)
			{
				System.Web.Security.FormsAuthentication.RedirectToLoginPage(Page.ClientQueryString);
				return;
			}

			if (e.CommandName.ToLower() == "enviarcomentario")
			{
				int id = 0;

				if (int.TryParse(e.CommandArgument.ToString(), out id))
				{
					XaduxClassLibrary.NoticiaBanda linhaNoticia = XaduxClassLibrary.NoticiaBanda.Consultar(id);
					Repeater rept_respostas = (Repeater)e.Item.FindControl("rept_respostas");
					TextBox txt_newComentario = (TextBox)e.Item.FindControl("txt_newComentario");

					XaduxClassLibrary.RespostaNoticiaBanda resp = XaduxClassLibrary.RespostaNoticiaBanda.CreateRespostaNoticiaBanda(
						0,
						(txt_newComentario.Text.Length <= 250 ? txt_newComentario.Text : txt_newComentario.Text.Substring(0, 250)),
						user.Id,
						DateTime.Now,
						id,
						true);

					XaduxClassLibrary.RespostaNoticiaBanda.Inserir(resp);
					txt_newComentario.Text = string.Empty;

					if (linhaNoticia != null)
					{
						rept_respostas.DataSource = linhaNoticia.RespostaNoticiaBanda.OrderByDescending(a => a.DataCadastro);
						rept_respostas.DataBind();
					}
				}
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class Banda : System.Web.UI.Page
	{
		private XaduxClassLibrary.Banda _banda;
		private XaduxClassLibrary.Banda banda
		{
			get
			{
				if (_banda == null)
				{
					int bandaId = 0;
					if (ViewState["CurrentBandaId"] != null)
						if (int.TryParse(ViewState["CurrentBandaId"].ToString(), out bandaId))
							_banda = XaduxClassLibrary.Banda.Consultar(bandaId);
				}
				return (XaduxClassLibrary.Banda)_banda;
			}
			set
			{
				_banda = value;
				if (value != null)
					ViewState["CurrentBandaId"] = value.Id;
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
            //tabMenu.Items[mview_abas.ActiveViewIndex].Selected = true;

			if (!IsPostBack)
			{
                try
				{
					string nomeBanda = string.Empty;

					if (Page.RouteData.Values["nomeBanda"] == null)
						return;

					nomeBanda = Page.RouteData.Values["nomeBanda"].ToString().Replace('-', ' ');
					banda = XaduxClassLibrary.Banda.Consultar(nomeBanda);

					if (banda != null)
					{
						//Adiciona o acesso para a banda
						XaduxClassLibrary.AcessosBanda acc = XaduxClassLibrary.AcessosBanda.CreateAcessosBanda(
							0,
							banda.Id,
							Request.ServerVariables["REMOTE_ADDR"],
							DateTime.Now);

						if (usuario != null)
						{
							acc.fk_Usuario_Id = usuario.Id;
						}

						XaduxClassLibrary.Banda.AdicionarAcesso(acc);
					}
					
					Carregar();
				}
				catch (Exception erro)
				{
				    throw erro;
				}
			}
		}

        //protected void tabMenu_MenuItemClick(object sender, MenuEventArgs e)
        //{
        //    switch (e.Item.Value)
        //    {
        //        case "t1":
        //            mview_abas.ActiveViewIndex = 0;
        //            break;

        //        case "t2":
        //            mview_abas.ActiveViewIndex = 1;
        //            break;

        //        case "t3":
        //            mview_abas.ActiveViewIndex = 2;
        //            break;

        //        case "t4":
        //            mview_abas.ActiveViewIndex = 3;
        //            break;
        //    }

        //}

		protected void Carregar()
		{
			
			if (banda != null)
			{
				if (usuario == null)
				{
					bto_virarFa.Visible = true;
					bto_deixarDeSerFa.Visible = false;
				}
				else
				{
					//Verifica se o usuário é fã da banda
					bto_deixarDeSerFa.Visible = usuario.BandaFa.Contains(banda);
					bto_virarFa.Visible = !bto_deixarDeSerFa.Visible;
				}

				img_banda.ImageUrl = banda.CaminhoImagem;
				img_banda.AlternateText = banda.Nome;

				//Dados contato
				lbl_nomeBanda1.Text = banda.Nome;
				lbl_emailBanda.Text = banda.Email;
				if (banda.Estado != null)
					lbl_estadoBanda.Text = banda.Estado.Nome;
				lbl_telefoneBanda.Text = banda.Telefone;
				if (banda.EstiloMusical != null)
				{
					bto_estiloMusicalBanda.Text = banda.EstiloMusical.Nome;
					bto_estiloMusicalBanda.CommandArgument = banda.EstiloMusical.Nome;
				}

				rept_musicas.DataSource = banda.MusicaBanda;
				rept_musicas.DataBind();

				UsuariosList_fas.DataSource = banda.UsuarioFa;
				UsuariosList_fas.DataBind();
				lbl_qtdeFas.Text = banda.UsuarioFa.ToList().Count.ToString();

				lbl_nomeBanda2.Text = banda.Nome;
				lit_descricaoBanda.Text = banda.Descricao;
				UsuariosList_integrantes.DataSource = banda.UsuarioIntegrante;
				UsuariosList_integrantes.DataBind();

				eventos_agenda.DataSource = XaduxClassLibrary.Evento.ListarPorBanda(banda.Id);
				eventos_agenda.DataBind();

				if (!string.IsNullOrEmpty(banda.Facebook))
				{
					link_facebook.NavigateUrl = banda.Facebook;
					link_facebook.ToolTip = banda.Nome + " no Facebook";
					link_facebook.Visible = true;
				}
				if (!string.IsNullOrEmpty(banda.Twitter))
				{
					link_twitter.NavigateUrl = banda.Twitter;
					link_twitter.ToolTip = banda.Nome + " no Twitter";
					link_twitter.Visible = true;
				}

				rept_fotos.DataSource = banda.FotoBanda;
				rept_fotos.DataBind();

				rept_videos.DataSource = banda.VideoBanda;
				rept_videos.DataBind();

				NoticiasList_banda.DataSource = banda.NoticiaBanda.OrderByDescending(a => a.DataCadastro).ToList();
				NoticiasList_banda.DataBind();
			}
		}

		protected void ButtonCommand_Click(object sender, EventArgs e)
		{
			WebControl bto = (WebControl)sender;
			string pagina = SiteSupport.CommandRedirect(bto);
			
			if (pagina != string.Empty)
				Response.Redirect(pagina);
		}

		protected void bto_virarFa_Click(object sender, EventArgs e)
		{
			if (usuario == null)
			{
				System.Web.Security.FormsAuthentication.RedirectToLoginPage(Page.ClientQueryString);
				return;
			}
			banda.UsuarioFa.Add(usuario);
			Carregar();
		}

		protected void bto_deixarDeSerFa_Click(object sender, EventArgs e)
		{
			banda.UsuarioFa.Remove(usuario);
			Carregar();
		}

		protected void bto_download_Click(object sender, ImageClickEventArgs e)
		{
			ImageButton bto_download = (ImageButton)sender;

			if (usuario == null)
			{
				System.Web.Security.FormsAuthentication.RedirectToLoginPage(Page.ClientQueryString);
				return;
			}

			if (bto_download != null)
			{
				int id = 0;

				if (int.TryParse(bto_download.CommandArgument, out id))
				{
					XaduxClassLibrary.MusicaBanda item = XaduxClassLibrary.MusicaBanda.Consultar(id);

					if (item != null)
					{
						//Faz o download da música
						if (SiteSupport.DownloadArquivo(item.Caminho, Response, Server))
						{
							//Registra o download no sistema
							XaduxClassLibrary.DownloadMusicas.Inserir(
								XaduxClassLibrary.DownloadMusicas.CreateDownloadMusicas(
								0,
								id,
								usuario.Id,
								DateTime.Now));
						}
					}
				}
			}
		}

        protected void link_noticias_Click(object sender, EventArgs e)
        {
            mview_abas.ActiveViewIndex = 0;
        }

        protected void link_fotos_Click(object sender, EventArgs e)
        {
            mview_abas.ActiveViewIndex = 1;
        }

        protected void link_videos_Click(object sender, EventArgs e)
        {
            mview_abas.ActiveViewIndex = 2;
        }

        protected void link_agenda_Click(object sender, EventArgs e)
        {
            mview_abas.ActiveViewIndex = 3;
        }

		protected void bto_denuncie_Click(object sender, ImageClickEventArgs e)
		{
			ScriptManager.RegisterClientScriptBlock(
				Page,
				Page.GetType(),
				"denuncie",
				"window.open(\"denuncie.aspx?id=" + banda.Id + "\");",
				true);
		}

	}
}
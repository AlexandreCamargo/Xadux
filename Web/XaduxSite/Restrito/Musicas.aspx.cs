using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace XaduxSite.Restrito
{
	public partial class Musicas : System.Web.UI.Page
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
					rept_musicas_DataBind();
				}
			}
		}

		protected void rept_musicas_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			int id = 0;
			XaduxClassLibrary.MusicaBanda musica = null;

			if (int.TryParse(e.CommandArgument.ToString(), out id))
				musica = XaduxClassLibrary.MusicaBanda.Consultar(id);

			if (musica != null)
			{
				switch (e.CommandName.ToLower())
				{
					case "editar":
						div_musica.Visible = true;
						txt_nomeMusica.Text = musica.Nome;
						lbl_caminhoMusica.Visible = true;
						lbl_caminhoMusica.Text = musica.Caminho;
						upd_musica.Visible = false;
						hid_musicaId.Value = musica.Id.ToString();

						break;
					case "excluir":
						XaduxClassLibrary.MusicaBanda.Excluir(musica.Id);
						SiteSupport.ExcluirArquivo(musica.Caminho, Server);

						rept_musicas_DataBind();
						break;
				}
			}
		}

		protected void rept_musicas_DataBind()
		{
			rept_musicas.DataSource = XaduxClassLibrary.MusicaBanda.Listar(banda.Id);
			rept_musicas.DataBind();
		}

		protected void link_novaMusica_Click(object sender, EventArgs e)
		{
			div_musica.Visible = true;

			txt_nomeMusica.Text = string.Empty;
			lbl_caminhoMusica.Text = string.Empty;
			lbl_caminhoMusica.Visible = false;
			upd_musica.Visible = true;
			hid_musicaId.Value = string.Empty;
		}

		protected void bto_atualizar_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				int musicaId = 0;
				XaduxClassLibrary.MusicaBanda musica = null;

				try
				{
					if (int.TryParse(hid_musicaId.Value, out musicaId) && musicaId != 0)
					{
						musica = XaduxClassLibrary.MusicaBanda.Consultar(musicaId);
						musica.Nome = txt_nomeMusica.Text;

						XaduxClassLibrary.MusicaBanda.Atualizar(musica);
					}
					else
					{
						string caminho = ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/bandas/" + banda.Nome + "/musicas/";
						caminho += SiteSupport.SalvarMusica(
							upd_musica,
							Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "/bandas/" + banda.Nome + "/musicas/",
							upd_musica.FileName);

						musica = XaduxClassLibrary.MusicaBanda.CreateMusicaBanda(
							0,
							txt_nomeMusica.Text,
							caminho,
							DateTime.Now,
							usuario.Id,
							banda.Id);

						XaduxClassLibrary.MusicaBanda.Inserir(musica);
					}
					rept_musicas_DataBind();
					div_musica.Visible = false;
				}
				catch (Exception erro)
				{
					lbl_msg.Text = erro.Message;
				}
			}
		}
	}
}
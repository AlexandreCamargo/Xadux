using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace XaduxSite
{
	public partial class Upload_Musica : System.Web.UI.Page
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
						string caminho = ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/bandas/" + banda.Nome + "/musicas";
						caminho += SiteSupport.SalvarMusica(
							upd_musica,
							Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "/bandas/" + banda.Nome + "/musicas",
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

					//div_musica.Visible = false;
					//rept_musicas_DataBind();
				}
				catch (Exception erro)
				{
					//lbl_msg.Text = erro.Message;
				}
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace XaduxSite.Restrito
{
	public partial class Imagem_Banda : System.Web.UI.Page
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
					Carregar();
				}
			}
		}

		protected void Carregar()
		{
			if (!string.IsNullOrEmpty(banda.CaminhoImagem))
			{
				img_foto.ImageUrl = banda.CaminhoImagem;
				img_foto.Visible = true;
				bto_excluirFoto.Visible = true;
			}
			else
			{
				img_foto.Visible = false;
				bto_excluirFoto.Visible = false;
			}
		}

		protected void bto_atualizar_Click(object sender, EventArgs e)
		{
			if (banda != null)
			{
				if (upd_foto.HasFile)
				{
					banda.CaminhoImagem = ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/bandas/" + banda.Nome + "/";
					banda.CaminhoImagem += SiteSupport.SalvarImagem(
						upd_foto,
                        Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "/bandas/" + banda.Nome + "/",
						upd_foto.FileName);
					SiteSupport.CriarThumbnailImage(
						Server,
						Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\bandas\\" + banda.Nome + "\\" + upd_foto.FileName.Replace(' ', '-'),
						Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\bandas\\" + banda.Nome + ".jpg");
				}

				XaduxClassLibrary.Banda.Atualizar(banda);
				Carregar();
				lbl_mensagem.Text = "Cadastro atualizado";
			}
		}

		protected void bto_excluirFoto_Click(object sender, ImageClickEventArgs e)
		{
			bool excluiu = SiteSupport.ExcluirArquivo(banda.CaminhoImagem, Server);

			banda.CaminhoImagem = string.Empty;

			XaduxClassLibrary.Banda.Atualizar(banda);
			Carregar();
		}
	}
}
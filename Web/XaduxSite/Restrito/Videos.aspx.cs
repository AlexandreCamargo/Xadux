using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite.Restrito
{
	public partial class Videos : System.Web.UI.Page
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
					rept_videos_DataBind();
				}
			}
		}

		protected void rept_videos_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			int id = 0;
			XaduxClassLibrary.VideoBanda video = null;

			if (int.TryParse(e.CommandArgument.ToString(), out id))
				video = XaduxClassLibrary.VideoBanda.Consultar(id);

			if (video != null)
			{
				switch (e.CommandName.ToLower())
				{
					case "editar":
						div_video.Visible = true;
						txt_nomeVideo.Text = video.Nome;
						lit_video.Text = video.URL;
						txt_urlVideo.Text = video.URL;
						hid_videoId.Value = video.Id.ToString();

						break;
					case "excluir":
						XaduxClassLibrary.VideoBanda.Excluir(video.Id);

						rept_videos_DataBind();
						break;
				}
			}
		}

		protected void rept_videos_DataBind()
		{
			rept_videos.DataSource = XaduxClassLibrary.VideoBanda.Listar(banda.Id);
			rept_videos.DataBind();
		}

		protected void link_novoVideo_Click(object sender, EventArgs e)
		{
			div_video.Visible = true;

			txt_nomeVideo.Text = string.Empty;
			lit_video.Text = string.Empty;
			hid_videoId.Value = string.Empty;
		}

		protected void bto_atualizar_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				int videoId = 0;
				XaduxClassLibrary.VideoBanda video = null;

				if (int.TryParse(hid_videoId.Value, out videoId) && videoId != 0)
				{
					video = XaduxClassLibrary.VideoBanda.Consultar(videoId);
					video.Nome = txt_nomeVideo.Text;
					video.URL = txt_urlVideo.Text;

					XaduxClassLibrary.VideoBanda.Atualizar(video);
				}
				else
				{
					video = XaduxClassLibrary.VideoBanda.CreateVideoBanda(
						0,
						txt_nomeVideo.Text,
						txt_urlVideo.Text,
						DateTime.Now,
						usuario.Id,
						banda.Id);

					XaduxClassLibrary.VideoBanda.Inserir(video);
				}

				div_video.Visible = false;
				rept_videos_DataBind();
			}
		}

		protected void bto_preview_Click(object sender, EventArgs e)
		{
			lit_video.Text = txt_urlVideo.Text;
		}
	}
}
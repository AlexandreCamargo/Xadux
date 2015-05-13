using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace XaduxSite
{
	public partial class Pre_Cadastro : System.Web.UI.Page
	{
		#region propriedades


		private XaduxClassLibrary.Banda CurrentBanda
		{
			get
			{
				if (Session["SessionBanda"] != null)
					return (XaduxClassLibrary.Banda)Session["SessionBanda"];
				return null;
			}
			set
			{
				Session["SessionBanda"] = value;
			}
		}

		private XaduxClassLibrary.Usuario CurrentUsuario
		{
			get
			{
				if (Session["SessionUsuario"] != null)
					return (XaduxClassLibrary.Usuario)Session["SessionUsuario"];
				return null;
			}
			set
			{
				Session["SessionUsuario"] = value;
			}
		}


		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				drop_sexo_Databind();
				chk_instrumentosMusicais_DataBind();
				chk_estilosMusicais_DataBind();
				drop_estiloMusical_DataBind();
				drop_estado_DataBind();
				drop_gravadora_DataBind();
			}
		}

		protected void bto_primeiroPasso_Click(object sender, EventArgs e)
		{
			lbl_senhas.Visible = (txt_senha.Text != txt_senha2.Text);
			if (Page.IsValid && !lbl_senhas.Visible)
            {
				if (XaduxClassLibrary.Usuario.Consultar(txt_login.Text) != null)
				{
					lbl_mensagem.Text = "Já existe este login em nosso cadastro, favor alterar.";
					return;
				}
				if (XaduxClassLibrary.Usuario.Consultar(txt_email.Text) != null)
				{
					lbl_mensagem.Text = "Já existe este e-mail em nosso cadastro, favor alterar.";
					return;
				}

                try
                {
                    //Inicia o cadastro do usuário
                    XaduxClassLibrary.Usuario usuario = XaduxClassLibrary.Usuario.CreateUsuario(
                        0,
                        txt_email.Text,
                        1, //Brasil
                        false,
                        DateTime.Now,
                        true);

                    int sexoId = 0;

                    usuario.Nome = txt_nome.Text;
                    usuario.Login = txt_login.Text;

                    if (int.TryParse(rdio_sexo.Text, out sexoId) && sexoId != 0)
                        usuario.fk_Sexo_Id = sexoId;

                    usuario.DataNascimento = DateTime.Parse(txt_dataNasc.Text);
                    usuario.Descricao = txt_descricao.Text;

                    if (txt_senha.Text != string.Empty)
                        usuario.Senha = txt_senha.Text;

                    foreach (ListItem item in chk_instrumentosMusicais.Items)
                    {
                        if (item.Selected)
                        {
                            int id = int.Parse(item.Value);
                            XaduxClassLibrary.InstrumentoMusical instrumento = XaduxClassLibrary.InstrumentoMusical.Consultar(id);
                            usuario.InstrumentoMusical.Add(instrumento);
                        }
                    }

                    foreach (ListItem item in chk_estilosMusicais.Items)
                    {
                        if (item.Selected)
                        {
                            int id = int.Parse(item.Value);
                            XaduxClassLibrary.EstiloMusical estilo = XaduxClassLibrary.EstiloMusical.Consultar(id);
                            usuario.EstiloMusical.Add(estilo);
                        }
                    }

                    if (upd_foto.HasFile)
                    {
						usuario.CaminhoImagem = ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/usuarios/" + usuario.Login;
                        usuario.CaminhoImagem += SiteSupport.SalvarImagem(
                            upd_foto,
                            Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "/usuarios/" + usuario.Login,
                            upd_foto.FileName);
                        SiteSupport.CriarThumbnailImage(
                            Server,
                            Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\usuarios\\" + usuario.Login + "\\" + upd_foto.FileName.Replace(' ','-'),
                            Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\usuarios\\" + usuario.Login + ".jpg");
                    }
                    else
                    {
                        usuario.CaminhoImagem = "~/Imagens/imgBanda.jpg";

                        SiteSupport.CriarThumbnailImage(
                            Server,
                            Server.MapPath("~/Imagens/") + "\\imgBanda.jpg",
                            Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\usuarios\\" + usuario.Login + ".jpg");
                    }

					if (XaduxClassLibrary.Usuario.Inserir(usuario) == null)
					{
						lbl_mensagem.Text = "Houve um problema no cadastro de seu usuario. Favor verificar seus dados ou tentar novamente mais tarde.";
					}
					else
					{
						CurrentUsuario = usuario;

						//Avança para o passo 2
						lbl_mensagem.Text = string.Empty;
						multi_passos.ActiveViewIndex++;
					}
                }
                catch (Exception erro)
                {
                    lbl_mensagem.Text = erro.Message;
                }
            }
		}

		protected void bto_segundoPasso_Click(object sender, EventArgs e)
		{
            if (Page.IsValid)
            {
				if (XaduxClassLibrary.Banda.Consultar(txt_nomeBanda.Text) != null)
				{
					lbl_mensagem.Text = "Já existe esta banda em nosso cadastro, favor alterar.";
					return;
				}

                try
                {
                    int estadoId = 0;
					int gravadoraId = 0;
                    XaduxClassLibrary.Banda banda = XaduxClassLibrary.Banda.CreateBanda(
                        0,
                        txt_nomeBanda.Text,
                        CurrentUsuario.Id,
                        DateTime.Now,
                        int.Parse(drop_estiloMusical.Text));

                    banda.Descricao = txt_descricaoBanda.Text;
                    banda.Site = txt_siteBanda.Text;
                    banda.Facebook = txt_facebookBanda.Text;
                    banda.Twitter = txt_twitterBanda.Text;
                    banda.Email = txt_emailBanda.Text;
                    banda.Cidade = txt_cidadeBanda.Text;

                    if (int.TryParse(drop_estado.Text, out estadoId) && estadoId != 0)
                        banda.fk_Estado_Id = estadoId;

					if (int.TryParse(drop_gravadora.Text, out gravadoraId) && gravadoraId != 0)
						banda.fk_Empresa_Id_Gravadora = gravadoraId;
					

                    if (upd_fotoBanda.HasFile)
                    {
						banda.CaminhoImagem = ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/bandas/" + banda.Nome;
                        banda.CaminhoImagem += SiteSupport.SalvarImagem(
                            upd_fotoBanda,
                            Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "/bandas/" + banda.Nome,
                            upd_fotoBanda.FileName);
                        SiteSupport.CriarThumbnailImage(
                            Server,
                            Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\bandas\\" + banda.Nome + "\\" + upd_fotoBanda.FileName.Replace(' ','-'),
                            Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\bandas\\" + banda.Nome + ".jpg");
                    }
                    else
                    {
                        banda.CaminhoImagem = "~/Imagens/imgBanda.jpg";

                        SiteSupport.CriarThumbnailImage(
                            Server,
                            Server.MapPath("~/Imagens/") + "\\imgBanda.jpg",
                            Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\bandas\\" + banda.Nome + ".jpg");
                    }

                    XaduxClassLibrary.Banda.Inserir(banda);
                    CurrentBanda = banda;

                    //Avança para o passo 3
                    lbl_mensagem.Text = string.Empty;
                    multi_passos.ActiveViewIndex++;
                }
                catch (Exception erro)
                {
                    lbl_mensagem.Text = erro.Message;
                }
            }
		}

		protected void bto_terceiroPasso_Click(object sender, EventArgs e)
		{
            if (Page.IsValid)
            {
                try
                {
                    string urlBanda = "http://xadux.com.br/" + CurrentBanda.Nome.Replace(' ', '-');

                    div_addThis.Attributes.Add("addthis:url", urlBanda);
                    div_addThis.Attributes.Add("addthis:title", CurrentBanda.Nome);
                    div_addThis.Attributes.Add("addthis:description", CurrentBanda.Descricao);

                    link_paginaBanda.Text = CurrentBanda.Nome;
                    link_paginaBanda.NavigateUrl = urlBanda;

                    //Avança para o passo 4
                    lbl_mensagem.Text = string.Empty;
                    multi_passos.ActiveViewIndex++;
                }
                catch (Exception erro)
                {
                    lbl_mensagem.Text = erro.Message;
                }
            }
		}

        protected void chkTermos_CheckedChanged(object sender, EventArgs e)
        {
            if (btoPrimeiroPasso.Enabled = chk_termos.Checked)
            {
                lblMsgTermos.Visible = false;
            }
            else
            {
                lblMsgTermos.Visible = true;
            }
            
        }

		#region DataBind


		protected void drop_sexo_Databind()
		{
			rdio_sexo.DataSource = XaduxClassLibrary.Sexo.Consultar();
			rdio_sexo.DataBind();
		}

		protected void chk_instrumentosMusicais_DataBind()
		{
			chk_instrumentosMusicais.DataSource = XaduxClassLibrary.InstrumentoMusical.Consultar();
			chk_instrumentosMusicais.DataBind();
		}

		protected void chk_estilosMusicais_DataBind()
		{
			chk_estilosMusicais.DataSource = XaduxClassLibrary.EstiloMusical.Consultar();
			chk_estilosMusicais.DataBind();
		}

		protected void drop_estado_DataBind()
		{
			drop_estado.DataSource = XaduxClassLibrary.Estado.Consultar();
			drop_estado.DataBind();
			drop_estado.Items.Insert(0, new ListItem("Selecione...", "0"));
		}

		protected void drop_estiloMusical_DataBind()
		{
			drop_estiloMusical.DataSource = XaduxClassLibrary.EstiloMusical.Consultar();
			drop_estiloMusical.DataBind();
		}

		protected void drop_gravadora_DataBind()
		{
			drop_gravadora.DataSource = XaduxClassLibrary.Empresa.Consultar();
			drop_gravadora.DataBind();
			drop_gravadora.Items.Insert(0, new ListItem("Não", "0"));
		}

		#endregion

		#region Músicas


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
						upd_musica.Visible = false;

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
			rept_musicas.DataSource = XaduxClassLibrary.MusicaBanda.Listar(CurrentBanda.Id);
			rept_musicas.DataBind();
		}

		protected void bto_novaMusica_Click(object sender, EventArgs e)
		{
			div_musica.Visible = true;

			txt_nomeMusica.Text = string.Empty;
			upd_musica.Visible = true;
		}

		protected void bto_inserirMusica_Click(object sender, EventArgs e)
		{
			string caminho = string.Empty;
			lbl_mensagem.Text = string.Empty;

			try
			{
				caminho = ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/bandas/" + CurrentBanda.Nome + "/musicas";
				caminho += SiteSupport.SalvarMusica(
					upd_musica,
					Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "/bandas/" + CurrentBanda.Nome + "/musicas",
					upd_musica.FileName);
			}
			catch (Exception erro)
			{
				lbl_mensagem.Text = "Erro: " + erro.Message;
				return;
			}
			XaduxClassLibrary.MusicaBanda musica = musica = XaduxClassLibrary.MusicaBanda.CreateMusicaBanda(
				0,
				txt_nomeMusica.Text,
				caminho,
				DateTime.Now,
				CurrentUsuario.Id,
				CurrentBanda.Id);

			XaduxClassLibrary.MusicaBanda.Inserir(musica);

			div_musica.Visible = false;
			rept_musicas_DataBind();
		}


		#endregion

		#region Fotos


		protected void rept_fotos_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			int id = 0;
			XaduxClassLibrary.FotoBanda foto = null;

			if (int.TryParse(e.CommandArgument.ToString(), out id))
				foto = XaduxClassLibrary.FotoBanda.Consultar(id);

			if (foto != null)
			{
				switch (e.CommandName.ToLower())
				{
					case "editar":
						div_foto.Visible = true;
						txt_nomeFoto.Text = foto.Nome;
						img_foto.Visible = true;
						img_foto.ImageUrl = foto.Caminho;
						upd_foto.Visible = false;

						break;
					case "excluir":
						XaduxClassLibrary.FotoBanda.Excluir(foto.Id);
						SiteSupport.ExcluirArquivo(foto.Caminho, Server);

						rept_fotos_DataBind();
						break;
				}
			}
		}

		protected void rept_fotos_DataBind()
		{
			rept_fotos.DataSource = XaduxClassLibrary.FotoBanda.Listar(CurrentBanda.Id);
			rept_fotos.DataBind();
		}

		protected void bto_novaFoto_Click(object sender, EventArgs e)
		{
			div_foto.Visible = true;

			txt_nomeFoto.Text = string.Empty;
			img_foto.ImageUrl = string.Empty;
			img_foto.Visible = false;
			upd_foto.Visible = true;
		}

		protected void bto_atualizarFoto_Click(object sender, EventArgs e)
		{
			XaduxClassLibrary.FotoBanda foto = null;
			string caminho = string.Empty;
			lbl_mensagem.Text = string.Empty;

			try
			{
				caminho = ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/bandas/" + CurrentBanda.Nome + "/fotos";
				caminho += SiteSupport.SalvarImagem(
					upd_fotoParaBanda,
					Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "/bandas/" + CurrentBanda.Nome + "/fotos",
					upd_fotoParaBanda.FileName);
			}
			catch (Exception erro)
			{
				lbl_mensagem.Text = "Erro: " + erro.Message;
				return;
			}

			foto = XaduxClassLibrary.FotoBanda.CreateFotoBanda(
				0,
				txt_nomeFoto.Text,
				caminho,
				DateTime.Now,
				CurrentUsuario.Id,
				CurrentBanda.Id);

			XaduxClassLibrary.FotoBanda.Inserir(foto);

			div_foto.Visible = false;
			rept_fotos_DataBind();
		}


		#endregion Fotos

		#region Vídeos


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
			rept_videos.DataSource = XaduxClassLibrary.VideoBanda.Listar(CurrentBanda.Id);
			rept_videos.DataBind();
		}

		protected void bto_novoVideo_Click(object sender, EventArgs e)
		{
			div_video.Visible = true;

			txt_nomeVideo.Text = string.Empty;
			lit_video.Text = string.Empty;
		}

		protected void bto_atualizarVideo_Click(object sender, EventArgs e)
		{
			XaduxClassLibrary.VideoBanda video = null;
			lbl_mensagem.Text = string.Empty;

			video = XaduxClassLibrary.VideoBanda.CreateVideoBanda(
				0,
				txt_nomeVideo.Text,
				txt_urlVideo.Text,
				DateTime.Now,
				CurrentUsuario.Id,
				CurrentBanda.Id);

			XaduxClassLibrary.VideoBanda.Inserir(video);
			
			div_video.Visible = false;
			rept_videos_DataBind();
		}

		protected void bto_preview_Click(object sender, EventArgs e)
		{
			lit_video.Text = txt_urlVideo.Text;
		}


		#endregion

		protected void topo_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect("default.aspx");
		}
	}
}
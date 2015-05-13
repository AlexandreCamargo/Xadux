using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace XaduxSite.Restrito
{
    public partial class Editar_Perfil : System.Web.UI.Page
    {
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
                Usuario_DataBind();
            }
        }

        protected void Usuario_DataBind()
        {
            if (usuario != null)
            {
                drop_sexo_DataBind();
                drop_estado_DataBind();
                chk_instrumentosMusicais_DataBind();
                chk_estilosMusicais_DataBind();

                lbl_login.Text = usuario.Login;
                lbl_email.Text = usuario.Email;
                txt_nome.Text = usuario.Nome;
                drop_sexo.Text = usuario.fk_Sexo_Id.ToString();
                txt_dataNasc.Text = usuario.DataNascimento.Value.ToString("dd/MM/yyyy");
                txt_cidade.Text = usuario.Cidade;
                drop_estado.Text = usuario.fk_Estado_Id.ToString();
                txt_celular.Text = usuario.Celular;
                txt_descricao.Text = usuario.Descricao;

                foreach (ListItem item in chk_instrumentosMusicais.Items)
                {
                    int id = int.Parse(item.Value);
                    XaduxClassLibrary.InstrumentoMusical instrumento = XaduxClassLibrary.InstrumentoMusical.Consultar(id);

                    if (usuario.InstrumentoMusical.Contains(instrumento))
                        item.Selected = true;
                }

                foreach (ListItem item in chk_estilosMusicais.Items)
                {
                    int id = int.Parse(item.Value);
                    XaduxClassLibrary.EstiloMusical estilo = XaduxClassLibrary.EstiloMusical.Consultar(id);

                    if (usuario.EstiloMusical.Contains(estilo))
                        item.Selected = true;
                }

                if (!string.IsNullOrEmpty(usuario.CaminhoImagem))
                {
                    img_foto.ImageUrl = usuario.CaminhoImagem;
                    img_foto.Visible = true;
                    bto_excluirFoto.Visible = true;
                }
            }
        }

        protected void drop_sexo_DataBind()
        {
            drop_sexo.DataSource = XaduxClassLibrary.Sexo.Consultar();
            drop_sexo.DataBind();
        }

        protected void drop_estado_DataBind()
        {
            drop_estado.DataSource = XaduxClassLibrary.Estado.Consultar();
            drop_estado.DataBind();
            drop_estado.Items.Insert(0, new ListItem("Selecione...", "0"));
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

        protected void bto_atualizar_Click(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                int sexoId = 0;
                int estadoId = 0;

                usuario.Nome = txt_nome.Text;

                if (int.TryParse(drop_sexo.Text, out sexoId) && sexoId != 0)
                    usuario.fk_Sexo_Id = sexoId;

                usuario.DataNascimento = DateTime.Parse(txt_dataNasc.Text);
                usuario.Cidade = txt_cidade.Text;

                if (int.TryParse(drop_estado.Text, out estadoId) && estadoId != 0)
                    usuario.fk_Estado_Id = estadoId;

                usuario.Celular = txt_celular.Text;
                usuario.Descricao = txt_descricao.Text;

                if (txt_senha.Text != string.Empty)
                    usuario.Senha = txt_senha.Text;

                usuario.InstrumentoMusical.Clear();
                foreach (ListItem item in chk_instrumentosMusicais.Items)
                {
                    if (item.Selected)
                    {
                        int id = int.Parse(item.Value);
                        XaduxClassLibrary.InstrumentoMusical instrumento = XaduxClassLibrary.InstrumentoMusical.Consultar(id);
                        usuario.InstrumentoMusical.Add(instrumento);
                    }
                }

                usuario.EstiloMusical.Clear();
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
                    try
                    {
                        {
                            usuario.CaminhoImagem = ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/usuarios/" + usuario.Login + "/";
                            usuario.CaminhoImagem += SiteSupport.SalvarImagem(
                                upd_foto,
                                Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "/usuarios/" + usuario.Login + "/",
                                upd_foto.FileName);
                            SiteSupport.CriarThumbnailImage(
                                Server,
                                Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\usuarios\\" + usuario.Login + "\\" + upd_foto.FileName.Replace(' ', '-'),
                                Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "\\usuarios\\" + usuario.Login + ".jpg");
                        }

                        XaduxClassLibrary.Usuario.Atualizar(usuario);

                        lbl_mensagem.Text = "Cadastro atualizado";

                        Usuario_DataBind();
                    }
                    catch (Exception erro)
                    {
                        lbl_msg.Text = erro.Message;
                        lbl_mensagem.Visible = false;
                    }
            }
        }

        protected void bto_excluirFoto_Click(object sender, ImageClickEventArgs e)
        {
            bool excluiu = SiteSupport.ExcluirArquivo(usuario.CaminhoImagem, Server);

            usuario.CaminhoImagem = string.Empty;

            XaduxClassLibrary.Usuario.Atualizar(usuario);

            bto_excluirFoto.Visible = false;
            img_foto.Visible = false;
        }
    }
}

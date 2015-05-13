using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace XaduxSite.Restrito
{
    public partial class Fotos : System.Web.UI.Page
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
                    rept_fotos_DataBind();
                }
            }
        }

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
                        hid_fotoId.Value = foto.Id.ToString();

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
            rept_fotos.DataSource = XaduxClassLibrary.FotoBanda.Listar(banda.Id);
            rept_fotos.DataBind();
        }

        protected void link_novaFoto_Click(object sender, EventArgs e)
        {
            div_foto.Visible = true;

            txt_nomeFoto.Text = string.Empty;
            img_foto.ImageUrl = string.Empty;
            img_foto.Visible = false;
            upd_foto.Visible = true;
            hid_fotoId.Value = string.Empty;
        }

        protected void bto_atualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int fotoId = 0;
                XaduxClassLibrary.FotoBanda foto = null;

                try
                {
                    if (int.TryParse(hid_fotoId.Value, out fotoId) && fotoId != 0)
                    {
                        foto = XaduxClassLibrary.FotoBanda.Consultar(fotoId);
                        foto.Nome = txt_nomeFoto.Text;

                        XaduxClassLibrary.FotoBanda.Atualizar(foto);
                    }
                    else
                    {
                        string caminho = ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/bandas/" + banda.Nome + "/fotos/";
                        caminho += SiteSupport.SalvarImagem(
                            upd_foto,
                            Server.MapPath(ConfigurationManager.AppSettings["Local_CaminhoFisicoArquivos"]) + "/bandas/" + banda.Nome + "/fotos/",
                            upd_foto.FileName);

                        foto = XaduxClassLibrary.FotoBanda.CreateFotoBanda(
                            0,
                            txt_nomeFoto.Text,
                            caminho,
                            DateTime.Now,
                            usuario.Id,
                            banda.Id);

                        XaduxClassLibrary.FotoBanda.Inserir(foto);
                    }

                    div_foto.Visible = false;
                    rept_fotos_DataBind();
                }
                catch (Exception erro)
                {
                    lbl_msg.Text = erro.Message;
                }
            }

        }
    }
}
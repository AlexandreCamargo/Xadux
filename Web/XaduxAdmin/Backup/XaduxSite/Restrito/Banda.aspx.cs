using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite.Restrito
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
				if (usuario == null)
					return;

				try
				{
					drop_estado_DataBind();
					drop_gravadora_DataBind();
					drop_estiloMusical_DataBind();

					if (banda != null)
						Carregar();
				}
				catch (Exception erro)
				{
					throw erro;
				}
			}
		}

		protected void Carregar()
		{
			if (banda != null)
			{
				txt_nome.Text = banda.Nome;
				txt_descricao.Text = banda.Descricao;
				drop_gravadora.Text = banda.fk_Empresa_Id_Gravadora.ToString();
				txt_site.Text = banda.Site;
				txt_facebook.Text = banda.Facebook;
				txt_twitter.Text = banda.Twitter;
				drop_estiloMusical.Text = banda.fk_EstiloMusical_Id.ToString();
				txt_email.Text = banda.Email;
				txt_cidade.Text = banda.Cidade;
				drop_estado.Text = banda.fk_Estado_Id.ToString();
				txt_telefone.Text = banda.Telefone;
			}
		}

		protected void bto_atualizar_Click(object sender, EventArgs e)
		{
			//Atualiza o cadastro
			if (banda != null)
			{
				int gravadoraId = 0;
				int estiloMusicalId = 0;
				int estadoId = 0;

				banda.Nome = txt_nome.Text;
				banda.Descricao = txt_descricao.Text;

				if (int.TryParse(drop_gravadora.Text, out gravadoraId) && gravadoraId != 0)
					banda.fk_Empresa_Id_Gravadora = gravadoraId;

				banda.Site = txt_site.Text;
				banda.Facebook = txt_facebook.Text;
				banda.Twitter = txt_twitter.Text;

				if (int.TryParse(drop_estiloMusical.Text, out estiloMusicalId) && estiloMusicalId != 0)
					banda.fk_EstiloMusical_Id = estiloMusicalId;
				
				banda.Email = txt_email.Text;
				banda.Cidade = txt_cidade.Text;

				if (int.TryParse(drop_estado.Text, out estadoId) && estadoId != 0)
					banda.fk_Estado_Id = estadoId;
				
				banda.Telefone = txt_telefone.Text;

				XaduxClassLibrary.Banda.Atualizar(banda);

				lbl_mensagem.Text = "Dados da banda atualizados.";
			}
			//Inclui um novo cadastro
			else
			{
				int gravadoraId = 0;
				int estadoId = 0;

				XaduxClassLibrary.Banda bandaAux = XaduxClassLibrary.Banda.CreateBanda(
					0,
					txt_nome.Text,
					usuario.Id,
					DateTime.Now,
					int.Parse(drop_estiloMusical.Text));

				bandaAux.Descricao = txt_descricao.Text;

				if (int.TryParse(drop_gravadora.Text, out gravadoraId) && gravadoraId != 0)
					bandaAux.fk_Empresa_Id_Gravadora = gravadoraId;
				
				bandaAux.Site = txt_site.Text;
				bandaAux.Facebook = txt_facebook.Text;
				bandaAux.Twitter = txt_twitter.Text;
				bandaAux.Email = txt_email.Text;
				bandaAux.Cidade = txt_cidade.Text;

				if (int.TryParse(drop_estado.Text, out estadoId) && estadoId != 0)
					bandaAux.fk_Estado_Id = estadoId;
				
				bandaAux.Telefone = txt_telefone.Text;

				XaduxClassLibrary.Banda.Inserir(bandaAux);

				bandaAux.UsuarioIntegrante.Add(usuario);

				Response.Redirect(SiteSupport.CommandRedirect(SiteSupport.RedirectType.BandaAdministrativo, bandaAux.Nome));

				lbl_mensagem.Text = "Banda cadastrada com sucesso.";
			}
		}
		
		protected void drop_estado_DataBind()
		{
			drop_estado.DataSource = XaduxClassLibrary.Estado.Consultar();
			drop_estado.DataBind();
			drop_estado.Items.Insert(0, new ListItem("Selecione...", "0"));
		}
		
		protected void drop_gravadora_DataBind()
		{
			drop_gravadora.DataSource = XaduxClassLibrary.Empresa.Consultar();
			drop_gravadora.DataBind();
			drop_gravadora.Items.Insert(0, new ListItem("Não", "0"));
		}

		protected void drop_estiloMusical_DataBind()
		{
			drop_estiloMusical.DataSource = XaduxClassLibrary.EstiloMusical.Consultar();
			drop_estiloMusical.DataBind();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite.Restrito
{
	public partial class Eventos : System.Web.UI.Page
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
					rept_eventos_DataBind();
				}
			}
		}

		protected void rept_eventos_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			int id = 0;
			XaduxClassLibrary.Evento evento = null;

			if (int.TryParse(e.CommandArgument.ToString(), out id))
				evento = XaduxClassLibrary.Evento.Consultar(id);

			if (evento != null)
			{
				switch (e.CommandName.ToLower())
				{
					case "editar":
						div_evento.Visible = true;
						txt_nomeEvento.Text = evento.Nome;
						txt_dataEvento.Text = evento.Data.ToShortDateString();
						txt_horario.Text = evento.Horario;
						drop_casaShow.Text = evento.fk_Empresa_Id_CasaShow.ToString();
						txt_descricao.Text = evento.Descricao;
						txt_preco.Text = evento.Preco.ToString();
						txt_siteEvento.Text = evento.Site;
						hid_eventoId.Value = evento.Id.ToString();

						break;
					case "excluir":
						XaduxClassLibrary.Evento.Excluir(evento.Id);

						rept_eventos_DataBind();
						break;
				}
			}
		}

		protected void rept_eventos_DataBind()
		{
			rept_eventos.DataSource = XaduxClassLibrary.Evento.ListarPorBanda(banda.Id);
			rept_eventos.DataBind();
		}

		protected void link_novaEvento_Click(object sender, EventArgs e)
		{
			div_evento.Visible = true;

			txt_nomeEvento.Text = string.Empty;
			hid_eventoId.Value = string.Empty;
		}

		protected void bto_atualizar_Click(object sender, EventArgs e)
		{
			int eventoId = 0;
			XaduxClassLibrary.Evento evento = null;

			int casaShowId = 0;
			decimal preco = (decimal)0;

			if (int.TryParse(hid_eventoId.Value, out eventoId) && eventoId != 0)
			{
				evento = XaduxClassLibrary.Evento.Consultar(eventoId);
				evento.Nome = txt_nomeEvento.Text;
				evento.Site = txt_siteEvento.Text;

				evento.Data = DateTime.Parse(txt_dataEvento.Text);
				evento.Horario = txt_horario.Text;

				if (int.TryParse(drop_casaShow.Text, out casaShowId) && casaShowId != 0)
					evento.fk_Empresa_Id_CasaShow = casaShowId;

				evento.Descricao = txt_descricao.Text;
				if (decimal.TryParse(txt_preco.Text, out preco))
					evento.Preco = preco;

				XaduxClassLibrary.Evento.Atualizar(evento);
			}
			else
			{
				evento = XaduxClassLibrary.Evento.CreateEvento(
					0,
					txt_nomeEvento.Text,
					DateTime.Parse(txt_dataEvento.Text),
					usuario.Id,
					DateTime.Now,
					banda.Id);

				evento.Site = txt_siteEvento.Text;
				evento.Horario = txt_horario.Text;

				if (int.TryParse(drop_casaShow.Text, out casaShowId) && casaShowId != 0)
					evento.fk_Empresa_Id_CasaShow = casaShowId;

				evento.Descricao = txt_descricao.Text;
				if (decimal.TryParse(txt_preco.Text, out preco))
					evento.Preco = preco;

				XaduxClassLibrary.Evento.Inserir(evento);
			}

			div_evento.Visible = false;
			rept_eventos_DataBind();
		}
	}
}
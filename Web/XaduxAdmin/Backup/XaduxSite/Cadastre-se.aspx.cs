using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class Cadastre_se : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				drop_sexo_DataBind();
				drop_estado_DataBind();
			}
		}

		protected void bto_enviar_Click(object sender, EventArgs e)
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

                DateTime dataNasc = DateTime.MinValue;
                int estadoId = 0;
                XaduxClassLibrary.Usuario user = XaduxClassLibrary.Usuario.CreateUsuario(
                    0,
                    txt_email.Text,
                    1, //Brasil
                    false,
                    DateTime.Now,
                    true);

                user.Nome = txt_nome.Text;
                user.Login = txt_login.Text;
                user.fk_Sexo_Id = int.Parse(drop_sexo.Text);
                user.Cidade = txt_cidade.Text;
                user.Senha = txt_senha.Text;

                if (DateTime.TryParse(txt_dataNasc.Text, out dataNasc) && txt_dataNasc.Text != string.Empty)
                    user.DataNascimento = dataNasc;

                if (int.TryParse(drop_estado.Text, out estadoId) && drop_estado.Text != "0")
                    user.fk_Estado_Id = estadoId;

                XaduxClassLibrary.Usuario.Inserir(user);

                panel_agradecimento.Visible = true;
                panel_cadastro.Visible = false;
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

		protected void chkTermos_CheckedChanged(object sender, EventArgs e)
		{
			bto_enviar.Enabled = chk_termos.Checked;
		}
	}
}
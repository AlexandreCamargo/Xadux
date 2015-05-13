using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class faleConosco : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void bto_enviar_Click(object sender, EventArgs e)
		{
			System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(
			"xadux@xadux.com.br", 
			"xadux@xadux.com.br", 
			"Xadux - Fale Conosco", 
			"Nome: " + txt_nome.Text + "\n" + "E-mail: " + txt_email.Text + "\n" + "Cidade: " + txt_cidade.Text + "\n" + "Estado: " + txtEstado.Text + "\n" + "Assunto: " + txtAssunto.Text 
			);
			System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

			try
			{
				client.Send(msg);

				lbl_mensagem.Visible = true;
				lbl_mensagem.Text = "Sua mensagem foi enviada. Obrigado!";
				phFaleConosco.Visible = false;
			}
			catch
			{
				lbl_mensagem.Visible = true;
				lbl_mensagem.Text = "Ocorreu um erro na tentativa de envio do e-mail. Tente novamente mais tarde.";
				phFaleConosco.Visible = false;
			}
		}

	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
    public partial class esqueci_a_senha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bto_enviarSenha_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
				XaduxClassLibrary.Usuario user = XaduxClassLibrary.Usuario.Consultar(txt_email.Text);
				if (user != null)
				{
					System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(
						"xadux@xadux.com.br",
						txt_email.Text,
						"Xadux - Esqueci a Senha",
						"A sua senha é " + user.Senha);
					System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

					try
					{
						client.Send(msg);

						lbl_msg.Text = "Foi enviado para seu e-mail sua senha atual. Obrigado!";
					}
					catch 
					{
						lbl_msg.Text = "Ocorreu um erro na tentativa de envio do e-mail. Tente novamente mais tarde.";
					}
				}
				else
				{
					lbl_msg.Text = "O e-mail nao foi encontrado.";
				}
            }
        }
    }
}
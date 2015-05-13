using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite
{
	public partial class Denuncie : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void bto_denuncie_Click(object sender, EventArgs e)
		{
			string id = Request["id"];

			if (!string.IsNullOrEmpty(id))
			{
				int iId = 0;
				XaduxClassLibrary.Banda banda = null;

				int.TryParse(id, out iId);

				if (iId != 0)
					banda = XaduxClassLibrary.Banda.Consultar(iId);

				if (banda != null)
				{
					System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(
						"xadux@xadux.com.br",
						"xadux@xadux.com.br",
						"Xadux - Denuncie",
						"A Banda " + banda.Nome + " foi denunciada por um usuário. Segue o motivo: " + txt_denuncie.Text);
					System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

					try
					{
						client.Send(msg);

						lbl_msg.Visible = true;
						lbl_msg.Text = "Sua denuncia foi enviada. Obrigado!";
						phDenuncie.Visible = false;
					}
					catch
					{
						lbl_msg.Visible = true;
						lbl_msg.Text = "Ocorreu um erro na tentativa de envio do e-mail. Tente novamente mais tarde.";
						phDenuncie.Visible = false;
					}
				}
				else
				{
					lbl_msg.Visible = true;
					lbl_msg.Text = "A banda não foi encontrada.";
					phDenuncie.Visible = false;
				}
			}
		}
	}
}
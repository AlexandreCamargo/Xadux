<%@ Page Language="C#" theme="SiteMain" AutoEventWireup="true" CodeBehind="Denuncie.aspx.cs" Inherits="XaduxSite.Denuncie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Denuncie</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:0 auto;width:500px">
		<br />
		<div class="tituloADM">Por que você deseja denunciar esta banda?</div><br /><br />
		<asp:PlaceHolder ID="phDenuncie" Visible="true" runat="server">
			<asp:TextBox ID="txt_denuncie" TextMode="MultiLine" runat="server" Height="86px" 
					Width="475px"></asp:TextBox><br />
			<asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txt_denuncie"
						ErrorMessage="Preenchimento obrigatório" Text="Preenchimento obrigatório!" 
						ForeColor="#FF3300"></asp:RequiredFieldValidator>

			<br />
			<asp:Button ID="bto_denuncie" runat="server" Text="Enviar denúncia" 
					onclick="bto_denuncie_Click" />
    			<br />
				<br />
		</asp:PlaceHolder>
		<br />
		<br />
		<asp:Label ID="lbl_msg" runat="server" Text="Label" Visible="false"></asp:Label>
    
	</div>
    </form>
</body>
</html>

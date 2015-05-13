<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload-Musica.aspx.cs" Inherits="XaduxSite.Upload_Musica" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:HiddenField ID="hid_musicaId" runat="server" />
		Nome: 
		<asp:TextBox ID="txt_nomeMusica" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator ControlToValidate="txt_nomeMusica" ValidationGroup="musica"
			ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="Digite o nome da música!"></asp:RequiredFieldValidator>
		<asp:Label ID="lbl_caminhoMusica" runat="server" Text=""></asp:Label>
		<asp:FileUpload ID="upd_musica" runat="server" />
		<br />
		<br />
		<asp:Button ID="bto_atualizar" runat="server" Text="Atualizar"  ValidationGroup="musica"
			onclick="bto_atualizar_Click" />
    </div>
    </form>
</body>
</html>

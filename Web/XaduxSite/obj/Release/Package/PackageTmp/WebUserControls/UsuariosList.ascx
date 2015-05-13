<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsuariosList.ascx.cs" Inherits="XaduxSite.WebUserControls.UsuariosList" %>
<asp:Repeater ID="rept_usuarios" runat="server">
	<ItemTemplate>
		<asp:ImageButton  Width="50px" ID="img_usuarios" runat="server" ImageUrl='<%#Eval("CaminhoImagemThumbnail") %>' AlternateText='<%#Eval("Nome") %>' 
		CommandName="usuario" CommandArgument='<%#Eval("Login") %>' OnClick="ButtonCommand_Click" />
		&nbsp;
	</ItemTemplate>
</asp:Repeater>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BandasList.ascx.cs" Inherits="XaduxSite.WebUserControls.BandasList" %>
<asp:Repeater ID="rept_bandas" runat="server">
	<ItemTemplate>
		<asp:ImageButton runat="server" Width="32px" ID="img_bandas" ImageUrl='<%#Eval("CaminhoImagemThumbnail") %>' 
			AlternateText='<%#Eval("Nome") %>' CommandName="banda" CommandArgument='<%#Eval("Nome") %>' OnClick="ButtonCommand_Click" />
		&nbsp;
	</ItemTemplate>
</asp:Repeater>
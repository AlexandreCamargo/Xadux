<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopBandas.ascx.cs" Inherits="XaduxSite.WebUserControls.TopBandas" %>

<asp:Repeater ID="rept_bandas" runat="server">
	<ItemTemplate>
		<asp:ImageButton runat="server" Width="150px" ID="img_bandas" runat="server"  ImageUrl='<%#Eval("CaminhoImagem") %>' 
			AlternateText='<%#Eval("Nome") %>' CommandName="banda" CommandArgument='<%#Eval("Nome") %>' OnClick="ButtonCommand_Click" />
		<p />
	</ItemTemplate>
</asp:Repeater>
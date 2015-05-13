<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="XaduxSite.Usuario" %>
<%@ Register src="WebUserControls/NoticiasList.ascx" tagname="NoticiasList" tagprefix="Xadux" %>
<%@ Register src="WebUserControls/BandasList.ascx" tagname="BandasList" tagprefix="Xadux" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderUp" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="server">
	<div>
		<asp:Image ID="img_usuario" runat="server" Width="150" />
	</div>
	<p />
	<div id="divDadosUsuario">
		<table>
			<tr><td colspan="2"><asp:Label ID="lbl_nomeUsuario1" runat="server" Text="" Font-Bold="true"></asp:Label></td></tr>
			<tr>
				<td style="font-weight:bold; vertical-align: top;">Curte: </td>
				<td style="min-height: 30px; width: 100px;">
					<asp:Repeater ID="rept_estilosMusicaisUsuario" runat="server">
						<ItemTemplate>
							<asp:LinkButton ID="link_estiloMusical" runat="server" CommandName="estiloMusical" CommandArgument='<%#Eval("Nome") %>'  OnClick="ButtonCommand_Click"><%#Eval("Nome") %></asp:LinkButton>
							&nbsp;
						</ItemTemplate>
					</asp:Repeater>
				</td>
			</tr>
			<tr>
				<td style="font-weight:bold; vertical-align: top;">Toca: </td>
				<td style="min-height: 30px;">
					<asp:Repeater ID="rept_instrumentosMusicaisUsuario" runat="server">
						<ItemTemplate>
							<asp:LinkButton ID="link_instrumentoMusical" runat="server" CommandName="instrumentoMusical" CommandArgument='<%#Eval("Nome") %>'  OnClick="ButtonCommand_Click"><%#Eval("Nome") %></asp:LinkButton>
							&nbsp;
						</ItemTemplate>
					</asp:Repeater>
				</td>
			</tr>
		</table>
	</div>
	<p />

	<div class="menuTopicos">BANDAS QUE PARTICIPO</div>
	<div id="divBandasQueParticipo">
		<Xadux:BandasList ID="BandasList_minhasBandas" runat="server" />
	</div>

	<p />
	<!--<div class="menuTopicos">TRABALHO COM:</div>
	<div id="divServicos">
		- Estúdio de Gravação<br />
		- Casa de Show
	</div>-->

	<p />
	<div class="menuTopicos">BANDAS QUE SOU FÃ (<asp:Label ID="lbl_qtdeBandasQuemEuOuco" runat="server" Text="Label"></asp:Label>)</div>
    <div id="divFas">
		<Xadux:BandasList ID="BandasList_quemEuOuco" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	<div id="divnomeUsuario"><asp:Label ID="lbl_nomeUsuario2" runat="server" Text="" Font-Bold="true"></asp:Label></div>
	<%--<div id="divBtoEnviar">
		<img src="imagens/imgfacebook.jpg" width="23px"> 
		<img src="imagens/imgTwitter.jpg" width="23px">
		<img src="imagens/imgOrkut.jpg" width="23px">
		<img alt="" src="imagens/btoEnviar.jpg" />
	</div>--%>
	<br /><br /><br />

	<div id="historicoBanda">
		<asp:Literal ID="lit_descricaoUsuario" runat="server"></asp:Literal>
	</div>
	<br />
	<p />

	<div id="divNoticias">
		<div class="menuTopicos">MURAL</div><p />
		<Xadux:NoticiasList ID="NoticiasList_banda" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderRight" runat="server">
</asp:Content>

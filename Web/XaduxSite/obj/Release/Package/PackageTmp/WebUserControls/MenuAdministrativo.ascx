<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuAdministrativo.ascx.cs"
	Inherits="XaduxSite.WebUserControls.MenuAdministrativo" %>

<div id="contentLeft"> 
    <%--<div>
		<img runat="server" id="ImgBanda" src="~/imagens/imgBanda.jpg" />
	</div>
    <p />--%>

	<div style="text-align:left; padding:7px">
		Banda: <asp:Label ID="lbl_nomeBanda" runat="server" Font-Bold="true"></asp:Label>
		<br />
		<asp:Repeater ID="rept_bandasUsuario" runat="server">
			<ItemTemplate>
				<asp:LinkButton ID="link_bandaAdm" runat="server" CommandName="bandaAdministrativo"
					CommandArgument='<%#Eval("Id") %>' OnClick="ButtonCommand_Click">
						<%#Eval("Nome") %>
				</asp:LinkButton>
				<br />
			</ItemTemplate>
			<FooterTemplate>
				<asp:LinkButton ID="link_bandaNova" runat="server" CommandName="bandaAdministrativo"
					CommandArgument="0" OnClick="ButtonCommand_Click">
						[+] Nova Banda
				</asp:LinkButton>
			</FooterTemplate>
		</asp:Repeater>
	</div>
	<p />
	<div id="div_menu" runat="server">
		<div class="botaoADM"><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/restrito/banda.aspx">Dados Cadastrais</asp:HyperLink></div>	
		<div class="botaoADM"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/restrito/imagem-banda.aspx">Imagem Apresentação</asp:HyperLink></div>
		<div class="botaoADM"><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/restrito/musicas.aspx">Músicas</asp:HyperLink></div>
		<div class="botaoADM"><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/restrito/fotos.aspx">Fotos</asp:HyperLink></div>
		<div class="botaoADM"><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/restrito/videos.aspx">Vídeos</asp:HyperLink></div>
		<div class="botaoADM"><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/restrito/integrantes.aspx">Integrantes</asp:HyperLink></div>
		<div class="botaoADM"><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/restrito/eventos.aspx">Eventos</asp:HyperLink></div>
		<div class="botaoADM"><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/restrito/noticias.aspx">Notícias</asp:HyperLink></div>
	</div>
</div>
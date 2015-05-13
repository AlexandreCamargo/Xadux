<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true"
	CodeBehind="Portal.aspx.cs" Inherits="XaduxSite.Portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderUp" runat="server">
	<div id="divEstiloMusical">
		<div class="estilosMusicais">
			<asp:Label ID="lbl_estiloMusical" runat="server" Text=""></asp:Label>
		</div>
		<div class="estilosMusicaisGenero">Mostrar todos artistas deste gênero</div>
		<!--<div class="cadastreSuaBanda">
            <img alt="" src="imagens/btoCadastrarBanda.png" />
        </div>-->
	</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="server">
	<div class="menuTopicos">
		TOP 5 ARTISTAS</div>
	<p />
	<Xadux:TopBandas ID="TopBandas_topBandas" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	<div class="menuTopicos">BANDA DESTAQUE</div>
    <div id="divDestaqueEstiloMusical">
		<asp:ImageButton ID="img_bandaDestaque" Width="340" runat="server" CommandName="banda" OnClick="ButtonCommand_Click"/>
		<p />												
	</div>
	
	<div id="divAgendaShows">
		<div class="menuTopicos">
			AGENDA DE SHOWS</div>
		<p />
		<Xadux:EventosList ID="EventosList_topEventos" runat="server" />
	</div>
	<div id="divMusicasBaixadas">
		<div class="menuTopicos">
			MÚSICAS MAIS BAIXADAS</div>
		<p />
		<Xadux:TopMusicas ID="TopMusicas_topMusicas" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderRight" runat="server">
	<div id="divNoticias">
		<div class="menuTopicos">
			NOTÍCIAS</div>
		<p />
		<Xadux:NoticiasList ID="NoticiasList_topNews" runat="server" ShowRespostas="False" />
	</div>
	<div id="divRedesSociais">
		<div class="menuTopicos">
			SIGA O XADUX</div>
		<p />
		<img runat="server" src="~/imagens/imgfacebook.jpg">
		<img runat="server" src="~/imagens/imgTwitter.jpg">
		<img runat="server" src="~/imagens/imgOrkut.jpg">
	</div>
</asp:Content>

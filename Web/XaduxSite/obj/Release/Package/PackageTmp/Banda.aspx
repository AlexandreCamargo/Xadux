<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true"
	CodeBehind="Banda.aspx.cs" Inherits="XaduxSite.Banda" %>

<%@ OutputCache Duration="10" VaryByParam="nomeBanda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style>
		#preview
		{
			position: absolute;
			border: 1px solid #ccc;
			background: #333;
			padding: 5px;
			display: none;
			color: #fff;
		}
	</style>
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
	<script language="javascript" src="../Scripts/Preview.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="server">
	<div>
		<asp:Image ID="img_banda" runat="server" Width="180px" /></div>
	<div id="divContatoBanda">
		<asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/iconeEstrela.gif" />
		<asp:LinkButton ID="bto_virarFa" runat="server" Text="Virar Fã" Visible="false" OnClick="bto_virarFa_Click" />
		<asp:LinkButton ID="bto_deixarDeSerFa" runat="server" Text="Deixar de ser Fã" Visible="false"
			OnClick="bto_deixarDeSerFa_Click" />
		<br />
		<!--<asp:Image ID="Image2" runat="server" ImageUrl="~/Imagens/iconeMensagem.gif" />
		Mensagem-->
		<br />
		<table  style="width:100px;margin:0 auto;">
			<tr>
				<td width="20">
					<asp:HyperLink ID="link_facebook" runat="server" Target="_blank" Visible="false">
						<asp:Image ID="img_facebook" ImageUrl="~/imagens/imgfacebook.jpg" Width="15px" Height="15px"
							AlternateText="Acompanhe-nos no Facebook" runat="server" />
				</td>
				<td style="text-align:left;width:80px">Facebook
					</asp:HyperLink>
				</td>	
			</tr>
			<tr>
				<td>
					<asp:HyperLink ID="link_twitter" runat="server" Target="_blank" Visible="false">
						<asp:Image ID="img_twitter" ImageUrl="~/imagens/imgTwitter.jpg" Width="15px" Height="15px"
							AlternateText="Siga-nos no Twitter" runat="server" />
				</td>
				<td style="text-align:left;">
						Twitter
					</asp:HyperLink>
				</td>
			</tr>
		</table>
	</div>
	<div id="divDadosBanda">
		<p />
		<asp:Label ID="lbl_nomeBanda1" runat="server" Text="" Font-Bold="true"></asp:Label><br />
		E-mail:
		<asp:Label ID="lbl_emailBanda" runat="server" Text=""></asp:Label><br />
		Estado:
		<asp:Label ID="lbl_estadoBanda" runat="server" Text=""></asp:Label><br />
		Telefone:
		<asp:Label ID="lbl_telefoneBanda" runat="server" Text=""></asp:Label><br />
		Estilo Musical:
		<asp:LinkButton ID="bto_estiloMusicalBanda" runat="server" CommandName="estiloMusical"
			CommandArgument="" OnClick="ButtonCommand_Click"></asp:LinkButton><p>
				<!--<img src="imagens/imgOrkut.jpg" width="23px">-->
				<p>
	</div>
	<div id="divFas">
		<strong>Fãs (<asp:Label ID="lbl_qtdeFas" runat="server" Text=""></asp:Label>)</strong><br />
		<div style="width: 100%">
			<Xadux:UsuariosList ID="UsuariosList_fas" runat="server" />
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	<div id="divnomeBanda">
		<asp:Label ID="lbl_nomeBanda2" runat="server" Text="" Font-Bold="true"></asp:Label>
	</div>
	<div id="divBtoEnviar">
		<!-- AddThis Button BEGIN -->
		<div id="div_addThis" class="addthis_toolbox addthis_default_style addthis_32x32_style">
			<a class="addthis_button_preferred_1"></a><a class="addthis_button_preferred_2"></a>
			<a class="addthis_button_preferred_3"></a><a class="addthis_button_preferred_4"></a>
			<a class="addthis_button_compact"></a><a class="addthis_counter addthis_bubble_style"></a>
			&nbsp;<asp:ImageButton ID="bto_denuncie" ImageUrl="~/Imagens/iconeDenuncie.png" title="Denuncie!"
			AlternateText="Denuncie" runat="server" onclick="bto_denuncie_Click" />
		</div>
		<script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4df52f69673ee0ab"></script>
		<!-- AddThis Button END -->

		
	</div>
	<br />
	<br />
	<br />
	<div id="divHistorico">
		<asp:Literal ID="lit_descricaoBanda" runat="server"></asp:Literal>
	</div>
	<br />
	<div id="divIntegrantes">
		<div class="menuTopicos">
			INTEGRANTES</div>
		<br />
		<div style="width: 100%">
			<Xadux:UsuariosList ID="UsuariosList_integrantes" runat="server" />
		</div>
		<br />
	</div>
	<div>
		<asp:LinkButton ID="link_noticias" runat="server" onclick="link_noticias_Click"><img src="/Imagens/BtnNoticiasOn.gif"></asp:LinkButton>
		<asp:LinkButton ID="link_fotos" runat="server" OnClick="link_fotos_Click"><img src="/Imagens/BtnFotosOn.gif"></asp:LinkButton>		
		<asp:LinkButton ID="link_videos" runat="server" OnClick="link_videos_Click"><img src="/Imagens/BtnVideosOn.gif"></asp:LinkButton>
		<asp:LinkButton ID="link_agenda" runat="server" OnClick="link_agenda_Click"><img src="/Imagens/BtnAgenda.gif"></asp:LinkButton>
		<span style="clear: both;" />
	</div>
	<asp:MultiView ID="mview_abas" runat="server" ActiveViewIndex="0">
		<asp:View ID="view_noticias" runat="server">
			<div id="divNoticias" style="background-color:#cccccc;">
				
				<Xadux:NoticiasList ID="NoticiasList_banda" runat="server" />
			</div>
		</asp:View>
		<asp:View ID="view_fotos" runat="server">
			<div style="width: 100%; background-color:#999999;">
				<br />
				<asp:Repeater ID="rept_fotos" runat="server">
					<ItemTemplate>
						<a id="A1" runat="server" href='<%#Eval("Caminho") %>' target="_blank" class="preview"
							title='<%#Eval("Nome") %>'>
							<asp:Image Width="100px" ID="img_fotos" runat="server" ImageUrl='<%#Eval("Caminho") %>'
								AlternateText='<%#Eval("Nome") %>' />
						</a>
					</ItemTemplate>
				</asp:Repeater>
			</div>
		</asp:View>
		<asp:View ID="view_multimedia" runat="server">
			<div style="background:#333333;text-align:center;">
				<asp:Repeater ID="rept_videos" runat="server">
					<ItemTemplate>
						<br /><asp:Literal ID="lit_videos" runat="server" Text='<%#Eval("URL") %>'></asp:Literal><br /><br />
					</ItemTemplate>
				</asp:Repeater>
				<br style="clear: both;" />
			</div>
		</asp:View>
		<asp:View ID="view_agenda" runat="server">
			<div style="background:#333333;text-align:center;padding:5px;">
				<Xadux:EventosList ID="eventos_agenda" runat="server" />
			</div>
		</asp:View>
	</asp:MultiView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderRight" runat="server">
	<div class="menuTopicos">
		MÚSICAS</div>
	<div id="divMusicas">
		<asp:Repeater ID="rept_musicas" runat="server">
			<ItemTemplate>
				<div style="background-color: #F8F8F8; font-family: Verdana; margin-bottom: 2px;">
					<div style="float: left">
						<asp:HyperLink ID="link_musica" runat="server" NavigateUrl='<%#Eval("Caminho") %>'><%#Eval("Nome") %></asp:HyperLink>
					</div>
					<div style="float: right">
						<%--<asp:Button ID="bto_download" runat="server" Text="Download" CommandArgument='<%# Eval("Id") %>'
							OnClick="bto_download_Click" />--%>

						<asp:ImageButton ID="bto_download" runat="server" ImageUrl="~/Imagens/imgSetaDownload.jpg" CommandArgument='<%# Eval("Id") %>' OnClick="bto_download_Click"/>
					
					</div>
					<div style="clear: both;">
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
	<script type="text/javascript" src="http://mediaplayer.yahoo.com/js"></script>
	<%--<script type="text/javascript" src="../Scripts/yahooMediaPlayer.js"></script>--%>
	<p />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderUp" runat="server">
</asp:Content>
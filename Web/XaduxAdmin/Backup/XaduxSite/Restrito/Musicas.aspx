<%@ Page Title="" Language="C#" MasterPageFile="~/Restrita.master" AutoEventWireup="true"
	CodeBehind="Musicas.aspx.cs" Inherits="XaduxSite.Restrito.Musicas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	<div class="tituloADM">
		Músicas</div>
	<br />
	<div style="border-style: solid; border-width: thin; color: darkgreen; padding: 5px;">
		1. <strong>Não serão aceitos covers ou versões, em hipótese alguma, incluindo remixes
			ou samplers de músicas de outros artistas.</strong><br />
		2. Tamanho máximo do arquivo: 10MB;<br />
		3. Não use caracteres especiais para os nomes dos arquivos;<br />
		4. Espere a confirmação do envio para ter certeza que o arquivo chegou completo;
	</div>
	<br />
	<br />
	<asp:Button ID="link_novaMusica" runat="server" OnClick="link_novaMusica_Click" Text="+ Adicionar nova música" />
	&nbsp;&nbsp;<asp:Label ID="lbl_msg" runat="server" ViewStateMode="Disabled" ForeColor="#FF3300"></asp:Label>
	<div id="div_musica" runat="server" visible="false">
		<asp:HiddenField ID="hid_musicaId" runat="server" />
		Nome:
		<asp:TextBox ID="txt_nomeMusica" runat="server"></asp:TextBox>
		<asp:FileUpload ID="upd_musica" runat="server" />
		<asp:Button ID="bto_atualizar" runat="server" Text="Atualizar" ValidationGroup="musica"
			OnClick="bto_atualizar_Click" /><br />
		<br />
		<asp:RequiredFieldValidator ControlToValidate="txt_nomeMusica" ValidationGroup="musica"
			ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
			Text="Digite o nome da música!" ForeColor="Red"></asp:RequiredFieldValidator>
		<br />
		<asp:Label ID="lbl_caminhoMusica" runat="server" ForeColor="Red"></asp:Label>
		<br />
	</div>
	<br />
	<asp:Repeater ID="rept_musicas" runat="server" OnItemCommand="rept_musicas_ItemCommand">
		<ItemTemplate>
			<div>
				<asp:HyperLink ID="link_musica" runat="server" NavigateUrl='<%#Eval("Caminho") %>'><%#Eval("Nome") %></asp:HyperLink>
				|
				<asp:LinkButton ID="lnk_editar" runat="server" CommandName="editar" CommandArgument='<%#Eval("Id") %>'>editar</asp:LinkButton>
				|
				<asp:LinkButton ID="lnk_excluir" runat="server" CommandName="excluir" CommandArgument='<%#Eval("Id") %>'
					OnClientClick="confirm('Tem certeza?');">excluir</asp:LinkButton>
			</div>
		</ItemTemplate>
	</asp:Repeater>
	<script type="text/javascript" src="http://mediaplayer.yahoo.com/js"></script>
</asp:Content>

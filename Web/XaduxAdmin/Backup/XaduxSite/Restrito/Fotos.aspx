<%@ Page Title="" Language="C#" MasterPageFile="~/Restrita.master" AutoEventWireup="true" CodeBehind="Fotos.aspx.cs" Inherits="XaduxSite.Restrito.Fotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	
	<div class="tituloADM">Fotos</div>
		<br />
		<div style="border-style:solid; border-width:thin;color:darkgreen;padding:5px;">
			<strong>As fotos que você enviar por este formulário serão exibidas na galeria de fotos do site.</strong><br /><br />
				1. Extensões aceitas: GIF,JPG e PNG;<br /><br />
				2. Largura ou altura máxima da foto: 1280 pixels;<br /><br />
				3. Tamanho máximo do arquivo: 1mb;<br /><br />
				4. Sempre adicione legendas, enriqueça seu site!<br /><br />
				5. Não use caracteres especiais para os nomes dos arquivos;<br /><br />
				6. Espere a confirmação do envio para ter certeza que sua foto chegou completa;

		</div>
		<br />	
	
	<asp:Button ID="link_novaFoto" runat="server" onclick="link_novaFoto_Click" Text="+ Adicionar nova foto" />
	<asp:Label ID="lbl_msg" runat="server" ViewStateMode="Disabled" ForeColor="#FF3300"></asp:Label>
	<div id="div_foto" runat="server" visible="false">
		<asp:HiddenField ID="hid_fotoId" runat="server" />
		Nome: 
		<asp:TextBox ID="txt_nomeFoto" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator ControlToValidate="txt_nomeFoto" ValidationGroup="foto"
			ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="*"></asp:RequiredFieldValidator>
		
		<asp:Image ID="img_foto" Width="150px" runat="server" />
		<asp:FileUpload ID="upd_foto" runat="server" />
		<%--<br />
		<br />--%>
		<asp:Button ID="bto_atualizar" runat="server" Text="Atualizar"  ValidationGroup="foto"
			onclick="bto_atualizar_Click" />
	</div>

	<br />
	<br />
	<asp:Repeater ID="rept_fotos" runat="server" 
		onitemcommand="rept_fotos_ItemCommand">
		<ItemTemplate>
			<div>
				<asp:Image ID="img_foto" ImageUrl='<%#Eval("Caminho") %>' Width="70px" runat="server" />  |
				<asp:LinkButton ID="lnk_editar" runat="server" CommandName="editar" CommandArgument='<%#Eval("Id") %>'>editar</asp:LinkButton> |
				<asp:LinkButton ID="lnk_excluir" runat="server" CommandName="excluir" CommandArgument='<%#Eval("Id") %>' OnClientClick="confirm('Tem certeza?');">excluir</asp:LinkButton>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</asp:Content>
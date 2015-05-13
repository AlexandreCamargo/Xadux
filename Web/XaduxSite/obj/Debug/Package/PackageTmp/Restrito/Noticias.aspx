<%@ Page Title="" Language="C#" MasterPageFile="~/Restrita.master" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="XaduxSite.Restrito.Noticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	
	<div class="tituloADM">Notícias</div>
		<br />
		<div style="border-style:solid; border-width:thin;color:darkgreen;padding:5px;">
			<strong>Os noticias que você cadastrar nesta seção serão adicionados à agenda do seu site 
			e poderão ser divulgados no Xadux, mediante aprovação do moderador.</strong><br /><br />
			1. Atenção às informações inseridas, elas são de sua inteira responsabilidade;<br /><br />
			2. Atenção ao preencher o nome das bandas. Escreva corretamente;<br /><br />
			3. Depois de cadastrar o noticia, não se esqueça de conferir todos os dados.
	</div><br />

	<asp:Button ID="link_novaNoticia" runat="server" OnClick="link_novaNoticia_Click" Text="+ Adicionar novo noticia" />
	<div id="div_noticia" runat="server" visible="false">
		<asp:HiddenField ID="hid_noticiaId" runat="server" />
		Nome:
		<asp:TextBox ID="txt_nomeNoticia" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator ControlToValidate="txt_nomeNoticia" ValidationGroup="noticia"
			ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="*"></asp:RequiredFieldValidator>
		<br />
		<br />
		<asp:Button ID="bto_atualizar" runat="server" Text="Atualizar" OnClick="bto_atualizar_Click" ValidationGroup="noticia" />
	</div>
	<br />
	<br />
	<asp:Repeater ID="rept_noticias" runat="server" OnItemCommand="rept_noticias_ItemCommand">
		<ItemTemplate>
			<div>
				<asp:Label ID="lbl_data" runat="server" Font-Bold="true" Text='<%#Eval("DataCadastro", "{0:d}") %>'></asp:Label> - 
				<asp:Label ID="lbl_nome" runat="server" Font-Bold="true" Text='<%#Eval("Nome") %>'></asp:Label>
				<br />
				<asp:LinkButton ID="lnk_editar" runat="server" CommandName="editar" CommandArgument='<%#Eval("Id") %>'>editar</asp:LinkButton>
				|
				<asp:LinkButton ID="lnk_excluir" runat="server" CommandName="excluir" CommandArgument='<%#Eval("Id") %>'
					OnClientClick="confirm('Tem certeza?');">excluir</asp:LinkButton>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</asp:Content>
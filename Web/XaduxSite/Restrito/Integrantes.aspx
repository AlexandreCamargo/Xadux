<%@ Page Title="" Language="C#" MasterPageFile="~/Restrita.master" AutoEventWireup="true" CodeBehind="Integrantes.aspx.cs" Inherits="XaduxSite.Restrito.Integrantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	<%--<link href="../../App_Themes/SiteMain/jquery.autocomplete.css" rel="stylesheet" type="text/css" />--%>
	<script src="../../scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../../scripts/jquery.autocomplete.js" type="text/javascript"></script>
	<script type="text/javascript">
		$(document).ready(function () {
			$("#<%=txt_usuario.ClientID%>").autocomplete('IntegranteAutoComplete.ashx');
		});      
	</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">

	<div class="tituloADM">Integrantes</div>
		<br />
		<div style="border-style:solid; border-width:thin;color:darkgreen;padding:5px;">
			Para adicionar um integrante, o mesmo deverá ter um cadastro individual no XaduX, em seguida é só fazer a busca por nome 
			e adicioná-lo a banda. 
		</div>
	<br />

	Integrantes<br />
	<br />
	<asp:Repeater ID="rept_integrantes" runat="server">
		<ItemTemplate>
			<div>
				<asp:Image ID="img_user" Width="50px" ImageUrl='<%#Eval("CaminhoImagem") %>' runat="server" />
				<asp:Button ID="bto_remover" runat="server" Text="Remover" CommandArgument='<%#Eval("Id") %>' OnClick="bto_remover_Click"/>
				<br />
				<asp:Label ID="lbl_nome" runat="server" Font-Bold="true" Text='<%#Eval("Nome") %>'></asp:Label>
				<br />
				<asp:Label ID="lbl_email" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
			</div>
		</ItemTemplate>
	</asp:Repeater>
	<br />

	Digite o login ou e-mail do usuário que você deseja adicionar como integrante desta banda:<br />
	<asp:TextBox ID="txt_usuario" runat="server" ValidationGroup="busca" AutoCompleteType="Search"></asp:TextBox>
	<asp:Button ID="bto_buscar" runat="server" Text="Buscar" ValidationGroup="busca"
		onclick="bto_buscar_Click" /><br />
	<asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
	
	<br />
	<br />
	<asp:Repeater ID="rept_usuarios" runat="server">
		<ItemTemplate>
			<div>
				<asp:Image ID="img_user" Width="50px" ImageUrl='<%#Eval("CaminhoImagem") %>' runat="server" />
				<asp:Label ID="lbl_nome" runat="server" Font-Bold="true" Text='<%#Eval("Nome") %>'></asp:Label>
				<br />
				<asp:Label ID="lbl_email" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
				<br />
				<asp:Label ID="lbl_dataNasc" runat="server" Text=""><%#Eval("DataNascimento", "{0:d}") %></asp:Label>
				<asp:Button ID="bto_adicionar" runat="server" Text="Adicionar" CommandArgument='<%#Eval("Id") %>' OnClick="bto_adicionar_Click"/>
			</div>
		</ItemTemplate>
	</asp:Repeater>

</asp:Content>
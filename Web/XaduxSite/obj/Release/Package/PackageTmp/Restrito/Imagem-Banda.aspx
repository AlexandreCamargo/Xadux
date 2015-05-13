<%@ Page Title="" Language="C#" MasterPageFile="~/Restrita.master" AutoEventWireup="true"
	CodeBehind="Imagem-Banda.aspx.cs" Inherits="XaduxSite.Restrito.Imagem_Banda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	<asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>

    <div class="tituloADM">Imagem de Apresentação</div>
	<br />
	<div style="width:350px;float:left;">
		A imagem de apresentação deve possuir 180px de largura por 180px de altura, 
		padrão (formatos JPG ou PNG).<br /><br />
		Use o exemplo ao lado como referência. 
		Uma boa imagem de apresentação dá credibilidade e aumenta 
		suas chances de ser destaque no portal.
	</div>
	<div style="float:right;">
		<img src="/imagens/modeloImagem.jpg">
	</div>
	<br style="clear:both;" /> 	    
	<div class="menuTopicos">ENVIE A SUA IMAGEM</div>
	<br />

	<asp:FileUpload ID="upd_foto" runat="server" /><br />
	<asp:Image ID="img_foto" runat="server" Visible="false" />
	<asp:ImageButton ID="bto_excluirFoto" AlternateText="Excluir Foto" runat="server"
		Visible="false" OnClick="bto_excluirFoto_Click" />
	<br />
	<br />
	<asp:Button ID="bto_atualizar" runat="server" Text="Atualizar" 
		onclick="bto_atualizar_Click" />
</asp:Content>

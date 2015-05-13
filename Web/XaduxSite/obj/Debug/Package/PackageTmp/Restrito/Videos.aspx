<%@ Page Title="" Language="C#" MasterPageFile="~/Restrita.Master" AutoEventWireup="true" ValidateRequest="false"   
	CodeBehind="Videos.aspx.cs" Inherits="XaduxSite.Restrito.Videos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	<div class="tituloADM">
		Vídeos</div>
	<br />
	<div style="border-style: solid; border-width: thin; width:600px ;color: darkgreen; padding: 5px;">
		<strong>É muito fácil enviar os seus vídeos para o XaduX, vejam 2 exemplos:<br />
        <br />
        <asp:Image ID="ImgVimeo" runat="server" ImageUrl="~/Imagens/Vimeo.jpg" />
        <asp:Image ID="imgYouTube" runat="server" ImageUrl="~/Imagens/youtube.jpg" />
        <br />
        <br />
        </strong>
	</div>
	<br />
	<div>
		<asp:Button ID="link_novoVideo" runat="server" OnClick="link_novoVideo_Click" Text="+ Adicionar novo video" />
		<div id="div_video" runat="server" visible="false">
			<asp:HiddenField ID="hid_videoId" runat="server" />
			Nome:
			<asp:TextBox ID="txt_nomeVideo" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ControlToValidate="txt_nomeVideo" ID="RequiredFieldValidator1"
				runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="video"
				Text="*"></asp:RequiredFieldValidator>
			URL:
			<asp:TextBox ID="txt_urlVideo" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ControlToValidate="txt_urlVideo" ID="RequiredFieldValidator2"
				runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="video"
				Text="*"></asp:RequiredFieldValidator>
			<asp:Button ID="bto_preview" runat="server" Text="Preview" OnClick="bto_preview_Click" />
			<asp:Button ID="bto_atualizar" runat="server" Text="Atualizar" OnClick="bto_atualizar_Click"
				ValidationGroup="video" />
			<br />
			<asp:Literal ID="lit_video" runat="server"></asp:Literal>
		</div>
		<br />
		<br />
		<asp:Repeater ID="rept_videos" runat="server" OnItemCommand="rept_videos_ItemCommand">
			<ItemTemplate>
				<div>
					<asp:Label ID="lbl_nome" runat="server" Font-Bold="true" Text='<%#Eval("Nome") %>'></asp:Label>
					<br />
					<%#Eval("URL")%>
					<br />
					<asp:LinkButton ID="lnk_editar" runat="server" CommandName="editar" CommandArgument='<%#Eval("Id") %>'>editar</asp:LinkButton>
					|
					<asp:LinkButton ID="lnk_excluir" runat="server" CommandName="excluir" CommandArgument='<%#Eval("Id") %>'
						OnClientClick="confirm('Tem certeza?');">excluir</asp:LinkButton>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</asp:Content>

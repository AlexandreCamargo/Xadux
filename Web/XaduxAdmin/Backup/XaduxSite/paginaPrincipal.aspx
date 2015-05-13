<%@ Page Title="" Language="C#" MasterPageFile="~/Parent.Master" AutoEventWireup="true" CodeBehind="paginaPrincipal.aspx.cs" Inherits="XaduxSite.paginaPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 179px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
<div style="width:980px;margin:0 auto;margin-top:0px;background-color:#ffdd55;padding-left:20px;padding-top:20px;padding-bottom:20px;"> 
	<div style="height:460px;margin:0 auto;">
	<span class="tituloADM">Seja bem vindo ao Xadux, o lugar onde fãs e ídolos se encontram.</span><p />
		<table cellpadding="22" cellspacing="30" border="0" style="border-collapse:collapse;width:930px;background-color :Gray;">
			<tr>
				<td>
					<asp:ImageButton ID="btnBanda" runat="server" 
						ImageUrl="~/Imagens/btnBanda.gif" onclick="btnBanda_Click" />
				</td>
				<td>
					<asp:ImageButton ID="btnFaMusica" runat="server" 
						ImageUrl="~/Imagens/btnFaMusica.gif" onclick="btnFaMusica_Click" />
				</td>
				<td>

					<asp:Image ID="Image1" ImageUrl="~/Imagens/btnMusicas.gif" runat="server" />
				</td>
			</tr>

			<tr>
				<td style="font-size:large;font-family:Arial;color:#ffffff;" class="style1">
					Cadastre a sua banda no Xadux, é fácil, grátis e rápido.
                    Em apenas 4 passos você terá a sua fã page, com suas 
                    músicas, vídeos, fotos e agenda de shows.<br />

				</td>
				<td style="font-size:large;font-family:Arial;color:#ffffff;" class="style1">
					Se você curte ouvir música, se cadastre no Xadux como fã de música e
                    interaja com a sua banda favorita, curtindo músicas,
                    vídeos e enviando scraps.
				</td>
				<td style="font-size:large;font-family:Arial;color:#ffffff;" class="style1">
                    Encontre a banda / artista facilmente utilizando o menu no topo da página,
					busque por estilo musical ou nome. Compartilhe com seus amigos.
				</td>
			</tr>
		</table><br />
        <div style="text-align:right;width:900px;">
            <a href="http://www.facebook.com/pages/Xadux-Seu-Estilo-Sua-M%C3%BAsica/161380797244884" target="_blank"><img src="/Imagens/imgFacebook.jpg"></a>&nbsp;
            <a href="http://twitter.com/#!/xadux" target="_blank"><img src="/Imagens/imgTwitter.jpg"></a>&nbsp;
        </div>
	</div>

</div>
</asp:Content>
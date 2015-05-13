<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopMusicas.ascx.cs" Inherits="XaduxSite.WebUserControls.TopMusicas" %>

<div>
	<asp:Repeater ID="rept_musicas" runat="server">
		<ItemTemplate>
			<div class="musicaListItem">
				<div class="firstColumn">
					<asp:LinkButton ID="link_nomeMusica" runat="server" CommandName="banda" CommandArgument='<%#Eval("Banda.Nome") %>'>
						<%#Eval("Nome") %>
					</asp:LinkButton>
				</div>
				<div class="SecondColumn">
					<asp:LinkButton ID="link_estiloMusical" runat="server" CommandName="estiloMusical" CommandArgument='<%#Eval("Banda.EstiloMusical.Nome") %>'>
						<%#Eval("Banda.EstiloMusical.Nome") %>
					</asp:LinkButton>
				</div>
				<div style="clear: both;"></div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
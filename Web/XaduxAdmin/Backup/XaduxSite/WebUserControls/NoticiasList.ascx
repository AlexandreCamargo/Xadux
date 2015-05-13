<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoticiasList.ascx.cs" Inherits="XaduxSite.WebUserControls.NoticiasList" %>

<asp:Repeater ID="rept_noticias" runat="server" 
		onitemdatabound="rept_noticias_ItemDataBound" 
	onitemcommand="rept_noticias_ItemCommand">
	<ItemTemplate>
		<table>
			<tr>
				<td>
					<asp:ImageButton  Width="50px" ID="img_userNoticia" runat="server" 
						ImageUrl='<%#Eval("Banda.CaminhoImagemThumbnail") %>' CommandName="banda" 
						AlternateText='<%#Eval("Banda.Nome") %>'
						CommandArgument='<%#Eval("Banda.Nome") %>'
						OnClick="ButtonCommand_Click" />
				</td>
				<td colspan="2" style="background-color: #F8F8F8; width: 100%; text-align: left;">
					<asp:Label ID="lbl_noticia" runat="server" Text='<%#Bind("Nome") %>'></asp:Label>
				</td>
			</tr>

			<asp:Repeater ID="rept_respostas" runat="server">
				<ItemTemplate>
					<tr>
						<td></td>
						<td>
							<asp:ImageButton Width="32px" ID="img_userResposta" runat="server" 
								ImageUrl='<%#Eval("Usuario.CaminhoImagemThumbnail") %>' CommandName="usuario" 
								AlternateText='<%#Eval("Usuario.Nome") %>'
								CommandArgument='<%#Eval("Usuario.Email") %>'
								OnClick="ButtonCommand_Click" />
						</td>
						<td style="background-color: #F0F0F0; width: 100%;  text-align: left;">
							<asp:Label ID="lbl_resposta" runat="server" Text='<%#Bind("Nome") %>'></asp:Label>
						</td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
			<tr runat="server" id="tr_newComentario">
				<td></td>
				<td colspan="2">
					<asp:TextBox ID="txt_newComentario" MaxLength="250" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox><br />
					<asp:Button ID="bto_enviarComentario" runat="server" Text="Enviar" CommandName="enviarComentario" 
						CommandArgument='<%#Eval("Id") %>' />
				</td>
			</tr>
		</table>
	</ItemTemplate>
</asp:Repeater>
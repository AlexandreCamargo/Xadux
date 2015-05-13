<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true"
	CodeBehind="faleConosco.aspx.cs" Inherits="XaduxSite.faleConosco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderUp" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	<table>
		<tr>
			<td class="tituloADM" colspan="2">
				Fale Conosco
			</td>
		</tr>
		<tr>
			<td colspan="2">
				Este espaço é para você entrar em contato com a equipe do Xadux, envie a sua dúvida, sugestão ou crítica.
			</td>
		</tr>
		<asp:PlaceHolder id="phFaleConosco" Visible="true" runat="server">
			<tr>
				<td style="text-align: right;">
					Nome:
				</td>
				<td class="tb7">
					<asp:TextBox ID="txt_nome" runat="server" Width="300px"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txt_nome"
						ValidationGroup="cadastro" ErrorMessage="O campo Nome é obrigatório" Text="O campo Nome é obrigatório!"
						ForeColor="#FF3300"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="text-align: right;">
					E-mail:
				</td>
				<td>
					<asp:TextBox ID="txt_email" runat="server" Width="300px"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_email"
						ValidationGroup="cadastro" ErrorMessage="O campo E-mail é obrigatório" Text="O campo E-mail é obrigatório!"
						ForeColor="#FF3300"></asp:RequiredFieldValidator><br />
					<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email"
						Display="Dynamic" ErrorMessage="Informe um e-mail correto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Informe um e-mail correto
					</asp:RegularExpressionValidator>--%>
				</td>
			</tr>
			<tr>
				<td style="text-align: right;">
					Cidade:
				</td>
				<td>
					<asp:TextBox ID="txt_cidade" runat="server"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cidade"
						ValidationGroup="cadastro" ErrorMessage="O campo Cidade é obrigatório" Text="O campo Cidade é obrigatório!"
						ForeColor="#FF3300"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="text-align: right;">
					Estado:
				</td>
				<td>
					<asp:TextBox ID="txtEstado" runat="server" MaxLength="2" Width="20"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEstado"
						ValidationGroup="cadastro" ErrorMessage="O campo Estado é obrigatório" Text="O campo Estado é obrigatório!"
						ForeColor="#FF3300"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					Assunto
				</td>
				<td>
					<asp:TextBox ID="txtAssunto" TextMode="MultiLine" runat="server" Height="100px" Width="300px"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAssunto"
						ValidationGroup="cadastro" ErrorMessage="O campo nome é obrigatório" Text="O campo Assunto é obrigatório!"
						ForeColor="#FF3300"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
				</td>
				<td>
					<asp:Button ID="bto_enviar" runat="server" Text="Enviar" 
						ValidationGroup="cadastro" onclick="bto_enviar_Click" />
				</td>
			</tr>
		</asp:PlaceHolder>
		<tr style="height:50px;">
			<td></td>
			<td style="color: red">
				<strong><asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label></strong>
			</td>
		</tr>
	</table>
</asp:Content>

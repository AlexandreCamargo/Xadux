<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true" CodeBehind="Cadastre-se.aspx.cs" Inherits="XaduxSite.Cadastre_se"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="server">
	&nbsp;
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	

	<asp:Panel ID="panel_cadastro" runat="server">
		<table>
			<tr>
				<td class="tituloADM" colspan="2">Cadastre-se grátis</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td colspan="2">
					<strong>Seja bem vindo a maior rede social musical do planeta, onde fãs e idolos se encontram.</strong><p />
					o cadastro é muito simples e rápido, primeiro cadastre o seu usuário, a partir 
					daí poderá navegar pelas páginas das bandas que você curte se
					tornando fã e ficar por dentro de todas notícias da banda e ainda
					podendo interagir enviando scraps direto nas postagens.<p />

					Se você é músico, poderá criar a página exclusiva da sua(s) banda(s), 
					divulgando suas músicas, vídeos e fotos.
				</td>
			</tr>
			<tr>
				<td style="color:red" colspan="2"><strong><asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label></strong><br /></td>
			</tr>
			<tr>
				<td style="text-align:right;">Termos:</td>
				<td class="tb7">
					<asp:CheckBox ID="chk_termos" runat="server" AutoPostBack="True" 
						oncheckedchanged="chkTermos_CheckedChanged" /> Li e concordo com os 
					<a href="#" onclick="javascript: window.open('termosCadastro.aspx', 'titulo', 'scrollbars=yes,resizable=yes,width=700,height=500,status=no,location=no,toolbar=no');"><font color="green">termos de cadastro.</font></a></td>
			</tr>
			<tr>
				<td style="text-align:right;">
					Nome:
				</td>
				<td class="tb7">
					<asp:TextBox ID="txt_nome" runat="server" Width="300px"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txt_nome"
						ValidationGroup="cadastro" ErrorMessage="O campo nome é obrigatório" Text="O campo nome é obrigatório!" 
						ForeColor="#FF3300"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="text-align:right;">
					E-mail:
				</td>
				<td>
					<asp:TextBox ID="txt_email" runat="server"  Width="300px"></asp:TextBox><br />
					
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_email"
						ValidationGroup="cadastro" ErrorMessage="O campo E-mail é obrigatório" Text="O campo mail é obrigatório!" 
						ForeColor="#FF3300"></asp:RequiredFieldValidator><br />

					<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
						ValidationGroup="cadastro"
						ControlToValidate="txt_email" Display="Dynamic" ErrorMessage="Informe um e-mail correto" 
						ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Informe um e-mail correto
					</asp:RegularExpressionValidator>


				</td>
			</tr>
			<tr>
				<td style="text-align:right;">
					Login:
				</td>
				<td>
					<asp:TextBox ID="txt_login" runat="server"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_login"
						ValidationGroup="cadastro" ErrorMessage="O campo login é obrigatório" Text="O campo login é obrigatório!" 
						ForeColor="#FF3300"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="text-align:right;">
					Sexo:
				</td>
				<td>
					<asp:DropDownList ID="drop_sexo" runat="server" DataTextField="Nome" DataValueField="Id">
					</asp:DropDownList>

				</td>
			</tr>
			<tr>
				<td style="text-align:right;">
					Data de Nascimento:
				</td>
				<td>
					<asp:TextBox ID="txt_dataNasc" runat="server" onkeypress="formataData(this); return numerico(event);" MaxLength="10"></asp:TextBox><br />
					
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dataNasc"
						ValidationGroup="cadastro" ErrorMessage="O campo Data de Nascimento é obrigatório" Text="O campo Data de Nascimento é obrigatório!" 
						ForeColor="#FF3300">
					</asp:RequiredFieldValidator>

					<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_dataNasc"
						ValidationGroup="cadastro"
						Display="Dynamic" ErrorMessage="Data Errada" ForeColor="Red" Height="24px" 
						Operator="GreaterThan" Type="Date" ValueToCompare="01/01/1900">*
					</asp:CompareValidator>

				</td>
			</tr>
			<tr>
				<td style="text-align:right;">
					Cidade:
				</td>
				<td>
					<asp:TextBox ID="txt_cidade" runat="server"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cidade"
						ValidationGroup="cadastro" ErrorMessage="O campo cidade é obrigatório" Text="O campo cidade é obrigatório!" 
						ForeColor="#FF3300"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="text-align:right;">
					Estado:
				</td>
				<td>
					<asp:DropDownList ID="drop_estado" runat="server" DataTextField="Nome" DataValueField="Id">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td style="text-align:right;">
					Senha:
				</td>
				<td>
					<asp:TextBox ID="txt_senha" runat="server" TextMode="Password"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="txt_senha"
						ValidationGroup="cadastro" ErrorMessage="O campo senha é obrigatório" 
						Text="O campo senha é obrigatório!" 
						ForeColor="#FF3300"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="text-align:right;">
					Digite novamente a senha:
				</td>
				<td>
					<asp:TextBox ID="txt_senha2" runat="server" TextMode="Password"></asp:TextBox>				
					<asp:Label ID="lbl_senhas" runat="server" Text="As senhas estão diferentes" 
						Visible="false" ValidationGroup="cadastro"
						ForeColor="Red"></asp:Label>
				</td>
			</tr>
			<tr>
				<td></td>
				<td>
					<asp:Button ID="bto_enviar" runat="server" Text="Cadastrar" ValidationGroup="cadastro"
						OnClick="bto_enviar_Click" Enabled="False" />
				</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
	</asp:Panel>

	<asp:Panel ID="panel_agradecimento" Visible="false" runat="server">
		<div style="margin:0 auto;width:500px;height:500px;background-color:lightGray;padding:20px;">
			<div class="tituloADM">Obrigado!<br /><br />O seu cadastro está pronto,<br />faça o login no topo da página com o seu<br />
			usuário e senha, navegue pelas páginas de suas bandas preferidas se tornando fã,<br />
			comentando as notícias via scrap e<br />
			divulgando para todos os seus amigos.<br />através dos links de compartilhamento.</div>
		</div>	
	</asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderRight" runat="server">
&nbsp;
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderUp" runat="server"></asp:Content>
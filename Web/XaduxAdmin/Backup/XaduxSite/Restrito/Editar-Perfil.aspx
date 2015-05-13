<%@ Page Title="" Language="C#" MasterPageFile="~/Restrita.master" AutoEventWireup="true" CodeBehind="Editar-Perfil.aspx.cs" Inherits="XaduxSite.Restrito.Editar_Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	<asp:ValidationSummary ID="summary_cadastro" ValidationGroup="cadastro" runat="server" />
		<table>
			<tr>
				<td>
					Login:
				</td>
				<td>
					<asp:Label ID="lbl_login" runat="server" Text=""></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					E-mail:
				</td>
				<td>
					<asp:Label ID="lbl_email" runat="server" Text=""></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					Nome:
				</td>
				<td>
					<asp:TextBox ID="txt_nome" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="cadastro"
						ControlToValidate="txt_nome" ErrorMessage="O campo nome é obrigatório" Text="*"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					Sexo:
				</td>
				<td>
					<asp:DropDownList ID="drop_sexo" runat="server" DataTextField="Nome" DataValueField="Id">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
					Data de Nascimento:
				</td>
				<td>
					<asp:TextBox ID="txt_dataNasc" runat="server" ></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					Cidade:
				</td>
				<td>
					<asp:TextBox ID="txt_cidade" runat="server" AutoCompleteType="HomeCity"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					Estado:
				</td>
				<td>
					<asp:DropDownList ID="drop_estado" runat="server" DataTextField="Nome" DataValueField="Id">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
					Celular:
				</td>
				<td>
					<asp:TextBox ID="txt_celular" runat="server" AutoCompleteType="Cellular"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					Toco:
				</td>
				<td>
					<asp:CheckBoxList ID="chk_instrumentosMusicais" runat="server" DataValueField="Id" DataTextField="Nome">
					</asp:CheckBoxList>
				</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>
					Curto:
				</td>
				<td>
					<asp:CheckBoxList ID="chk_estilosMusicais" runat="server" DataValueField="Id" DataTextField="Nome">
					</asp:CheckBoxList>
				</td>
			</tr>
			<tr>
				<td>
					Descrição:
				</td>
				<td>
					<asp:TextBox ID="txt_descricao" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					Imagem:
				</td>
				<td>
					<asp:FileUpload ID="upd_foto" runat="server" /><br />
					<asp:Image ID="img_foto" runat="server" Visible="false" />
					<asp:ImageButton ID="bto_excluirFoto" AlternateText="Excluir Foto" 
						runat="server"  Visible="true" onclick="bto_excluirFoto_Click" 
                        ImageUrl="~/Imagens/iconeExcluir.gif" Width="16px"/>
				</td>
			</tr>
			<tr><td colspan="2">
                <asp:Label ID="lbl_msg" runat="server" ViewStateMode="Disabled" ForeColor="#FF3300"></asp:Label>
            </td></tr>
			<tr>
				<td colspan="2" class="tituloADM">
					Altere a sua senha de usuário:
				</td>
			</tr>
			<tr>
				<td>
					Senha:
				</td>
				<td>
					<asp:TextBox ID="txt_senha" runat="server" TextMode="Password" ></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					Digite novamente a senha:
				</td>
				<td>
					<asp:TextBox ID="txt_senha2" runat="server" TextMode="Password"></asp:TextBox>
					<asp:CompareValidator ID="CompareValidator1" ValidationGroup="cadastro" runat="server"
						ErrorMessage="As senhas estão diferentes" ControlToValidate="txt_senha2" ControlToCompare="txt_senha"></asp:CompareValidator>
				</td>
			</tr>
		</table>
	<asp:Button ID="bto_atualizar" runat="server" Text="Atualizar dados"  ValidationGroup="cadastro"
		onclick="bto_atualizar_Click" />
	<asp:Label ID="lbl_mensagem" ForeColor="#FF3300" runat="server" Text=""></asp:Label>
	</asp:Content>

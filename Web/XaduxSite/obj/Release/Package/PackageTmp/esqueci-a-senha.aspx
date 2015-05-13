<%@ Page Title="" Language="C#" MasterPageFile="~/Parent.Master" AutoEventWireup="true"
	CodeBehind="esqueci-a-senha.aspx.cs" Inherits="XaduxSite.esqueci_a_senha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server"><br /><br />	
	<div style="width:600px;margin:0 auto;margin-top:0px;height:300px;background-color:#ffdd55;padding-left:20px;padding-top:20px;padding-bottom:20px;"> 
		<div class="tituloADM" style="padding-top:70px;">Digite o seu e-mail de cadastro abaixo para receber a sua senha!</div><br /><br />
		<div>
			E-mail: <asp:TextBox ID="txt_email" runat="server" ValidationGroup="email" Width="270px"></asp:TextBox>
				<asp:RequiredFieldValidator 
					ControlToValidate="txt_email"
					ID="Required_email" runat="server" Text="*" ErrorMessage="O campo e-mail é necessário"
					ValidationGroup="email">
				</asp:RequiredFieldValidator>	
			<asp:Button ID="bto_enviarSenha" runat="server" Text="enviar" ValidationGroup="email"
			OnClick="bto_enviarSenha_Click" /><br /><br />
			<strong><asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label></strong>
		</div><br /><br />
	</div>
</asp:Content>

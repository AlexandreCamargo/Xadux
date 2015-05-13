<%@ Page Title="" Language="C#" MasterPageFile="~/Parent.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XaduxSite.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
	<asp:Login ID="login_acesso" runat="server" 
		OnAuthenticate="login_acesso_Authenticate" 
		FailureText="Login ou senha inválidos, digite novamente.">
		<LayoutTemplate>
			<div id="" style="width:600px;margin:0 auto;margin-top:70px;background-color:#ffdd55;padding-left:20px;padding-top:20px;padding-bottom:20px;"> 
				<span class="tituloADM">Seja bem vindo a área de login do Xadux.</span><p />
				<table cellpadding="1" cellspacing="0" border="0" style="border-collapse:collapse;">
					<tr>
						<td>
							<table cellpadding="0" border="0">
								<tr>
									<td align="right">
										<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">E-mail:</asp:Label>
									</td>
									<td>
										<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
										<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
											ControlToValidate="UserName" ErrorMessage="User Name is required." 
											ToolTip="User Name is required." ValidationGroup="login_acesso">*</asp:RequiredFieldValidator>
									</td>

									<td align="right">
										<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>
									</td>
									<td>
										<asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
										<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
											ControlToValidate="Password" ErrorMessage="Digite a senha" 
											ToolTip="Password is required." ValidationGroup="login_acesso">*</asp:RequiredFieldValidator>
									</td>

									<td style="color:Red;text-align:left;">
										&nbsp;</td>

									<td align="left">
										<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" 
											ValidationGroup="login_acesso" />
									</td>
								</tr>
								<tr>
									<td></td>
									<td colspan="3">
										<asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
									</td>
								</tr>
								<tr>
									<td>&nbsp;</td>
								</tr>
								<tr>
									<td>&nbsp;</td>
									<td colspan="3">
                                        <asp:HyperLink ID="lnk_esqueciASenha" runat="server" NavigateUrl="~/esqueci-a-senha.aspx">
                                            <u>Esqueceu sua senha?</u>
                                        </asp:HyperLink>
                                    </td>
								</tr>
								<%--<tr>
									<td colspan="2">Não é usuário ainda? Então <asp:HyperLink ID="link_cadastrar" runat="server" NavigateUrl="Cadastre-se.aspx">cadastre-se</asp:HyperLink>!</td>
								</tr>--%>
							</table>
						</td>
					</tr>
				</table>
			</div>

		<div id="" style="width:1000px;margin:0 auto;text-align:center;height:400px;">
			<div id="Div1" style="width:600px;margin:0 auto;text-align:left;margin-top:40px;font-size:large;background-color:#ffdd55;padding-left:20px;padding-top:20px;padding-bottom:20px;"> 
				<span class="tituloADM">Não é usuário ainda?</span><p />
				Para você se tornar fã de sua banda preferida, interagir comentando notícias, 
				enviando mensagens e baixando músicas é necessário estar cadastrado no Xadux, 
				para isso é muito fácil e rápido.<p />
				<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Cadastre-se.aspx"><u>Clique aqui e cadastre-se grátis!</u></asp:HyperLink>
			</div>

		</div>
		</LayoutTemplate>
	</asp:Login>
</asp:Content>
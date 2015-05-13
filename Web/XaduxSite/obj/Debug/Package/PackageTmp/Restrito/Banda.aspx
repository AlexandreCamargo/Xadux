<%@ Page Title="" Language="C#" MasterPageFile="~/Restrita.master" AutoEventWireup="true"
    CodeBehind="Banda.aspx.cs" Inherits="XaduxSite.Restrito.Banda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">
    <div class="tituloADM">
        Dados Cadastrais</div>
    <div>
        <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label><br />
        <table style="width: 570px">
            <tr>
                <td colspan="2" class="menuTopicos">
                    DADOS DA BANDA
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    Nome:
                </td>
                <td style="width: 400px">
                    <asp:TextBox ID="txt_nome" runat="server"></asp:TextBox>
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
                    Estilo Musical:
                </td>
                <td>
                    <asp:DropDownList ID="drop_estiloMusical" runat="server" DataTextField="Nome" DataValueField="Id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Tem Gravadora?
                </td>
                <td>
                    <asp:DropDownList ID="drop_gravadora" runat="server" DataTextField="Nome" DataValueField="Id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" class="menuTopicos">
                    INTERNET / REDES SOCIAIS
                </td>
            </tr>
            <tr>
                <td>
                    Site:
                </td>
                <td>
                    <asp:TextBox ID="txt_site" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Facebook:
                </td>
                <td>
                    <asp:TextBox ID="txt_facebook" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Twitter:
                </td>
                <td>
                    <asp:TextBox ID="txt_twitter" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" class="menuTopicos">
                    CONTATO
                </td>
            </tr>
            <tr>
                <td>
                    E-mail:
                </td>
                <td>
                    <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Cidade:
                </td>
                <td>
                    <asp:TextBox ID="txt_cidade" runat="server"></asp:TextBox>
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
                    Telefone:
                </td>
                <td>
                    <asp:TextBox ID="txt_telefone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:CheckBox ID="chkTermos" runat="server" />
                    Lí e concordo com os <a href="#" onclick="javascript: window.open('termosCadastroBanda.aspx', 'titulo', 'scrollbars=yes,resizable=yes,width=500,height=500,status=no,location=no,toolbar=no');">
                        <font color="green">termos para cadastro de banda.</font></a>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="bto_atualizar" runat="server" Text="Atualizar" OnClick="bto_atualizar_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both;">
    </div>
</asp:Content>

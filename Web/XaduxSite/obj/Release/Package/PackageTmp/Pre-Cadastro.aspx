<%@ Page Language="C#" AutoEventWireup="true" Theme="PreCadastro" CodeBehind="Pre-Cadastro.aspx.cs"
    ValidateRequest="false" Inherits="XaduxSite.Pre_Cadastro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%--<BGSOUND SRC="Basketcase.mp3" />--%>
<head id="Head1" runat="server">
    <script language="javascript" src="Scripts/JScript_other.js"></script>
</head>
<body>
    <div id="topContent">
        <a id="A1" runat="server" href="~/default.aspx">
            <img id="Img33" style="float: left;margin-left:150px;border:0px;" alt="" runat="server" src="~/imagens/logoXaduX.png" />
        </a>
        <div class="tituloBanner" style="float: left;margin-left:100px;" ></div>
    </div>
    <form id="formCadastro" runat="server">
    <div id="siteBlock">
        <div id="middleContent">
            <div id="divPassosCadastro">
                <asp:MultiView ID="multi_passos" runat="server" ActiveViewIndex="0">
                    <!-- Passo 1 -->
                    <asp:View runat="server" ID="view_dadosCadastro">
                        <div id="middleContentRight">
                            <asp:Image ID="imgBoxTop" runat="server" ImageUrl="~/Imagens/boxPasso1.png" /></div>
                        <div id="middleContentLeft">
                            <div id="middleContentTitulo">
                                CADASTRE A SUA BANDA, É GRÁTIS E RÁPIDO!</div>
                            <div class="titulo">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/etapa01.png" />
                            </div>
                            <table width="500px" border="0" cellpadding="2">
                                <tr>
                                    <td class="tb7">
                                        <asp:CheckBox ID="chk_termos" runat="server" AutoPostBack="True" OnCheckedChanged="chkTermos_CheckedChanged" />
                                        Li e concordo com os <a href="#" onclick="javascript: window.open('termosCadastro.aspx', 'titulo', 'scrollbars=yes,resizable=yes,width=700,height=500,status=no,location=no,toolbar=no');">
                                            <font color="green">termos de cadastro.</font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        Nome:<br />
                                        <asp:TextBox ID="txt_nome" runat="server" MaxLength="50" Width="500px"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_nome"
                                            ValidationGroup="Usuario" ErrorMessage="O campo nome é obrigatório" Text="O campo nome é obrigatório!"
                                            ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        Login:<br />
                                        <asp:TextBox ID="txt_login" runat="server" MaxLength="40" Width="500px"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_login"
                                            ValidationGroup="Usuario" ErrorMessage="O campo login é obrigatório" Text="O campo login é obrigatório!"
                                            ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        Data de Nascimento:<br />
                                        <asp:TextBox ID="txt_dataNasc" runat="server" MaxLength="10" Width="100px" onkeypress="formataData(this); return numerico(event);"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_dataNasc"
                                            ValidationGroup="Usuario" ErrorMessage="O campo data de nascimento é obrigatório"
                                            Text="O campo data de nascimento é obrigatório!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        E-mail:<br />
                                        <asp:TextBox ID="txt_email" runat="server" MaxLength="50" Width="300px"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_email"
                                            ValidationGroup="Usuario" ErrorMessage="O campo email é obrigatório" Text="O campo email é obrigatório!"
                                            ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; vertical-align: top;">
                                        <table class="style1" style="vertical-align: top; background-color: lightGray;">
                                            <tr style="vertical-align: top;">
                                                <td style="width: 250px;">
                                                    Instrumentos que toco:
                                                    <asp:CheckBoxList ID="chk_instrumentosMusicais" runat="server" DataTextField="Nome"
                                                        DataValueField="Id">
                                                    </asp:CheckBoxList>
                                                </td>
                                                <td style="width: 250px;">
                                                    Estilos musicais que curto:<asp:CheckBoxList ID="chk_estilosMusicais" runat="server"
                                                        DataTextField="Nome" DataValueField="Id">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        Sexo:<br />
                                        <asp:RadioButtonList ID="rdio_sexo" runat="server" DataTextField="Nome" DataValueField="Id"
                                            RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rdio_sexo"
                                            ValidationGroup="Usuario" ErrorMessage="Selecione o sexo" Text="Selecione o sexo!"
                                            ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        Imagem para o seu perfil:<br />
                                        <asp:FileUpload ID="upd_foto" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        Descreva sobre você:<br />
                                        <asp:TextBox ID="txt_descricao" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                        <br />
                                    </td>
                                    <td style="text-align: right;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        Senha:<br />
                                        <asp:TextBox ID="txt_senha" runat="server" MaxLength="50" Width="250px" TextMode="Password"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_senha"
                                            ErrorMessage="O campo senha é obrigatório" ForeColor="#FF3300" Text="O campo senha é obrigatório!."
                                            ValidationGroup="Usuario"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        Digite novamente a Senha:<br />
                                        <asp:TextBox ID="txt_senha2" runat="server" MaxLength="50" Width="250px" TextMode="Password"></asp:TextBox><br />
                                        <asp:Label ID="lbl_senhas" runat="server" Text="As senhas estão diferentes" Visible="false"
                                            ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_mensagem" runat="server" BorderColor="Yellow" 
                                            Font-Names="verdana" ForeColor="Red"></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                       

                                        <asp:Label ID="lblMsgTermos" runat="server" Text="Aceite os termos de cadastro no início do formulário para avançar"
                                            ForeColor="#FF3300"></asp:Label>
                                        <asp:ImageButton ID="btoPrimeiroPasso" runat="server" ImageUrl="~/Imagens/btoAvancar.png"
                                            OnClick="bto_primeiroPasso_Click" ValidationGroup="Usuario" Enabled="False" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br style="clear: both;" />
                    </asp:View>
                    <!-- Passo 2 -->
                    <asp:View runat="server" ID="view_banda">
                        <div id="middleContentRight">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagens/boxPasso2.png" /></div>
                        <div id="middleContentLeft">
                            <div id="middleContentTitulo">
                                CADASTRE A SUA BANDA, É GRÁTIS E RÁPIDO!</div>
                            <div class="titulo">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagens/etapa02.png" />
                            </div>
                            <table width="500px" border="0" bgcolor="" cellpadding="2">
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Nome da Banda:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txt_nomeBanda" runat="server" Width="300px" MaxLength="50"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_nomeBanda"
                                            ValidationGroup="Banda" ErrorMessage="O campo nome da banda é obrigatório" Text="O campo nome da banda é obrigatório!"
                                            ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        E-mail:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txt_emailBanda" Width="300px" MaxLength="50" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Site:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txt_siteBanda" runat="server" Width="300px" MaxLength="40"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Estilo Musical:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="drop_estiloMusical" runat="server" Height="19px" Width="107px"
                                            DataTextField="Nome" DataValueField="Id">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
								<tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Tem Gravadora?
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="drop_gravadora" runat="server" Height="19px" Width="107px"
                                            DataTextField="Nome" DataValueField="Id">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Facebook:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txt_facebookBanda" runat="server" Width="300px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Twitter:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txt_twitterBanda" runat="server" Width="300px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Cidade:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txt_cidadeBanda" runat="server" Width="300px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Estado:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="drop_estado" runat="server" DataTextField="Nome" DataValueField="Id">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="O campo estado é obrigatório."
                                            ValidationGroup="Banda" ForeColor="Red" Text="Campo obrigatório" ControlToValidate="drop_estado"
                                            ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Imagem:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:FileUpload ID="upd_fotoBanda" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: left; color: red">
                                        O tamanho máximo da imagem é de 1MB.
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txtFormRight" style="width: 50">
                                        Descrição:
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txt_descricaoBanda" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:ImageButton ID="btoSegundoPasso" runat="server" OnClick="bto_segundoPasso_Click"
                                            ImageUrl="~/Imagens/btoAvancar.png" ValidationGroup="Banda" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br style="clear: both;" />
                    </asp:View>
                    <!-- Passo 3 -->
                    <asp:View runat="server" ID="view_dadosBanda">
                        <div id="middleContentRight">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagens/boxPasso3.png" />
                        </div>
                        <div id="middleContentLeft">
                            <div id="middleContentTitulo">
                                CADASTRE A SUA BANDA, É GRÁTIS E RÁPIDO!</div>
                            <div class="titulo">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagens/etapa03.png" />
                            </div>
                            <asp:Button ID="bto_novaMusica" runat="server" Text="+ Adicionar Nova Música" OnClick="bto_novaMusica_Click" />
                            <div id="div_musica" runat="server" visible="false">
                                Nome:
                                <asp:TextBox ID="txt_nomeMusica" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txt_nomeMusica" ID="RequiredFieldValidator1"
                                    runat="server" ErrorMessage="RequiredFieldValidator" Text="*"></asp:RequiredFieldValidator>
                                <asp:FileUpload ID="upd_musica" runat="server" />
                                <asp:Button ID="bto_inserirMusica" runat="server" Text="Inserir Música" OnClick="bto_inserirMusica_Click" />
                            </div>
                            <br />
                            <br />
                            <asp:Repeater ID="rept_musicas" runat="server" OnItemCommand="rept_musicas_ItemCommand">
                                <ItemTemplate>
                                    <div>
                                        <asp:HyperLink ID="link_musica" runat="server" NavigateUrl='<%#Eval("Caminho") %>'><%#Eval("Nome") %></asp:HyperLink>
                                        |
                                        <asp:LinkButton ID="lnk_excluir" runat="server" CommandName="excluir" CommandArgument='<%#Eval("Id") %>'
                                            OnClientClick="confirm('Tem certeza?');">excluir</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <script type="text/javascript" src="http://mediaplayer.yahoo.com/js"></script>
                            <br />
                            <br />
                            <asp:Button ID="bto_novaFoto" runat="server" OnClick="bto_novaFoto_Click" Text="+ Adicionar nova foto" />
                            <div id="div_foto" runat="server" visible="false">
                                Nome:
                                <asp:TextBox ID="txt_nomeFoto" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txt_nomeFoto" ID="RequiredFieldValidator2"
                                    runat="server" ErrorMessage="RequiredFieldValidator" Text="*"></asp:RequiredFieldValidator>
                                <asp:Image ID="img_foto" Width="150px" runat="server" />
                                <asp:FileUpload ID="upd_fotoParaBanda" runat="server" />
                                <asp:Button ID="bto_atualizarFoto" runat="server" Text="Atualizar" OnClick="bto_atualizarFoto_Click" />
                            </div>
                            <br />
                            <br />
                            <asp:Repeater ID="rept_fotos" runat="server" OnItemCommand="rept_fotos_ItemCommand">
                                <ItemTemplate>
                                    <div>
                                        <asp:Image ID="img_foto" ImageUrl='<%#Eval("Caminho") %>' Width="70px" runat="server" />
                                        |
                                        <asp:LinkButton ID="lnk_excluir" runat="server" CommandName="excluir" CommandArgument='<%#Eval("Id") %>'
                                            OnClientClick="confirm('Tem certeza?');">excluir</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <br />
                            <br />
                            <asp:Button ID="bto_novoVideo" runat="server" OnClick="bto_novoVideo_Click" Text="+ Adicionar novo video" />
                            <br />
                            Para adicionar um vídeo é muito fácil:<br />
                            www.vimeo.com, clique em "Embed", copie e cole o código no campo URL abaixo.<br />
                            ww.youtube.com, clique em compartilhar / Incorporar, copie e cole o código no campo URL abaixo.<br /><br />
                            <div id="div_video" runat="server" visible="false">
                                Nome:
                                <asp:TextBox ID="txt_nomeVideo" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txt_nomeVideo" ID="RequiredFieldValidator3"
                                    runat="server" ErrorMessage="RequiredFieldValidator" Text="*"></asp:RequiredFieldValidator>
                                URL:
                                <asp:TextBox ID="txt_urlVideo" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txt_urlVideo" ID="RequiredFieldValidator4"
                                    runat="server" ErrorMessage="RequiredFieldValidator" Text="*"></asp:RequiredFieldValidator>
                                <asp:Button ID="bto_preview" runat="server" Text="Preview" OnClick="bto_preview_Click" />
                                <asp:Literal ID="lit_video" runat="server"></asp:Literal>
                                <asp:Button ID="bto_atualizarVideo" runat="server" Text="Atualizar" OnClick="bto_atualizarVideo_Click" />
                            </div>
                            <asp:Repeater ID="rept_videos" runat="server" OnItemCommand="rept_videos_ItemCommand">
                                <ItemTemplate>
                                    <div>
                                        <asp:Label ID="lbl_nome" runat="server" Font-Bold="true" Text='<%#Eval("Nome") %>'></asp:Label>
                                        <br />
                                        <%#Eval("URL").ToString().Replace("<", "&lt;").Replace(">", "&gt;")%>
                                        <asp:LinkButton ID="lnk_excluir" runat="server" CommandName="excluir" CommandArgument='<%#Eval("Id") %>'
                                            OnClientClick="confirm('Tem certeza?');">excluir</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <br />
                            <br />
                            <asp:ImageButton ID="btoTerceiroPasso" runat="server" OnClick="bto_terceiroPasso_Click"
                                ImageUrl="~/Imagens/btoAvancar.png" />
                        </div>
                        <br style="clear: both;" />
                    </asp:View>
                    <!-- Passo 4 -->
                    <asp:View runat="server" ID="view_divulgar">
                        <div id="middleContentRight">
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Imagens/boxPasso4.png" /></div>
                        <div id="middleContentLeft">
                            <div id="middleContentTitulo">
                                SUA BANDA ESTÁ PRONTA PARA O SUCESSO!</div>
                            <div class="titulo">
                                <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagens/etapa04.png" />
                            </div>
                            <div class="titulo" style="text-align: left;">
                                Sua página está pronta, clique para visualizá-la:
                                <asp:HyperLink ID="link_paginaBanda" Target="_blank" runat="server">&nbsp;</asp:HyperLink>
                                <br />
                                <br />
                            </div>
                            <!-- AddThis Button BEGIN -->
                            <div style="text-align: left;">
                                <strong>Divulgue para seus colegas através dos ícones das redes sociais abaixo:</strong></div>
                            <br />
                            <div runat="server" id="div_addThis" class="addthis_toolbox addthis_default_style addthis_32x32_style"
                                style="width: 600px; margin: 0 auto; text-align: left;">
                                <a class="addthis_button_preferred_1"></a><a class="addthis_button_preferred_2">
                                </a><a class="addthis_button_preferred_3"></a><a class="addthis_button_preferred_4">
                                </a><a class="addthis_button_compact"></a><a class="addthis_counter addthis_bubble_style">
                                </a>
                            </div>
                            <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4df52f69673ee0ab"></script>
                            <!-- AddThis Button END -->
                            <br />
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
    </form>
    <div id="bottonContent">
        © 2011 xadux.com.br · Cadastre-se GRÁTIS! · Aviso Legal · Privacidade · Fale com
        o Xadux.</div>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Parent.Master" AutoEventWireup="true" CodeBehind="Busca.aspx.cs" Inherits="XaduxSite.Busca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">

	<div id="contentMiddle">
		<%--<div style="width:735px;margin:0 auto;margin-top:0px;height:20px;background-color:#ffdd55;padding-left:20px;padding-top:20px;padding-bottom:20px;"> 
			Buscar: 
			<asp:TextBox ID="txt_busca" runat="server"></asp:TextBox>
			<asp:Button ID="bto_busca" runat="server" Text="Consultar" 
				onclick="bto_busca_Click" />
		</div>--%>
		<br />
		<span class="tituloADM">
			<asp:Label ID="lbl_music" runat="server" Text="MUSICAS:" Visible="false"></asp:Label>
		</span><br />
		<asp:Repeater ID="rept_musicas" runat="server">
			<ItemTemplate>
				<div style="background-color:lightGray;padding:3px;width:750px">
				<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#Eval("Banda.CaminhoImagemThumbnail") %>' Width="50px" Height="50px" />
					<asp:LinkButton ID="LinkButton1" runat="server" CommandName="banda"  CommandArgument='<%#Eval("Banda.Nome") %>' OnClick="ButtonCommand_Click">
						<strong><%#Eval("Nome") %></strong>
					</asp:LinkButton>
					<%--<asp:Label ID="lbl_nomeMusica" runat="server" Text='<%#Eval("Nome") %>'></asp:Label>--%>
					-
					<asp:LinkButton ID="link_banda" runat="server" CommandName="banda" CommandArgument='<%#Eval("Banda.Nome") %>' OnClick="ButtonCommand_Click">
						<%#Eval("Banda.Nome") %><br />
					</asp:LinkButton>
				</div><br />
			</ItemTemplate>
		</asp:Repeater>
		<br />
		<span class="tituloADM">
			<asp:Label ID="lbl_bandas" runat="server" Text="BANDAS:" Visible="false"></asp:Label>
		</span><br />
		
		<asp:Repeater ID="rept_bandas" runat="server">
			<ItemTemplate>
				<div style="background-color:lightGray;padding:3px;width:750px;">
				<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#Eval("CaminhoImagemThumbnail") %>' Width="50px" Height="50px" />
					<asp:LinkButton ID="link_banda" runat="server" CommandName="banda"  CommandArgument='<%#Eval("Nome") %>' OnClick="ButtonCommand_Click">
						<strong><%#Eval("Nome") %></strong>
					</asp:LinkButton>
					-
					<asp:LinkButton ID="link_estiloMusical" runat="server" CommandName="estilomusical"  CommandArgument='<%#Eval("EstiloMusical.Nome") %>' OnClick="ButtonCommand_Click">
						<%#Eval("EstiloMusical.Nome") %><br />
					</asp:LinkButton>
				</div><br />
			</ItemTemplate>
		</asp:Repeater>
	</div>
	<div id="contentRight">
		<div id="divPublicidade">
			<!--<div class="menuTopicos">PUBLICIDADE</div><p />-->
				<script type="text/javascript"><!--
					google_ad_client = "pub-2382770655448354";
					/* 120x600, criado 05/09/11 */
					google_ad_slot = "6178494029";
					google_ad_width = 120;
					google_ad_height = 600;
				//-->
				</script>		
				<script type="text/javascript"
				src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
				</script>					
			<p />
		</div>
	</div>

</asp:Content>
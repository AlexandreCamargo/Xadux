<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventosList.ascx.cs"
	Inherits="XaduxSite.WebUserControls.EventosList" %>
<div>
	<asp:Repeater ID="rept_eventos" runat="server">
		<ItemTemplate>
			<div class="eventoListItem">
				<div class="firstColumn">
					<asp:Label ID="lbl_dataEvento" runat="server" Text='<%#Eval("Data", "{0:dd/MM/yyyy}") %>'
						Font-Bold="true"></asp:Label><br />
					<asp:Label ID="lbl_horarioEvento" runat="server" Text='<%#Bind("Horario") %>'></asp:Label><br />
					<asp:Label ID="lbl_precoEvento" runat="server" Text='<%#Eval("Preco", "{0:c}") %>'></asp:Label>
				</div>
				<div class="SecondColumn">
					<asp:Label ID="lbl_nomeBanda" runat="server" Text='<%#Bind("Banda.Nome") %>' Font-Bold="true"></asp:Label><br />
					<asp:Label ID="lbl_nomeEvento" runat="server" Text='<%#Bind("Nome") %>'></asp:Label><br />
					<asp:Label ID="lbl_localEvento" runat="server" Text='<%#Bind("Empresa.Nome") %>'></asp:Label>
					&nbsp;&nbsp;&nbsp;
					<asp:Label ID="lbl_cidadeEvento" runat="server" Text='<%#Bind("Empresa.Cidade") %>'></asp:Label>
					&nbsp;&nbsp;&nbsp;
					<asp:Label ID="lbl_estadoEvento" runat="server" Text='<%#Bind("Empresa.Estado.Sigla") %>'></asp:Label>
				</div>
				<div style="clear: both;">
				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>

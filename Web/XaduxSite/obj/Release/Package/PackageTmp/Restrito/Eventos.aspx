<%@ Page Title="" Language="C#" MasterPageFile="~/Restrita.master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="XaduxSite.Restrito.Eventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMiddle" runat="server">

	<div class="tituloADM">Eventos e Agenda de Shows</div>
		<br />
		<div style="border-style:solid; border-width:thin;color:darkgreen;padding:5px;">
			<strong>Os eventos que você cadastrar nesta seção serão adicionados à agenda do seu site 
			e poderão ser divulgados no Xadux, mediante aprovação do moderador.</strong><br /><br />
			1. Atenção às informações inseridas, elas são de sua inteira responsabilidade;<br /><br />
			2. Atenção ao preencher o nome das bandas. Escreva corretamente;<br /><br />
			3. Depois de cadastrar o evento, não se esqueça de conferir todos os dados.
	</div><br />

	<asp:Button ID="link_novaEvento" runat="server" OnClick="link_novaEvento_Click" Text="+ Adicionar novo evento" />
	<div id="div_evento" runat="server" visible="false">
		<asp:HiddenField ID="hid_eventoId" runat="server" />
		<table width="550px;" border="0">
			<tr>
				<td width="120px">Nome:</td>
				<td width="400px">
					<asp:TextBox ID="txt_nomeEvento" runat="server" Width="390px"></asp:TextBox>
					<asp:RequiredFieldValidator ControlToValidate="txt_nomeEvento" ValidationGroup="evento"
					ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="*"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td width="120px">Data:</td>
				<td width="400px">
					<asp:TextBox ID="txt_dataEvento" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ControlToValidate="txt_dataEvento" ValidationGroup="evento"
					ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Text="*"></asp:RequiredFieldValidator>
				</td>
			</tr>

			<tr>
				<td width="120px">Horário:</td>
				<td width="400px">
					<asp:TextBox ID="txt_horario" runat="server"></asp:TextBox>
				</td>
			</tr>

			<tr>
				<td width="120px">Casa de Show</td>
				<td width="400px">
					<asp:DropDownList ID="drop_casaShow" runat="server"  DataTextField="Nome" DataValueField="Id"></asp:DropDownList>
				</td>
			</tr>

			<tr>
				<td width="120px">Descrição:</td>
				<td width="400px">
					<asp:TextBox ID="txt_descricao" TextMode="MultiLine" runat="server" 
						Width="334px"></asp:TextBox>
				</td>
			</tr>

			<tr>
				<td width="120px">Preço</td>
				<td width="400px">
					<asp:TextBox ID="txt_preco" runat="server"></asp:TextBox>
				</td>
			</tr>

			<tr>
				<td width="120px">Site:</td>
				<td width="400px">
					<asp:TextBox ID="txt_siteEvento" runat="server"></asp:TextBox>
				</td>
			</tr>

			<tr>
				<td width="120px"></td>
				<td width="400px">
							<asp:Button ID="bto_atualizar" runat="server" Text="Atualizar" OnClick="bto_atualizar_Click" ValidationGroup="evento" />
				</td>
			</tr>

		</table>
	</div>
	<br />
	<br />
	<asp:Repeater ID="rept_eventos" runat="server" OnItemCommand="rept_eventos_ItemCommand">
		<ItemTemplate>
			<div>
				<asp:Label ID="lbl_data" runat="server" Font-Bold="true" Text='<%#Eval("Data", "{0:d}") %>'></asp:Label> - 
				<asp:Label ID="lbl_nome" runat="server" Font-Bold="true" Text='<%#Eval("Nome") %>'></asp:Label>
				<br />
				<asp:LinkButton ID="lnk_editar" runat="server" CommandName="editar" CommandArgument='<%#Eval("Id") %>'>editar</asp:LinkButton>
				|
				<asp:LinkButton ID="lnk_excluir" runat="server" CommandName="excluir" CommandArgument='<%#Eval("Id") %>'
					OnClientClick="confirm('Tem certeza?');">excluir</asp:LinkButton>
			</div>
		</ItemTemplate>
	</asp:Repeater>

</asp:Content>
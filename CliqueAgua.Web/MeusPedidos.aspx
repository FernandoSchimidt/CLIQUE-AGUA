<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Theme="padrao2" StylesheetTheme="padrao2" CodeBehind="MeusPedidos.aspx.cs" Inherits="CliqueAgua.Web.MeusPedidos" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <div class="corpo">
        <asp:Label ID="d" runat="server" Text=">> Pedidos" CssClass="corpotituloh2"></asp:Label><br />

        <asp:Button ID="btnConsultar" runat="server" Text="Atualizar" OnClick="btnConsultar_Click" CssClass="btn1" />
        <asp:Button ID="btnNovoPedido" OnClick="btnNovoPedido_Click" runat="server" Text="Novo Pedido" CssClass="btn1" />

        <asp:GridView ID="GridView1" DataKeyNames="Id" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="782px" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnRowEditing="GridView1_RowEditing" CssClass="t4">
            <AlternatingRowStyle BackColor="Black" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Id" DataFormatString="{0:n0}" HeaderText="Pedido" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Data" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data"  ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DataEntrega" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data Entrega" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" CssClass="t4" />
                </asp:BoundField>
                <asp:BoundField DataField="DataCancelamento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data Cancelamento" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DataEncerramento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data Encerramento" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Total" DataFormatString="{0:c2}" HeaderText="Total" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="true" EditText="Alterar Pedido">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

    </div>
</asp:Content>

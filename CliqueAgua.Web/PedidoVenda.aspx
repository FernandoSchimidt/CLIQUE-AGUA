<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Theme="padrao2" StylesheetTheme="padrao2" CodeBehind="PedidoVenda.aspx.cs" Inherits="CliqueAgua.Web.PedidoVenda" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <div class="corpo">
    <h1>
        <asp:Label ID="lblPedido" runat="server" Text="Pedido Venda"></asp:Label>
    </h1>
        <asp:Label ID="Label1" runat="server" Text="Produto: "></asp:Label>
        <asp:DropDownList ID="cmbProduto" runat="server" OnSelectedIndexChanged="cmbProduto_SelectedIndexChanged" Width="250px" AutoPostBack="True" DataTextField="Nome" DataValueField="Id" CssClass="campo3">
        </asp:DropDownList>

        <asp:Label ID="lblProdutoPreco" runat="server" Text="Preço: "></asp:Label>
        <asp:TextBox ID="txtPreco" runat="server" CssClass="campo2"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" Text="Quantidade: "></asp:Label>
        <asp:TextBox ID="txtQuantidade" runat="server" CssClass="campo2"></asp:TextBox>

    <div>
        <asp:Button ID="btnIncluir" OnClick="btnIncluir_Click" runat="server" Text="Incluir Produto" CssClass="btn1"/>
        <asp:Button ID="btnEncerrar" OnClick="btnEncerrar_Click" runat="server" Text="Finalizar Pedido" CssClass="btn1"/>
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" Text="Cancelar Pedido" CssClass="btn1"/>
        <asp:Button ID="btnVoltar" OnClick="btnVoltar_Click" runat="server" Text="Voltar" CssClass="btn1"/>
        <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
    </div>

    <div>
        <asp:GridView ID="GridView1" DataKeyNames="Id" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="782px" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnRowDeleting="GridView1_RowDeleting">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="#" Visible="False">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Produto_Codigo" DataFormatString="{0:n0}" HeaderText="Codigo" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Produto_Nome" HeaderText="Nome" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Preco" DataFormatString="{0:c2}"  HeaderText="Preço" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Quantidade" DataFormatString="{0:n0}" HeaderText="Quantidade" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Total" DataFormatString="{0:c2}" HeaderText="Total" ItemStyle-CssClass="t4" HeaderStyle-CssClass="t4" FooterStyle-CssClass="t4">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:CommandField ShowDeleteButton="true" DeleteText="Excluir Produto">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
    </div>
</asp:Content>

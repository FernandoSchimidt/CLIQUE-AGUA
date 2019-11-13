<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Theme="padrao2" StylesheetTheme="padrao2" CodeBehind="MinhaConta.aspx.cs" Inherits="CliqueAgua.Web.MinhaConta" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <h2 class="corpotitulo">Minha Conta</h2>
    <div class="corpo2">

            <p>
                <asp:Label ID="Label1" runat="server" Text="Nome: " CssClass="corpotitulo2"></asp:Label><br />
                <asp:TextBox ID="txtNome" runat="server" CssClass="campo1"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="Label2" runat="server" Text="Email: " CssClass="corpotitulo2"></asp:Label><br />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="campo1"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="Label3" runat="server" Text="Senha: " CssClass="corpotitulo2"></asp:Label><br />
                <asp:TextBox ID="txtSenha1" TextMode="Password" runat="server" CssClass="campo1"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Confirmar Senha: " CssClass="corpotitulo2"></asp:Label><br />
                <asp:TextBox ID="txtSenha2" TextMode="Password" runat="server" CssClass="campo1"></asp:TextBox>
            </p>



        <div class="bottom">
            <asp:Label ID="lblMensagem" ForeColor="Red" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnOK" runat="server" Text="Atualizar" OnClick="btnOK_Click" CssClass="btn1" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn1" />
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" Theme="padrao" StylesheetTheme="padrao" CodeBehind="Login.aspx.cs" Inherits="CliqueAgua.Web.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="box">
        <asp:Label ID="a" runat="server" Text="Login" CssClass="t1"></asp:Label><br />
        <asp:Label ID="Label1" runat="server" Text="Email: " CssClass="t2"></asp:Label>
        <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="campo1">E-mail</asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Senha: " CssClass="t2"></asp:Label>
        <asp:TextBox ID="txtSenha" TextMode="Password" runat="server" CssClass="campo1" Text="Senha"></asp:TextBox>
        <!--<asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label> -->
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn1" />
        <asp:HyperLink ID="lnkSenha" NavigateUrl="~/EsqueciMinhaSenha.aspx" runat="server" CssClass="t2">Esqueci Minha Senha</asp:HyperLink>
        <asp:HyperLink ID="lnkRegistro" NavigateUrl="~/RegistrarUsuario.aspx" runat="server" CssClass="t2">Registrar Usuario</asp:HyperLink>
    </div>
</asp:Content>


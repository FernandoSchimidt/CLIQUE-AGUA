<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" Theme="padrao" StylesheetTheme="padrao" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="CliqueAgua.Web.RegistrarUsuario" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="box">
        <asp:Label ID="b" runat="server" Text="Registro de Usuário" CssClass="t1"></asp:Label>
        <!-- <asp:Label ID="Label1" runat="server" Text="Email: "></asp:Label> -->
        <asp:TextBox ID="txtEMail" TextMode="Email" runat="server" Text="E-mail" CssClass="campo1"></asp:TextBox>
        <!-- <asp:Label ID="Label2" runat="server" Text="Nome: "></asp:Label> -->
        <asp:TextBox ID="txtNome" runat="server" Text="Nome" CssClass="campo1"></asp:TextBox>
        <!-- <asp:Label ID="Label4" runat="server" Text="Senha: "></asp:Label> -->
        <asp:TextBox ID="txtSenha1" TextMode="Password" runat="server" Text="Senha" CssClass="campo1"></asp:TextBox>
        <!-- <asp:Label ID="Label3" runat="server" Text="Confirme a Senha: "></asp:Label> -->
        <asp:TextBox ID="txtSenha2" TextMode="Password" runat="server" Text="Confirme a senha" CssClass="campo1"></asp:TextBox>
        <!-- <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label> -->
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="btn1"/>
        <asp:Button ID="btnRegistrar0" runat="server" Text="Voltar" OnClick="btnRegistrar0_Click"  CssClass="btn1"/>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" Theme="padrao" StylesheetTheme="padrao" CodeBehind="EsqueciMinhaSenha.aspx.cs" Inherits="CliqueAgua.Web.EsqueciMinhaSenha" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="box">
        <asp:Label ID="c" runat="server" Text="Recuperação de Senha" CssClass="t1"></asp:Label>
        <!-- <asp:Label ID="Label1" runat="server" Text="Informe seu Email: "></asp:Label> -->
        <asp:TextBox ID="txtEMail" TextMode="Email" runat="server" CssClass="campo1" text="E-mail"></asp:TextBox>
        <asp:Button ID="btnEnviar" runat="server" Text="Recuperar Senha" OnClick="btnEnviar_Click" CssClass="btn1"/>
        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CssClass="btn1"/>
    </div>
</asp:Content>

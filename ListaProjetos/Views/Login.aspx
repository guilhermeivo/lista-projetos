<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ListaProjetos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container forms-page">
        <div class="contentWrapper">
            <h1>Login </h1>
            <p>Entre e se diverta!</p>
            <div class="column">
                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" placeholder="Email"></asp:TextBox>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Senha"></asp:TextBox>
            </div>
            
            <p class="description">Vocé não tem <asp:HyperLink ID="inkCadastro" runat="server" NavigateUrl="~/Views/Register.aspx">Cadastro</asp:HyperLink>?</p>
            
            <asp:Button ID="btnLogin" runat="server" Text="Concluir cadastro" OnClick="btnLogin_Click" />
        </div>
    </div>
</asp:Content>

<%@ Page Title="Login" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ListaProjetos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container">
        <div class="contentWrapper">
            <h1>Login </h1>
            <p>Entre e se diverta!</p>
            <div class="column">
                <asp:TextBox ID="email" TextMode="Email" runat="server" placeholder="Email"></asp:TextBox>
                <asp:TextBox ID="password" TextMode="Password" runat="server" placeholder="Senha"></asp:TextBox>
            </div>
            
            <p class="description">Vocé não tem <asp:HyperLink ID="inkCadastro" runat="server" NavigateUrl="~/Pages/Register.aspx">Cadastro</asp:HyperLink>?</p>
            
            <asp:Button ID="btnLogin" runat="server" Text="Concluir cadastro" />
        </div>
    </div>
</asp:Content>

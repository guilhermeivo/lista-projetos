<%@ Page Title="Register" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ListaProjetos.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container">
        <div class="contentWrapper">
            <h1>Cadastro </h1>
            <p>Preencha os dados abaixo para começar</p>
            <div class="column">
                <asp:TextBox ID="txtNome" runat="server" placeholder="Nome"></asp:TextBox>
                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" placeholder="Email"></asp:TextBox>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Senha"></asp:TextBox>
            </div>

            <p class="chb">
                <asp:CheckBox ID="chbConfirm" runat="server" />
                <asp:Label ID="lblConfirm" AssociatedControlID="chbConfirm" runat="server" Text="Você confirma os termos de uso?"></asp:Label>
            </p>
            
            <asp:Button ID="btnLogin" runat="server" Text="Concluir cadastro" />
        </div>
    </div>
</asp:Content>

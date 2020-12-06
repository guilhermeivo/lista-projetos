<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilUser.aspx.cs" Inherits="ListaProjetos.Views.PerfilUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container forms-page">        
        <div class="contentWrapper">
            <h1>Seu perfil</h1>
            <p>Atualize os dados do seu perfil!</p>
            <div class="column">
                <asp:TextBox ID="txtNome" runat="server" placeholder="Nome"></asp:TextBox>
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" placeholder="Email"></asp:TextBox>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Senha"></asp:TextBox>
                <asp:TextBox ID="txtConfirmPassowrd" TextMode="Password" runat="server" placeholder="Confirmar Senha"></asp:TextBox>
                <asp:TextBox ID="txtWebsite" runat="server" placeholder="Website"></asp:TextBox>
                <asp:TextBox ID="txtCidade" runat="server" placeholder="Cidade"></asp:TextBox>
            </div>           
            
            <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar Registro" CssClass="primary-button" OnClick="btnAtualizar_Click" />
            <asp:Button ID="btnSair" runat="server" Text="Sair" CssClass="secondary-button" OnClick="btnSair_Click" />
        </div>
    </div>
</asp:Content>

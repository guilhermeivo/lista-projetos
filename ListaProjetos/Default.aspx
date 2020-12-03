<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ListaProjetos.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container home-page">
        <asp:Image ID="Image1" runat="server"  ImageUrl="~/Content/undraw_task_list_6x9d.svg" />

        <h1>A melhor plataforma para organizar seus projetos!</h1>
        <p>Para começar a organizar seus projetos crie uma conta, e veja tudo que temos para oferecer.</p>
        <asp:HyperLink ID="hlStart" runat="server" CssClass="btn btn-primary" NavigateUrl="~/Views/Register.aspx">Começar Já!</asp:HyperLink>
    </div>
</asp:Content>

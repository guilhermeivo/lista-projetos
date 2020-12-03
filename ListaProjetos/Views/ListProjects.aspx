<%@ Page Title="Lista de Projetos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListProjects.aspx.cs" Inherits="ListaProjetos.ListProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container-projects">
        <div class="sidebar-menu">
            <div class="photoPerfil"></div>
            <h1>Nome</h1>
            <p>Username</p>
            <p><span class="material-icons">person</span><span class="bold">7</span> following</p>

            <p>LinkWebsite</p>
            <p>Localization</p>

        </div>
        <div class="projects-list">
            <h1>Projetos</h1>

            <div class="box-cards">
                <div class="cards">
                    <h3>Title</h3>
                    <p>Description</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

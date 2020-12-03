<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateProjects.aspx.cs" Inherits="ListaProjetos.Views.CreateProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container forms-page">
        <div class="contentWrapper">
            <h1>Projetos </h1>
            <p>.</p>
            <div class="column">
                <asp:TextBox ID="txtTitulo" runat="server" placeholder="Titulo"></asp:TextBox>
                <asp:TextBox ID="txtDescricao" runat="server" placeholder="Descrição"></asp:TextBox>
            </div>
            <div class="column">
                <asp:TextBox ID="txtTags" runat="server" placeholder="Tag"></asp:TextBox>
                <asp:DropDownList ID="ddlStatus" runat="server">
                </asp:DropDownList>
            </div>
            
            <asp:Button ID="btnProjeto" runat="server" Text="Criar Projeto" OnClick="btnProjeto_Click"/>

            <div class="message">
                <asp:Literal ID="ltMessage" runat="server"/>
            </div>
        </div>
    </div>
</asp:Content>

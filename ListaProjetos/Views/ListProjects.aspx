<%@ Page Title="Lista de Projetos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListProjects.aspx.cs" Inherits="ListaProjetos.ListProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container projects-page">
        <div class="header-title">
            <h1>Projetos</h1>
            <asp:HyperLink ID="hpCreateProject" CssClass="btn btn-primary" runat="server" NavigateUrl="~/Views/CreateProjects.aspx" >Criar projeto!</asp:HyperLink>
        </div>
        

        <div runat="server" class="box" id="boxProjects">
            <asp:Repeater ID="rptProjetos" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <div class="title">
                            <span class="material-icons">
                            web_asset
                            </span>
                            <h3>
                                <%# DataBinder.Eval(Container.DataItem, "titulo") %>
                            </h3>
                        </div>
                        <p class="description">
                            <%# DataBinder.Eval(Container.DataItem, "descricao") %>
                        </p>
                        <div>
                            <div class="tags">
                                <%# DataBinder.Eval(Container.DataItem, "tag") %>
                            </div>
                        </div>                        
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

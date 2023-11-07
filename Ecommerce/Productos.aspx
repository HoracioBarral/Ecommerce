<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Ecommerce.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Productos</h1>
    <div>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                 <div class="card-group" style="max-width: 300px;">
    <div class="card">
        <div id="carousel<%# Container.ItemIndex %>" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <%# RenderImages(Container.DataItem) %>
            </div>
            <a class="carousel-control-prev" href="#carousel<%# Container.ItemIndex %>" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carousel<%# Container.ItemIndex %>" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
        <div class="card-body">
            <h5 class="card-title"><%# Eval("NombreArticulo") %></h5>
            <p class="card-text"><%# Eval("Descripcion") %></p>
            <p class="card-text"><%# Eval("Categoria") %></p>
            <p class="card-text"><%# Eval("Marca") %></p>
        </div>
    </div>
</div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

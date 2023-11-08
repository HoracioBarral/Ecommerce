<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Ecommerce.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Productos</h1>
    <div>
        <div class="alertita" id="alertita" style="display: flex; justify-content: flex-start;">
        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
</div>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="card-group" style="max-width: 300px;">
            <div class="card">
                <div class="card-body">
                    <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# GetImageUrl(Container.DataItem) %>' CssClass="img-fluid rounded-start" AlternateText="Imagen del artículo" />
                    <h5 class="card-title"><%# Eval("NombreArticulo") %></h5>
                    <p class="card-text"><%# Eval("Descripcion") %></p>
                    <p class="card-text"><%# Eval("Categoria") %></p>
                    <p class="card-text"><%# Eval("Marca") %></p>
                    <p> <a class="nav-link" style="text-decoration: none; color: darkblue; transition: transform 0.3s" " href="DetalleArticulo.aspx?id=<%# Eval("idArticulo") %>">Detalles</a></p>
                    <asp:Button ID="btnCarrito" runat="server" Text="Agregar al carrito 🛒" onclick="btnCarrito_Click" CommandArgument='<%#Eval("idArticulo") %>' CommandName="idArticulo" />
                </div>
            </div>
        </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

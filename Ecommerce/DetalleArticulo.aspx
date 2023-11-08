<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Ecommerce.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1>Detalle del Artículo</h1>

    <div>
        <h2>Nombre del Artículo:</h2>
        <asp:Label ID="lblNombreArticulo" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <h2>Descripción:</h2>
        <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <h2>Categoría:</h2>
        <asp:Label ID="lblCategoria" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <h2>Marca:</h2>
        <asp:Label ID="lblMarca" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <h2>Precio:</h2>
        <asp:Label ID="lblPrecio" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <h2>Stock:</h2>
        <asp:Label ID="lblStock" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>

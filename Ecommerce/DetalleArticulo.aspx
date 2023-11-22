<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Ecommerce.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-5">
    <div class="row">
        <!-- Columna izquierda para la imagen -->
 <div class="col-md-6">
    <asp:Panel ID="divImagenes" runat="server" CssClass="image-container">
        <div id="carouselImagenes" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %>">
                            <img class="d-block w-100" src="<%# Eval("UrlImagen") %>" alt="Imagen del Artículo">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselImagenes" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Anterior</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselImagenes" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Siguiente</span>
            </button>
        </div>
    </asp:Panel>
</div>
        <!-- Columna derecha para los detalles del producto -->
        <div class="col-md-6">
            <h1 class="display-4">Detalle del Artículo</h1>
            <table class="table">
                <tr>
                    <td><strong>Nombre del Artículo:</strong></td>
                    <td><asp:Label ID="lblNombreArticulo" runat="server"  Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>Descripción:</strong></td>
                    <td><asp:Label ID="lblDescripcion" runat="server"  Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>Categoría:</strong></td>
                    <td><asp:Label ID="lblCategoria" runat="server"  Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>Marca:</strong></td>
                    <td><asp:Label ID="lblMarca" runat="server"  Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>Precio:</strong></td>
                    <td><asp:Label ID="lblPrecio" runat="server"  Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>Seleccionar Talle:</strong></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTalles" AutoPostBack="true" CssClass="form-select">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><strong>Seleccionar Cantidad:</strong></td>
                    <td>
                        <asp:DropDownList ID="ddlCantidad" runat="server" AutoPostBack="true" CssClass="form-select">
                        </asp:DropDownList>
                    </td>
                </tr>
            
            </table>
        </div>
    </div>
</div>
</asp:Content>

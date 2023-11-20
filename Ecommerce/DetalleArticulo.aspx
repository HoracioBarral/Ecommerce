﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Ecommerce.DetalleArticulo" %>

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

    <div class="row">
        <div class="col">
            <asp:Label ID="lblTalle" runat="server" Text="Seleccionar Talle"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlTalles" AutoPostBack="true" OnSelectedIndexChanged="ddlTalles_SelectedIndexChanged">
            <asp:ListItem Text="XS" />
            <asp:ListItem Text="S" />
            <asp:ListItem Text="M" />
            <asp:ListItem Text="L" />
            <asp:ListItem Text="XL" />
        </asp:DropDownList>
        </div>
        <div class="col">
            <asp:Label ID="lblCantidad" runat="server" Text="Seleccionar Cantidad"></asp:Label>
            <asp:DropDownList ID="ddlCantidad" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </div>
    </div>

    <div>

        <!--<asp:Panel ID="divImagenes" runat="server" CssClass="image-container">-->
        <div id="carouselImagenes" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="carousel-item active" id="divCarouselItem">
                            <img class="d-block w-100" src="<%#Eval("UrlImagen") %>" alt="First slide">
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
        <!-- Las imágenes se agregarán dinámicamente aquí -->
        <!--</asp:Panel>-->
    </div>
    

</asp:Content>

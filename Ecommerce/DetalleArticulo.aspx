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

    <div>

        <asp:Panel ID="divImagenes" runat="server" CssClass="image-container">-->
            <div id="carouselImagenes" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="carousel-item active">
                                <img class="d-block w-100" src="<%#Container.DataItem %>" alt="First slide">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
            <!-- Las imágenes se agregarán dinámicamente aquí -->
        </asp:Panel>
    </div>

</asp:Content>

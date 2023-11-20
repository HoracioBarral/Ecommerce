<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarArticulo.aspx.cs" Inherits="Ecommerce.ModificarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtNombreArticulo">Nombre de Articulo</label>
                    <asp:TextBox runat="server" ID="txtNombreArticulo" CssClass="form-control" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtDescripcion">Descripción</label>
                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtCategoria">Categoría</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtMarca">Marca</label>
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtPrecio">Precio</label>
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtStock">Stock</label>
                    <asp:TextBox runat="server" ID="txtStock" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-12">
                <div class="d-flex justify-content-end">
                    <asp:Button runat="server" ID="btnGuardarCambios" Text="Guardar Cambios" CssClass="btn btn-primary mr-2" OnClick="btnGuardarCambios_Click" />
                    <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger mr-2" OnClick="btnEliminar_Click" />
                    <asp:Button runat="server" ID="btnVolverAtras" Text="Volver Atrás" CssClass="btn btn-secondary" OnClick="btnVolverAtras_Click" />
                </div>
            </div>
        </div>
    </div>
 
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="RepeaterImagenes" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <asp:Button runat="server" ID="btnEliminarImagen" Text="Eliminar Imagen" CssClass="btn btn-danger mr-2" CommandArgument='<%#Eval("UrlImagen") %>' OnClick="btnEliminarImagen_Click"/>
                        <div style="display: flex; justify-content: center;">
                            <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

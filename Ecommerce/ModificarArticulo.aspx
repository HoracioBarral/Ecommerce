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
                <asp:TextBox runat="server" ID="txtCategoria" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label for="txtMarca">Marca</label>
                <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" />
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
</asp:Content>

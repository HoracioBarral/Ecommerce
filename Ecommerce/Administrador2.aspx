<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administrador2.aspx.cs" Inherits="Ecommerce.Administrador2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <h3>Listado de Articulos</h3>

    <asp:GridView ID="dgvArticulos" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="idArticulo" OnRowCommand="dgvArticulos_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="nombreArticulo"/>
            <asp:BoundField HeaderText="Descripcion" DataField="descripcion"/>
            <asp:BoundField HeaderText="Categoria" DataField="categoria.nombreCategoria"/>
            <asp:BoundField HeaderText="Marca" DataField="marca.nombreMarca"/>
            <asp:BoundField HeaderText="Precio" DataField="precio"/>
            <asp:BoundField HeaderText="Stock" DataField="stock"/>
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="&#128077;" ControlStyle-CssClass="btn btn-link"/>
        </Columns>
    </asp:GridView>

</asp:Content>

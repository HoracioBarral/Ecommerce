<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Ecommerce.Carrito"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tu carrito</h1>


<div class="alertita" id="alertita" style="display: flex; justify-content: flex-start;">
        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
</div>
<table class="table table-bordered">
<thead>
    <tr>
        <th class="d-none">Id</th>
        <th>Nombre</th>
        <th>Descripción</th>
        <th>Marca</th>
        <th>Categoría</th>
        <th>Precio</th>
        <th>Ver Más</th>
        <th>Quitar</th>
    </tr>
</thead>
<tbody>
    <asp:Repeater ID="repeaterCarrito" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="d-none" name="id"<%# Eval("idArticulo") %></td>
                    <td><%# Eval("NombreArticulo") %></td>
                    <td><%# Eval("Descripcion") %></td>
                    <td><%# Eval("Marca") %></td>
                    <td><%# Eval("Categoria") %></td>
                    <td><%# Eval("Precio") %></td>
                    <td><a href="DetalleArticulo.aspx?id=<%# Eval("idArticulo") %>">Detalle</a></td>
                    <td><asp:Button ID="btnQuitar" runat="server" CssClass="btn btn-primary" OnClick="btnQuitar_Click1" Text="X" CommandName="Quitar" CommandArgument='<%# Eval("idArticulo") %>' /></td>
                    </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
    <tfoot>
        <tr>
            <td>Total</td>
            <td><asp:Label ID="lblPrecioTotal" runat="server" Text="0"></asp:Label></td>
            
    </tfoot>
</table>
</asp:Content>

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
        <th>Talle</th>
        <th>Categoría</th>
        <th>Precio</th>
        <th>Cantidad</th>
        <th>Ver Más</th>
        <th>Restar</th>
        <th>Sumar</th>
        <th>Quitar</th>
    </tr>
</thead>
<tbody>
    <% if (((List<dominio.Articulo>)(Session["carrito"])).Count == 0)
            { %>
    <asp:Image ID="imgMostrar" runat="server" ImageUrl="Imagen/carritoVacio.png" AlternateText="Carrito Vacio" />
     <div class="texto">
        <asp:Label ID="carritoVacio" runat="server" Text="Tu Carrito esta  Vacio"></asp:Label>
    </div>
    <% }
        else
        { %>
    <asp:Repeater ID="repeaterCarrito" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="d-none" name="id"<%# Eval("idArticulo") %></td>
                    <td class="d-none" name="id"<%# Eval("talle") %></td>
                    <td><%# Eval("NombreArticulo") %></td>
                    <td><%# Eval("Descripcion") %></td>
                    <td><%# Eval("Marca") %></td>
                    <td><%# Eval("Talle") %></td>
                    <td><%# Eval("Categoria") %></td>
                    <td><%# Eval("Precio") %></td>
                    <td><%# Eval("Cantidad") %></td>
                    <td><a href="DetalleArticulo.aspx?id=<%# Eval("idArticulo") %>">Detalle</a></td>
                    <td><asp:Button ID="btnRestar" runat="server" CssClass="btn btn-secondary" OnClick="btnRestar_Click" Text="-" CommandName="Restar" CommandArgument='<%# String.Format("{0}_{1}", Eval("idArticulo"), Eval("talle")) %>' /></td>
                    <td><asp:Button ID="btnSumar" runat="server" CssClass="btn btn-secondary" OnClick="btnSumar_Click"  Text="+" CommandName="Sumar" CommandArgument='<%# String.Format("{0}_{1}", Eval("idArticulo"), Eval("talle")) %>' /></td>
                    <td><asp:Button ID="btnQuitar" runat="server" CssClass="btn btn-secondary" OnClick="btnQuitar_Click1" Text="X" CommandName="Quitar" CommandArgument='<%# Eval("idArticulo") %>' /></td>
                    </tr>
            </ItemTemplate>
        </asp:Repeater>
     <% } %>
    </tbody>
    <tfoot>
        <tr>
            <td>Total</td>
            <td><asp:Label ID="lblPrecioTotal" runat="server" Text="0"></asp:Label></td>
            
    </tfoot>
</table>
                    <td><asp:Button ID="btnComprar" runat="server" CssClass="btn btn-primary" OnClick="btnComprar_Click" CommandName="Comprar" Text="Realizar Compra" /></td>
                    <td><asp:Button ID="btnVolver" runat="server" CssClass="btn btn-primary" OnClick="btnVolver_Click" CommandName="Volver" Text="Volver" /></td>
</asp:Content>

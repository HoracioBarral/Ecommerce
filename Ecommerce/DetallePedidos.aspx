<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallePedidos.aspx.cs" Inherits="Ecommerce.DetallePedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between mb-3">
        <h3>Detalle del pedido</h3>
    </div>
    <div class="d-flex justify-content-between mb-3">
        <asp:Button runat="server" ID="btnVolver" Text="Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click"/>
    </div>
    <asp:GridView ID="dgvDetalles" runat="server" AutoGenerateColumns="false" CssClass="table" >
        <Columns>
            <asp:BoundField HeaderText="idPedido" DataField="idPedido" />
            <asp:BoundField HeaderText="Nombre de Articulo" DataField="nombreArticulo" />
            <asp:BoundField HeaderText="Marca" DataField="marca.nombreMarca"/>
            <asp:BoundField HeaderText="Cantidad" DataField="cantidad" />
            <asp:BoundField HeaderText="Talle" DataField="talle" />
            <asp:BoundField HeaderText="Importe" DataField="importe" />
        </Columns>
    </asp:GridView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="HistorialPedidos.aspx.cs" Inherits="Ecommerce.HistorialPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between mb-3">
        <h3>Mis pedidos</h3>
    </div>
    <div class="d-flex justify-content-between mb-3">
        <asp:Button runat="server" ID="btnVolver" Text="Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click" />
    </div>
    <asp:GridView ID="dgvPedidos" runat="server" AutoGenerateColumns="false" CssClass="table">
        <Columns>
            <asp:BoundField HeaderText="Numero de compra" DataField="idPedido" />
            <asp:BoundField HeaderText="Cantidad de Articulos" DataField="cantidad" />
            <asp:BoundField HeaderText="Importe" DataField="importe" />
            <asp:BoundField HeaderText="Numero de envio" DataField="numeroEnvio" />
            <asp:BoundField HeaderText="Proveedor" DataField="proveedor" />
        </Columns>
    </asp:GridView>
</asp:Content>

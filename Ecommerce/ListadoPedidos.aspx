<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoPedidos.aspx.cs" Inherits="Ecommerce.ListadoPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between mb-3">
        <h3>Listado de pedidos</h3>
    </div>
    <div class="d-flex justify-content-between mb-3">
        <asp:Button runat="server" ID="btnVolver" Text="Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click"/>
    </div>
    <asp:GridView ID="dgvPedidos" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="idPedido" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="idPedido" DataField="idPedido" />
            <asp:BoundField HeaderText="ID Usuario" DataField="idUsuario" />
            <asp:BoundField HeaderText="Cantidad de Articulos" DataField="cantidad" />
            <asp:BoundField HeaderText="Importe" DataField="importe" />
            <asp:BoundField HeaderText="Estado" DataField="estado" />
            <asp:CommandField HeaderText="Ver Detalle" ShowSelectButton="true" SelectText="&#128077;" ControlStyle-CssClass="btn btn-link" />
        </Columns>
    </asp:GridView>
</asp:Content>

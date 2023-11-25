<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="Ecommerce.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between mb-3">
        <h3>Administracion de Stock</h3>
        <asp:Button ID="btnAltaStock" Text="Agregar Talle al stock" runat="server" CssClass="btn btn-primary" OnClick="btnAltaStock_Click" />
    </div>
    <asp:GridView ID="dgvStock" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="talle" OnSelectedIndexChanged="dgvStock_SelectedIndexChanged" OnRowDeleting="dgvStock_RowDeleting"  >
        <Columns>
            <asp:BoundField HeaderText="ID Articulo" DataField="idArticulo"/>
            <asp:BoundField HeaderText="Talle" DataField="talle"/>
            <asp:BoundField HeaderText="Stock" DataField="stock"/>
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="&#128077;" ControlStyle-CssClass="btn btn-link"/>
            <asp:CommandField HeaderText="Eliminar Stock" ShowDeleteButton="true" DeleteText="❌" ControlStyle-CssClass="btn btn-link"/>
        </Columns>
    </asp:GridView>
</asp:Content>

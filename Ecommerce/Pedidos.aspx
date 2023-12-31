﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Ecommerce.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between mb-3">
        <h3>Listado de pedidos</h3>
    </div>
    <div class="d-flex justify-content-between mb-3">
        <asp:Button runat="server" ID="btnVolver" Text="Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click" />
    </div>
    <asp:GridView ID="dgvPedidos" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="idPedido" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="idPedido" DataField="idPedido" />
            <asp:BoundField HeaderText="ID Usuario" DataField="idUsuario" />
            <asp:BoundField HeaderText="Cantidad de Articulos" DataField="cantidad" />
            <asp:BoundField HeaderText="Importe" DataField="importe" />
            <asp:BoundField HeaderText="Estado" DataField="estado" />
            <asp:TemplateField HeaderText="Seleccione nuevo estado">
                <ItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                        <asp:ListItem Text="1 - En carrito" Value="1" />
                        <asp:ListItem Text="2 - Compra Confirmada" Value="2" />
                        <asp:ListItem Text="3 - Compra Abonada" Value="3" />
                        <asp:ListItem Text="4 - Compra Cancelada" Value="4" />
                        <asp:ListItem Text="5 - Entregado o Retirado" Value="5" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Modificar Estado" ShowSelectButton="true" SelectText="&#128077;" ControlStyle-CssClass="btn btn-link" />
        </Columns>
    </asp:GridView>
</asp:Content>

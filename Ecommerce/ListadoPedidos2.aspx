<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoPedidos2.aspx.cs" Inherits="Ecommerce.ListadoPedidos2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div>
                <div class="alertita" id="alertita" style="display: flex; justify-content: flex-start;">
                    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                </div>
            </div>
            <div class="d-flex justify-content-between mb-3">
                <h3>Listado de pedidos</h3>
            </div>
            <div class="d-flex justify-content-between mb-3">
                <asp:Button runat="server" ID="btnVolver" Text="Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click" />
            </div>
            <asp:GridView ID="dgvPedidos" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="idPedido" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" OnRowCommand="dgvPedidos_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="idPedido" DataField="idPedido" />
                    <asp:BoundField HeaderText="ID Usuario" DataField="idUsuario" />
                    <asp:BoundField HeaderText="Cantidad de Articulos" DataField="cantidad" />
                    <asp:BoundField HeaderText="Importe" DataField="importe" />
                    <asp:BoundField HeaderText="Estado" DataField="estado" />
                    <asp:TemplateField HeaderText="Seleccione nuevo estado">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control" AutoPostBack="true">
                                <asp:ListItem Text="1 - En carrito" Value="1" />
                                <asp:ListItem Text="2 - Compra Confirmada" Value="2" />
                                <asp:ListItem Text="3 - Compra Abonada" Value="3" />
                                <asp:ListItem Text="4 - Compra Cancelada" Value="4" />
                                <asp:ListItem Text="5 - Entregado o Retirado" Value="5" />
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:ButtonField ButtonType="Button" Text="Modificar Estado" CommandName="ModificarEstado" ControlStyle-CssClass="btn btn-link" />
                    <asp:CommandField HeaderText="Ver Detalle" ShowSelectButton="true" SelectText="&#128077;" ControlStyle-CssClass="btn btn-link" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoPedidos2.aspx.cs" Inherits="Ecommerce.ListadoPedidos2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:HiddenField runat="server" ID="numeroEnvio" />
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
                            <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control" AutoPostBack="true" onchange="handleEstadoChange(this);">
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

    <div class="modal fade" id="modalEnvio" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalNumero">Tipo de envio o retiro</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label for="txtEnvio">Ingrese el numero de envio o 0 para retiro en tienda:</label>
                    <input type="text" id="txtEnvio" class="form-control" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" onclick="obtenerEnvio()">Aceptar</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        function handleEstadoChange(ddlEstado) {
            var nuevoEstado = ddlEstado.value;
            if (nuevoEstado === "3") {
                $('#modalEnvio').modal('show');
            }
        }

        function obtenerEnvio() {
            var envio = document.getElementById('txtEnvio').value;
            document.getElementById('<%= numeroEnvio.ClientID %>').value = envio;
            $('#modalEnvio').modal('hide');
        }
    </script>
</asp:Content>

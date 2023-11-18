<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="Ecommerce.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <h3>Bienvenido Administrador</h3>

        <style>
    .card:hover {
        box-shadow: -1px 9px 40px 2px #020202;
    }

    .card-text.clase2:hover {
        transform: scale(1.2);
    }

    .botonCarrito::after {
        content: none;
    }

    .botonCarrito::before {
        content: none;
    }

</style>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updatePanelProductos">
        <ContentTemplate>

            <div>
                <div class="alertita" id="alertita" style="display: flex; justify-content: flex-start;">
                    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                </div>
            </div>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card">
                                <div style="display: flex; justify-content: center;">
                                    <asp:HyperLink ID="hlImagen" runat="server" NavigateUrl='<%# "DetalleArticulo.aspx?id=" + Eval("idArticulo") %>'>
                                        <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# GetImageUrl(Container.DataItem) %>' AlternateText="Imagen del artículo" Width="300" Height="250" />
                                    </asp:HyperLink>
                                </div>
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("NombreArticulo") %></h5>
                                    <p class="card-text"><%# Eval("Descripcion") %></p>
                                    <p class="card-text"><%# Eval("Categoria") %></p>
                                    <p class="card-text"><%# Eval("Marca") %></p>
                                    <p class="card-text">Stock<%# Eval("Stock") %></p>
                                    <div style="display: flex; justify-content: space-evenly;">
                                        <asp:Button ID="btnModificar" runat="server" Text="Modificar⚙" OnClientClick="abrirModalEditar(); return false;" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="modal fade" id="modalEditarArticulo" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Editar Artículo</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <!-- Campo de edición del nombre del artículo -->
                            <asp:TextBox ID="txtNNombreArticulo" runat="server" CssClass="form-control" placeholder="Nombre del Artículo"></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                            <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar Cambios" OnClick="btnGuardarCambios_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

      
    <script type="text/javascript">
        $('.card').hover(
            function () {
                $(this).animate({
                    marginTop: "-=1%",
                    marginBottom: "+=1%"
                }, 200)
            },
            function () {
                $(this).animate({
                    marginTop: "+=1%",
                    marginBottom: "-=1%"
                })
            }
        )
        function abrirModalEditar() {
            $('#modalEditarArticulo').modal('show');
        }

        // Script para guardar cambios (aquí puedes realizar la lógica de actualización)
        function guardarCambios() {
            // Lógica para guardar los cambios en el servidor
            var nuevoNombre = $("#<%=txtNNombreArticulo.ClientID%>").val();
        }
        // Cerrar
        function cerrarModalEditar() {
            try {
                console.log("Cerrando modal...");
                $('#modalEditarArticulo').modal('hide');
            } catch (error) {
                console.error("Error al cerrar el modal:", error);
            }
        }
    </script>

    
</asp:Content>

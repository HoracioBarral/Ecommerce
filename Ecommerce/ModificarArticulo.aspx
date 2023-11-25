<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarArticulo.aspx.cs" Inherits="Ecommerce.ModificarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <!-- Columna 1 -->
                <div class="form-group">
                    <label for="txtNombreArticulo">Nombre de Articulo</label>
                    <asp:TextBox runat="server" ID="txtNombreArticulo" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <label for="txtDescripcion">Descripción</label>
                    <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label for="txtUrlImagen">Url Imagen</label>
                                <asp:TextBox runat="server" ID="txtUrlImagen" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtUrlImagen_TextChanged" />
                            </div>
                            <asp:Button ID="btnAgregarImagen" Text="Agregar Imagen" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnAgregarImagen_Click" Style="margin: 20px; padding: 10px;" />
                            <asp:Image ImageUrl=" " ID="Image1" runat="server" Width="60%" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>

            <div class="col-md-4">
                <!-- Columna 2 -->
                <div class="form-group">
                    <label for="txtCategoria">Categoría</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="txtMarca">Marca</label>
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="txtEstado">Estado</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Activo" Value="1" />
                        <asp:ListItem Text="Inactivo" Value="0" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-md-4">
                <!-- Columna 3 -->
                <div class="form-group">
                    <label for="txtPrecio">Precio</label>
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <asp:Button ID="btnStock" Text="Administrar stock" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnStock_Click" Style="margin: 20px; padding: 10px;" />
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="d-flex justify-content-end">
                            <asp:Button runat="server" ID="btnGuardarCambios" Text="Guardar Cambios" CssClass="btn btn-primary mb-2" OnClick="btnGuardarCambios_Click" />
                            <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger mb-2" OnClick="btnEliminar_Click" />
                            <asp:Button runat="server" ID="btnVolverAtras" Text="Volver Atrás" CssClass="btn btn-secondary mb-2" OnClick="btnVolverAtras_Click" />
                        </div>
                        <%if (ConfirmaEliminacion)
                            { %>
                        <div>
                            <asp:CheckBox Text="Confirmar" ID="chkConfirmElimi" runat="server" />
                            <asp:Button ID="btnEliminar2" runat="server" Text="Eliminar" OnClick="btnEliminar2_Click" CssClass="btn btn-outline-danger" />
                        </div>
                        <%} %>
            </div>
                        <div class="row">
                            <asp:Label ID="txtAdvertencia" runat="server" CssClass="form-control" Visible="false" ForeColor="Red" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>


            <div>
            </div>
            <!-- ... -->
            <div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <!-- Imágenes -->
                        <div class="row row-cols-1 row-cols-md-3 g-4">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <div class="col">
                                        <div class="card">
                                            <asp:Button runat="server" ID="btnEliminarImagen" Text="Eliminar Imagen" CssClass="btn btn-danger mt-2" CommandArgument='<%#Eval("UrlImagen") %>' OnClick="btnEliminarImagen_Click" />
                                            <div style="display: flex; justify-content: center;">
                                                <img src="<%#Eval("UrlImagen") %>" class="card-img-top">
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <asp:Repeater ID="RepeaterImagenes" runat="server">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card" style="margin-top: 10px; padding: 10px;">
                                    <asp:Button runat="server" ID="btnEliminarImagen" Text="Eliminar Imagen" CssClass="btn btn-danger mr-2" CommandArgument='<%#Eval("UrlImagen") %>' OnClick="btnEliminarImagen_Click" />
                                    <div style="display: flex; justify-content: center;">
                                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top">
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

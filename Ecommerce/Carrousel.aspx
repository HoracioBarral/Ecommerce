<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrousel.aspx.cs" Inherits="Ecommerce.Carrousel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <div class="row">
            <!-- Columna 1 -->
            <div class="col-md-4">
                <div class="form-group">
                    <label for="txtCarr1"><strong>Carrousel t1</strong></label>
                    <asp:DropDownList ID="ddlCarrousel1" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:Button ID="btnAgregar1" runat="server" Text="Agregar" OnClick="btnAgregar1_Click" CssClass="btn btn-outline-success mt-2" />
                    <asp:Button ID="btnEliminar1" runat="server" Text="Eliminar" OnClick="btnEliminar1_Click" CssClass="btn btn-outline-danger mt-2" />
                </div>

                <div class="form-group">
                    <label for="txtCarr2"><strong>Carrousel t2</strong></label>
                    <asp:DropDownList ID="ddlCarrousel2" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:Button ID="btnAgregar2" runat="server" Text="Agregar" OnClick="btnAgregar2_Click" CssClass="btn btn-outline-success mt-2" />
                    <asp:Button ID="btnEliminar2" runat="server" Text="Eliminar" OnClick="btnEliminar2_Click" CssClass="btn btn-outline-danger mt-2" />
                </div>

                <div class="form-group">
                    <label for="txtCarr3"><strong>Carrousel t3</strong></label>
                    <asp:DropDownList ID="ddlCarrousel3" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:Button ID="btnAgregar3" runat="server" Text="Agregar" OnClick="btnAgregar3_Click" CssClass="btn btn-outline-success mt-2" />
                    <asp:Button ID="btnEliminar3" runat="server" Text="Eliminar" OnClick="btnEliminar3_Click" CssClass="btn btn-outline-danger mt-2" />
                </div>

                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnVolver_Click" Style="margin: 20px; padding: 10px;" />
            </div>

            <!-- Columna 2 -->
            <div class="col-md-4">
                <div class="form-group">
                    <label for="txtnuevotexto"><strong> Nueva Información</strong></label>
                    <asp:TextBox runat="server" ID="txtNuevoTexto" CssClass="form-control" />
                    <asp:Button ID="btnAgregarNuevo" runat="server" Text="Agregar Texto" OnClick="btnAgregarNuevo_Click" CssClass="btn btn-primary mt-2" Style="margin: 20px; padding: 10px;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

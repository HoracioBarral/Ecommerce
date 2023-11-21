<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CategoriasMarcas.aspx.cs" Inherits="Ecommerce.CategoriasMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between mb-3">
        <h3>Desde aqui podra editar y/o agregar Marcas y Categorias</h3>
    </div>

    <div class="d-flex justify-content-between mb-3">
        <h3>Listado de Categorias</h3>
    </div>
    <asp:GridView ID="dgvCategorias" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="idCategoria" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="ID Categoria" DataField="idCategoria" />
            <asp:BoundField HeaderText="Descripcion" DataField="nombreCategoria" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="&#128077;" ControlStyle-CssClass="btn btn-link" />
        </Columns>
    </asp:GridView>
    <hr>
    <div class="d-flex justify-content-between mb-3">
        <h3>Listado de Marcas</h3>
    </div>
    <asp:GridView ID="dgvMarcas" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="idMarca" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderText="ID Marca" DataField="idMarca" />
            <asp:BoundField HeaderText="Nombre" DataField="nombreMarca" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="&#128077;" ControlStyle-CssClass="btn btn-link" />
        </Columns>
    </asp:GridView>
</asp:Content>

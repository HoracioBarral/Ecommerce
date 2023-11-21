<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UsuariosRegistrados.aspx.cs" Inherits="Ecommerce.UsuariosRegistrados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between mb-3">
        <h3>Listado de los usuarios registrados a la fecha</h3>
    </div>
    <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="idUsuario" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderText="ID Usuario" DataField="idUsuario" />
            <asp:BoundField HeaderText="Nombre Usuario" DataField="nombreUsuario" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="&#128077;" ControlStyle-CssClass="btn btn-link"/>
            <asp:CommandField HeaderText="Resetear Contraseña" ShowSelectButton="true" SelectText="&#128077;" ControlStyle-CssClass="btn btn-link" />
        </Columns>
    </asp:GridView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administrador2.aspx.cs" Inherits="Ecommerce.Administrador2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <asp:GridView ID="dgvArticulos" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="idArticulo" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="nombreArticulo"/>
                <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
                <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="&#128077;" />   
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

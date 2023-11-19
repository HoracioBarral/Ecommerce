<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarArticulo.aspx.cs" Inherits="Ecommerce.ModificarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-8">
            <div class="row">
                <asp:Label Text="Nombre de Articulo" runat="server" />
            </div>
            <asp:TextBox runat="server" ID="txtNombreArticulo"/>
        </div>
        <div class="col-8">
            <div class="row">
                <asp:Label Text="Descripcion" runat="server" />
            </div>
            <asp:TextBox runat="server" ID="txtDescripcion"/>
        </div>
        <div class="col-8">
            <div class="row">
                <asp:Label Text="Categoria" runat="server" />
            </div>
            <asp:TextBox runat="server" ID="txtCategoria"/>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminMarcas.aspx.cs" Inherits="Ecommerce.AdminMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <div class="form-group">
                        <label for="txtMarca">Marca</label>
                        <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" />
                    </div>
                    <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-danger mt-2" runat="server" Onclick="btnAceptar_Click" Style="margin: 20px; padding: 10px;" />
                    <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-danger mt-2" runat="server" Onclick="btnVolver_Click" Style="margin: 20px; padding: 10px;" />
                    <asp:Label ID="Label1" runat="server" CssClass="mensaje" EnableViewState="False"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

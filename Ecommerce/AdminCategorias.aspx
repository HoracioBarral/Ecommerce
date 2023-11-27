<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminCategorias.aspx.cs" Inherits="Ecommerce.AdminCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <div class="form-group">
                        <label for="txtCategoria">Categoria</label>
                        <asp:TextBox runat="server" ID="txtCategoria" CssClass="form-control" />
                    </div>
                    <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnAceptar_Click" Style="margin: 20px; padding: 10px;" />
                    <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnVolver_Click" Style="margin: 20px; padding: 10px;" />
                </div>
            </div>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" CssClass="mensaje" EnableViewState="False"></asp:Label>
        </div>
    </div>
</asp:Content>

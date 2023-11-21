<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdmStock.aspx.cs" Inherits="Ecommerce.AdmStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-md-4">
            <div class="form-group">
                <label for="txtTalle">Talle</label>
                <asp:DropDownList ID="ddlTalle" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        <div class="form-group">
                <label for="txtCantidad">Cantidad</label>
                <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" AutoPostBack="true" />
        </div>

        <div class="form-group">
                
                     <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnAceptar_Click1" style="margin: 20px; padding: 10px;"/>
                    <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnVolver_Click" style="margin: 20px; padding: 10px;"/>
                 
            </div>
     </div>
</asp:Content>

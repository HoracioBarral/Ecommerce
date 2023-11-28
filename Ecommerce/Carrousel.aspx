<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrousel.aspx.cs" Inherits="Ecommerce.Carrousel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-4">
    <!-- Columna 2 -->
    <div class="form-group">
        <label for="txtCarr1">Carrousel t1</label>
        <asp:DropDownList ID="ddlCarrousel1" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="txtCarr2">Carrousel t2</label>
        <asp:DropDownList ID="ddlCarrousel2" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
        <div class="form-group">
            <label for="txtCarr3">Carrousel t3</label>
            <asp:DropDownList ID="ddlCarrousel3" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

    </div>

                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnAceptar_Click" Style="margin: 20px; padding: 10px;" />
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnVolver_Click" Style="margin: 20px; padding: 10px;" />
     
</asp:Content>

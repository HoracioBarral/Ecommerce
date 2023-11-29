<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrousel.aspx.cs" Inherits="Ecommerce.Carrousel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="container">
    <div class="row">
        <!-- Columna 1 -->
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtCarr1">Carrousel t1</label>
                <asp:DropDownList ID="ddlCarrousel1" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:Button ID="btnAgregar1" runat="server" Text="Agregar" OnClick="btnAgregar1_Click" />
            </div>

            <div class="form-group">
                <label for="txtCarr2">Carrousel t2</label>
                <asp:DropDownList ID="ddlCarrousel2" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:Button ID="btnAgregar2" runat="server" Text="Agregar" OnClick="btnAgregar2_Click" />
            </div>

            <div class="form-group">
                <label for="txtCarr3">Carrousel t3</label>
                <asp:DropDownList ID="ddlCarrousel3" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:Button ID="btnAgregar3" runat="server" Text="Agregar" OnClick="btnAgregar3_Click" />
            </div>
            <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnVolver_Click" Style="margin: 20px; padding: 10px;" />
        </div>

        <!-- Columna 2 -->
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtnuevotexto">Nueva Información</label>
                <asp:TextBox runat="server" ID="txtNuevoTexto" CssClass="form-control" />
                <asp:Button ID="btnAgregarNuevo" runat="server" Text="Agregar Texto" OnClick="btnAgregarNuevo_Click" Cssclass="btn btn-primary" Style="margin: 20px; padding: 10px;" />
            </div>
        </div>
    </div>
</div>
  
     
</asp:Content>

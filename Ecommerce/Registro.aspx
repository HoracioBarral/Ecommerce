<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Ecommerce.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">Nombre de Usuario</label>
            <asp:TextBox ID="TxtNombreUser" runat="server" placeholder="nombreUsuario" CssClass="form-control"> </asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox ID="Txtpass" runat="server" placeholder="*****" CssClass="form-control" TextMode="Password"> </asp:TextBox>
        </div>
        <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" />
    </div>
    <div>
            <asp:Label ID="Label1" runat="server" CssClass="mensaje" Visible="false"></asp:Label>
        </div>
</asp:Content>

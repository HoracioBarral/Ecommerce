<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrousel.aspx.cs" Inherits="Ecommerce.Carrousel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
 <div>
        <!-- TextBox para ingresar el nuevo contenido del carrusel 1 -->
        <asp:TextBox ID="txtCarrusel1" runat="server"></asp:TextBox>
        <asp:Button ID="btnGuardarCarrusel1" runat="server" Text="Guardar1" OnClick="btnGuardarCarrusel1_Click" />

        <!-- TextBox para ingresar el nuevo contenido del carrusel 2 -->
        <asp:TextBox ID="txtCarrusel2" runat="server"></asp:TextBox>
        <asp:Button ID="btnGuardarCarrusel2" runat="server" Text="Guardar2" OnClick="btnGuardarCarrusel2_Click" />

        <!-- TextBox para ingresar el nuevo contenido del carrusel 3 -->
        <asp:TextBox ID="txtCarrusel3" runat="server"></asp:TextBox>
        <asp:Button ID="btnGuardarCarrusel3" runat="server" Text="Guardar3" OnClick="btnGuardarCarrusel3_Click" />
    </div>
</asp:Content>

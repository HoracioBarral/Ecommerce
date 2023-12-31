﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecommerce.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">Usuario</label>
            <asp:TextBox ID="Txtusuario" runat="server" placeholder="user name" CssClass="form-control"> </asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox ID="Txtpass" runat="server" placeholder="*****" CssClass="form-control" TextMode="Password"> </asp:TextBox>
        </div>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
        <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" EnableViewState="False"></asp:Label>
        <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
    </div>
    <div>
        <asp:LinkButton ID="lnkNuevaClave" runat="server" Text="Olvidó su Clave, haga clic aquí" OnClick="lnkNuevaClave_Click"></asp:LinkButton>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" CssClass="mensaje" EnableViewState="False"></asp:Label>
    </div>
</asp:Content>

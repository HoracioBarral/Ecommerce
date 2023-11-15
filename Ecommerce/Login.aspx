<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecommerce.Login" %>
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
               <asp:TextBox ID="Txtpass" runat="server" placeholder="*****" CssClass="form-control"> </asp:TextBox>
           </div>
           <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
       </div>
</asp:Content>

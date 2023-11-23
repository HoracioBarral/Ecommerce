<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Ecommerce.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
    <div class="row">
        <div class="col-md-4">
            <!-- Columna 1 -->
            <div class="form-group">
                <label for="txtMail">Direccion de correo electronico</label>
                <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtAsunto">Mensaje</label>
                <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtMensaje">Mensaje</label>
                <asp:TextBox runat="server" ID="txtMensaje" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnEnviarMensaje" Text="Enviar" CssClass="btn btn-danger mt-2" runat="server" OnClick="btnEnviarMensaje_Click" style="margin: 20px; padding: 10px;"/>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
        </div>
        </div>
</asp:Content>

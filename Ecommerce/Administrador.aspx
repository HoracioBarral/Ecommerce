<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="Ecommerce.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h3>Bienvenido Administrador</h3>

        <style>
    .card:hover {
        box-shadow: -1px 9px 40px 2px #020202;
    }

    .card-text.clase2:hover {
        transform: scale(1.2);
    }

    .botonCarrito::after {
        content: none;
    }

    .botonCarrito::before {
        content: none;
    }

</style>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updatePanelProductos">
        <ContentTemplate>
        
 <div>
     <div class="alertita" id="alertita" style="display: flex; justify-content: flex-start;">
      <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
     </div>
</div>
        <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
               <div class="col">
            <div class="card">
                <div style="display: flex; justify-content: center;">
                    <asp:HyperLink ID="hlImagen" runat="server" NavigateUrl='<%# "DetalleArticulo.aspx?id=" + Eval("idArticulo") %>'>
                    </asp:HyperLink>
                    </div>
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("NombreArticulo") %></h5>
                    <p class="card-text"><%# Eval("Descripcion") %></p>
                    <p class="card-text"><%# Eval("Categoria") %></p>
                    <p class="card-text"><%# Eval("Marca") %></p>
                    <p class="card-text"><%# Eval("Stock") %></p>
                    <div style="display: flex; justify-content: space-evenly;">
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar⚙" OnClick="btnModificar_Click" CommandArgument='<%#Eval("idArticulo") %>' CommandName="idArticulo"/>
                    </div>
                </div>
            </div>
        </div>

            </ItemTemplate>
        </asp:Repeater>
        </div>
       </ContentTemplate>
    </asp:UpdatePanel>

      
    <script type="text/javascript">
        $('.card').hover(
            function () {
                $(this).animate({
                    marginTop: "-=1%",
                    marginBottom: "+=1%"
                }, 200)
            },
            function () {
                $(this).animate({
                    marginTop: "+=1%",
                    marginBottom: "-=1%"
                })
            }
        )
    </script>

    
</asp:Content>

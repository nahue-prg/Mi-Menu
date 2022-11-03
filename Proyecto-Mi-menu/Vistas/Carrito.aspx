<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Vistas.Carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css"/>

    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Lobster&family=Nunito:ital,wght@0,200;0,300;0,400;0,500;0,700;0,800;1,600&display=swap" rel="stylesheet"/>
</head>
<body>
          <header>
        <nav class="menu-header">
              <ul>
                   <li class="menu-header_option liLogo">
                       <asp:HyperLink ID="hlk_logo" CssClass="LogoPrincipal" runat="server" NavigateUrl="~/Index.aspx">Mi menu <i class="fa-solid fa-utensils"></i></asp:HyperLink>
                   </li>
                   <li class="menu-header_option">
                       <asp:HyperLink ID="hlk_menuPrincipal" runat="server" NavigateUrl="~/Index.aspx">Menu principal</asp:HyperLink>

                   </li>
                   <li class="menu-header_option">
                       <asp:HyperLink ID="hlk_MiCuenta" runat="server" Text="Mi cuenta" NavigateUrl="~/Iniciar sesion.aspx"></asp:HyperLink>
                   </li>
                  <li class="menu-header_option carrito">
                       <asp:HyperLink ID="hlk_carrito" runat="server" NavigateUrl="~/Carrito.aspx"><i class="fa-solid fa-cart-shopping"></i> <asp:Label ID="lbl_carritoTotal" runat="server" Text="Carrito"></asp:Label></asp:HyperLink>
                   </li>
              </ul>
        </nav>
</header> 

    <form id="form1" runat="server">
        <div class="carrito_total">  
        <asp:Label ID="lbl_negocio" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#ff441f" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" CssClass="carrito-gridView">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#ff441f" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
         
            <div>
                <br />
                <asp:Label ID="lbl_total" runat="server" ForeColor="#FF441F"></asp:Label>
            </div>
            <br />
            <div class="btnList">
            <asp:RadioButtonList ID="btnList_MedioPago" runat="server">
                <asp:ListItem Selected="True">Efectivo</asp:ListItem>
                <asp:ListItem>Tarjeta</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RadioButtonList ID="btnList_Modalidad" runat="server">
                <asp:ListItem Selected="True">Retiro</asp:ListItem>
                <asp:ListItem>Envio</asp:ListItem>
            </asp:RadioButtonList>
            </div>
            <div class="botones-carrito">
            <asp:Button ID="Button1" runat="server" Text="Realizar pedido!" CssClass="buton" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Vaciar carrito" CssClass="buton vaciar-Carrito" OnClientClick="Confirmacion('Desea vaciar el carrito?')" OnClick="Button2_Click" />
                </div>
        </div>
        <script type="text/javascript">

            function alerta(mensaje) {
                alert(mensaje);
            }

        </script>

        <script type="text/javascript">

            function Confirmacion(Mensaje) {
                var seleccion = confirm(Mensaje);
                return seleccion;
            }
        </script>
        <div class="usuario-sticky">
            <asp:Label ID="lbl_usuarioR" runat="server" Text=""></asp:Label>
        </div>
    </form>
    



    
</body>

</html>

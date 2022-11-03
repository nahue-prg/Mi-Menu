<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiCuenta_Cliente.aspx.cs" Inherits="Vistas.MiCuenta_Cliente" %>

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
     <section class="titulo">
        <h1>Mi cuenta</h1>
    </section>
    <form id="form1" runat="server">
        <section class="mi-cuenta">
            <asp:Label ID="lbl_nombreCliente" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btn_MisPedidos" runat="server" Text="Mis pedidos" CssClass="buton" OnClick="btn_MisPedidos_Click" />
            <asp:Button ID="btn_CerrarSesion" runat="server" Text="Cerrar sesion" CssClass="buton" OnClick="btn_CerrarSesion_Click"  OnClientClick="return Confirmacion('Desea cerrar sesion?');" />
        </section>

        <div class="GridPedidos">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#ff441f" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#ff441f" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        </div>
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

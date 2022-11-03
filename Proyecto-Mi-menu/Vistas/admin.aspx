<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Vistas.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>admin</title>

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
        <h1>ADMINISTRADOR</h1>
    </section>
    
    <form id="form1" runat="server">
         
    <section class="seleccion">
        <%--<asp:Button ID="Button1" runat="server" Text="Reportes" />
        <asp:Button ID="Button2" runat="server" Text="Activar/eliminarnegocio" />
        <asp:Button ID="Button3" runat="server" Text="Activar/eliminar<br>cliente" />--%>
        <div>
           <i class="fa-solid fa-chart-line"></i>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin_reportes.aspx">Reportes</asp:HyperLink>
        </div>
        <div>
            <i class="fa-solid fa-shop"></i>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin_AB-negocios.aspx">Activar/eliminar<br />negocio</asp:HyperLink>
        </div>
        <div>
            <i class="fa-solid fa-person-rays"></i>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin_AB-clientes.aspx">Activar/eliminar<br />cliente</asp:HyperLink>
        </div>
     </section>
        <script type="text/javascript">

             function alerta(mensaje) {
                 alert(mensaje);
             }

        </script>
        <div class="usuario-sticky">
            <asp:Label ID="lbl_usuarioR" runat="server" Text=""></asp:Label>
        </div>
    </form>
    <footer>
        
    </footer>
</body>
</html>

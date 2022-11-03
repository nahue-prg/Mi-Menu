<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrar menu.aspx.cs" Inherits="Vistas.Administrar_menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0px;
        }
    </style>
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
        <h1>ADMINISTRAR MENU</h1>
    </section>

    <form id="form1" runat="server" enctype="multipart/form-data">
      
        <section class="seleccion">
            <div>
                <i class="fa-solid fa-burger"></i>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Administrar menu-Productos-Agregar.aspx">Agregar productos</asp:HyperLink>
            </div>
            <div>
                <i class="fa-solid fa-square-xmark"></i>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Administrar menu-Productos-Modificar.aspx">Modificar productos</asp:HyperLink>
            </div>
            <div>
                <i class="fa-solid fa-utensils"></i>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Index.aspx">Ver menu</asp:HyperLink>
            </div>
         </section>
            
        <div class="usuario-sticky">
            <asp:Label ID="lbl_usuarioR" runat="server" Text=""></asp:Label>
        </div>
    </form>
    
    <footer>

    </footer>
</body>
</html>

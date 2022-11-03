<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion_negocios.aspx.cs" Inherits="Vistas.IniciarSesion_negocios" %>

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
        <h1>INICIAR SESION/Negocios</h1>
    </section>


    <form id="form1" runat="server">
    
        <section class="IniciarSesion">
            <div class="IniciarSesion-campo">
                <asp:Label ID="Label1" runat="server" Text="MAIL"></asp:Label>
                <asp:TextBox ID="txt_mail" runat="server" ValidationGroup="1"></asp:TextBox>
            </div>
            <div class="IniciarSesion-campo">
                <asp:Label ID="Label2" runat="server" Text="CONTRASEÑA"></asp:Label>
                <asp:TextBox ID="txt_clave" runat="server" ValidationGroup="1" TextMode="Password"></asp:TextBox>
            </div>
            <div class="IniciarSesion-campo">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="link sesionSugerencia" NavigateUrl="~/Registro negocio.aspx">Haz click aqui para registrar tu negocio</asp:HyperLink>
            </div>
            <div class="IniciarSesion-campo-boton">
                <asp:Button ID="Button1" runat="server" Text="INICIAR SESION" ValidationGroup="1"  CssClass="buton" OnClick="Button1_Click" />
            </div>
        </section>
        <script type="text/javascript">

             function alerta(mensaje) {
                 alert(mensaje);
             }

        </script>
        </form>
</body>
</html>

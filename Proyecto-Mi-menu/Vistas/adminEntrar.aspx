<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminEntrar.aspx.cs" Inherits="Vistas.adminEntrar" %>

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
        <h1>ADMINISTRADOR/INICIAR SESION</h1>
    </section>
    
    <form id="form1" runat="server">
        <section class="IniciarSesion">
           <div class="IniciarSesion-campo">
                <asp:Label ID="Label1" runat="server" Text="USUARIO:"></asp:Label>
                <asp:TextBox ID="txt_usuario" runat="server"></asp:TextBox>
            </div>
            <div class="IniciarSesion-campo">
                <asp:Label ID="Label2" runat="server" Text="CONTRASEÑA:"></asp:Label>
                <asp:TextBox ID="txt_clave" runat="server" TextMode="Password"></asp:TextBox>
            </div> 
            <div class="IniciarSesion-campo-boton">
                 <asp:Button ID="btn_IniciarSesion" runat="server" Text="ACEPTAR" CssClass="buton" OnClick="btn_IniciarSesion_Click" ValidationGroup="1" />
            </div>
        </section>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese usuario para continuar" ControlToValidate="txt_usuario" ValidationGroup="1" Visible="False"></asp:RequiredFieldValidator>
        <script type="text/javascript">

            function alerta(mensaje) {
                alert(mensaje);
            }

        </script>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_clave" ErrorMessage="Ingrese clave para continuar" ValidationGroup="1" Visible="False"></asp:RequiredFieldValidator>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowModelStateErrors="False" ShowSummary="False" />
    </form>
       
    
        
</body>
</html>

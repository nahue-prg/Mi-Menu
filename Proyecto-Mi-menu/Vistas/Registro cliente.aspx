<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro cliente.aspx.cs" Inherits="Vistas.Registro_cliente" %>

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
    <style type="text/css">
        .auto-style1 {
            margin-top: 0;
        }
    </style>
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
        <h1>CLIENTES/Registrarse</h1>
    </section>

    <form id="form1" runat="server">

        <section class="formulario">
            <div class="formulario-Titulo">
                <label>Registrarse</label>
            </div>

            <div class="formulario-campo">
                <label>Usuario</label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             </div>
             <div class="formulario-campo">
                 <label>Nombre</label>
                 <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             </div>
            <div class="formulario-campo">
                <label>Apellido</label>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </div>
           <div class="formulario-campo">
               <label>Email</label>
               <asp:TextBox ID="TextBox4" runat="server" TextMode="Email"></asp:TextBox>
           </div>
            <div class="formulario-campo">
                <label>Celular</label>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </div>
            <div class="formulario-campo">
                <label>Contraseña</label>
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="formulario-campo">
                <label>Repetir contraseña</label>
                <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="formulario-campo-boton">
                <asp:Button ID="Button1" runat="server" Text="Registrarse!" OnClick="Button1_Click" CssClass="buton" ValidationGroup="1" />
            </div>
           </section>
        <div class="Aviso-error">
         <asp:Label ID="Label7" runat="server" CssClass="aviso"></asp:Label>
        </div>
        <div class="sugerencia">
            <asp:HyperLink ID="hlk_Sugerencia" runat="server" NavigateUrl="~/Iniciar sesion.aspx" CssClass="link">Iniciar Sesion</asp:HyperLink>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Complete el apellido" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Complete el email" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingrese un celular valido" ControlToValidate="TextBox5" Font-Size="0pt" ValidationExpression="^\d+$" ValidationGroup="1"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Complete el celular" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox1" ErrorMessage="Complete el usuario" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox2" ErrorMessage="Complete el Nombre" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese la cotraseña" ControlToValidate="TextBox6" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style1" ShowMessageBox="True" ShowModelStateErrors="False" ShowSummary="False" ValidationGroup="1" />
        
        <script type="text/javascript">

             function alerta(mensaje) {
                 alert(mensaje);
             }

        </script>
    </form>
</body>
</html>

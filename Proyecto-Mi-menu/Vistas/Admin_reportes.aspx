<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_reportes.aspx.cs" Inherits="Vistas.Admin_reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin reportes</title>
<link rel="stylesheet" href="Styles.css" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css"/>

    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Lobster&family=Nunito:ital,wght@0,200;0,300;0,400;0,500;0,700;0,800;1,600&display=swap" rel="stylesheet"/>
    
</head>
<body >
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
        <h1>ADMINISTRADOR/Reportes</h1>
    </section>

    <form id="form1" runat="server">
        <section class="reports-date">

             <div class="date">
            <h2>FILTRAR POR FECHA</h2>   
            <div class="date_option">

                <label class="date_option_label">DESDE:</label>
                <asp:TextBox ID="IDdate_Desd" runat="server" CssClass="fechita" TextMode="Date" ControlToValidate="IDdate_Desd" ValidationGroup="1"></asp:TextBox>
                </div>
               
            <div class="date_option">

                 <label class="date_option_label">HASTA:</label>
                 <asp:TextBox ID="IDdate_hast" runat="server" CssClass="fechita" TextMode="Date" ValidationGroup="1"></asp:TextBox>
            </div>
            <div class="reports_button">
            <asp:Button ID="btn_report"  runat="server" Text="FILTRAR" CssClass="buton" OnClick="btn_report_Click" ValidationGroup="1" />
        </div>
        </div>

        <div class="reports">
        <div class="reports_div">
            <i class="fa-solid fa-shop"></i>
            <label class="reports_div_label">Negocios registrados:</label><asp:Label ID="lbl_negociosRegistrados" runat="server" Text=""></asp:Label>
         </div>
        <div class="reports_div"> 
            <i class="fa-solid fa-person-rays"></i>
            <label class="reports_div_label">Clientes registrados:</label><asp:Label ID="lbl_clientesRegistrados" runat="server" Text=""></asp:Label>
        </div>
        <div class="reports_div"> 
            <i class="fa-solid fa-pizza-slice"></i>
            <label class="reports_div_label">Pedidos realizados:</label><asp:Label ID="lbl_pedidosRealizaxdos" runat="server" Text="" Visible="True"></asp:Label>
        </div>
             </div>

</section>
        <div class="volver">
            <asp:Button ID="Button1" runat="server" Text="VOLVER"  CssClass="buton" OnClick="Button1_Click"/>
        </div>
        <div class="usuario-sticky">
            <asp:Label ID="lbl_usuarioR" runat="server" Text=""></asp:Label>
        </div>

         <script type="text/javascript">

             function alerta(mensaje) {
                 alert(mensaje);
             }

         </script>
    </form>
   
</body>
</html>

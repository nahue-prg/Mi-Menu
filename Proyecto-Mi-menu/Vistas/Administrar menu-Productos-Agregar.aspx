<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrar menu-Productos-Agregar.aspx.cs" Inherits="Vistas.Administrar_menu_Productos" %>

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
        <h1>Administrar menu/Agregar productos</h1>
    </section>

    <form id="form1" runat="server">

            <%-- AGREGAR PRODUCTO--%>
            <section class="formulario">
                <div class="formulario-Titulo">
                    <label>Agregar producto</label>
                </div>
                <div class="formulario-campo">
                    <label>Nombre</label>
                    <asp:TextBox ID="txt_nombreProducto" runat="server"></asp:TextBox>
                </div>
                <div class="formulario-campo">
                    <label for="txt_descripcionProducto">Descripcionn</label>
                    <asp:TextBox ID="txt_descripcionProducto" runat="server"></asp:TextBox>
                </div>
                <div class="formulario-campo">
                    <label>Elegir categoria</label>
                    <asp:DropDownList ID="ddl_ElegirCategoriaAgregarProducto" runat="server"></asp:DropDownList>
                </div>
                <div class="formulario-campo">
                    <label>Precio</label>
                    <asp:TextBox ID="txt_precio" runat="server" TextMode="Number"></asp:TextBox>
                </div>
                <label class="formulario-aclaracion">Imagen (Subir nueva o elegir ya cargada)</label>
                <div class="formulario-campo">
                    <label>Subir imagen</label>
                    <asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="True" CssClass="auto-style1" />
                </div>
                <div class="formulario-campo">
                    <label>Seleccionar imagen</label>
                    <asp:DropDownList ID="ddl_SeleccionarImagen" runat="server" OnSelectedIndexChanged="ddl_SeleccionarImagen_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="formulario-campo-boton">
                     <asp:Button ID="btn_AgregarProducto" runat="server" Text="AGREGAR PRODUCTO"  CssClass="buton" OnClick="btn_AgregarProducto_Click" />
                </div>
            </section>

         <%--CATEGORIA DE PRODUCTO--%>            <%--AGREGAR--%>
            <section class="formulario">
                <div class="formulario-Titulo">
                    <label>Agregar categoria</label>
                </div>
                <div class="formulario-campo">
                    <label>Nombre de categoria</label>
                    <asp:TextBox ID="txt_nombreCategoria" runat="server"></asp:TextBox>
                </div>
                <div class="formulario-campo-boton">
                    <asp:Button ID="btn_AgregarCategoria" runat="server" Text="AGREGAR CATEGORIA" CssClass="buton" OnClick="btn_AgregarCategoria_Click" />
                </div>
            </section>

            <%--ELIMINAR--%>
            
       <div class="usuario-sticky">
            <asp:Label ID="lbl_usuarioR" runat="server" Text=""></asp:Label>
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
    </form>
    <footer>

    </footer>
</body>
</html>

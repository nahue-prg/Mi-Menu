<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro negocio.aspx.cs" Inherits="Vistas.Registro_negocio" %>

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
        <h1>NEGOCIO/Registrar negocio</h1>
    </section>
    <form id="form1" runat="server">
            <section class="formulario">
                <div class="formulario-Titulo">
                    <label>Negocio</label>
                </div>
                <div class="formulario-campo">
                    <label>Nombre del negocio</label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <div class="formulario-campo">
                    <label>Cuit</label>
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </div>
                <div class="formulario-campo"<>
                    <label>Categoria</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Descripcion_negcat" DataValueField="IDCategoria_negcat"></asp:DropDownList>
                </div>
                <div class="formulario-campo">
                    <label>Calle y numero</label>
                    <asp:TextBox ID="TextBox8" runat="server" Width="125px"></asp:TextBox>
                </div>
                <div class="formulario-campo">
                    <label>Provincia</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="Nombre_prov" DataValueField="IDProvincia_prov" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="formulario-campo">
                    <label>Localidad</label>
                     <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="Nombre_loc" DataValueField="IDLocalidad_loc"></asp:DropDownList>
                </div>
                <div class="formulario-campo">
                    <label>Email</label>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Email"></asp:TextBox>
                </div>
                <div class="formulario-campo">
                    <label>Contraseña</label>
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="formulario-campo">
                    <label>Repetir contraseña</label>
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
                </div>
              <div class="formulario-campo-boton">
                  <asp:Button ID="Button1" runat="server" Text="Registrar negocio" OnClick="Button1_Click" CssClass="buton" ValidationGroup="1" />
              </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString4 %>" SelectCommand="SELECT * FROM [NegociosCategorias]"></asp:SqlDataSource>
                  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString4 %>" SelectCommand="SELECT * FROM [Provincias]"></asp:SqlDataSource>
                  <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString4 %>" SelectCommand="SELECT * FROM [Localidades] WHERE ([IDProvincia_loc] = @IDProvincia_loc)">
                      <SelectParameters>
                          <asp:ControlParameter ControlID="DropDownList2" Name="IDProvincia_loc" PropertyName="SelectedValue" Type="Int32" />
                      </SelectParameters>
                </asp:SqlDataSource>
               </section>      
         <div class="Aviso-error">
            <asp:Label ID="Label5" runat="server" CssClass="aviso"></asp:Label>
        </div>
        <div class="sugerencia">
            <asp:HyperLink ID="hlk_Sugerencia" runat="server" NavigateUrl="~/IniciarSesion_negocios.aspx" CssClass="link">Iniciar Sesion</asp:HyperLink>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox1" ErrorMessage="Complete el Nombre" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox12" ErrorMessage="Complete el cuit" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Elija una categoria" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox8" ErrorMessage="Complete la calle" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DropDownList2" ErrorMessage="Elija una provincia" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DropDownList3" ErrorMessage="Elija una localidad" Font-Size="0pt" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox3" ValidationGroup="1" ErrorMessage="Complete el email" Font-Size="0pt"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox12" ValidationExpression="^\d+$" ErrorMessage="Ingrese un cuit valido" ValidationGroup="1"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowModelStateErrors="False" ShowSummary="False" ValidationGroup="1" />
        
        <script type="text/javascript">

             function alerta(mensaje) {
                 alert(mensaje);
             }

        </script>
    </form>



</body>
</html>

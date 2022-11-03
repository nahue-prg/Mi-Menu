<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_AB-negocios.aspx.cs" Inherits="Vistas.Admin_AB_negocios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin AB Negocios</title>
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
        <h1>ADMINISTRADOR/Activar-Eliminar negocio</h1>
    </section>

    <form id="form1" runat="server">

        <div class="Activar-eliminar">
            <div class="Activar-eliminar_option">
                <asp:DropDownList ID="ddl_Accion" runat="server" CssClass="DDL">
                    <asp:ListItem Value="1">ACTIVAR</asp:ListItem>
                    <asp:ListItem Value="0">ELIMINAR</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="Activar-eliminar_option">
                <label>Buscar por ID:</label><asp:TextBox ID="txt_ID" runat="server"></asp:TextBox><asp:Button ID="btn_ID" runat="server" Text="Buscar" CssClass="buton" OnClick="btn_ID_Click" />
            </div>
            <div class="Activar-eliminar_option">
                <label>Buscar por CUIT:</label><asp:TextBox ID="txt_Cuit" runat="server"></asp:TextBox><asp:Button ID="btn_Cuit" runat="server" Text="Buscar" CssClass="buton" OnClick="btn_Cuit_Click"/>
            </div>
            <div class="Activar-eliminar_option mostrar ">
                <asp:Label ID="lbl_Mostrar" runat="server" Text=""></asp:Label>
            </div>
            <div class="Activar-eliminar_option">
                <asp:Button ID="btn_aplicar" runat="server" Text="Aplicar"  CssClass="buton" OnClick="btn_aplicar_Click"/>
            </div>
        </div>

        <div class="filtrar">
            <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txt_FiltrarxNombre" runat="server"></asp:TextBox>
            <asp:Button ID="btn_filtrarNombre" runat="server" Text="Filtrar" CssClass="buton" OnClick="btn_filtrarNombre_Click" />
        </div>
            
        <div class="gridView">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" OnPreRender="GridView1_PreRender">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="CUIT" HeaderText="CUIT" SortExpression="CUIT" />
                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
                <asp:BoundField DataField="DIRECCION" HeaderText="DIRECCION" SortExpression="DIRECCION" />
                <asp:BoundField DataField="MAIL" HeaderText="MAIL" SortExpression="MAIL" />
                <asp:CheckBoxField DataField="ESTADO" HeaderText="ESTADO" SortExpression="ESTADO" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString2 %>" SelectCommand="SELECT * FROM [VIEW_NEGOCIOS_ID_CUIT_NOMBRE_DIRECCION_MAIL_ESTADO]"></asp:SqlDataSource>

        <div class="volver">
        <asp:Button ID="Button3" runat="server" Text="Volver" CssClass="buton" OnClick="Button3_Click"  />
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

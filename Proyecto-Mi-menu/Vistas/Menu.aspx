<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Vistas.Menu_de_negocio" %>

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

    <form id="form1" runat="server">

        <section class="Menu-Listview">
        <asp:ListView ID="ListViewExterno" runat="server" OnDataBinding="ListViewExterno_DataBinding">
            
            <EmptyDataTemplate>
                <span>Error al cargar</span>
            </EmptyDataTemplate>

            <ItemTemplate>  
              <div class="categoria-Completa">
                <div class="categoria">
                    <asp:Label ID="lbl_CategoriaNombre" CssClass="Categoria" runat="server" Text='<%# Eval("[NOMBRE]") %>'></asp:Label>
                </div>
                
                <asp:Label ID="lbl_IDCategoria" runat="server" Text='<%# Eval("[ID CATEGORIA]") %>' Visible="False"></asp:Label>
                <div class="ListviewInterno-Productos">
                <asp:ListView ID="listViewInterno" runat="server" DataSourceID="SqlDataSource3">

                    <ItemTemplate>
                        <div class="listView-Menu_div">
                             <div class="listView-Menu_div_img">
                                <asp:Image ID="img_producto" runat="server" CssClass="lisview-menu-img" ImageUrl='<%# Eval("[IMAGEN]") %>' />
                            </div>
                            <div class="listView-Menu_div_items">
                                <div class="listView-Menu_div_items_nombre">
                                    <asp:Label ID="lbl_Nombre" runat="server" Text='<%# Eval("[NOMBRE]") %>'></asp:Label>
                                </div>
                                <div class="listView-Menu_div_items_descripcion">
                                    <asp:Label ID="Descripcion" runat="server" Text='<%# Eval("[DESCRIPCION]") %>'></asp:Label>
                                </div>
                                <div class="listView-Menu_div_items_precio">
                                    <asp:Label ID="Precio" runat="server" Text='<%#"$ " + Eval("[PRECIO]") %>'></asp:Label>
                                </div>
                            </div>
                            <div class="listView-Menu_div_items_botones">
                                <asp:Button ID="btn_SumarAlCarrito" runat="server" Text="+" CommandName="AlCarrito" CssClass="buton buton-productos" CommandArgument='<%# Eval("[ID PRODUCTO]") + "-"+ Eval("[NOMBRE]") + "-" +Eval("[PRECIO]") %>' OnClick="btn_SumarAlCarrito_Click" />
                                <asp:Button ID="Button1" runat="server" Text="-" CommandName="AlCarrito" CssClass="buton buton-productos menos" CommandArgument='<%# Eval("[ID PRODUCTO]") %>' OnClick="Button1_Click" OnClientClick=" Confirmacion('Desea borrar el producto seleccionado?')" />
       
                            </div>
                        </div>
                    </ItemTemplate>
                    
                </asp:ListView>
                  </div>
                  </div>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString3 %>" SelectCommand="select * from VIEW_PRODUCTOS_IDCATEGORIA_IDPRODUCTO_IDNEGOCIO_NOMBRE_DESCRIPCION_IMAGEN_PRECIO_ESTADO WHERE ([ID CATEGORIA] = @ID_CATEGORIA) AND ESTADO = 1">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbl_IDCategoria" Name="ID_CATEGORIA" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

            </ItemTemplate>

        </asp:ListView>
            
        </section>
       <div class="div_realizarPedido">
            <asp:Button ID="Button2" runat="server" Text="Ir al carrito"  CssClass="buton realizarPedido" OnClick="Button2_Click"/>

           <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#ff441f" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" CssClass="carrito-gridView">
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
        <div class="usuario-sticky">
            <asp:Label ID="lbl_usuarioR" runat="server" Text=""></asp:Label>
        </div>
        
    </form>
</body>
</html>

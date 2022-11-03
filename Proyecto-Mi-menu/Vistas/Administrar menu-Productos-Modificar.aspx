<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrar menu-Productos-Modificar.aspx.cs" Inherits="Vistas.Administrar_menu_Productos_Modificar" %>

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
        <h1>NEGOCIO/Modificar productos</h1>
    </section>
    <form id="form1" runat="server">


        <asp:GridView ID="grd_EditarProductos" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" PageSize="5" CssClass="gridView" OnRowCancelingEdit="grd_EditarProductos_RowCancelingEdit" OnRowEditing="grd_EditarProductos_RowEditing" OnRowUpdating="grd_EditarProductos_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnPageIndexChanged="grd_EditarProductos_PageIndexChanged">

            <Columns>
                <asp:TemplateField HeaderText="ID PRODUCTO">
                    <ItemTemplate>
                        <asp:Label ID="lbl_IDProducto" runat="server" Text='<%# Bind("[ID PRODUCTO]") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="NOMBRE">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_nombreEdicion" runat="server" Text='<%# Bind("Nombre") %>' MaxLength="30"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="DESCRIPCION">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DESCRIPCION") %>'></asp:Label>
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txt_DescripcionEdicion" runat="server" Text='<%# Bind("DESCRIPCION") %>' MaxLength="40"></asp:TextBox>
                    </EditItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="IMAGEN">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("IMAGEN") %>'  Height="100px" Width="100px" ImageAlign="Middle" />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_ImagenesEdicion" runat="server" DataSourceID="SqlDataSource1" DataTextField="IMAGEN" DataValueField="IMAGEN"  AutoPostBack="True" OnDataBound="ddl_ImagenesEdicion_DataBound" ></asp:DropDownList>
                        <asp:Image ID="Image2" runat="server" Height="60px" ImageUrl='<%# Bind("IMAGEN") %>' Width="60px"  />
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("[ID NEGOCIO]") %>'  Visible="False"></asp:Label>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString4 %>" SelectCommand="SELECT [IMAGEN] FROM [View_Productos_IMAGEN_IDNEGOCIO] WHERE ([IDNEGOCIO] = @IDNEGOCIO)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="Label6" Name="IDNEGOCIO" PropertyName="Text" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                      <%--  ImageUrl='<%# Bind("IMAGEN") %>'--%>
                       <%-- DESKTOP-HJGVA31\SQLEXPRESS--%>
                    </EditItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="CATEGORIA">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CATEGORIA") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("[ID NEGOCIO]") %>' Visible="False"></asp:Label>
                        <asp:DropDownList ID="ddl_CategoriasEdicion" runat="server" DataSourceID="SqlDataSource2" DataTextField="NOMBRE" DataValueField="ID"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString3 %>" SelectCommand="SELECT [ID], [NOMBRE] FROM [View_PRODUCTOSCATEGORIA_ID_NOMBRE_ID_NEGOCIO] WHERE ([ID_NEGOCIO] = @ID_NEGOCIO) AND [ESTADO] = 1">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="Label7" Name="ID_NEGOCIO" PropertyName="Text" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="PRECIO">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("PRECIO") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_EdicionPrecio" runat="server" Text='<%# Bind("PRECIO") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ESTADO">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ESTADO") %>' Enabled="False" Height="40px" Width="40px" />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_EstadoEdicion" runat="server" OnDataBinding="ddl_EstadoEdicion_DataBinding"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

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

         

        <div class="formularios-horizontal">

            <section class="formulario">
                <div class="formulario-Titulo">
                    <label>Eliminar producto</label>
                </div>
                <div class="formulario-campo">
                    <label>Seleccione el producto</label>
                    <asp:DropDownList ID="ddl_producto" runat="server"></asp:DropDownList>
                </div>
                <div class="formulario-campo-boton">
                    <asp:Button ID="btn_EliminarProducto" runat="server" Text="ELIMINAR PRODUCTO"  CssClass="buton"  OnClientClick="return Confirmacion('Desea eliminar este producto? No podra recuperarlo');" OnClick="btn_EliminarProducto_Click"/>
                </div>
                </section>

        <section class="formulario">
                <div class="formulario-Titulo">
                    <label>Desactivar categoria</label>
                </div>
                <div class="formulario-campo">
                    <label>Seleccione la categoria</label>
                    <asp:DropDownList ID="ddl_ElegirCategoriaEliminarCategoria" runat="server"></asp:DropDownList>
                </div>
                <div class="formulario-campo-boton">
                    <asp:Button ID="btn_EliminarCategoria" runat="server" Text="ELIMINAR CATEGORIA"  CssClass="buton" OnClick="btn_EliminarCategoria_Click" OnClientClick="return Confirmacion(' Desea desactivar esta categoria? Los productos vinculados no se mostraran en el menu');"/>
                </div>
                </section>

        <section class="formulario">
                <div class="formulario-Titulo">
                    <label>Activar categoria</label>
                </div>
                <div class="formulario-campo">
                    <label>Seleccione la categoria</label>
                    <asp:DropDownList ID="ddl_activarCategoria" runat="server"></asp:DropDownList>
                </div>
                <div class="formulario-campo-boton">
                    <asp:Button ID="btn_activarCategoria" runat="server" Text="ACTIVAR CATEGORIA"  CssClass="buton"  OnClientClick="return Confirmacion('Desea activar esta categoria? Los productos vinculados se mostraran nuevamente en el menu');" OnClick="btn_activarCategoria_Click"/>
                </div>
                </section>

       
            </div>
      <%--  /*
        <section class="formulario">
            <div class="formulario-Titulo">
                <label>Modificar precio</label>
            </div>
            <div class="formulario-campo">
                <label>Selecciona producto</label>
                <asp:DropDownList ID="ddl_seleccionarProducto-Modprecio" runat="server"></asp:DropDownList>
            </div>
            <div class="formulario-campo">
                <label>Nuevo precio</label>
                <asp:TextBox ID="txt_NuevoPrecio" runat="server"></asp:TextBox>
            </div>
            <div class="formulario-campo-boton">
                <asp:Button ID="btn_ModficiarPrecio" runat="server" Height="26px" Text="Modificar" Width="67px" CssClass="buton" />
            </div>
            </section>

            
            
            <section class="formulario">
                <div class="formulario-Titulo">
                    <label>Activar productos</label>
                </div>
                <div class="formulario-campo">
                    <asp:DropDownList ID="ddl_ProductosDesactivados" runat="server"></asp:DropDownList>
                </div>
                <div class="formulario-campo-boton">
                    <asp:Button ID="btn_ActivarProducto" runat="server" Height="26px" Text="Activar" Width="67px" />
                </div>
            </section>

            
            PRODUCTOS ACTIVOS
            <asp:DropDownList ID="DropDownList7" runat="server"></asp:DropDownList>
            <asp:Button ID="Button10" runat="server" Height="26px" Text="Desactivar" Width="67px" />
            
            <section class="formulario">
            <div class="formulario-Titulo">
                <label>Eliminar producto</label>
            </div>
            <div class="formulario-campo">
                <label>Seleccionar producto</label>
                <asp:DropDownList ID="DropDownList1" runat="server"> </asp:DropDownList>
            </div>
            <div class="formulario-campo-boton">
                <asp:Button ID="Button4" runat="server" Height="26px" Text="Eliminar" Width="67px"  CssClass="buton"/>
            </div>
            </section>--%>
        
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
    <footer>

    </footer>
</body>
</html>

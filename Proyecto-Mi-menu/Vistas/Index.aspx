<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Vistas.Index" EnableEventValidation="false"%>
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

      <section class="Provincia">
              <i class="fa-solid fa-earth-americas"></i>
              <label>De que provincia sos?</label>
              <asp:DropDownList ID="ddl_Provincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Provincia_SelectedIndexChanged"></asp:DropDownList>
      </section>

      <section  class="busqueda-index">
          <div>
              <i class="fa-solid fa-shop"></i>
               <asp:TextBox ID="txt_busqueda" runat="server" placeHolder="Negocio.."></asp:TextBox>
          </div>

          <div>
              <i class="fa-solid fa-location-dot"></i>
              <asp:DropDownList ID="ddl_ubicacion" runat="server" OnSelectedIndexChanged="ddl_ubicacion_SelectedIndexChanged"></asp:DropDownList>
          </div>

          <div>
              <i class="fa-solid fa-burger"></i>
              <asp:DropDownList ID="ddl_Categorias" runat="server"></asp:DropDownList>
          </div>

          <div> 
              <asp:LinkButton ID="LinkButton1" runat="server" CssClass="boton-busqueda" OnClick="LinkButton1_Click">
                  <i class="fa-solid fa-magnifying-glass"></i>
                  <span>Buscar negocios</span>  
              </asp:LinkButton>
          </div>
      </section>

     <%-- View_Negocios_IDNEGOCIO_IDCATEGORIA_CATEGORIA_IDPROVINCIA_PROVINCIA_IDLOCALIDAD_LOCALIDAD_NOMBRE_IMAGEN_ESTADO--%>
  <section class="listView">
      <asp:ListView ID="ListView1" runat="server" OnPreRender="ListView1_PreRender" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">
          <GroupTemplate>
           <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server"></td>
                        </tr>
              </GroupTemplate>
          <ItemTemplate>
              <td runat="server" class="itemLV Negocio-Listview_ItemTemplate_div">
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="Negocio-Listview_imagen" CommandArgument='<%# Eval("[ID NEGOCIO]") +"-"+ Eval("[NOMBRE]") %>' ImageUrl='<%# Bind("[IMAGEN]") %>' OnCommand="ImageButton1_Command" CommandName="negocioElegido" />
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("[NOMBRE]") %>' CssClass="Negocio-Listview_Nombre"></asp:Label>
                 <asp:Label ID="Label2" runat="server" Text='<%# Eval("[PROVINCIA]") %>' CssClass="Negocio-Listview_Provincia"></asp:Label>
                  <asp:Label ID="Label3" runat="server" Text='<%# Eval("[LOCALIDAD]") %>' CssClass="Negocio-Listview_Localidad"></asp:Label>
              </td>
          </ItemTemplate>
          <EmptyDataTemplate>

          </EmptyDataTemplate>
          <LayoutTemplate>
              <table>
                    <tr runat="server">
                                <td runat="server" id="soyyo">
                                    <table id="groupPlaceholderContainer" runat="server">
                                        <tr id="groupPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>

              <tr runat="server">
                                <td runat="server" class="dataPager">
               <asp:DataPager ID="DataPager1" runat="server" PageSize="6" PagedControlID="ListView1" >
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="button" ShowNextPageButton="False" ButtonCssClass="buton lv dataPager" NextPageText="Siguiente &gt;&gt;" PreviousPageText="&lt;&lt; Anterior" />
                                            <asp:NumericPagerField />
                                            <asp:NextPreviousPagerField ButtonType="button" ShowPreviousPageButton="False" ButtonCssClass="buton lv dataPager" NextPageText="Siguiente &gt;&gt;" />
                                        </Fields>
                                    </asp:DataPager>
                   </td>
                            </tr>
                  </table>
          </LayoutTemplate>

      </asp:ListView>
  </section>

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
        <footer>

        </footer>
    </form>
</body>
</html>

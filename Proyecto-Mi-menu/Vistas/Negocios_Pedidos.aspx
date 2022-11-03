<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Negocios_Pedidos.aspx.cs" Inherits="Vistas.Negocios_Pedidos" %>

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
        <h1>Negocio/Pedidos</h1>
    </section>
    <asp:Label ID="lbl_idNegocio" runat="server" Font-Size="0pt"></asp:Label>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" CssClass="GridPedidos" runat="server" AllowPaging="True" BackColor="White" BorderColor="#FF441F" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" DataSourceID="SqlDataSource1">
            

            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#ff441f" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>

        <section class="Pedidos-Negocios">
            <div class="Idpedido">
                <label>Seleccione ID de pedido:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="ID_ped" DataValueField="ID_ped"></asp:DropDownList>
            </div>
            <div>
                <asp:Button ID="btn_verDetalle" runat="server" Text="Ver detalle" CssClass="buton" OnClick="btn_verDetalle_Click" />
            </div>
            <div>
                <label>Modificar estado:</label>
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource4" DataTextField="Nombre_pedEst" DataValueField="IdEstado_pedEst"></asp:DropDownList>
                <asp:Button ID="btn_ModificarEstado" runat="server" Text="Aplicar" CssClass="buton" OnClick="btn_ModificarEstado_Click" OnClientClick="Confirmacion('Desea modificar el estado del pedido?')" />
            </div>
        </section>

        <asp:GridView CssClass="GridPedidos"  ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="Id producto" DataSourceID="SqlDataSource3">
            <Columns>
                <asp:BoundField DataField="Id producto" HeaderText="Id producto" ReadOnly="True" SortExpression="Id producto" InsertVisible="False" />
                <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString4 %>" SelectCommand="select ID_ped as [Id pedido], Usuario_cli as [Usuario de cliente], Nombre_pedEst as [Estado], Modalidad_ped as [Modalidad], MedioPago_ped as [Medio de pago], Fecha_ped as [Fecha], Total_ped as [Total] from Pedidos inner join  PedidosEstados on Pedidos.Estado_ped = PedidosEstados.IdEstado_pedEst inner join Clientes  on Clientes.ID_cli = Pedidos.IDCliente_ped WHERE ([IDNegocio_ped] = @IDNegocio_ped)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbl_idNegocio" Name="IDNegocio_ped" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString4 %>" SelectCommand="SELECT [ID_ped] FROM [Pedidos] WHERE ([IDNegocio_ped] = @IDNegocio_ped)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbl_idNegocio" Name="IDNegocio_ped" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString4 %>" SelectCommand="select IDProducto_prod as [Id producto],Nombre_prod as [Producto],Cantidad_detPed as [Cantidad], PU_detPed as [Precio] from detallePedidos inner join Productos on DetallePedidos.IDProducto_detPed = Productos.IDProducto_prod where ([IDPedido_detPed] = @IDPedido_detPed2)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="IDPedido_detPed2" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MiMenuConnectionString4 %>" SelectCommand="SELECT * FROM [PedidosEstados]"></asp:SqlDataSource>
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

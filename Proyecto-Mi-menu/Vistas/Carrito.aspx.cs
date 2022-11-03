using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;


namespace Vistas
{
    public partial class Carrito : System.Web.UI.Page
    {
        //Session["Negocio-elegido"]
        //Session["Carrito"]
        public static string IdNegocio;
        public static string NombreNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
          //  Session["Cliente-ID"] = "2";


            if (!IsPostBack) {
                mostrarUsuario();
            if (Session["Carrito"] == null)
            {
                carritoVacio();
               mostrarMensaje("El carrito esta vacio");
                }
            else
            {

                carritoActivo();
                
            }
            }

        }
        public void mostrarUsuario()
        {
            if (Session["Cliente-usuario"] != null)
            {
                lbl_usuarioR.Text = Session["Cliente-usuario"].ToString();
            }
            else if (Session["Admin-usuario"] != null)
            {
                lbl_usuarioR.Text = Session["Admin-usuario"].ToString();
            }
            else if (Session["Negocio-nombre"] != null)
            {
                lbl_usuarioR.Text = Session["Negocio-nombre"].ToString();
            }
        }

        public void carritoActivo()
        {
            cargarNombreNegocio();
            lbl_negocio.Text = NombreNegocio;
            cargarGrid();
            GestionCarrito gestC = new GestionCarrito();
            lbl_total.Text = "Total : $";
            lbl_total.Text += gestC.carritoTotal(Session["Carrito"] as DataTable);
            Button1.Visible = true;
            lbl_negocio.Visible = true;
        }

        public void cargarNombreNegocio()
        {
            string negocio = Session["Negocio-elegido"] as string;
            string[] Datos = negocio.Split('-');
            IdNegocio = Datos[0];
            NombreNegocio = Datos[1];
        }

        public void cargarGrid()
        {
            GridView1.DataSource = Session["Carrito"] as DataTable;
            GridView1.DataBind();
        }

        public void carritoVacio()
        {
           
            Button1.Visible = false;
            lbl_total.Text = "El carrito esta vacio";
            lbl_negocio.Visible = false;
            btnList_MedioPago.Visible = false;
            btnList_Modalidad.Visible = false;
            Button2.Visible = false;
        }

        /*
           Session["Negocio-ID"] = ID;
           Session["Negocio-elegido"] = negocio;
         */



        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Cliente-ID"]==null)
            {
                mostrarMensaje("Debe iniciar sesion para realizar el pedido!");

            }
            else
            {
                gestionNegocio gestN = new gestionNegocio();
                GestionCarrito GESTu = new GestionCarrito();
                float total = float.Parse(GESTu.carritoTotal(Session["Carrito"] as DataTable));
                Pedidos pedido = new Pedidos(Int32.Parse(Session["Negocio-ID-menu"].ToString()), Int32.Parse(Session["Cliente-ID"].ToString()), 5, btnList_Modalidad.SelectedValue, btnList_MedioPago.SelectedValue, total);
                int ID= gestN.agregarPedido(ref pedido);

                if (gestN.agregarDetalle(ID, Session["Carrito"] as DataTable))
                {
                    mostrarMensaje("Pedido realizado con exito!");
                    carritoVacio();
                    Session["Carrito"] = null;
                    GridView1.Visible = false;

                }
                else
                {
                    mostrarMensaje("Error al realizar el pedido");
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Carrito"] = null;
            GridView1.Visible = false;
            carritoVacio();
        }
    }
}
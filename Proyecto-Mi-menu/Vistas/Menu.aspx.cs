using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace Vistas
{
    public partial class Menu_de_negocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarMenu();
                mostrarUsuario();
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
        public void cargarMenu()
        {
            string negocio = Request.QueryString["Negocio"];   //RECIBE EL ID DE NEGOCIO Y NOMBRE EN LA URL

            if (negocio == null)
            {
                mostrarMensaje("Error al cargar el negocio");
            }
            else
            {
                Session["Carrito"] = null;
                string[] Datos = negocio.Split('-');
                string ID = Datos[0];
                string Nombre = Datos[1];
                Session["Negocio-ID-menu"] = ID;
                Session["Negocio-elegido"] = negocio;
                cargarMenuListview(ID);
            }
        }


        public void cargarMenuListview(string ID)
        {
            gestionNegocio gestN = new gestionNegocio();
            ListViewExterno.DataSource= gestN.cargarListViewMenu(ID);
            ListViewExterno.DataBind();
        }


        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void ListViewExterno_DataBinding(object sender, EventArgs e)
        {

        }

        protected void btn_SumarAlCarrito_Click(object sender, EventArgs e)
        {
            var boton = sender as Button;
            if (Session["Carrito"] == null)
            {
                GestionUsuario gestU = new GestionUsuario();

                Session["Carrito"] = (DataTable)gestU.generarTablaCarrito();
            }
            
                                //SI YA SE ENCUENTRA EL PRODUCTO EN EL CARRITO MODIFICA DEVUELVE LA CANITDAD A MODIFICAR DE ESE PRODUCTO
            Session["Carrito"] = (DataTable)agregarRegistroCarrito(boton);
            

            GridView1.DataSource = Session["Carrito"] as DataTable;
            GridView1.DataBind();

            mostrarMensaje("Producto agregado con exito!");

        }



        public DataTable agregarRegistroCarrito(Button boton)
        {
            DataTable tabla = Session["Carrito"] as DataTable;
            GestionUsuario gestU = new GestionUsuario();

            String[] Producto = boton.CommandArgument.ToString().Split('-');   //El argumento del boton contiene ID-NOMBRE-PRECIO
            gestU.agregarFilaCarrito(ref tabla,Producto[0],Producto[1],Producto[2]);   ///LO PASA COMO PARAMETRO
            return tabla;
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Carrito"] == null)
            {
                mostrarMensaje("Aun no añadio ningun producto al carrito");
            }
            else
            {
                var boton = sender as Button;
                GestionUsuario gestn = new GestionUsuario();


                if (gestn.quitarProducto(boton.CommandArgument.ToString(), Session["Carrito"] as DataTable))
                {
                    GridView1.DataSource = Session["Carrito"] as DataTable;
                    GridView1.DataBind();
                    mostrarMensaje("Producto quitado con exito!");
                }
                else mostrarMensaje("El producto seleccionado no puede quitar ya que no se encuentra en el carrito");
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }
    }
}
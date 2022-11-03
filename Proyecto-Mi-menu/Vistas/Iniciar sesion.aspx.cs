using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Mi_cuenta : System.Web.UI.Page
    {

        /*
        -------SESSIONS CLIENTES
       Session["Cliente-ID"]
       Session["Cliente-usuario"]

       ------SESSIONS ADMINISTRADORES
       Session["Admin-usuario"]

      -----SESSIONS NEGOCIOS
       Session["Negocio-ID"]
       Session["Negocio-nombre"]

    
        */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                redirigir();

            }
        }

        public void redirigir()
        {
            if (Session["Admin-usuario"] != null)
            {
                Response.Redirect("admin.aspx");
            }
            if (Session["Cliente-ID"] != null)
            {
                Response.Redirect("MiCuenta_Cliente.aspx");
            }
            if (Session["Negocio-ID"] != null)
            {
                Response.Redirect("Mi cuenta negocio.aspx");
            }
        }
       

        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GestionSesiones gestS = new GestionSesiones();
            if (txt_usuario.Text.Length < 1 || txt_Clave.Text.Length < 1) mostrarMensaje("Ingrese usuario y contraseña para continuar");
            else
            {
                int id = gestS.ingresoCliente(txt_usuario.Text, txt_Clave.Text); 
                if (id!=-1)
                {
                    Session["Cliente-ID"] = id.ToString();
                    Session["Cliente-usuario"] = txt_usuario.Text;
                    Response.Redirect("Index.aspx");
                }
                else
                {

                    mostrarMensaje("CREDENCIALES NO VALIDAS, REVISE LOS INGRESOS");
                }
            }
            txt_usuario.Text = "";
            txt_Clave.Text = "";
        }
    }
}
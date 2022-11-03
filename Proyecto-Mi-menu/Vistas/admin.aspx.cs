using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class admin : System.Web.UI.Page
    {
        /*Session["Admin-usuario"] */
        /*Session["Admin-Clave"]*/
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarUsuario();

           // Session["Admin-usuario"] = "nahue";  ///LUEGO QUITAR 
            if (Session["Admin-usuario"] == null) { 
                mostrarMensaje("ACCESO DENEGADO, DEBE INICIAR SESION COMO ADMINISTRADOR PARA INGRESAR");
                Response.Redirect("adminEntrar.aspx.cs"); 
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

        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }

   

}
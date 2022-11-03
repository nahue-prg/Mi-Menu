using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Mi_cuenta_negocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //   Session["Negocio-ID"] = "2"; //ATENCION ---->>> RECORDAR COMENTAR/BORRAR ESTA LINEA --------- SOLO VALIDO EN PROCESO DE DESARROLLO ------------
            verificarAcceso();
            mostrarUsuario();
        }

        public void verificarAcceso()
        {
            if (Session["Negocio-ID"] == null)
            {
                mostrarMensaje("ACCESO DENEGADO");
                Response.Redirect("Index.aspx");
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

        protected void lkb_CerrarSession_Click(object sender, EventArgs e)
        {
            Session["Negocio-ID"] = null;
            Response.Redirect("Index.aspx");
        }
    }
}
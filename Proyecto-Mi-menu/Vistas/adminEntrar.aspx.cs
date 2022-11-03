using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class adminEntrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Admin-usuario"] != null) { Session["Admin-usuario"] = null;}
        }

        protected void btn_IniciarSesion_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            if (txt_clave.Text.Length < 1 || txt_usuario.Text.Length < 1) mostrarMensaje("Ingrese usuario y contraseña para continuar");
            else
            {
                if (adm.ingresoAdmin(txt_usuario.Text, txt_clave.Text))
                {
                    Session["Admin-usuario"] = txt_usuario.Text;
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    
                    mostrarMensaje("USUARIO NO ENCONTRADO");
                }
            }
            txt_usuario.Text = "";
            txt_clave.Text = "";

        }

        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

    }
}




/*Session["Admin-usuario"] */
/*Session["Admin-Clave"]*/
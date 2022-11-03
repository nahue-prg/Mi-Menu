using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class IniciarSesion_negocios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         ---------SESSIONS NEGOCIO
        Session["Negocio-ID"]
        Session["Negocio-nombre"]

         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            GestionSesiones gestS = new GestionSesiones();
            if (txt_mail.Text.Length < 1 || txt_clave.Text.Length < 1) mostrarMensaje("Ingrese usuario y contraseña para continuar");
            else
            {
                int ID = gestS.ingresoNegocio(txt_mail.Text, txt_clave.Text);
                if (ID !=-1)
                {
                    Session["Negocio-ID"] = ID.ToString();
                    Session["Negocio-nombre"] = gestS.buscarNegocioXid(ID);
                    Response.Redirect("Mi cuenta negocio.aspx");
                   // Response.Redirect("Index.aspx");
                }
                else
                {

                    mostrarMensaje("CREDENCIALES NO VALIDAS, VERIFIQUE LOS INGRESOS");
                }
            }
            txt_mail.Text = "";
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
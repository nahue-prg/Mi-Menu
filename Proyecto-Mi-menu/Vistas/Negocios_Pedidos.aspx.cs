using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Negocios_Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView2.Visible = false;

           // Session["Negocio-ID"] = "2"; //ATENCION ---->>> RECORDAR COMENTAR/BORRAR ESTA LINEA --------- SOLO VALIDO EN PROCESO DE DESARROLLO ------------

            if (!IsPostBack)
            {
                mostrarUsuario();
                if (Session["Negocio-ID"] != null)
                {
                    lbl_idNegocio.Text = Session["Negocio-ID"].ToString();
                }
                else
                {
                    mostrarMensaje("Inicie sesion para ingresar");
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

        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void btn_verDetalle_Click(object sender, EventArgs e)
        {
            GridView2.DataBind();
            GridView2.Visible = true;
        }

        protected void btn_ModificarEstado_Click(object sender, EventArgs e)
        {
            string idPedido = DropDownList1.SelectedValue;
            string estado = DropDownList2.SelectedValue;
            gestionNegocio gestN = new gestionNegocio();
            if (gestN.ModificarEstadoPedido(idPedido, estado))
            {
                GridView1.DataBind();
                mostrarMensaje("Estado modificado con exito!");
            }
            else mostrarMensaje("Error al modificar el estado");
        }
    }
}
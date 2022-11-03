using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Admin_AB_negocios : System.Web.UI.Page
    {
        
        static string Identificador;
        static bool encontrado = false;
        static bool filtro = false;
        static Gestion_SqlDataSource gestionsql = new Gestion_SqlDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarUsuario();
          //  Session["Admin-usuario"] = "2";    //ATENCION ---->>> RECORDAR COMENTAR/BORRAR ESTA LINEA --------- SOLO VALIDO EN PROCESO DE DESARROLLO ------------

            if (Session["Admin-usuario"] == null)
            {
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
        protected void btn_ID_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            lbl_Mostrar.Text= adm.negocio_CuitYnombre_porID(txt_ID.Text);
            if (lbl_Mostrar.Text.Length > 0 && lbl_Mostrar.Text != "No encontrado")
            {
                encontrado = true;
                Identificador = txt_ID.Text;
            }

            else
            {
                encontrado = false;
                Identificador = "";
            }
            txt_ID.Text = "";
            txt_Cuit.Text = "";
        }


        protected void btn_Cuit_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            lbl_Mostrar.Text = adm.negocio_CuitYnombre_porCUIT(txt_Cuit.Text);
            if (lbl_Mostrar.Text.Length > 0 && lbl_Mostrar.Text != "No encontrado")
            {
                encontrado = true;
                Identificador = adm.buscarIDxCUIT(txt_Cuit.Text);
            }
            else
            {
                encontrado = false;
                Identificador = "";
            }
            txt_ID.Text = "";
            txt_Cuit.Text = "";
        }


        protected void btn_aplicar_Click(object sender, EventArgs e)
        {

            if (!encontrado)
            {
                mostrarMensaje("Error al modificar registros, primero debe buscar un negocio.");
            }
            else
            {
                Admin adm = new Admin();
                int estadoActual = adm.Negocio_chequearEstado(Identificador);
                int estadoElegido = Int32.Parse(ddl_Accion.SelectedValue);
                

                if (estadoElegido ==estadoActual )
                {
                        mostrarMensaje("El negocio ya se encuentra en el estado elegido(activo/baja logica), no es posible modificarlo.");
                    lbl_Mostrar.Text = "";
                    encontrado = false;
                }
                else
                {
                    if (adm.NEGOCIO_cambiarEstado(Int32.Parse(Identificador), estadoElegido)) { 
                        mostrarMensaje("Negocio modificado con exito");
                        GridView1.DataBind();
                        lbl_Mostrar.Text = "";
                    }
                    else mostrarMensaje("Error al modificar negocio");
                }
                encontrado = false;
                Identificador = "0";
            }

        }

        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }



        protected void btn_filtrarNombre_Click(object sender, EventArgs e)
        {
            if (txt_FiltrarxNombre.Text.Length>0)
            {
                
                gestionsql.Negocio_filtrarPorNombre(txt_FiltrarxNombre.Text);
                filtro = true;
            }

            else
            {
                GridView1.DataBind();
            }
            txt_FiltrarxNombre.Text = "";
            lbl_Mostrar.Text = "";
        }


        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (filtro) {
                if (gestionsql.contarRegistros())
                {
                    SqlDataSource1.SelectCommand = gestionsql.Consulta;
                }
                else
                {
                    mostrarMensaje("No se encontro negocio con el nombre ingresado");
                }
                filtro = false;
                }
            
        }
    }
}
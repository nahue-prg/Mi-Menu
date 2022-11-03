using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Admin_AB_clientes : System.Web.UI.Page
    {
        static string Identificador;
        static bool encontrado = false;
        Gestion_SqlDataSource gestionsql = new Gestion_SqlDataSource();
        static bool filtro = false;
        /*Session["Admin-usuario"] */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin-usuario"] == null)
            {
                mostrarMensaje("ACCESO DENEGADO, DEBE INICIAR SESION COMO ADMINISTRADOR PARA INGRESAR");
                Response.Redirect("adminEntrar.aspx");
            }

        }

        protected void btn_ID_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            lbl_Mostrar.Text = adm.Cliente_mailYusuario_porID(txt_ID.Text);
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
            txt_Usuario.Text = "";
        }


        protected void btn_usuario_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            string ID = adm.CLIENTE_buscarIDxUsuario(txt_Usuario.Text);
            lbl_Mostrar.Text = adm.Cliente_mailYusuario_porID(txt_ID.Text);

            if (lbl_Mostrar.Text.Length > 0 && lbl_Mostrar.Text != adm.Error)
            {
                encontrado = true;
                Identificador = ID;
            }

            else
            {
                
                encontrado = false;
                Identificador = "";
            }
            txt_ID.Text = "";
            txt_Usuario.Text = "";
        }


        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void btn_aplicar_Click(object sender, EventArgs e)
        {
            if (!encontrado)
            {
                mostrarMensaje("Error al modificar registros, primero debe buscar un cliente.");
            }
            else
            {
                Admin adm = new Admin();
                int estadoActual = adm.Cliente_chequearEstado(Identificador);
                int estadoElegido = Int32.Parse(ddl_Accion.SelectedValue);

                if (estadoElegido == estadoActual)
                {
                    mostrarMensaje("El negocio ya se encuentra en el estado elegido(activo/baja logica), no es posible modificarlo.");
                    lbl_Mostrar.Text = "";
                    encontrado = false;
                }
                else
                {
                    if (adm.CLIENTE_cambiarEstado(Int32.Parse(Identificador), estadoElegido))
                    {
                        mostrarMensaje("Cliente modificado con exito");
                        GridView1.DataBind();
                        lbl_Mostrar.Text = "";
                    }
                    else mostrarMensaje("Error al modificar cliente");

                    encontrado = false;
                    Identificador = "0";
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void btn_filtrarxUsuario_Click(object sender, EventArgs e)
        {
            if (txt_FiltrarxUsuario.Text.Length > 0)
            {
                gestionsql.Cliente_filtrarPorUsuario(txt_FiltrarxUsuario.Text);
                filtro = true;
            }
            else
            {
                GridView1.DataBind();
            }
            txt_FiltrarxUsuario.Text = "";
            lbl_Mostrar.Text = "";
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (filtro)
            {
                if (gestionsql.contarRegistros())
                {
                    SqlDataSource1.SelectCommand = gestionsql.Consulta;
                }
                else
                {
                    mostrarMensaje("No se encontro usuario con el nombre ingresado");
                }
                filtro = false;
            }
        }
    }
}
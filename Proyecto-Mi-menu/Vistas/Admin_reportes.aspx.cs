using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using Negocio;




namespace Vistas
{
    public partial class Admin_reportes : System.Web.UI.Page
    {

        static public string fechaInicio="null";
        static public string fechaFinal="null";
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarUsuario();
            if (Session["Admin-usuario"] == null)
            {
                mostrarError("ACCESO DENEGADO, DEBE INICIAR SESION COMO ADMINISTRADOR PARA INGRESAR");
                Response.Redirect("adminEntrar.aspx.cs");
            }

            if (!IsPostBack)
            {
                cargarReportes();
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


        protected void btn_report_Click(object sender, EventArgs e)
        {

            if (IDdate_Desd.Text == "" || IDdate_hast.Text == "")
            {
                mostrarError("Ingrese fechas para filtrar!");
            }

            else
            {
               fechaInicio = IDdate_Desd.Text;
               fechaFinal = IDdate_hast.Text;

                string[] FechaFinal = fechaFinal.Split('-');      //DEVOLVIENDO ARRAY DIVIDIDO (AÑO, MES, DIA)
                string[] FechaInicio = fechaInicio.Split('-');

                DateTime desde = new DateTime(Int32.Parse(FechaInicio[0]), Int32.Parse(FechaInicio[1]), Int32.Parse(FechaInicio[2]));   //ALMACENANDO EN DATETIME
                DateTime hasta = new DateTime(Int32.Parse(FechaFinal[0]), Int32.Parse(FechaFinal[1]), Int32.Parse(FechaFinal[2]));

            if (desde > hasta)  //COMPARA LAS FECHAS MEDIANTE ESTRUCTURA DEL DATETIME
             {
                    mostrarError("La fecha de inicio es menor que la final, no es posible filtrar");
             }
             
                else
                {
                    Admin adm = new Admin();
                    lbl_negociosRegistrados.Text= adm.negocios_filtrarPorFecha(fechaInicio, fechaFinal);
                    lbl_clientesRegistrados.Text = adm.clientes_filtrarPorFecha(fechaInicio,fechaFinal);
                    lbl_pedidosRealizaxdos.Text = adm.pedidos_filtrarPorFecha(fechaInicio,fechaFinal);
                    
                }

            }

        }



        private void cargarReportes()
        {
            Admin adm = new Admin();
            lbl_negociosRegistrados.Text = adm.negociosRegistradosALL();
            lbl_clientesRegistrados.Text = adm.clientesRegistradosALL();
            lbl_pedidosRealizaxdos.Text = adm.pedidosRealizados();
        }



        private void mostrarError(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('"+error+"'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}
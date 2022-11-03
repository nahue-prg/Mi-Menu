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
    public partial class MiCuenta_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Cliente-usuario"] = "NahueMiMenu";
            //Session["Cliente-ID"] = "1";
           
            if (!IsPostBack)
            {
                mostrarUsuario();
                if (Session["Cliente-usuario"] != null)
                {
                    cargarDatos();
                }
                else
                {
                    lbl_nombreCliente.Text = "Inicie sesion para continuar";
                    btn_CerrarSesion.Visible = false;
                    btn_MisPedidos.Visible = false;
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


        public void cargarDatos()
        {
            lbl_nombreCliente.Text = "Usuario: " + Session["Cliente-usuario"].ToString();

        }

        protected void btn_MisPedidos_Click(object sender, EventArgs e)
        {
            cargarGridView();

        }

        public void cargarGridView()
        {
            GestionUsuario gUs = new GestionUsuario();
            GridView1.DataSource = gUs.cargarPedidos(Session["Cliente-ID"].ToString());
            GridView1.DataBind();
        }


        protected void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Cliente-usuario"] = null;
            Session["Cliente-ID"] = null;
            Response.Redirect("index.aspx");

        }
    }
}
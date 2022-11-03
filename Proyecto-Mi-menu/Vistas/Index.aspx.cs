using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                mostrarUsuario();
                if (Session["Cliente-usuario"] != null)
                {
                    
                    mostrarMensaje("Bienvenido " + Session["Cliente-usuario"]);
                }
                else
                {
                    
                }
                cargasIniciales();

            }
        }

        public void mostrarUsuario()
        {
            if (Session["Cliente-usuario"] != null) { 
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


        public void cargasIniciales()
        {
            cargarListView();
            cargarDDlProvincias(ddl_Provincia);
            ddl_ubicacion.Items.Insert(0, new ListItem("Localidad", "0"));
            cargarDDlCategorias();
        }

        public void cargarDDlCategorias()
        {
            gestionNegocio gestn = new gestionNegocio();
            DataTable tabla = gestn.cargarCategoriasNegocio();
            ListItem i;
            foreach (DataRow r in tabla.Rows)
            {
                i = new ListItem(r["NOMBRE"].ToString(), r["ID"].ToString());
                ddl_Categorias.Items.Add(i);
            }
            ddl_Categorias.Items.Insert(0, new ListItem("Categoria", "0"));

        }

        public void cargarDDlProvincias(DropDownList ddl)
        {
            gestionNegocio gestn = new gestionNegocio();
            DataTable tabla = gestn.cargarDDlProvincias();
            ListItem i;
            foreach (DataRow r in tabla.Rows)
            {
                i = new ListItem(r["NOMBRE"].ToString(), r["ID"].ToString());
                ddl.Items.Add(i);
            }

            ddl.Items.Insert(0, new ListItem("Elegi tu provincia!", "0"));

        }


        public void cargarListView()
        {
            gestionNegocio gestN = new gestionNegocio();
            ListView1.DataSource = gestN.Negocio_cargarListViewIndex();
            ListView1.DataBind();
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "negocioElegido")
            {
                //ID-NOMBRENEGOCIO
                mostrarMensaje(e.CommandArgument.ToString());
                Response.Redirect("Menu.aspx?Negocio=" + e.CommandArgument.ToString());
            }


        }

        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void ddl_ubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = ddl_Provincia.SelectedValue.ToString();

            if (ID != "0")
            {
                cargarLocalidades(ID);
            }
            else {
                ddl_ubicacion.Items.Clear();
                ddl_ubicacion.Items.Insert(0, new ListItem("Localidad", "0"));
            }
        }

        public void cargarLocalidades(string ID)
        {
            ddl_ubicacion.Items.Clear();
            gestionNegocio gestN = new gestionNegocio();
            DataTable tabla = gestN.Localidades_X_IDProvincia(ID);
            ListItem i;
            foreach (DataRow r in tabla.Rows)
            {
                i = new ListItem(r["NOMBRE"].ToString(), r["ID"].ToString());
                ddl_ubicacion.Items.Add(i);
            }

            ddl_ubicacion.Items.Insert(0, new ListItem("Localidad", "0"));
        }

        protected void ListView1_PreRender(object sender, EventArgs e)
        {


        }

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            //Establecer paginación en el control DataPager
            ((DataPager)ListView1.FindControl("DataPager1")).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            //DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, False)

            /// Enlazar el control ListView a datos
            cargarListView();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            bool filtro = false;
            string condicion="";
            filtrado(ref condicion, ref filtro);
            //select* from View_Negocios_IDNEGOCIO_IDCATEGORIA_CATEGORIA_IDPROVINCIA_PROVINCIA_IDLOCALIDAD_LOCALIDAD_NOMBRE_IMAGEN_ESTADO where[ID CATEGORIA] = 2 AND[ID LOCALIDAD] = 1 AND NOMBRE LIKE 'R%'
            if (filtro)
            {
                cargarListView(condicion);
                if (ListView1.Items.Count == 0)
                {
                    mostrarMensaje("No se encontraron resultados con los filtros ingresados");
                    cargarListView();
                }
            }
            else cargarListView();
        }

        public void filtrado(ref string condicion, ref bool filtro)
        {
            condicion = "Where ";

            if (ddl_Provincia.SelectedValue!="0" && ddl_Provincia.SelectedValue != "")
            {
                filtro = true;
                condicion += "[ID PROVINCIA] = " + ddl_Provincia.SelectedValue;
                ddl_Provincia.SelectedIndex = 0;
            }

            if (ddl_ubicacion.SelectedValue != "0" && ddl_ubicacion.SelectedValue != "")
            {
                if (filtro)
                {
                    condicion += " AND";
                }
                filtro = true;
                condicion += " [ID LOCALIDAD] = " + ddl_ubicacion.SelectedValue;
                ddl_ubicacion.SelectedIndex = 0;
            }

            if (txt_busqueda.Text.Trim().Length >= 1)
            {
                if (filtro)
                {
                    condicion += " AND";
                }
                condicion += " NOMBRE LIKE '" + txt_busqueda.Text + "%'";
                filtro = true;
                txt_busqueda.Text = "";
            }

            if (ddl_Categorias.SelectedValue != "0" && ddl_Categorias.SelectedValue != "")
            {
                if (filtro)
                {
                    condicion += " AND";

                }
                condicion += " [ID CATEGORIA] = " + ddl_Categorias.SelectedValue;
                filtro = true;
                ddl_Categorias.SelectedIndex = 0;
            }
        }

        public void cargarListView(string condicion)
        {
            gestionNegocio gestN = new gestionNegocio();
            ListView1.DataSource = gestN.Negocio_cargarListViewIndex(condicion);
            ListView1.DataBind();
        }
    }
}
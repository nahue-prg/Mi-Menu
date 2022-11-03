using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class Administrar_menu_Productos_Modificar : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session["Negocio-ID"] = "2";  //ATENCION ---->>> RECORDAR COMENTAR/BORRAR ESTA LINEA --------- SOLO VALIDO EN PROCESO DE DESARROLLO ------------
         
            verificarAcceso();
            if (!IsPostBack)
            {
                mostrarUsuario();
                cargaInicial();
            }
        }

        public void cargaInicial()
        {
            
            cargarDDL(ddl_ElegirCategoriaEliminarCategoria, "1");
            cargarDDL(ddl_activarCategoria, "0");
            cargarDDLProducto(ddl_producto);
            cargarGridView();
        }

        public void cargarDDL(DropDownList ddl, string estado)
        {
            try
            {
                ddl.Items.Clear();                                   //NECESARIO LIMPIARLA ANTES DE RECARGARLA
                gestionNegocio gestN = new gestionNegocio();
                DataTable tabla = gestN.cargarCategoriasDDL(Session["Negocio-ID"].ToString(), estado);
                ListItem i;
                foreach (DataRow r in tabla.Rows)
                {
                    i = new ListItem(r["NOMBRE"].ToString(), r["ID"].ToString());
                    ddl.Items.Add(i);
                }

                ddl.Items.Insert(0, new ListItem("--seleccionar--", "0"));
            }
            catch
            {
                ddl.Items.Insert(0, new ListItem("--seleccionar--", "0"));
            }
        }

        public void cargarDDLProducto(DropDownList ddl)
        {

            ddl.Items.Clear();
            try
            {
                gestionNegocio gestN = new gestionNegocio();
                DataTable tabla = gestN.cargarProductosDDL(Session["Negocio-ID"].ToString());
                ListItem i;
                foreach (DataRow r in tabla.Rows)
                {
                    string nombre = r["ID"].ToString()+" - " + r["NOMBRE"].ToString();
                    i = new ListItem(nombre, r["ID"].ToString());
                    ddl.Items.Add(i);
                }

                ddl.Items.Insert(0, new ListItem("--seleccionar--", "0"));
            }

            catch
            {
                ddl.Items.Insert(0, new ListItem("--seleccionar--", "0"));
            }
        }



        public void cargarGridView()
        {
            gestionNegocio gestN = new gestionNegocio();

            grd_EditarProductos.DataSource = gestN.Productos_CargarGridView(Session["Negocio-ID"].ToString());
            grd_EditarProductos.DataBind();
        }

        public void verificarAcceso()
        {
            if (Session["Negocio-ID"] == null)
            {
                mostrarMensaje("ACCESO DENEGADO");
                Response.Redirect("Index.aspx");
            }
        }

        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void grd_EditarProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grd_EditarProductos.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void grd_EditarProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grd_EditarProductos.EditIndex = -1;
            cargarGridView();
        }

        protected void grd_EditarProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string urlImage;

            var nombre = grd_EditarProductos.Rows[e.RowIndex].FindControl("txt_nombreEdicion") as TextBox;
            var descripcion = grd_EditarProductos.Rows[e.RowIndex].FindControl("txt_DescripcionEdicion") as TextBox;
            var ddl_imagenes = grd_EditarProductos.Rows[e.RowIndex].FindControl("ddl_ImagenesEdicion") as DropDownList;
            var imagen = grd_EditarProductos.Rows[e.RowIndex].FindControl("Image2") as Image;

            if (ddl_imagenes.SelectedValue == "0")
            {
                urlImage = imagen.ImageUrl;
            }
            else
            {
                urlImage = ddl_imagenes.SelectedValue;
                
            }

            var ddl_categoria = grd_EditarProductos.Rows[e.RowIndex].FindControl("ddl_CategoriasEdicion") as DropDownList;
            
            var precio =  grd_EditarProductos.Rows[e.RowIndex].FindControl("txt_EdicionPrecio") as TextBox;
           
            var ddl_Estado = grd_EditarProductos.Rows[e.RowIndex].FindControl("ddl_EstadoEdicion") as DropDownList;
            var idProducto = grd_EditarProductos.Rows[e.RowIndex].FindControl("lbl_IDProducto") as Label;
            
           


            if (verificarIngresos(nombre.Text, descripcion.Text, precio.Text))
            {
                float precio2 = float.Parse(precio.Text);
                Productos producto = new Productos(Int32.Parse(idProducto.Text),Int32.Parse(ddl_categoria.SelectedValue),Int32.Parse(Session["Negocio-ID"].ToString()),nombre.Text,descripcion.Text,urlImage,precio2,bool.Parse(ddl_Estado.SelectedValue));
                gestionNegocio gestn = new gestionNegocio();
                if (gestn.updateProducto(producto)) mostrarMensaje("Registo actualizado con exito");
                else mostrarMensaje("Registro actualizado con exito!");
                grd_EditarProductos.EditIndex = -1;
                cargarGridView();
            }
            
        }

        protected void ddl_ImagenesEdicion_DataBound(object sender, EventArgs e)
        {
            var ddl_imagenes = sender as DropDownList;
            ddl_imagenes.Items.Insert(0, new ListItem("------DEJAR IMAGEN ACTUAL------", "0"));
        }

        protected void ddl_EstadoEdicion_DataBinding(object sender, EventArgs e)
        {
            var ddlEstado = sender as DropDownList;
            ddlEstado.Items.Insert(0, new ListItem("ACTIVO", "True"));
            ddlEstado.Items.Insert(1, new ListItem("INACTIVO", "False"));
        }

        public bool verificarIngresos(string nombre, string descripcion, String precio)
        {
            bool verificador = true;
            try
            {
                float precio2 = float.Parse(precio);
            }
            catch
            {
                mostrarMensaje("Ingrese valores validos para el precio (SOLO NUMERICOS)");
                verificador = false;
            }
            if (nombre.Trim().Length < 1) { mostrarMensaje("Ingrese un nombre para continuar");verificador = false; }
            if (descripcion.Trim().Length < 1) { mostrarMensaje("Ingrese una descripcion para continuar"); verificador = false; }
            return verificador;
        }

        protected void btn_EliminarCategoria_Click(object sender, EventArgs e)
        {
            gestionNegocio gestN = new gestionNegocio();
            //mostrarMensaje("ADVERTENCIA: Todos los productos vinculados a esta categoria dejaran de mostrarse en el menu.");
            if (gestN.borrarCategoria(ddl_ElegirCategoriaEliminarCategoria.SelectedValue)) { mostrarMensaje("Categoria desactivada con exito!"); cargarDDL(ddl_ElegirCategoriaEliminarCategoria,"1"); cargarDDL(ddl_activarCategoria, "0"); }
            else mostrarMensaje("Error al desactivar la categoria");
        }

        protected void btn_activarCategoria_Click(object sender, EventArgs e)
        {
            gestionNegocio gestN = new gestionNegocio();
            //mostrarMensaje("ADVERTENCIA: Todos los productos vinculados a esta categoria dejaran de mostrarse en el menu.");
            if (gestN.ActivarCategoria(ddl_activarCategoria.SelectedValue)) { mostrarMensaje("Categoria activada con exito!"); cargarDDL(ddl_activarCategoria,"0"); cargarDDL(ddl_ElegirCategoriaEliminarCategoria, "1"); }
            else mostrarMensaje("Error al activar la categoria");
        }

        protected void btn_EliminarProducto_Click(object sender, EventArgs e)
        {
            gestionNegocio gestn = new gestionNegocio();
            if (ddl_producto.SelectedValue != "0")
            {
                if (gestn.EliminarProducto(ddl_producto.SelectedValue)){
                    cargarDDLProducto(ddl_producto);
                    cargarGridView();
                    mostrarMensaje("Producto eliminado con exito");
                }
                else
                {
                    mostrarMensaje("Error al eliminar producto");
                }
            }
        }

        protected void grd_EditarProductos_PageIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


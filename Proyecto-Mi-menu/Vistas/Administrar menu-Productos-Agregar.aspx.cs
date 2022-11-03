using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;
using System.IO;

namespace Vistas
{
    public partial class Administrar_menu_Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["Negocio-ID"] = "2";  //ATENCION ---->>> RECORDAR COMENTAR/BORRAR ESTA LINEA --------- SOLO VALIDO EN PROCESO DE DESARROLLO ------------
            verificarAcceso();
            mostrarUsuario();
            cargarImagenes();
            if (!IsPostBack)
            {
                cargarDDLs();
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
        public void cargarImagenes()
        {
            gestionNegocio gestN = new gestionNegocio();
            
            try
            {
                ddl_SeleccionarImagen.Items.Clear(); 
               
                DataTable tabla = gestN.Productos_cargarImagenes(Session["Negocio-ID"].ToString());
                ListItem i;
                foreach (DataRow r in tabla.Rows)
                {
                    i = new ListItem(r["IMAGEN"].ToString(), r["IMAGEN"].ToString());   //El valor es el path de la imagen seleccionada
                    ddl_SeleccionarImagen.Items.Add(i);
                }
                ddl_SeleccionarImagen.Items.Insert(0, new ListItem("--seleccionar--", "0"));
            }
            catch
            {
                //nada por aqui
            }
        }

        public void cargarDDLs()
        {
            cargarDDL(ddl_ElegirCategoriaAgregarProducto);

            
        }


        public void verificarAcceso()
        {
            if (Session["Negocio-ID"] == null)
            {
                mostrarMensaje("ACCESO DENEGADO");
                Response.Redirect("Index.aspx");
            }
        }

       

        protected void btn_AgregarCategoria_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_nombreCategoria.Text))
            {
                mostrarMensaje("Ingrese nombre de categoria!");
            }
            else
            {
                gestionNegocio gestn = new gestionNegocio();
                ProductosCategorias categoria = new ProductosCategorias(Int32.Parse(Session["Negocio-ID"].ToString()),txt_nombreCategoria.Text,1);

                if (gestn.AgregarCategoria(categoria)) { mostrarMensaje("La categoria fue agregada con exito!"); cargarDDLs(); txt_nombreCategoria.Text = ""; }
                else { mostrarMensaje("Error al agregar la categoria a la BDD"); txt_nombreCategoria.Text = ""; }
            }
        }

        public void cargarDDL(DropDownList ddl)
        {
            try
            {
                ddl.Items.Clear();                                   //NECESARIO LIMPIARLA ANTES DE RECARGARLA
                gestionNegocio gestN = new gestionNegocio();
                DataTable tabla = gestN.cargarCategoriasDDL(Session["Negocio-ID"].ToString(),"1");
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
                
            }
        }

      

        protected void btn_AgregarProducto_Click(object sender, EventArgs e)
        {

            if (verficiarAgregarProducto())
            {
                string path = imagen();

                if (path != "-1")
                {
                    Productos producto = new Productos(0,Int32.Parse(ddl_ElegirCategoriaAgregarProducto.SelectedValue), Int32.Parse(Session["Negocio-ID"].ToString()), txt_nombreProducto.Text, txt_descripcionProducto.Text, path, float.Parse(txt_precio.Text), true);     //SUMAR PARAMETROS AL OBJETO Y GUARDAR EN LA BDD
                    gestionNegocio gestN = new gestionNegocio();
                    if (gestN.agregarProducto(producto)) {
                        txt_descripcionProducto.Text = "";
                        txt_nombreCategoria.Text = "";
                        txt_nombreProducto.Text = "";
                        txt_precio.Text = "";
                        ddl_SeleccionarImagen.SelectedValue = "0";
                        cargarImagenes();

                        mostrarMensaje("Producto agregado con exito!"); }
                    else
                    {
                        mostrarMensaje("Ocurrio un error durante la carga del producto, no fue posible agregarlo.");
                    }
                }
            }
        }



        public bool verficiarAgregarProducto()
        {
            if (FileUpload2.HasFile && ddl_SeleccionarImagen.SelectedValue != "0")   //VERIFICA QUE NO SE CARGUE Y A LA VEZ SE ELIJA UNA IMAGEN DE LAS YA EXISTENTES
            {
                mostrarMensaje("No es posible seleccionar una imagen y subir una imagen al mismo tiempo. Seleccione o suba una imagen para proseguir o ninguna de las anteriores.");
                ddl_SeleccionarImagen.SelectedIndex = 0;
                return false;
            }

            else if (ddl_ElegirCategoriaAgregarProducto.SelectedValue == "0") { mostrarMensaje("Seleccione una categoria para agregar el producto"); return false; }
            else if (string.IsNullOrEmpty(txt_nombreProducto.Text) || string.IsNullOrEmpty(txt_precio.Text) || string.IsNullOrEmpty(txt_descripcionProducto.Text)) { mostrarMensaje("Complete todos los campos para continuar"); return false; }
            else if (!txt_precio.Text.All(Char.IsNumber)) {mostrarMensaje("El campo 'Precio' solo acepta numeros, corrija el campo para continuar");  return false;
        }
            else return true;
        }



        public string imagen()
        {

            if (FileUpload2.HasFile)
            {
               return verficarImagen();  //SI ES EXITOSO GUARDA LA IMAGEN EN EL SERVIDOR Y DEVUELVE EL PATH
                
                        
             }
            else
            {
                if (ddl_SeleccionarImagen.SelectedIndex != 0) return ddl_SeleccionarImagen.SelectedValue;
                else return imagenPorDefault();
            }


        }

        public string imagenPorDefault()
        {
            return "~/NegociosImagenes/Default.jpg";
        }


        public string verficarImagen() //RETORNA -1 SI HABIA UNA IMAGEN CARGADA Y NO SE PUDO SUBIR A LA BSS, RETORNA 0 SI NO HABIA UNA IMAGEN CARGADA, RETORNA EL PATH DE LA IMAGEN SI HABIA UNA IMAGEN CARGADA Y SE SUBIO EXITOSAMENTE
        {
            if (FileUpload2.HasFile)                     //GUARDANDO IMAGEN EN EL SERVIDOR -> DENTRO DE LA CARPETA VISTAS -> DENTRO DE LA CARPETA NEGOCIOSIMAGENES
            {
                string extension = System.IO.Path.GetExtension(FileUpload2.FileName); ///OBTIENE LA EXTENSION DEL ARCHIVO.
                if (extension == ".jpg" || extension == ".png")
                {
                    string path = "~/ProductosImagenes/" + FileUpload2.FileName;   //path que guardaremos en la base de datos
                    if (!File.Exists(Server.MapPath(path)))  //SI NO EXISTE UN ARCHIVO CON EL NOMBRE VA A SUBIRLO
                    {
                        gestionNegocio gestN = new gestionNegocio();
                        FileUpload2.SaveAs(Server.MapPath(path));  //-->Guarda el archivo en la carpeta
                        return path;

                    }
                    else
                    {
                        mostrarMensaje("NO ES POSIBLE SUBIR LA IMAGEN, MODIFIQUE EL NOMBRE DEL ARCHIVO PARA CONTINUAR(DEBE SER UNICO EN LA BASE DE DATOS). CONSEJO: ANTEPONGA EL NOMBRE DE SU NEGOCIO O CUIT EN EL NOMBRE DEL ARCHIVO");
                        return "-1";
                    }
                }
                else
                {
                    mostrarMensaje("ERROR AL CARGAR LA IMAGEN SOLO SE PERMITEN ARCHIVOS CON EXTENSION .JPG O .PNG. LA EXTENSION DE SU ARCHIVO ES "+ System.IO.Path.GetExtension(FileUpload2.FileName));
                    return "-1";
                }
            }
            else
            {
                return "0";
            }

        }

        protected void ddl_SeleccionarImagen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile) {
                mostrarMensaje("No es posible selecccionar una imagen ya cargada y subir una nueva imagen al mismo tiempo");
                ddl_SeleccionarImagen.SelectedValue = "0";
            }
        }


        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

      /*  private void PedirConfirmacion(string mensaje)
        {
            string script = @"<script type='text/javascript'>
                            var seleccion = confirm('" + mensaje + "');return seleccion;  </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "confirm", script, false);
        }*/
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;   //LIBRERIA PARA MANEJO DE ARCHIVOS
using Negocio;

namespace Vistas
{
    public partial class Administrar_Menu_negocio : System.Web.UI.Page
    {

        
        


        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Session["Negocio-ID"] = "2"; //ATENCION ---->>> RECORDAR COMENTAR/BORRAR ESTA LINEA --------- SOLO VALIDO EN PROCESO DE DESARROLLO ------------
            //Session["Negocio-nombre"] = "Nahue";
            mostrarUsuario();
            verificarAcceso();
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

        protected void Button8_Click(object sender, EventArgs e)
        {

            if (FileUpload2.HasFile)                     //GUARDANDO IMAGEN EN EL SERVIDOR -> DENTRO DE LA CARPETA VISTAS -> DENTRO DE LA CARPETA NEGOCIOSIMAGENES
            {
                string extension = System.IO.Path.GetExtension(FileUpload2.FileName); ///OBTIENE LA EXTENSION DEL ARCHIVO.
                 if(extension==".jpg"|| extension == ".png")
                {
                    string path = "~/NegociosImagenes/" + FileUpload2.FileName;   //path que guardaremos en la base de datos
                    if (!File.Exists(Server.MapPath(path)))  //SI NO EXISTE UN ARCHIVO CON EL NOMBRE VA A SUBIRLO
                    {
                        gestionNegocio gestN = new gestionNegocio();
                        FileUpload2.SaveAs(Server.MapPath(path));  //path para encontrar carpeta desde la posicion actual


                        if (gestN.guardarPathImagen(Int32.Parse(Session["Negocio-ID"].ToString()), path)) mostrarMensaje("Imagen cargada con exito!");
                        else mostrarMensaje("Error al vincular el path de la imagen con el negocio en la BDD");



                    }
                    else
                    {
                        mostrarMensaje("YA EXISTE UN ARCHIVO CON EL MISMO NOMBRE, MODIFIQUE EL NOMBRE DEL ARCHIVO PARA CONTINUAR");
                    }
                }
                else
                {
                    mostrarMensaje("SOLO SE PERMITEN ARCHIVOS .JPG O .PNG");
                }
            }
            else
            {
                mostrarMensaje("No se selecciono archivo");
            }


        }

        public void verificarAcceso()
        {
            if (Session["Negocio-ID"] == null)
            {
                mostrarMensaje("ACCESO DENEGADO");
                Response.Redirect("Index.aspx");
            }
        }

        
        protected void Button7_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_nombre.Text))
            {
                mostrarMensaje("INTRODUZCA UN NOMBRE PARA CONTINUAR");
            }
            else
            {
                gestionNegocio gestN = new gestionNegocio();
                if (gestN.cambiarNombre(txt_nombre.Text, Session["Negocio-ID"].ToString())) mostrarMensaje("NOMBRE MODIFICADO CON EXITO!");
                else mostrarMensaje("ERROR AL MODIFICAR EL NOMBRE EN LA BDD");
            }


        }

       private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
}
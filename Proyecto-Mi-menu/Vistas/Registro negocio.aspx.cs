using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Registro_negocio : System.Web.UI.Page
    {

       static  GestionRegistros reg = new GestionRegistros();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox4.Text == TextBox5.Text)
            {
                if (TextBox4.Text.Contains(" "))
                {
                    Label5.Text = "No se permiten espacios en blanco en la contraseña!";
                }
                else { 
                    if (TextBox4.Text.Length >= 4) { 
                bool estado;
                estado = reg.agregarNegocio(Int32.Parse(DropDownList2.SelectedValue), Int32.Parse(DropDownList3.SelectedValue), Int32.Parse(DropDownList1.SelectedValue), TextBox12.Text, TextBox1.Text, TextBox8.Text, TextBox3.Text, TextBox4.Text, 1);
                
                        if (estado == true)
                             {
                                 Label5.Text = "Negocio registrado con exito";
                            limpiarControles();
                             }
                        else
                             {
                                 Label5.Text = "Ya existe el negocio";
                             }
                    }
                    else
                         {
                         Label5.Text = "Ingrese una contraseña mayor o igual a 4 carateres sin espacios en blanco";
                         }
                    }   
                
            }
            else
            {
                Label5.Text = "Las contraseñas no coinciden";
            }
        }

        public void limpiarControles()
        {
            TextBox1.Text = "";
            TextBox12.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox8.Text = "";
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
        }

        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Registro_cliente : System.Web.UI.Page
    {
        GestionRegistros reg = new GestionRegistros();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (TextBox6.Text == TextBox7.Text)
            {
                if (TextBox6.Text.Contains(" "))
                {
                    Label7.Text = "No se permiten espacios en blanco en la contraseña!";
                }
                else
                {
                    if (TextBox6.Text.Length >= 4)
                    {
                        Boolean estado = false;
                        estado = reg.agregarCliente(TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox1.Text, TextBox6.Text, 1);
                        if (estado == true)
                        {
                            Label7.Text = "Registro exitoso!";
                            limpiarControles();
                        }
                        else
                        {
                            Label7.Text = "Ya existe un usuario con ese nombre";
                        }

                    }
                    else
                    {
                        Label7.Text = "Ingrese una contraseña mayor o igual a 4 carateres sin espacios en blanco";
                    }
                }
            }
            else
            {
                Label7.Text = "Las contraseñas no coinciden";
            }
            
        }

        public void limpiarControles()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }

        private void mostrarMensaje(string error)   //Para que funcione es necesario insertar un script con una funcion Javascript en el html 
        {
            string script = @"<script type='text/javascript'>
                                        alerta('" + error + "'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
}
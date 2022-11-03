using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class Gestion_SqlDataSource
    {
        private string consulta;

        public Gestion_SqlDataSource(string consulta=null)
        {
            this.consulta = consulta;
        }

        public string Consulta { get => consulta; set => consulta = value; }

        public void Negocio_cargarTodas()
        {
            consulta = "SELECT * FROM VIEW_NEGOCIOS_ID_CUIT_NOMBRE_DIRECCION_MAIL_ESTADO";
        }

        public void Cliente_cargarTodas()
        {
            consulta = "select * from View_CLIENTES_ID_USUARIO_NOMBRE_APELLIDO_MAIL_ESTADO";
        }


        public void Negocio_filtrarPorNombre(string nombre)
        {
            if (nombre.Length > 0)
            {
                consulta = "SELECT * FROM VIEW_NEGOCIOS_ID_CUIT_NOMBRE_DIRECCION_MAIL_ESTADO where NOMBRE like '" + nombre + "%'";
            }
            else { Negocio_cargarTodas(); }
        }

        public void Cliente_filtrarPorUsuario(string usuario)
        {
            if (usuario.Length > 0)
            {
                consulta = "select * from View_CLIENTES_ID_USUARIO_NOMBRE_APELLIDO_MAIL_ESTADO where USUARIO LIKE '" + usuario + "%'"; 
            }
            else
            {
                Cliente_cargarTodas();
            }

        }

        public bool contarRegistros()
        {
            Conexion conexion = new Conexion();
            if (conexion.VerificarRegistros(consulta)) return true;
            else return false;
        }



    }
}

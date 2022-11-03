using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Negocio
{
    public class Admin
    {

        private string error;    /// <summary>
        /// Devuelve un mensaje de error en caso que la peticion no sea exitosa, se puede definir esta propiedad.
        /// </summary>

        public string Error { get => error; set => error = value; }

        public Admin(string error= "No encontrado")
        {
            this.error = error;
        }

        /*---------------REPORTES-------------------*/
        public string negociosRegistradosALL()
        {
            DataTable tabla = new DataTable();
            string consulta = "select count(IDNegocio_neg) as [NEGOCIOS REGISTRADOS] from Negocios";
            tabla = _consulta(consulta);
            return tabla.Rows[0]["NEGOCIOS REGISTRADOS"].ToString();
        }

        public string clientesRegistradosALL()
        {
           
            DataTable tabla = new DataTable();
            string consulta = "SELECT COUNT(ID_cli) as [CLIENTES REGISTRADOS] FROM Clientes";
            tabla = _consulta(consulta);
            return tabla.Rows[0]["CLIENTES REGISTRADOS"].ToString();
        }

        public string pedidosRealizados()
        {
           
            DataTable tabla = new DataTable();
            string consulta = "select count(ID_ped) as [PEDIDOS REALIZADOS] from Pedidos";
            tabla = _consulta(consulta);
            return tabla.Rows[0]["PEDIDOS REALIZADOS"].ToString();
        }

        public string pedidos_filtrarPorFecha(string desde, string hasta)  ///cual -> 0 = clientes , 1 = negocios, 2 = pedidos
        {
           string consulta = "select COUNT(Fecha_ped) as [PEDIDOS REALIZADOS] from Pedidos where Fecha_ped >= '"+ desde +"' AND Fecha_ped <= '"+ hasta+"'";
            DataTable tabla = new DataTable();
            tabla = _consulta(consulta);
               return tabla.Rows[0]["PEDIDOS REALIZADOS"].ToString();
        }

        public string negocios_filtrarPorFecha(string desde, string hasta)
        {
            string consulta = "select count(IDNegocio_neg) as [NEGOCIOS REGISTRADOS] from Negocios where Fecha_neg >= '"+desde+ "' AND Fecha_neg <= '"+ hasta+"'";
            DataTable tabla = new DataTable();
            tabla = _consulta(consulta);
            return tabla.Rows[0]["NEGOCIOS REGISTRADOS"].ToString();
        }

        public string clientes_filtrarPorFecha(string desde, string hasta)
        {
            string consulta = "select COUNT(FechaReg_Cli) as [CLIENTES REGISTRADOS] from Clientes where FechaReg_Cli >= '" + desde+ "' AND FechaReg_Cli <= '"+hasta+"'";
            DataTable tabla = new DataTable();
            tabla = _consulta(consulta);
            return tabla.Rows[0]["CLIENTES REGISTRADOS"].ToString();
        }

 /*-----------------------AB_CLIENTESYNEGOCIOS-----------------------------*/


        public string negocio_CuitYnombre_porID(string ID)
        {
            string consulta = "select CUIT, NOMBRE from View_NEGOCIO_cuitYnombre_PorID where ID = " + ID;
            Conexion conexion = new Conexion();
            
            try
            {
                DataTable tabla = conexion.EjecutarLectura(consulta);
                string CuitYNombre = tabla.Rows[0]["CUIT"].ToString();
                CuitYNombre += " - ";
                CuitYNombre += tabla.Rows[0]["NOMBRE"].ToString();
                return CuitYNombre;
            }
            catch
            {
                return error;
            }

        }

        public string Cliente_mailYusuario_porID(string ID)
        {
            string consulta = "select MAIL, USUARIO from View_CLIENTES_MAIL_USUARIO_ID where ID =" + ID;
            

            try
            {
                DataTable tabla = _consulta(consulta);
                string MailyUsuario = tabla.Rows[0]["MAIL"].ToString() + " - " + tabla.Rows[0]["USUARIO"].ToString();
                return MailyUsuario;
            }
            catch
            {
                return error;
            }

        }

        public string CLIENTE_buscarIDxUsuario(string usuario)
        {
            string consulta = "select ID from View_CLIENTES_ID_USUARIO where USUARIO = '" +usuario +"'";
            
            try
            {
                DataTable tabla = _consulta(consulta);
                return tabla.Rows[0]["ID"].ToString();
            }
            catch
            {
                return error;
            }

        }

        public string negocio_CuitYnombre_porCUIT(string CUIT)
        {
            string consulta = "select * from View_NEGOCIO_cuitYnombre_PorCUIT where CUIT = '" + CUIT + "'";
            Conexion conexion = new Conexion();
            
            try
            {
                DataTable tabla = conexion.EjecutarLectura(consulta);
                string CuitYNombre = tabla.Rows[0]["CUIT"].ToString();
                CuitYNombre += " - ";
                CuitYNombre += tabla.Rows[0]["NOMBRE"].ToString();
                return CuitYNombre;
            }
            catch
            {
                return error;
            }
            
            
        }

        public string buscarIDxCUIT(string CUIT)
        {
            string consulta = "select ID from View_NEGOCIO_BuscarIDporCUIT where CUIT = '"+CUIT+"'";
            Conexion conexion = new Conexion();
            
            try
            {
                DataTable tabla = conexion.EjecutarLectura(consulta);
                string ID = tabla.Rows[0]["ID"].ToString();
                return ID;
            }
            catch
            {
                return error;
            }
        }

        public int Negocio_chequearEstado(string ID)
        {
            string consulta = "select ESTADO from View_NEGOCIOS_estadoPorId WHERE ID = " +ID;
            DataTable tabla = _consulta(consulta);
            if (tabla.Rows[0]["ESTADO"].ToString() == "True") return 1;
            else return 0;
        }

        public int Cliente_chequearEstado(string ID)
        {
            string consulta = "select ESTADO from View_CLIENTES_ID_ESTADO WHERE ID = "+ID ;
                DataTable tabla = _consulta(consulta);
            if (tabla.Rows[0]["ESTADO"].ToString() == "True") return 1;    //LOS CAMPOS BITS DE SQL DEVUELVEN TRUE OR FALSE -- NO 1 O 0
            else return 0;
        }

        public bool NEGOCIO_cambiarEstado(int Identificador,int estadoElegido)
        {
            string consulta = "update Negocios set Activo_neg = " + estadoElegido + " where IDNegocio_neg = " + Identificador;
            Conexion conexion = new Conexion();
            return conexion.EjecutarModificacion(consulta);
        }


        public bool CLIENTE_cambiarEstado(int Identificador, int estadoElegido)
        {
            string consulta = "update Clientes set Activo_Cli = " + estadoElegido + " where ID_cli = " + Identificador;
            Conexion conexion = new Conexion();
            return conexion.EjecutarModificacion(consulta);
        }


        /*--------------------GENERAL---------------------*/
        public DataTable _consulta(string consulta)
        {
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }

        /*--------------------ADMIN sesion----------------------*/
        public bool ingresoAdmin(string usuario,string clave)
        {
            string consulta = "select * from view_ADMINISTRADORES_USUARIO_CLAVE where USUARIO = '" + usuario + "' and CLAVE = '" + clave + "'";
            
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.VerificarRegistros(consulta)) return true;
                else return false;
            }

            catch
            {
                return false;
            }

            
            
        }

       

        



    }
}

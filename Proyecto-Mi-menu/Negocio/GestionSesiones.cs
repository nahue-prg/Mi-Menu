using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Negocio
{
    public class GestionSesiones
    {

        public DataTable _consulta(string consulta)
        {
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }

        public int ingresoCliente(string usuario,string clave)
        {

            string consulta = "select * from View_CLIENTES_ID_USUARIO_CLAVE  where USUARIO = '" + usuario + "' and CLAVE = '" + clave + "'";

            try
            {
                DataTable tabla =_consulta(consulta);
                string id = tabla.Rows[0]["ID"].ToString();
               if (id=="") {
                    return -1;
                }
                else
                {
                    return Int32.Parse(id);
                }

            }

            catch
            {
                return -1;
            }

        }
        
        public int ingresoNegocio(string mail, string clave)
        {
            string consulta = "select * from View_NEGOCIOS_ID_MAIL_NOMBRE_CLAVE where MAIL = '" +mail+"' and CLAVE = '" +clave+"'";
            try
            {
                DataTable tabla = _consulta(consulta);
                string id = tabla.Rows[0]["ID"].ToString();
                if (id == "")
                {
                    return -1;
                }
                else
                {
                    return Int32.Parse(id);
                }

            }

            catch
            {
                return -1;
            }

        }

        public string buscarNegocioXid(int ID)
        {
            string consulta = "select Nombre_neg as [NOMBRE] from Negocios where IDNegocio_neg = " + ID;
            try
            {
                DataTable tabla=  _consulta(consulta);
                return tabla.Rows[0]["NOMBRE"].ToString();
            }
            catch
            {
                return "null";
            }

        }


        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Negocio
{
    public class GestionUsuario
    {

        public DataTable generarTablaCarrito()
        {
            DataTable dt = new DataTable();

            DataColumn columna = new DataColumn("ID", System.Type.GetType("System.String")); //Obtiene el tipo de dato de la libreria system.string, el nombre de la columna es nombre
            dt.Columns.Add(columna);

            columna = new DataColumn("NOMBRE", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("PRECIO", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("CANTIDAD", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }

        public bool quitarProducto(string ID, DataTable tabla)
        {

            bool encontrado = false;
            int fila = 0;
            bool valorNulo = false;

            foreach (DataRow dr in tabla.Rows)    // Se verifica en todas las filas de la tabla que el id no este repetido, en caso de que este repetido se suma una unidad del producto         
            {
                if (ID == dr[0].ToString())
                {
                    int cantidad = Int32.Parse(tabla.Rows[fila]["CANTIDAD"].ToString()) - 1;
                    if (cantidad <= 0) { valorNulo = true; encontrado = true; break; } 
                    else tabla.Rows[fila]["CANTIDAD"] = cantidad.ToString();
                    encontrado = true;
                    
                }
                fila++;
            }

            if (valorNulo)
            {
                tabla.Rows[fila].Delete();
            }
            return encontrado;

        }


        public void agregarFilaCarrito(ref DataTable tabla, string ID, string NOMBRE, string precio)
        {

                 bool repetido = false;
                int fila = 0;
            string PRECIO = float.Parse(precio).ToString();

                foreach (DataRow dr in tabla.Rows)    // Se verifica en todas las filas de la tabla que el id no este repetido, en caso de que este repetido se suma una unidad del producto         
                {
                    if (ID == dr[0].ToString())     
                    {
                    int cantidad = Int32.Parse(tabla.Rows[fila]["CANTIDAD"].ToString()) + 1;
                    tabla.Rows[fila]["CANTIDAD"] = cantidad.ToString();
                    repetido = true;
                    }
                    fila++;
                }


            if (repetido == false)
            {
                DataRow dr = tabla.NewRow();
                dr["ID"] = ID;
                dr["NOMBRE"] = NOMBRE;
                dr["PRECIO"] = "$"+PRECIO;
                dr["CANTIDAD"] = "1";
                tabla.Rows.Add(dr);
            }
        }

      public DataTable cargarPedidos(string ID)
        {
            /*
             string consulta = "SELECT IDCategoria_negcat as ID, Descripcion_negcat as [NOMBRE] from NegociosCategorias";
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
             */
            Conexion conexion = new Conexion();
            string consulta = "SELECT  Nombre_neg as [Negocio] , Nombre_pedEst as [Estado] ,Modalidad_ped as [Modalidad], Fecha_ped as [Fecha], Total_ped as [Total] from Pedidos inner join Negocios on Pedidos.IDNegocio_ped = Negocios.IDNegocio_neg inner join PedidosEstados on PedidosEstados.IdEstado_pedEst = Pedidos.Estado_ped WHERE IDCliente_ped =" + ID;
            return conexion.EjecutarLectura(consulta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
       private SqlConnection conexion = new SqlConnection();


        public Conexion()
        {
            string ruta = "Data Source=DESKTOP-HJGVA31\\SQLEXPRESS;Initial Catalog=MiMenu;Integrated Security=True";
            conexion.ConnectionString = ruta;
        }


        public DataTable EjecutarLectura(string consultaSQL)  //Recibe la consulta y devuelve una DataTable con los datos almacenados.
        {
            conexion.Open();
            SqlDataAdapter adap = new SqlDataAdapter(consultaSQL, conexion);
            DataSet ds = new DataSet();
            adap.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public bool VerificarRegistros(string consulta)  //SERIA CONVENIENTE USARLO COMO CONTADOR Y NO BOOLEANO (MODIFICAR SI ES NECESARIO)
        {
            int contador = 0;
            DataTable data;
            data = EjecutarLectura(consulta);
            foreach (DataRow fila in data.Rows)
            {
                contador++;
            }
            if (contador > 0) return true;
            else return false;
        }


        public bool EjecutarModificacion(string consulta)  //Ejecuta modificaciones en la base de datos
        {
            SqlCommand comando = new SqlCommand();
            conexion.Open();
            comando.CommandText = consulta;
            comando.Connection = conexion;
            int filas = comando.ExecuteNonQuery();
            conexion.Close();
            if (filas > 0) { return true; }
            else { return false; }
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP) //Comando que recibe ya debe tener los parametros incluidos, nombre de procedimiento almacenado
        {
            int FilasCambiadas;
            SqlCommand cmd = new SqlCommand();
            conexion.Open();
            cmd = Comando;
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            conexion.Close();
            return FilasCambiadas;
        }

        public Boolean existe(String consulta)
        {

            Boolean estado = false;
            conexion.Open();
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            conexion.Close();
            return estado;
        }

    }
}

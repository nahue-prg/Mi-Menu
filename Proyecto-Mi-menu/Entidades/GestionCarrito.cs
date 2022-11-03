using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;


namespace Entidades
{
    public class GestionCarrito
    {

        public string carritoTotal(DataTable tabla)
        {

            float total = 0;
            float importe;

            foreach (DataRow dr in tabla.Rows)
            {

                string precio = dr["PRECIO"].ToString().Replace("$", "").Trim();
                string cantidad = dr["CANTIDAD"].ToString().Trim();
                //* Int32.Parse(cantidad);
                importe = float.Parse(precio) * float.Parse(cantidad); 
                total += importe;

            }

            return total.ToString(); 

        }

     




    }
}

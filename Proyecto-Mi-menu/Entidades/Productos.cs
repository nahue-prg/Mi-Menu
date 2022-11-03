using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Productos
    {
        private int IDProducto;
        private int IDCaterogia;
        private int IDnegocio;
        private string nombre;
        private string descripcion;
        private string imagen_path;
        private float precio;
        private bool activo;

        public Productos(int iDProducto=0, int iDCaterogia=0, int iDnegocio=0, string nombre="null", string descripcion="null", string imagen_path="", float precio=0f, bool activo=false)
        {
            IDProducto = iDProducto;
            IDCaterogia = iDCaterogia;
            IDnegocio = iDnegocio;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.imagen_path = imagen_path;
            this.precio = precio;
            this.activo = activo;
        }

        public int IDProducto1 { get => IDProducto; set => IDProducto = value; }
        public int IDCaterogia1 { get => IDCaterogia; set => IDCaterogia = value; }
        public int IDnegocio1 { get => IDnegocio; set => IDnegocio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Imagen_path { get => imagen_path; set => imagen_path = value; }
        public float Precio { get => precio; set => precio = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}

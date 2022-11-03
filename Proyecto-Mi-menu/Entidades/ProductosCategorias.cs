using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductosCategorias
    {
        private int idNegocio;
        private string nombre;
        private int activo;

        public ProductosCategorias(int idNegocio=0, string nombre="null", int activo=0)
        {
            this.idNegocio = idNegocio;
            this.nombre = nombre;
            this.activo = activo;
        }

        public int IdNegocio { get => idNegocio; set => idNegocio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Activo { get => activo; set => activo = value; }
    }
}

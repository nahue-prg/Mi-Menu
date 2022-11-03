using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class NegociosCategorias
    {
        private int IdCategoria;
        private string Descripcion;

        public NegociosCategorias(int idCategoria, string descripcion)
        {
            IdCategoria = idCategoria;
            Descripcion = descripcion;
        }

        public int IdCategoria1 { get => IdCategoria; set => IdCategoria = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class PedidosEstados
    {
        private int IDestado;
        private string nombre;

        public PedidosEstados(int iDestado, string nombre)
        {
            IDestado = iDestado;
            this.nombre = nombre;
        }

        public int IDestado1 { get => IDestado; set => IDestado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}

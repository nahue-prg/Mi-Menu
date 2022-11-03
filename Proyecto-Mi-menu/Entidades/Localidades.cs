using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Localidades
    {
        private int IDLocalidad;
        private Provincias provincia;
        private String Nombre;

        public Localidades(int iDLocalidad, Provincias provincia, string nombre)
        {
            IDLocalidad = iDLocalidad;
            this.provincia = provincia;
            Nombre = nombre;
        }

        public int IDLocalidad1 { get => IDLocalidad; set => IDLocalidad = value; }
      
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        internal Provincias Provincia { get => provincia; set => provincia = value; }
    }
}

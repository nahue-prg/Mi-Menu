using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Provincias
    {
        private int IDProvincia;
        private String Nombre;

        public Provincias(int iDProvincia, string nombre)
        {
            IDProvincia = iDProvincia;
            Nombre = nombre;
        }

        public int IDProvincia1 { get => IDProvincia; set => IDProvincia = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
    }
}

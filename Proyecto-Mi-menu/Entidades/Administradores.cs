using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Administradores
    {
        private int IDadmin;
        private string Usuario;
        private string clave;
        private int activo;

        public Administradores(int iDadmin, string usuario, string clave, int activo)
        {
            IDadmin = iDadmin;
            Usuario = usuario;
            this.clave = clave;
            this.activo = activo;
        }

        public int IDadmin1 { get => IDadmin; set => IDadmin = value; }
        public string Usuario1 { get => Usuario; set => Usuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public int Activo { get => activo; set => activo = value; }
    }
}

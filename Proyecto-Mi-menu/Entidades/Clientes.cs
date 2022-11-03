using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes
    {
        private int IDCliente;
        private String Nombre;
        private String Apellido;
        private String Mail;
        private String Celular;
        private String Usuario;
        private String Clave;
        private int activo;

        public Clientes( string nombre, string apellido, string mail, string celular, string usuario, string clave, int activo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Celular = celular;
            Usuario = usuario;
            Clave = clave;
            this.activo = activo;
        }

        public int IDCliente1 { get => IDCliente; set => IDCliente = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public string Mail1 { get => Mail; set => Mail = value; }
        public string Celular1 { get => Celular; set => Celular = value; }
        public string Usuario1 { get => Usuario; set => Usuario = value; }
        public string Clave1 { get => Clave; set => Clave = value; }
        public int Activo { get => activo; set => activo = value; }
    }
}

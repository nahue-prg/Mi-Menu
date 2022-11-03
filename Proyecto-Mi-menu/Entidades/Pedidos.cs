using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedidos
    {
        private int IDPedido;
        private int IDnegocio;
        private int idCliente;
        private int estado;
        private string modalidad;
        private string medioPago;
        private float Total;

        public Pedidos( int iDnegocio=0, int idCliente=0, int estado=0, string modalidad="", string medioPago="", float total=0)
        {
            
            IDnegocio = iDnegocio;
            this.idCliente = idCliente;
            this.estado = estado;
            this.modalidad = modalidad;
            this.medioPago = medioPago;
            Total = total;
        }

        
        public int IDnegocio1 { get => IDnegocio; set => IDnegocio = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Modalidad { get => modalidad; set => modalidad = value; }
        public string MedioPago { get => medioPago; set => medioPago = value; }
       
        public int Estado { get => estado; set => estado = value; }
        public float Total1 { get => Total; set => Total = value; }
        public int IDPedido1 { get => IDPedido; set => IDPedido = value; }
    }
}

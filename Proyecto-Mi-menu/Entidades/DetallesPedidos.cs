using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallesPedidos
    {
        private int IDpedido;
        private int IDProducto;
        private int Cantidad;
        private float PrecioUnitario;

        public DetallesPedidos(int iDpedido=0, int iDProducto=0, int cantidad=0, float precioUnitario=0)
        {
            IDpedido = iDpedido;
            IDProducto = iDProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        public int IDpedido1 { get => IDpedido; set => IDpedido = value; }
        public int IDProducto1 { get => IDProducto; set => IDProducto = value; }
        public int Cantidad1 { get => Cantidad; set => Cantidad = value; }
        public float PrecioUnitario1 { get => PrecioUnitario; set => PrecioUnitario = value; }
    }
}

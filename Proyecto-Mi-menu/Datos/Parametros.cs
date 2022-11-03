using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    
    public class Parametros
    {
        Conexion ds = new Conexion();
        /*
        public int agregarPedido(ref Pedidos pedido)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametros = new SqlParameter();

            parametros = comando.Parameters.Add("IDNEGOCIO", SqlDbType.Int);
            parametros.Value = pedido.IDnegocio1;

            parametros = comando.Parameters.Add("IDCLIENTE", SqlDbType.Int);
            parametros.Value = pedido.IdCliente;

            parametros = comando.Parameters.Add("ESTADO", SqlDbType.Int);
            parametros.Value = pedido.Estado;

            parametros = comando.Parameters.Add("MODALIDAD", SqlDbType.VarChar, 20);
            parametros.Value = pedido.Modalidad;

            parametros = comando.Parameters.Add("MEDIOPAGO", SqlDbType.VarChar, 20);
            parametros.Value = pedido.MedioPago;

            parametros = comando.Parameters.Add("TOTAL", SqlDbType.Money);
            parametros.Value = pedido.Total1;


            Conexion conexion = new Conexion();
            return conexion.EjecutarProcedimientoAlmacenado(comando, "SP_INSERTARPEDIDOS");
        }
        */
        public int agregarDetalle( DetallesPedidos detalleP)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametros = new SqlParameter();

            parametros = comando.Parameters.Add("IDPEDIDO", SqlDbType.Int);
            parametros.Value = detalleP.IDpedido1;

            parametros = comando.Parameters.Add("IDPRODUCTO", SqlDbType.Int);
            parametros.Value = detalleP.IDProducto1;

            parametros = comando.Parameters.Add("CANTIDAD", SqlDbType.Int);
            parametros.Value = detalleP.Cantidad1;

            parametros = comando.Parameters.Add("PU", SqlDbType.Money);
            parametros.Value = detalleP.PrecioUnitario1;


            Conexion conexion = new Conexion();
            return conexion.EjecutarProcedimientoAlmacenado(comando, "SP_INSERTARDETALLEPEDIDOS");
        }

        public int AgregarProductoCategoria(ProductosCategorias categoria)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametros = new SqlParameter();

            parametros = comando.Parameters.Add("IDNEGOCIO", SqlDbType.Int);
            parametros.Value = categoria.IdNegocio;

            parametros = comando.Parameters.Add("NOMBRE", SqlDbType.VarChar, 50);
            parametros.Value = categoria.Nombre.ToString();
           
            Conexion conexion = new Conexion();

            return conexion.EjecutarProcedimientoAlmacenado(comando,"SP_INSERTARPRODCAT");


        }

        public int agregarProducto(Productos producto)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametros = new SqlParameter();

            parametros = comando.Parameters.Add("IDPRODCAT", SqlDbType.Int);
            parametros.Value = producto.IDCaterogia1;

            parametros = comando.Parameters.Add("IDNEGOCIO", SqlDbType.Int);
            parametros.Value = producto.IDnegocio1;

            parametros = comando.Parameters.Add("NOMBRE", SqlDbType.VarChar, 30);
            parametros.Value = producto.Nombre;

            parametros = comando.Parameters.Add("DESCRIPCION", SqlDbType.Char, 40);
            parametros.Value = producto.Descripcion;

            parametros = comando.Parameters.Add("IMAGEN", SqlDbType.VarChar, 50);
            parametros.Value = producto.Imagen_path;

            parametros = comando.Parameters.Add("PRECIO", SqlDbType.Money);
            parametros.Value = producto.Precio;

            parametros = comando.Parameters.Add("ACTIVO", SqlDbType.Bit);
            parametros.Value = 1;

            Conexion conexion = new Conexion();
            return conexion.EjecutarProcedimientoAlmacenado(comando, "SP_INSERTARPRODUCTOS");
        }

        public Boolean existeCliente(Clientes cl)
        {
            String consulta = "Select * from Clientes where Usuario_cli= '" + cl.Usuario1 + "'";
            return ds.existe(consulta);
        }

        public int agregarCliente(Clientes cl)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosClienteAgregar(ref comando, cl);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SP_INSERTARCLIENTES");
        }

        private void ArmarParametrosClienteAgregar(ref SqlCommand Comando, Clientes cl)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@USUARIO", SqlDbType.Char);
            SqlParametros.Value = cl.Usuario1;
            SqlParametros = Comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = cl.Nombre1;
            SqlParametros = Comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            SqlParametros.Value = cl.Apellido1;
            SqlParametros = Comando.Parameters.Add("@MAIL", SqlDbType.VarChar);
            SqlParametros.Value = cl.Mail1;
            SqlParametros = Comando.Parameters.Add("@CELULAR", SqlDbType.Char);
            SqlParametros.Value = cl.Celular1;
            SqlParametros = Comando.Parameters.Add("@CLAVE", SqlDbType.Char);
            SqlParametros.Value = cl.Clave1;
            SqlParametros = Comando.Parameters.Add("@ACTIVO", SqlDbType.Bit);
            SqlParametros.Value = cl.Activo;
        }

        public Boolean existeNegocio(Negocios ng)
        {
            String consulta = "Select * from Negocios where Mail_neg='" + ng.Mail1 + "'";
            return ds.existe(consulta);
        }

        public int agregarNegocio(Negocios ng)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosNegocioAgregar(ref comando, ng);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SP_INSERTARNEGOCIOS");
        }

        private void ArmarParametrosNegocioAgregar(ref SqlCommand Comando, Negocios ng)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDPROVINCIA", SqlDbType.Int);
            SqlParametros.Value = ng.IDProvincia1;
            SqlParametros = Comando.Parameters.Add("@IDLOCALIDAD", SqlDbType.Int);
            SqlParametros.Value = ng.IDLocalidad1;
            SqlParametros = Comando.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
            SqlParametros.Value = ng.IDCategoria1;
            SqlParametros = Comando.Parameters.Add("@CUIT", SqlDbType.Char);
            SqlParametros.Value = ng.Cuit1;
            SqlParametros = Comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = ng.Nombre1;
            SqlParametros = Comando.Parameters.Add("@CALLE", SqlDbType.VarChar);
            SqlParametros.Value = ng.Calle1;
            SqlParametros = Comando.Parameters.Add("@IMAGEN", SqlDbType.VarChar);
            SqlParametros.Value = "~/NegociosImagenes/Default.jpg";
            SqlParametros = Comando.Parameters.Add("@MAIL", SqlDbType.VarChar);
            SqlParametros.Value = ng.Mail1;
            SqlParametros = Comando.Parameters.Add("@CLAVE", SqlDbType.Char);
            SqlParametros.Value = ng.Clave1;
            SqlParametros = Comando.Parameters.Add("@ACTIVO", SqlDbType.Bit);
            SqlParametros.Value = ng.Activo1;
        }

        public int updateProducto(Productos producto)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametros = new SqlParameter();

            parametros = comando.Parameters.Add("ID_PRODUCTO",SqlDbType.Int);
            parametros.Value = producto.IDProducto1;

            parametros = comando.Parameters.Add("ID_PRODCAT", SqlDbType.Int );
            parametros.Value = producto.IDCaterogia1;

            parametros = comando.Parameters.Add("NOMBRE", SqlDbType.VarChar,30);
            parametros.Value = producto.Nombre;

            parametros = comando.Parameters.Add("DESCRIPCION", SqlDbType.Char, 40 );
            parametros.Value = producto.Descripcion;

            parametros = comando.Parameters.Add("IMAGEN", SqlDbType.VarChar, 50);
            parametros.Value = producto.Imagen_path;

            parametros = comando.Parameters.Add("PRECIO", SqlDbType.Money);
            parametros.Value = producto.Precio;

            parametros = comando.Parameters.Add("ACTIVO", SqlDbType.Bit);
            if (producto.Activo) parametros.Value = 1;
            else parametros.Value = 0;




            Conexion conexion = new Conexion();
            return conexion.EjecutarProcedimientoAlmacenado(comando, "SP_UpdateProducto");
        }




        /*  public DataTable ReportesAdmin_filtrarPorFecha(DateTime desde, DateTime hasta, string procedimiento)
          {
              SqlCommand comando = new SqlCommand();
              SqlParameter parametros = new SqlParameter();

              parametros.ParameterName = "@desde";
              parametros.SqlDbType = SqlDbType.Date;
              parametros.Value = desde.ToString();
              comando.Parameters.Add(parametros);

              parametros.ParameterName = "@hasta";
              parametros.SqlDbType = SqlDbType.Date;
              parametros.Value = hasta.ToString();
              comando.Parameters.Add(parametros);

              Conexion conexion = new Conexion();
              return conexion.EjecutarProcedimientoAlmacenado(comando, procedimiento);
              }
        ----------------------------FALLOOO------------------------
          */



    }
}

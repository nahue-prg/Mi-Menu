using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;

namespace Negocio
{
    public class gestionNegocio
    {
        public bool guardarPathImagen(int ID, string path)
        {
            string procedimiento = "update Negocios set Imagen_neg = '" + path + "' where IDNegocio_neg = " + ID.ToString();
            Conexion conexion = new Conexion();
            try
            {
                return conexion.EjecutarModificacion(procedimiento);
            }
            catch
            {
                return false;
            }
        }

        public bool cambiarNombre(string nombre, string ID)
        {
            string procedimiento = "update Negocios set Nombre_neg = '" + nombre + "' where IDNegocio_neg = " + ID;
            Conexion conexion = new Conexion();
            try
            {
                return conexion.EjecutarModificacion(procedimiento);
            }
            catch
            {
                return false;
            }
        }

        public bool AgregarCategoria(ProductosCategorias categoria)
        {
            Parametros parametros = new Parametros();

            try {
                if (parametros.AgregarProductoCategoria(categoria) >= 1) return true;
                else return false;
            }
            catch { return false; }

        }

        public DataTable cargarCategoriasDDL(string ID, string estado)
        {
            string consulta = "select * from View_PRODUCTOSCATEGORIA_ID_NOMBRE_ID_NEGOCIO where ID_NEGOCIO = " + ID + " AND ESTADO = " + estado;
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);

        }

        public DataTable cargarCategoriasTodasDDL()
        {
            string consulta = "SELECT ID_prodcat as ID, Nombre_prodcat as [NOMBRE] from ProductosCategoria where Activo_proCat = 1 ";
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }

        public DataTable cargarCategoriasNegocio(){
            string consulta = "SELECT IDCategoria_negcat as ID, Descripcion_negcat as [NOMBRE] from NegociosCategorias";
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);

        }

        public bool EliminarProducto(string ID)
        {
            string procedimienot = "delete from Productos where IDProducto_prod = " + ID;
            Conexion conexion = new Conexion();
            if (conexion.EjecutarModificacion(procedimienot)) { return true; }
            else return false;

        }

        public DataTable cargarProductosDDL(string ID)
        {
            string consulta = "select [ID], [NOMBRE] from View_PRODUCOTS_ID_NOMBRE_IDNEGOCIO where [IDNEGOCIO] = " + ID;
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }

        public bool borrarCategoria(string ID)
        {
            string procedimiento = "update ProductosCategoria set Activo_proCat = 0 where ID_prodcat =" + ID;
            Conexion conexion = new Conexion();
            try
            {
                return conexion.EjecutarModificacion(procedimiento);
            }
            catch
            {
                return false;
            }
        }

        public bool ActivarCategoria(string ID)
        {
            string procedimiento = "update ProductosCategoria set Activo_proCat = 1 where ID_prodcat = " + ID;
            Conexion conexion = new Conexion();
            try
            {
                return conexion.EjecutarModificacion(procedimiento);
            }
            catch
            {
                return false;
            }

        }

        public DataTable  Productos_cargarImagenes(string ID)
        {
            string consulta = "SELECT * from VIEW_PRODUCTOS_IMAGEN_ID where ID = "+ ID ;
            Conexion conexion = new Conexion();
            
                return conexion.EjecutarLectura(consulta);
           

        }

        public bool agregarProducto(Productos producto)
        {

            Parametros parametros = new Parametros();

            if (parametros.agregarProducto(producto) >= 1) return true;
            else return false;

        }

        public DataTable  Productos_CargarGridView( string ID)
        {
            string consulta = "select * from View_Productos_IDPRODUCTO_IDCATEGORIA_IDNEGOCIO_CATEGORIA_NOMBRE_DESCRIPCION_IMAGEN_PRECIO_ESTADO where [ID NEGOCIO] = "+ ID + " ORDER BY [ID PRODUCTO]";
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }

        public bool updateProducto(Productos producto)
        {
            Parametros parametros = new Parametros();
            if (parametros.updateProducto(producto) >= 1) return true;
            else return false;
        }

        public DataTable Negocio_cargarListViewIndex()
        {
            string consulta = "select * from View_Negocios_IDNEGOCIO_IDCATEGORIA_CATEGORIA_IDPROVINCIA_PROVINCIA_IDLOCALIDAD_LOCALIDAD_NOMBRE_IMAGEN_ESTADO";
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }

        public DataTable Negocio_cargarListViewIndex(string condicion)
        {
            string consulta = "select * from View_Negocios_IDNEGOCIO_IDCATEGORIA_CATEGORIA_IDPROVINCIA_PROVINCIA_IDLOCALIDAD_LOCALIDAD_NOMBRE_IMAGEN_ESTADO "+ condicion;
           
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }

        public DataTable cargarDDlProvincias()
        {
            string consulta = "SELECT IDProvincia_prov as [ID], Nombre_prov as [NOMBRE] FROM Provincias";
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }


        public DataTable Localidades_X_IDProvincia(string ID)
        {
            string consulta = "select * from View_Localidades_x_Provincia where [ID PROVINCIA] = " + ID;
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }

        public DataTable cargarListViewMenu(string ID)
        {
            string consulta = "SELECT * FROM VIEW_PRODUCTOSCATEGORIAS_IDCATEGORIA_IDNEGOCIO_NOMBRE_ESTADO  WHERE [ID NEGOCIO] = " + ID + " AND ESTADO = 1";
            Conexion conexion = new Conexion();
            return conexion.EjecutarLectura(consulta);
        }

        public int agregarPedido(ref Pedidos pedido)
        {
            string consulta = "INSERT INTO Pedidos(IDNegocio_Ped,IDCliente_ped,Estado_ped,Modalidad_ped,MedioPago_ped,Total_ped) select " + pedido.IDnegocio1.ToString() + "," + pedido.IdCliente.ToString() + "," + pedido.Estado.ToString() + ",'" + pedido.Modalidad.ToString() + "','" + pedido.MedioPago.ToString() + "'," + pedido.Total1.ToString() + "; " + "select SCOPE_IDENTITY() as ID;";
            Conexion conexion = new Conexion();
            DataTable tabla = conexion.EjecutarLectura(consulta);   //Lo agrega como consulta para que retorne el ID del registro agregado mediante la funcion ScopeIdentity de sql
            int ID = Int32.Parse(tabla.Rows[0]["ID"].ToString());
            return ID;
        }

        public bool agregarDetalle(int ID, DataTable tablaCarrito)    
        {
            Parametros parametros = new Parametros();
            bool estado = false;
            foreach ( DataRow dr in tablaCarrito.Rows)
            {
                float precio = float.Parse(dr[2].ToString().Replace("$", ""));

                DetallesPedidos detalleP = new DetallesPedidos(ID,Int32.Parse(dr[0].ToString()), Int32.Parse(dr[3].ToString()), precio);
              if (parametros.agregarDetalle(detalleP) >= 1)
                {
                    estado = true;
                }

            }

            return estado;
        }

        public bool ModificarEstadoPedido(string idPedido,string estado)
        {
            string modificacion = "update Pedidos set Estado_ped = " + estado + "where ID_ped = " + idPedido;
            Conexion conexion = new Conexion();

            try
            {
                return conexion.EjecutarModificacion(modificacion);
            }
            catch
            {
                return false;
            }
          


        }

    }
}

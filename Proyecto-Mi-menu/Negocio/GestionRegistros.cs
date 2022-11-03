using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class GestionRegistros
    {
        public bool agregarCliente(String usuario, String nombre, String apellido, String mail, String celular, String clave, int activo)
        {
            int cantFilas = 0;

            Clientes cl = new Clientes(usuario, nombre, apellido, mail, celular, clave, activo);

            Parametros pm = new Parametros();
            if (pm.existeCliente(cl) == false)
            {
                cantFilas = pm.agregarCliente(cl);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }


        public bool agregarNegocio(int idprovincia, int idlocalidad, int idcategoria, String cuit, String nombre, String calle, String mail, String clave, int activo)
        {
            int cantFilas = 0;

            Negocios ng = new Negocios(idprovincia, idlocalidad, idcategoria, cuit, nombre, calle, mail, clave, activo);

            Parametros pm = new Parametros();
            if (pm.existeNegocio(ng) == false)
            {
                cantFilas = pm.agregarNegocio(ng);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }



    }
}

namespace Entidades
{
    public class Negocios
    {
        private int IDNegocio;
        private int IDProvincia;
        private int IDLocalidad;
        private int IDCategoria;
        private string Cuit;
        private string imagen;
        private string Nombre;
        private string Calle;
        private string Mail;
        private string Clave;
        private int Activo;

        public Negocios(int idprovincia, int idlocalidad, int idcategoria, string cuit, string nombre, string calle, string mail, string clave, int activo)
        {
            IDProvincia = idprovincia;
            IDLocalidad = idlocalidad;
            IDCategoria = idcategoria;
            Cuit = cuit;
            Nombre = nombre;
            Calle = calle;
            Mail = mail;
            Clave = clave;
            Activo = activo;
        }

        public int IDNegocio1 { get => IDNegocio; set => IDNegocio = value; }

        public int IDProvincia1 { get => IDProvincia; set => IDProvincia = value; }

        public int IDLocalidad1 { get => IDLocalidad; set => IDLocalidad = value; }

        public int IDCategoria1 { get => IDCategoria; set => IDCategoria = value; }
        public string Cuit1 { get => Cuit; set => Cuit = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Calle1 { get => Calle; set => Calle = value; }
        public string Mail1 { get => Mail; set => Mail = value; }
        /// public string Imagen1 { get => Imagen; set => Imagen = value; }
        public string Clave1 { get => Clave; set => Clave = value; }
        public int Activo1 { get => Activo; set => Activo = value; }
        public string Imagen { get => imagen; set => imagen = value; }
    }
}

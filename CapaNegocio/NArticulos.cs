using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NArticulos
    {
        public static string InsertarArticulos(List<string> variables,
            DataTable imagenes, out int id_articulo)
        {
            DArticulos dArticulos = new DArticulos();
            return dArticulos.InsertarArticulos(variables, imagenes, out id_articulo);
        }

        public static string EditarArticulos(List<string> variables,
            DataTable imagenes, int id_articulo)
        {
            DArticulos dArticulos = new DArticulos();
            return dArticulos.EditarArticulos(variables, imagenes, id_articulo);
        }

        public static DataTable BuscarArticulos(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            return DArticulos.BuscarArticulos(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}

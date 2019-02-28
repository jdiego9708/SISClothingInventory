using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class DTipo_articulos
    {
        public static string InsertarTipoArticulo(List<string> variables, out int id_tipo)
        {
            DTipo_articulo DTipo_articulo = new DTipo_articulo();
            return DTipo_articulo.InsertarTipoArticulos(variables, out id_tipo);
        }

        public static string EditarTipoArticulo(List<string> variables, int id_tipo)
        {
            DTipo_articulo DTipo_articulo = new DTipo_articulo();
            return DTipo_articulo.EditarTipoArticulos(variables, id_tipo);
        }

        public static DataTable BuscarTipoArticulos(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            return DTipo_articulo.Buscar_tipo_articulos(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}

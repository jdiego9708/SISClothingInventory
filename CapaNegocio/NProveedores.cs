using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NProveedores
    {
        public static string InsertarProveedores(List<string> variables, out int id_proveedor)
        {
            DProveedores dProveedores = new DProveedores();
            return dProveedores.InsertarProveedores(variables, out id_proveedor);
        }

        public static string EditarProveedores(List<string> variables, int id_proveedor)
        {
            DProveedores dProveedores = new DProveedores();
            return dProveedores.EditarProveedores(variables, id_proveedor);
        }

        public static DataTable BuscarProveedores(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            return DProveedores.BuscarProveedores(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}

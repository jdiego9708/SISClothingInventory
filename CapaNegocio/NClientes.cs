using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NClientes
    {
        public static string InsertarClientes(List<string> variables, out int id_cliente)
        {
            DClientes dClientes = new DClientes();
            return dClientes.InsertarClientes(variables, out id_cliente);
        }

        public static string EditarClientes(List<string> variables, int id_cliente)
        {
            DClientes dClientes = new DClientes();
            return dClientes.EditarClientes(variables, id_cliente);
        }

        public static DataTable BuscarClientes(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            return DClientes.BuscarClientes(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarDireccionClientes(List<string> variables, out int id_direccion)
        {
            DClientes dClientes = new DClientes();
            return dClientes.InsertarDireccionClientes(variables, out id_direccion);
        }

        public static string EditarDireccionClientes(List<string> variables, int id_direccion)
        {
            DClientes dClientes = new DClientes();
            return dClientes.EditarClientes(variables, id_direccion);
        }
    }
}

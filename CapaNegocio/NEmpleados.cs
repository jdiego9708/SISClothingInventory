using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NEmpleados
    {
        public static string InsertarEmpleado(List<string> variables, out int id_empleado)
        {
            DEmpleados dEmpleados = new DEmpleados();
            return dEmpleados.InsertarEmpleados(variables, out id_empleado);
        }

        public static string EditarEmpleado(List<string> variables, int id_empleado)
        {
            DEmpleados dEmpleados = new DEmpleados();
            return dEmpleados.EditarEmpleados(variables, id_empleado);
        }

        public static DataTable BuscarEmpleado(string tipo_busqueda, string texto_busqueda,
                                                 out string rpta)
        {
            return DEmpleados.BuscarEmpleados(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static DataTable Login(string usuario, string password,
                                                 out string rpta)
        {
            return DEmpleados.Login(usuario, password, out rpta);
        }
    }
}

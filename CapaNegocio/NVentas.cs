using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NVentas
    {
        public static string InsertarVentas(List<string> variables, DataTable detalle ,out int id_venta)
        {
            DVentas dVentas = new DVentas();
            return dVentas.InsertarVenta(variables, detalle, out id_venta);
        }

        public static string InsertarDetalleVentas(int id_venta, DataTable detalle)
        {
            DVentas dVentas = new DVentas();
            return dVentas.InsertarDetalleVenta(id_venta, detalle);
        }
    }
}

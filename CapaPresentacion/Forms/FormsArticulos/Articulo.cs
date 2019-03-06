using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public class Articulo
    {
        private int _id_articulo;
        private int _id_tipo_articulo;
        private string _tipo_articulo;
        private string _nombre_articulo;
        private int _id_proveedor;
        private string _nombre_proveedor;
        private int _cantidad;
        private string _tipo_detalle;
        private string _descripcion_articulo;
        private int _precio;
        private DataTable dtImagenes;

        public int Id_articulo { get => _id_articulo; set => _id_articulo = value; }
        public int Id_tipo_articulo { get => _id_tipo_articulo; set => _id_tipo_articulo = value; }
        public string Tipo_articulo { get => _tipo_articulo; set => _tipo_articulo = value; }
        public string Nombre_articulo { get => _nombre_articulo; set => _nombre_articulo = value; }
        public int Id_proveedor { get => _id_proveedor; set => _id_proveedor = value; }
        public string Nombre_proveedor { get => _nombre_proveedor; set => _nombre_proveedor = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Tipo_detalle { get => _tipo_detalle; set => _tipo_detalle = value; }
        public string Descripcion_articulo { get => _descripcion_articulo; set => _descripcion_articulo = value; }
        public int Precio { get => _precio; set => _precio = value; }
        public DataTable DtImagenes { get => dtImagenes; set => dtImagenes = value; }
    }
}

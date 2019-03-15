using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace CapaPresentacion.Forms.FormsVentas
{
    public class VentasEnvios
    {
        public VentasEnvios()
        {

        }

        public VentasEnvios(DataTable dtEnvios, int rowIndex)
        {
            if (dtEnvios != null)
            {
                this.Id_venta = Convert.ToInt32(dtEnvios.Rows[rowIndex]["Id_venta"]);
                this.Id_empleado = Convert.ToInt32(dtEnvios.Rows[rowIndex]["Id_empleado"]);
                this.Id_cliente = Convert.ToInt32(dtEnvios.Rows[rowIndex]["Id_cliente"]);
                this.Id_direccion = Convert.ToInt32(dtEnvios.Rows[rowIndex]["Id_direccion"]);
                this.Tipo_venta = Convert.ToString(dtEnvios.Rows[rowIndex]["Tipo_venta"]);
                this.Estado_venta = Convert.ToString(dtEnvios.Rows[rowIndex]["Estado_venta"]);
                this.Fecha_venta = Convert.ToDateTime(dtEnvios.Rows[rowIndex]["Fecha_venta"]);
                this.Hora_venta = Convert.ToString(dtEnvios.Rows[rowIndex]["Hora_venta"]);
                this.Observaciones = Convert.ToString(dtEnvios.Rows[rowIndex]["Observaciones"]);
                this.Nombre_empleado = Convert.ToString(dtEnvios.Rows[rowIndex]["Nombre_empleado"]);
                this.Nombre_cliente = Convert.ToString(dtEnvios.Rows[rowIndex]["Nombre_cliente"]);
                this.Telefono_cliente = Convert.ToString(dtEnvios.Rows[rowIndex]["Telefono_cliente"]);
                this.Correo_electronico = Convert.ToString(dtEnvios.Rows[rowIndex]["Correo_electronico"]);
                this.Direccion = Convert.ToString(dtEnvios.Rows[rowIndex]["Direccion"]);
                this.Referencias = Convert.ToString(dtEnvios.Rows[rowIndex]["Referencias"]);
            }
        }

        public VentasEnvios(DataRow row)
        {
            if (row != null)
            {
                this.Id_venta = Convert.ToInt32(row["Id_venta"]);
                this.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                this.Id_cliente = Convert.ToInt32(row["Id_cliente"]);
                this.Id_direccion = Convert.ToInt32(row["Id_direccion"]);
                this.Tipo_venta = Convert.ToString(row["Tipo_venta"]);
                this.Estado_venta = Convert.ToString(row["Estado_venta"]);
                this.Fecha_venta = Convert.ToDateTime(row["Fecha_venta"]);
                this.Hora_venta = Convert.ToString(row["Hora_venta"]);
                this.Observaciones = Convert.ToString(row["Observaciones"]);
                this.Nombre_empleado = Convert.ToString(row["Nombre_empleado"]);
                this.Nombre_cliente = Convert.ToString(row["Nombre_cliente"]);
                this.Telefono_cliente = Convert.ToString(row["Telefono_cliente"]);
                this.Correo_electronico = Convert.ToString(row["Correo_electronico"]);
                this.Direccion = Convert.ToString(row["Direccion"]);
                this.Referencias = Convert.ToString(row["Referencias"]);
            }
        }

        public int Id_venta { get => _id_venta; set => _id_venta = value; }
        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public int Id_direccion { get => _id_direccion; set => _id_direccion = value; }
        public string Tipo_venta { get => _tipo_venta; set => _tipo_venta = value; }
        public string Estado_venta { get => _estado_venta; set => _estado_venta = value; }
        public DateTime Fecha_venta { get => _fecha_venta; set => _fecha_venta = value; }
        public string Hora_venta { get => _hora_venta; set => _hora_venta = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
        public string Nombre_empleado { get => _nombre_empleado; set => _nombre_empleado = value; }
        public string Nombre_cliente { get => _nombre_cliente; set => _nombre_cliente = value; }
        public string Telefono_cliente { get => _telefono_cliente; set => _telefono_cliente = value; }
        public string Correo_electronico { get => _correo_electronico; set => _correo_electronico = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Referencias { get => _referencias; set => _referencias = value; }

        private int _id_venta;
        private int _id_empleado;
        private int _id_cliente;
        private int _id_direccion;
        private string _tipo_venta;
        private string _estado_venta;
        private DateTime _fecha_venta;
        private string _hora_venta;
        private string _observaciones;
        private string _nombre_empleado;
        private string _nombre_cliente;
        private string _telefono_cliente;
        private string _correo_electronico;
        private string _direccion;
        private string _referencias;


    }
}

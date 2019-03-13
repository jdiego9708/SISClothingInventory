using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsEmpleados
{
    public class Empleado
    {
        public Empleado()
        {

        }

        public Empleado(DataTable dtEmpleado, int rowIndex)
        {
            this.Id_empleado = Convert.ToInt32(dtEmpleado.Rows[rowIndex]["Id_empleado"]);
            this.Nombre_empleado = Convert.ToString(dtEmpleado.Rows[rowIndex]["Nombre_empleado"]);
            this.Telefono_empleado = Convert.ToString(dtEmpleado.Rows[rowIndex]["Telefono_empleado"]);
            this.Correo_electronico = Convert.ToString(dtEmpleado.Rows[rowIndex]["Correo_electronico"]);
            this.Cargo_empleado = Convert.ToString(dtEmpleado.Rows[rowIndex]["Cargo_empleado"]);
            this.Password = Convert.ToString(dtEmpleado.Rows[rowIndex]["Password"]);
        }

        public Empleado(DataGridViewRow row)
        {
            this.Id_empleado = Convert.ToInt32(row.Cells["Id_empleado"].Value);
            this.Nombre_empleado = Convert.ToString(row.Cells["Nombre_empleado"].Value);
            this.Telefono_empleado = Convert.ToString(row.Cells["Telefono_empleado"].Value);
            this.Correo_electronico = Convert.ToString(row.Cells["Correo_electronico"].Value);
            this.Cargo_empleado = Convert.ToString(row.Cells["Cargo_empleado"].Value);
            this.Password = Convert.ToString(row.Cells["Password"].Value);
        }

        public Empleado(DataRow row)
        {
            this.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
            this.Nombre_empleado = Convert.ToString(row["Nombre_empleado"]);
            this.Telefono_empleado = Convert.ToString(row["Telefono_empleado"]);
            this.Correo_electronico = Convert.ToString(row["Correo_electronico"]);
            this.Cargo_empleado = Convert.ToString(row["Cargo_empleado"]);
            this.Password = Convert.ToString(row["Password"]);
        }

        public static List<string> DatosEmpleado(Empleado empleado)
        {
            return new List<string>()
            {
                empleado.Nombre_empleado,
                empleado.Telefono_empleado,
                empleado.Correo_electronico,
                empleado.Cargo_empleado,
                empleado.Password
            };
        }

        private int _id_empleado;
        private string _nombre_empleado;
        private string _telefono_empleado;
        private string _correo_electronico;
        private string _cargo_empleado;
        private string _password;

        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public string Nombre_empleado { get => _nombre_empleado; set => _nombre_empleado = value; }
        public string Telefono_empleado { get => _telefono_empleado; set => _telefono_empleado = value; }
        public string Correo_electronico { get => _correo_electronico; set => _correo_electronico = value; }
        public string Cargo_empleado { get => _cargo_empleado; set => _cargo_empleado = value; }
        public string Password { get => _password; set => _password = value; }
    }
}

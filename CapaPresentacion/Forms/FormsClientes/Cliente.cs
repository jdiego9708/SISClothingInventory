using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Forms.FormsClientes
{
    public class Cliente
    {
        private int _id_cliente;
        private DateTime _fecha_ingreso;
        private string _nombre;
        private string _telefono;
        private string _correo;

        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public DateTime Fecha_ingreso { get => _fecha_ingreso; set => _fecha_ingreso = value; }
    }
}

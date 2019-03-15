using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Forms.FormsVentas;

namespace CapaPresentacion.Forms.FormsEntradasSalidas
{
    public partial class SalidaSmall : UserControl
    {
        public SalidaSmall()
        {
            InitializeComponent();
        }

        public void AsignarDatos(VentasEnvios envio)
        {
            this.Envio = envio;
            this.txtCliente.Text =
                string.Concat("Nombre: ", envio.Nombre_cliente);
            this.txtDireccion.Text = envio.Direccion;
            this.txtTelefono.Text = "Teléfono: " + envio.Telefono_cliente;
            this.txtCorreo.Text = "Correo eletrónico: " + envio.Correo_electronico;
            this.toolTip1.SetToolTip(this.txtDireccion, envio.Referencias);
            this.txtQuienRecibe.Text = "Persona que recibe el envío: " + envio.Nombre_cliente;

            this.gbEstado.Text = "Seguimiento de envío";
        }

        public VentasEnvios Envio;
    }
}

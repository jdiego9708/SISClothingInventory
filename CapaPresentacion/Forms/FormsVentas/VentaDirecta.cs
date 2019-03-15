using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Forms.FormsClientes;

namespace CapaPresentacion.Forms.FormsVentas
{
    public partial class VentaDirecta : UserControl
    {
        public VentaDirecta()
        {
            InitializeComponent();
            this.txtCliente.Click += TxtCliente_Click;
        }

        public bool Comprobaciones(out int id_cliente, 
            out string tipo_pago, out string observaciones)
        {
            id_cliente = 0;
            tipo_pago = this.rdEfectivo.Checked ? "EFECTIVO" : "TARJETA";
            observaciones = this.txtObservaciones.Text;
            if (this.txtCliente.Tag == null)
            {
                return false;
            }
            else
            {
                id_cliente = Convert.ToInt32(this.txtCliente.Tag);
                return true;
            }
        }

        private void TxtCliente_Click(object sender, EventArgs e)
        {
            FrmObservarClientes observarClientes = new FrmObservarClientes
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            observarClientes.ondgvDoubleClick += ObservarClientes_ondgvDoubleClick;
            observarClientes.ShowDialog();
        }

        private void ObservarClientes_ondgvDoubleClick(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)sender;
            this.txtCliente.Text = cliente.Nombre;
            this.txtCliente.Tag = cliente.Id_cliente;
        }
    }
}

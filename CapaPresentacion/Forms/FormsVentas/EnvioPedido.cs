using CapaNegocio;
using CapaPresentacion.Forms.FormsClientes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsVentas
{
    public partial class EnvioPedido : UserControl
    {
        public EnvioPedido()
        {
            InitializeComponent();
            this.txtCliente.Click += TxtCliente_Click;
            this.Load += EnvioPedido_Load;
            this.rdMismoCliente.CheckedChanged += RdMismoCliente_CheckedChanged;
        }

        public bool Comprobacion(out int id_cliente, out int id_direccion, out string observaciones)
        {
            bool result = true;
            id_cliente = 0;
            id_direccion = 0;
            observaciones = this.txtObservaciones.Text;
            if (this.listaCalleCarrera.Text.Equals(""))
            {
                result = false;
                this.errorProvider1.SetError(this.listaCalleCarrera, "Campo obligatorio");
            }

            if (this.txtNumeroCalleCarrera.Text.Equals(""))
            {
                result = false;
                this.errorProvider1.SetError(this.txtNumeroCalleCarrera, "Campo obligatorio");
            }

            if (this.txtNumero1.Text.Equals(""))
            {
                result = false;
                this.errorProvider1.SetError(this.txtNumero1, "Campo obligatorio");
            }

            if (this.txtReferencias.Text.Equals(""))
            {
                result = false;
                this.errorProvider1.SetError(this.txtReferencias, "Escriba al menos 1 referencia");
            }

            if (this.rdMismoCliente.Checked)
            {
                if (this.txtCliente.Tag == null)
                {
                    result = false;
                    this.errorProvider1.SetError(this.txtCliente, "Seleccione un cliente");
                }
            }
            else
            {
                if (this.txtNombre.Text.Equals(""))
                {
                    result = false;
                    this.errorProvider1.SetError(this.txtNombre, "Escriba un nombre de la persona que recibe");
                }

                if (this.txtTelefono.Text.Equals(""))
                {
                    result = false;
                    this.errorProvider1.SetError(this.txtTelefono, "Escriba el teléfono de la persona que recibe");
                }
            }


            if (result)
            {
                //Insertar la dirección del cliente
                List <string> direccionCliente = new List<string>()
                {
                    Convert.ToString(this.txtCliente.Tag), this.listaCalleCarrera.Text,
                    this.txtNumeroCalleCarrera.Text, this.txtNumero1.Text,
                    this.txtNumero2.Text, this.txtReferencias.Text
                };

                id_cliente = Convert.ToInt32(this.txtCliente.Tag);
                string rpta =
                    NClientes.InsertarDireccionClientes(direccionCliente, out id_direccion);
                if (rpta.Equals("OK"))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        private void RdMismoCliente_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
            if (chk.Checked)
            {
                this.panelOtroCliente.Visible = false;
            }
            else
            {
                this.panelOtroCliente.Visible = true;
            }
        }

        private void EnvioPedido_Load(object sender, EventArgs e)
        {
            this.txtCliente.MaxLength = 4;
            this.listaCalleCarrera.Items.Add("CALLE");
            this.listaCalleCarrera.Items.Add("CARRERA");
            this.rdEfectivo.Checked = true;
            this.rdMismoCliente.Checked = true;
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

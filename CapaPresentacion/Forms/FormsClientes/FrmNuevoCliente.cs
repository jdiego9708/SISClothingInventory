using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsClientes
{
    public partial class FrmNuevoCliente : Form
    {
        public FrmNuevoCliente()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.Load += FrmNuevoCliente_Load;
        }

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            this.toolBox1.Texto = this.Text;
            this.toolBox1.EstablecerTexto();
        }

        public void AsignarDatosEditar(Cliente cliente)
        {
            this.Id_cliente = cliente.Id_cliente;
            this.txtNombre.Text = cliente.Nombre;
            this.txtTelefono.Text = cliente.Telefono;
            this.txtCorreo.Text = cliente.Correo;
        }

        private void Limpiar()
        {
            this.Tag = null;
            this.Id_cliente = 0;
            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.txtCorreo.Clear();
            this.errorProvider1.Clear();
        }

        private List<string> Variables()
        {
            return new List<string>
            {
                this.txtNombre.Text, this.txtTelefono.Text, this.txtCorreo.Text
            };
        }

        private bool Comprobaciones()
        {
            if (this.txtNombre.Text.Equals(string.Empty))
            {
                this.errorProvider1.SetError(this.txtNombre, "El nombre es requerido");
                return false;
            }

            if (this.txtTelefono.Text.Equals(string.Empty))
            {
                this.errorProvider1.SetError(this.txtTelefono, "El nombre es requerido");
                return false;
            }
            else
            {
                long tel;
                if (!Int64.TryParse(this.txtTelefono.Text, out tel))
                {
                    this.errorProvider1.SetError(this.txtTelefono, "El teléfono solo puede contener números");
                    return false;
                }
            }

            if (this.txtCorreo.Text.Equals(string.Empty))
            {
                this.errorProvider1.SetError(this.txtCorreo, "El correo electrónico es requerido");
                return false;
            }

            try
            {
                new MailAddress(this.txtCorreo.Text);
            }
            catch (FormatException)
            {
                this.errorProvider1.SetError(this.txtCorreo, "El correo electrónico debe tener un formato correcto");
                return false;
            }
            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones())
                {
                    string mensaje = "";
                    string rpta = "";
                    int id_cliente;
                    if (this.IsEditar)
                    {
                        rpta = NClientes.EditarClientes(this.Variables(), this.Id_cliente);
                        mensaje = "Se actualizó correctamente los datos del cliente";
                    }
                    else
                    {
                        rpta = NClientes.InsertarClientes(this.Variables(), out id_cliente);
                        mensaje = "Se guardó correctamente el cliente";
                    }

                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeOkForm(mensaje);
                        this.Limpiar();
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar un cliente", ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private int _id_cliente;
        private bool _isEditar;

        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}

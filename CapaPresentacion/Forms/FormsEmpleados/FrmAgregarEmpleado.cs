using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsEmpleados
{
    public partial class FrmAgregarEmpleado : Form
    {
        public FrmAgregarEmpleado()
        {
            InitializeComponent();
            this.Load += FrmAgregarEmpleado_Load;
            this.txtPass1.LostFocus += TxtPass1_LostFocus;
            this.txtPass2.LostFocus += TxtPass2_LostFocus;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        public void AsignarDatos(Empleado empleado)
        {
            this.empleado = empleado;
            this.txtNombre.Text = empleado.Nombre_empleado;
            this.txtTelefono.Text = empleado.Telefono_empleado;
            this.txtCorreo.Text = empleado.Correo_electronico;
            this.listaCargo = LlenarListas.ListaTipoUsuarios(this.listaCargo);
            this.listaCargo.Text = empleado.Cargo_empleado;
            this.txtPass1.Text = empleado.Password;
            this.txtPass2.Text = empleado.Password;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out Empleado empleado))
                {
                    string rpta = "OK";
                    string mensaje = "";
                    if (this.IsEditar)
                    {
                        rpta = 
                            NEmpleados.EditarEmpleado(Empleado.DatosEmpleado(empleado), empleado.Id_empleado);
                        mensaje = "Se actualizó correctamente el empleado";
                    }
                    else
                    {
                        rpta = 
                            NEmpleados.InsertarEmpleado(Empleado.DatosEmpleado(empleado), out int id_empleado);
                        mensaje = "Se agregó correctamente el empleado";
                    }

                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeOkForm(mensaje);
                        this.Close();
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
                    "Hubo un error al guardar un empleado", ex.Message);
            }
        }

        private bool Comprobaciones(out Empleado empleado)
        {
            bool result = true;
            empleado = new Empleado();
            if (this.txtNombre.Text.Equals(string.Empty))
            {
                result = false;
                this.errorProvider1.SetIconPadding(this.txtNombre, -5);
                this.errorProvider1.SetError(this.txtNombre, "El nombre es un campo obligatorio");
            }

            if (this.txtTelefono.Text.Equals(string.Empty))
            {
                result = false;
                this.errorProvider1.SetIconPadding(this.txtTelefono, -5);
                this.errorProvider1.SetError(this.txtTelefono, "El teléfono es un campo obligatorio");
            }

            if (this.listaCargo.Text.Equals(string.Empty))
            {
                result = false;
                this.errorProvider1.SetIconPadding(this.listaCargo, -1);
                this.errorProvider1.SetError(this.listaCargo, "El cargo es obligatorio");
            }

            if (!this.txtPass1.Text.Equals(this.txtPass2.Text))
            {
                result = false;
                this.errorProvider1.SetIconPadding(this.txtPass1, -5);
                this.errorProvider1.SetError(this.txtPass1, "Las contraseñas deben ser iguales");
            }

            if (result)
            {
                empleado.Nombre_empleado = this.txtNombre.Text;
                empleado.Telefono_empleado = this.txtTelefono.Text;
                empleado.Correo_electronico = this.txtCorreo.Text;
                empleado.Cargo_empleado = this.listaCargo.Text;
                empleado.Password = this.txtPass2.Text;
            }
            else
            {
                empleado = null;
            }

            return result;
        }

        private void TxtPass2_LostFocus(object sender, EventArgs e)
        {
            if (this.txtPass1.Text.Equals(this.txtPass2.Text))
            {
                this.errorProvider1.Clear();
            }
            else
            {
                this.errorProvider1.SetIconPadding(this.txtPass2, -5);
                this.errorProvider1.SetError(this.txtPass2, "Las contraseñas deben ser iguales");
                this.txtPass2.Focus();
            }
        }

        private void TxtPass1_LostFocus(object sender, EventArgs e)
        {
            this.txtPass2.Focus();
        }

        private void FrmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            this.listaCargo = LlenarListas.ListaTipoUsuarios(this.listaCargo);
        }

        public Empleado empleado;
        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}

using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsProveedores
{
    public partial class FrmAgregarProveedor : Form
    {
        public FrmAgregarProveedor()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.Load += FrmAgregarProveedor_Load;
            this.TextChanged += FrmAgregarProveedor_TextChanged;
        }

        private void FrmAgregarProveedor_TextChanged(object sender, EventArgs e)
        {
            this.lblEncabezaco.Text = this.Text;
        }

        private void FrmAgregarProveedor_Load(object sender, EventArgs e)
        {
            
        }

        public void AsignarDatos(List<string> datosProveedor)
        {
            this.Id_proveedor = Convert.ToInt32(datosProveedor[0]);
            this.txtNombre.Text = datosProveedor[2];
            this.txtTelefono.Text = datosProveedor[3];
            this.txtCorreo.Text = datosProveedor[4];
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpiar()
        {
            this.Tag = null;
            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.txtCorreo.Clear();
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
            bool result = true;
            if (this.txtNombre.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtNombre, "Campo obligatorio");
                result = false;
            }

            if (this.txtTelefono.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtTelefono, "Campo obligatorio");
                result = false;
            }

            return result;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.Comprobaciones())
                {
                    string mensaje = "";
                    int id_proveedor;
                    if (this.IsEditar)
                    {
                        rpta = NProveedores.EditarProveedores(this.Variables(), this.Id_proveedor);
                        mensaje = "Se actualizó correctamente el proveedor";
                    }
                    else
                    {
                        rpta = NProveedores.InsertarProveedores(this.Variables(), out id_proveedor);
                        mensaje = "Se agregó correctamente el proveedor";
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
                    "Hubo un error al guardar un proveedor", ex.Message);
            }
        }

        private int _id_proveedor;
        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
        public int Id_proveedor { get => _id_proveedor; set => _id_proveedor = value; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsClientes
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
            this.btnNuevoCliente.Click += BtnNuevoCliente_Click;
            this.btnEditarCliente.Click += BtnEditarCliente_Click;
            this.btnObservarClientes.Click += BtnObservarClientes_Click;
            this.Load += FrmClientes_Load;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            this.OpenObservarClientes(true, false);
        }

        private void BtnObservarClientes_Click(object sender, EventArgs e)
        {
            this.OpenObservarClientes(true, false);
        }

        private void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            this.OpenObservarClientes(true, true);
        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            this.OpenNuevoCliente(true, false, null);
        }

        private void OpenNuevoCliente(bool visible, bool isEditar,
            Cliente cliente)
        {
            if (visible)
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (frmNuevoCliente == null)
                {
                    frmNuevoCliente = new FrmNuevoCliente
                    {
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill,
                        TopLevel = false,
                        Text = "Agregar un nuevo artículo"
                    };
                    frmNuevoCliente.FormClosed += Frm_FormClosed;
                    frmNuevoCliente.IsEditar = isEditar;
                    if (isEditar)
                    {
                        //frmNuevoCliente.AsignarDatosCliente(cliente);
                        frmNuevoCliente.Text = "Editar los datos de un cliente";
                    }
                    this.panel1.Controls.Add(frmNuevoCliente);
                    this.panel1.Tag = frmNuevoCliente;
                    frmNuevoCliente.Show();
                    frmNuevoCliente.BringToFront();
                }
                else
                {
                    frmNuevoCliente.IsEditar = isEditar;
                    frmNuevoCliente.Text = "Agregar un nuevo cliente";
                    if (isEditar)
                    {
                        //frmNuevoCliente.AsignarDatosCliente(cliente);
                        frmNuevoCliente.Text = "Editar los datos de un cliente";
                    }
                    this.panel1.Controls.Add(frmNuevoCliente);
                    this.panel1.Tag = frmNuevoCliente;
                    this.frmNuevoCliente.Activate();
                    this.frmNuevoCliente.BringToFront();
                }
                this.panel1.Refresh();
            }
        }

        private void OpenObservarClientes(bool visible, bool isEditar)
        {
            if (visible)
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (frmObservarClientes == null)
                {
                    frmObservarClientes = new FrmObservarClientes
                    {
                        Text = "Observar clientes existentes",
                        IsEditar = isEditar,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill,
                        TopLevel = false
                    };
                    frmObservarClientes.FormClosed += Frm_FormClosed;

                    if (isEditar)
                    {
                        frmObservarClientes.ondgvDoubleClick += FrmObservarClientes_ondgvDoubleClick;
                        frmObservarClientes.Text = "Seleccione un cliente para editar";
                    }
                    this.panel1.Controls.Add(frmObservarClientes);
                    this.panel1.Tag = frmObservarClientes;
                    frmObservarClientes.Show();
                    frmObservarClientes.BringToFront();
                }
                else
                {
                    frmObservarClientes.Text = "Observar clientes existentes";
                    if (isEditar)
                    {
                        frmObservarClientes.ondgvDoubleClick += FrmObservarClientes_ondgvDoubleClick;
                        frmObservarClientes.Text = "Seleccione un cliente para editar";
                    }

                    frmObservarClientes.IsEditar = isEditar;
                    this.panel1.Controls.Add(frmObservarClientes);
                    this.panel1.Tag = frmObservarClientes;
                    frmObservarClientes.Activate();
                    frmObservarClientes.BringToFront();
                }
                this.panel1.Refresh();
            }
        }

        private void FrmObservarClientes_ondgvDoubleClick(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)sender;
            this.OpenNuevoCliente(true, true, cliente);
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            if (frm is FrmNuevoCliente)
            {
                this.frmNuevoCliente = null;
            }
            else if (frm is FrmObservarClientes)
            {
                this.frmObservarClientes = null;
            }
        }

        private FrmNuevoCliente frmNuevoCliente;
        private FrmObservarClientes frmObservarClientes;
    }
}

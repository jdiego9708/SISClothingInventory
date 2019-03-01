using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsProveedores
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
            this.btnNuevoProveedor.Click += BtnNuevoProveedor_Click;
            this.btnEditarProveedor.Click += BtnEditarProveedor_Click;
            this.btnObservarProveedores.Click += BtnObservarProveedores_Click;
            this.Load += FrmProveedores_Load;
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            this.OpenObservarProveedor(true, false);
        }

        private void BtnEditarProveedor_Click(object sender, EventArgs e)
        {
            this.OpenObservarProveedor(true, true);
        }

        private void BtnObservarProveedores_Click(object sender, EventArgs e)
        {
            this.OpenObservarProveedor(true, false);
        }

        private void BtnNuevoProveedor_Click(object sender, EventArgs e)
        {
            this.OpenAgregarProveedor(true, false, null);
        }

        private void OpenAgregarProveedor(bool visible, bool isEditar,
            List<string> variables)
        {
            if (visible)
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.frmAgregarProveedor == null)
                {
                    frmAgregarProveedor = new FrmAgregarProveedor();
                    frmAgregarProveedor.FormBorderStyle = FormBorderStyle.None;
                    frmAgregarProveedor.Dock = DockStyle.Fill;
                    frmAgregarProveedor.TopLevel = false;
                    frmAgregarProveedor.FormClosed += Frm_FormClosed;
                    frmAgregarProveedor.IsEditar = isEditar;
                    frmAgregarProveedor.Text = "Agregar un nuevo proveedor";
                    if (isEditar)
                    {
                        frmAgregarProveedor.AsignarDatos(variables);
                        frmAgregarProveedor.Text = "Editar los datos de un proveedor";
                    }
                    this.panel1.Controls.Add(frmAgregarProveedor);
                    this.panel1.Tag = frmAgregarProveedor;
                    frmAgregarProveedor.Show();
                    frmAgregarProveedor.BringToFront();
                }
                else
                {
                    this.frmAgregarProveedor.IsEditar = isEditar;
                    this.frmAgregarProveedor.Text = "Agregar un nuevo proveedor";
                    if (isEditar)
                    {
                        this.frmAgregarProveedor.AsignarDatos(variables);
                        this.frmAgregarProveedor.Text = "Editar los datos de un proveedor";
                    }
                    this.panel1.Controls.Add(frmAgregarProveedor);
                    this.panel1.Tag = frmAgregarProveedor;
                    this.frmAgregarProveedor.Activate();
                    this.frmAgregarProveedor.BringToFront();
                }
                this.panel1.Refresh();
            }
        }

        private void OpenObservarProveedor(bool visible, bool isEditar)
        {
            if (visible)
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.frmObservarProveedores == null)
                {
                    frmObservarProveedores = new FrmObservarProveedores();
                    frmObservarProveedores.editarProveedor = isEditar;
                    frmObservarProveedores.FormBorderStyle = FormBorderStyle.None;
                    frmObservarProveedores.Dock = DockStyle.Fill;
                    frmObservarProveedores.TopLevel = false;
                    frmObservarProveedores.FormClosed += Frm_FormClosed;
                    this.frmObservarProveedores.Text = "Observar proveedores existentes";
                    if (isEditar)
                    {
                        this.frmObservarProveedores.ondgvDoubleClick += FrmObservarProveedores_ondgvDoubleClick;
                        this.frmObservarProveedores.Text = "Seleccione un proveedor para editar";
                    }
                    this.panel1.Controls.Add(frmObservarProveedores);
                    this.panel1.Tag = frmObservarProveedores;
                    frmObservarProveedores.Show();
                    frmObservarProveedores.BringToFront();
                }
                else
                {
                    this.frmObservarProveedores.Text = "Observar proveedores existentes";
                    if (isEditar)
                    {
                        this.frmObservarProveedores.ondgvDoubleClick += FrmObservarProveedores_ondgvDoubleClick;
                        this.frmObservarProveedores.Text = "Seleccione un proveedor para editar";
                    }

                    this.frmObservarProveedores.editarProveedor = isEditar;
                    this.panel1.Controls.Add(frmObservarProveedores);
                    this.panel1.Tag = frmObservarProveedores;
                    this.frmObservarProveedores.Activate();
                    frmObservarProveedores.BringToFront();
                }
                this.panel1.Refresh();
            }
        }

        private void FrmObservarProveedores_ondgvDoubleClick(object sender, EventArgs e)
        {
            List<string> datos =
                DatagridString.ReturnValuesOfCells(sender, 0);
            this.OpenAgregarProveedor(true, true, datos);
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            if (frm is FrmAgregarProveedor)
            {
                this.frmAgregarProveedor = null;
            }
            else if (frm is FrmObservarProveedores)
            {
                this.frmObservarProveedores = null;
            }
        }

        private FrmAgregarProveedor frmAgregarProveedor;
        private FrmObservarProveedores frmObservarProveedores;

    }
}

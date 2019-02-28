using System;
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
            frmObservarProveedores = new FrmObservarProveedores();
            frmObservarProveedores.FormBorderStyle = FormBorderStyle.None;
            frmObservarProveedores.Dock = DockStyle.Fill;
            frmObservarProveedores.TopLevel = false;
            frmObservarProveedores.editarProveedor = false;
            frmObservarProveedores.FormClosed += FrmObservarProveedores_FormClosed;
            this.panel1.Controls.Add(frmObservarProveedores);
            this.panel1.Tag = frmObservarProveedores;
            frmObservarProveedores.Show();
            frmObservarProveedores.BringToFront();
        }

        private void BtnObservarProveedores_Click(object sender, EventArgs e)
        {
            if (this.frmObservarProveedores == null)
            {
                frmObservarProveedores = new FrmObservarProveedores();
                frmObservarProveedores.FormBorderStyle = FormBorderStyle.None;
                frmObservarProveedores.Dock = DockStyle.Fill;
                frmObservarProveedores.TopLevel = false;
                frmObservarProveedores.editarProveedor = false;
                frmObservarProveedores.FormClosed += FrmObservarProveedores_FormClosed;
                this.panel1.Controls.Add(frmObservarProveedores);
                this.panel1.Tag = frmObservarProveedores;
                frmObservarProveedores.Show();
                frmObservarProveedores.BringToFront();
            }
            else
            {
                frmObservarProveedores.Activate();
                frmObservarProveedores.BringToFront();
            }
        }

        private void FrmObservarProveedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frmObservarProveedores = null;
        }

        private void BtnEditarProveedor_Click(object sender, EventArgs e)
        {
            if (this.frmObservarProveedores == null)
            {
                frmObservarProveedores = new FrmObservarProveedores();
                frmObservarProveedores.FormBorderStyle = FormBorderStyle.None;
                frmObservarProveedores.Dock = DockStyle.Fill;
                frmObservarProveedores.TopLevel = false;
                frmObservarProveedores.editarProveedor = true;
                frmObservarProveedores.ondgvDoubleClick += FrmObservar_ondgvDoubleClick;
                this.panel1.Controls.Add(frmObservarProveedores);
                this.panel1.Tag = frmObservarProveedores;
                frmObservarProveedores.Show();
                frmObservarProveedores.BringToFront();
            }
            else
            {
                frmObservarProveedores.editarProveedor = true;
                frmObservarProveedores.ondgvDoubleClick += FrmObservar_ondgvDoubleClick;
                frmObservarProveedores.Activate();
                frmObservarProveedores.BringToFront();
            }
        }

        private void FrmObservar_ondgvDoubleClick(object sender, EventArgs e)
        {
            FrmAgregarProveedor frm = new FrmAgregarProveedor();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            frm.IsEditar = true;
            frm.AsignarDatos(DatagridString.ReturnValuesOfCells(sender, 0));
            this.panel1.Controls.Add(frm);
            this.panel1.Tag = frm;
            frm.Show();
            frm.BringToFront();
        }

        private void BtnNuevoProveedor_Click(object sender, EventArgs e)
        {
            if (this.frmAgregarProveedor == null)
            {
                frmAgregarProveedor = new FrmAgregarProveedor();
                frmAgregarProveedor.FormBorderStyle = FormBorderStyle.None;
                frmAgregarProveedor.Dock = DockStyle.Fill;
                frmAgregarProveedor.TopLevel = false;
                frmAgregarProveedor.FormClosed += FrmAgregarProveedor_FormClosed;
                this.panel1.Controls.Add(frmAgregarProveedor);
                this.panel1.Tag = frmAgregarProveedor;
                frmAgregarProveedor.Show();
                frmAgregarProveedor.BringToFront();
            }
            else
            {
                this.frmAgregarProveedor.Activate();
                frmAgregarProveedor.BringToFront();
            }
        }

        private void FrmAgregarProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frmAgregarProveedor = null;
        }

        private FrmAgregarProveedor frmAgregarProveedor;
        private FrmObservarProveedores frmObservarProveedores;

    }
}

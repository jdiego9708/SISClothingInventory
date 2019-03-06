using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public partial class FrmArticulos : Form
    {
        public FrmArticulos()
        {
            InitializeComponent();
            this.btnNuevoArticulo.Click += BtnNuevoArticulo_Click;
            this.btnEditarArticulo.Click += BtnEditarArticulo_Click;
            this.btnObservarArticulos.Click += BtnObservarArticulos_Click;
            this.Load += FrmArticulos_Load;
        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            this.OpenObservarArticulos(true, false);
        }

        private void BtnObservarArticulos_Click(object sender, EventArgs e)
        {
            this.OpenObservarArticulos(true, false);
        }

        private void BtnEditarArticulo_Click(object sender, EventArgs e)
        {
            this.OpenObservarArticulos(true, true);
        }

        private void BtnNuevoArticulo_Click(object sender, EventArgs e)
        {
            this.OpenNuevoArticulo(true, false, null);
        }

        private void OpenNuevoArticulo(bool visible, bool isEditar,
            Articulo articulo)
        {
            if (visible)
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.frmNuevoArticulo == null)
                {
                    frmNuevoArticulo = new FrmNuevoArticulo();
                    frmNuevoArticulo.FormBorderStyle = FormBorderStyle.None;
                    frmNuevoArticulo.Dock = DockStyle.Fill;
                    frmNuevoArticulo.TopLevel = false;
                    frmNuevoArticulo.FormClosed += Frm_FormClosed;
                    frmNuevoArticulo.IsEditar = isEditar;
                    frmNuevoArticulo.Text = "Agregar un nuevo artículo";
                    if (isEditar)
                    {
                        frmNuevoArticulo.AsignarDatosArticulo(articulo);
                        frmNuevoArticulo.Text = "Editar los datos de un artículo";
                    }
                    this.panel1.Controls.Add(frmNuevoArticulo);
                    this.panel1.Tag = frmNuevoArticulo;
                    frmNuevoArticulo.Show();
                    frmNuevoArticulo.BringToFront();
                }
                else
                {
                    this.frmNuevoArticulo.IsEditar = isEditar;
                    this.frmNuevoArticulo.Text = "Agregar un nuevo artículo";
                    if (isEditar)
                    {
                        frmNuevoArticulo.AsignarDatosArticulo(articulo);
                        this.frmNuevoArticulo.Text = "Editar los datos de un artículo";
                    }
                    this.panel1.Controls.Add(frmNuevoArticulo);
                    this.panel1.Tag = frmNuevoArticulo;
                    this.frmNuevoArticulo.Activate();
                    this.frmNuevoArticulo.BringToFront();
                }
                this.panel1.Refresh();
            }
        }

        private void OpenObservarArticulos(bool visible, bool isEditar)
        {
            if (visible)
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.frmObservarArticulos == null)
                {
                    frmObservarArticulos = new FrmObservarArticulos();
                    frmObservarArticulos.IsEditar = isEditar;
                    frmObservarArticulos.FormBorderStyle = FormBorderStyle.None;
                    frmObservarArticulos.Dock = DockStyle.Fill;
                    frmObservarArticulos.TopLevel = false;
                    frmObservarArticulos.FormClosed += Frm_FormClosed;
                    this.frmObservarArticulos.Text = "Observar artículos existentes";
                    if (isEditar)
                    {
                        this.frmObservarArticulos.onEditarArticulo += FrmArticuloProfileEdit;
                        this.frmObservarArticulos.Text = "Seleccione un artículo para editar";
                    }
                    this.panel1.Controls.Add(frmObservarArticulos);
                    this.panel1.Tag = frmObservarArticulos;
                    frmObservarArticulos.Show();
                    frmObservarArticulos.BringToFront();
                }
                else
                {
                    this.frmObservarArticulos.Text = "Observar artículos existentes";
                    if (isEditar)
                    {
                        this.frmObservarArticulos.onEditarArticulo += FrmArticuloProfileEdit;
                        this.frmObservarArticulos.Text = "Seleccione un artículo para editar";
                    }

                    this.frmObservarArticulos.IsEditar = isEditar;
                    this.panel1.Controls.Add(frmObservarArticulos);
                    this.panel1.Tag = frmObservarArticulos;
                    this.frmObservarArticulos.Activate();
                    frmObservarArticulos.BringToFront();
                }
                this.panel1.Refresh();
            }
        }

        private void FrmArticuloProfileEdit(object sender, EventArgs e)
        {
            FrmArticuloProfile frmArticuloProfile = (FrmArticuloProfile)sender;
            Articulo articulo = frmArticuloProfile.Articulo;
            this.OpenNuevoArticulo(true, true, articulo);
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            if (frm is FrmNuevoArticulo)
            {
                this.frmNuevoArticulo = null;
            }
            else if (frm is FrmObservarArticulos)
            {
                this.frmObservarArticulos = null;
            }
        }

        private FrmNuevoArticulo frmNuevoArticulo;
        private FrmObservarArticulos frmObservarArticulos;
    }
}

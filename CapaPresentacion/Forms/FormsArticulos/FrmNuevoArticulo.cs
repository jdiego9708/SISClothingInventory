using CapaPresentacion.Controles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using CapaPresentacion.Forms.FormsProveedores;
using CapaPresentacion.Forms.FormsTipoArticulos;
using System.Data;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public partial class FrmNuevoArticulo : Form
    {
        public FrmNuevoArticulo()
        {
            InitializeComponent();
            this.btnAddImagenes.Click += BtnAddImagenes_Click;
            this.numericImagenes.ValueChanged += NumericImagenes_ValueChanged;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.txtTipo.Click += TxtTipo_Click;
            this.txtProveedor.Click += TxtProveedor_Click;
            this.txtPrecio.KeyPress += TxtPrecio_KeyPress;
        }

        private DataTable dtImages(out string rpta)
        {
            rpta = "OK";
            try
            {
                if (this.listImages == null)
                {
                    return null;
                }
                else if (this.listImages.Count < 1)
                {
                    return null;
                }

                DataTable table = new DataTable("Images");
                table.Columns.Add("Imagen", typeof(string));
                table.Columns.Add("Descripcion_imagen", typeof(string));

                foreach (UploadImage upload in this.listImages)
                {
                    //Código para guardar el nombre de la imagen y la descripcion en la tabla
                    //También llamar al método guardar de upload imagen
                }
                return table;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtProveedor_Click(object sender, EventArgs e)
        {
            FrmObservarProveedores frmObservarProveedores = new FrmObservarProveedores
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarProveedores.ondgvDoubleClick += FrmObservarProveedores_ondgvDoubleClick;
        }

        private void FrmObservarProveedores_ondgvDoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)sender;
            if (row != null)
            {
                this.txtProveedor.Text = Convert.ToString(row.Cells["Nombre_proveedor"].Value);
                this.txtProveedor.Tag = Convert.ToInt32(row.Cells["Id_proveedor"].Value);
            }
        }

        private void TxtTipo_Click(object sender, EventArgs e)
        {
            FrmObservarTipoArticulos observarTipoArticulos = new FrmObservarTipoArticulos();
            observarTipoArticulos.StartPosition = FormStartPosition.CenterScreen;
            observarTipoArticulos.ondgvDoubleClick += ObservarTipoArticulos_ondgvDoubleClick;
            observarTipoArticulos.ShowDialog();
        }

        private void ObservarTipoArticulos_ondgvDoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)sender;
            if (row != null)
            {
                this.txtTipo.Text = Convert.ToString(row.Cells["Nombre_tipo"].Value);
                this.txtTipo.Tag = Convert.ToInt32(row.Cells["Id_tipo_articulo"].Value);
            }
        }

        private bool Comprobaciones()
        {

        }

        private List<string> Variables()
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar artículos", ex.Message);
            }
        }

        List<UploadImage> listImages;

        private void NumericImagenes_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numeric = (NumericUpDown)sender;
            int cantidad_nueva = Convert.ToInt32(numeric.Value);
            int cantidad_anterior = Convert.ToInt32(numeric.Tag);
            if (cantidad_nueva > 0)
            {
                if (this.listImages.Count == 0)
                {
                    UploadImage upload = new UploadImage();
                    upload.Name = "Image" + cantidad_nueva;
                    upload.Numero_imagen = cantidad_nueva;
                    upload.Location = new System.Drawing.Point(0, 0);
                    this.listImages.Add(upload);
                    this.panelImágenes.Controls.Add(upload);
                }
                else
                {
                    if (cantidad_nueva > cantidad_anterior)
                    {
                        //Obtener último elemento de la lista
                        UploadImage upload = this.listImages.Last<UploadImage>();
                        int y = upload.Location.Y + upload.Height;
                        upload = new UploadImage();
                        upload.Name = "Image" + cantidad_nueva;
                        upload.Numero_imagen = cantidad_nueva;
                        upload.Location = new System.Drawing.Point(0, y);
                        this.listImages.Add(upload);
                        this.panelImágenes.Controls.Add(upload);
                    }
                    else
                    {
                        //Obtener último elemento de la lista
                        UploadImage upload = this.listImages.Last<UploadImage>();
                        this.listImages.Remove(upload);
                        this.panelImágenes.Controls.Remove(upload);
                    }
                }
                this.numericImagenes.Tag = cantidad_nueva;
            }
            else
            {
                this.listImages = new List<UploadImage>();
                this.panelImágenes.Controls.Clear();
            }
        }

        private void BtnAddImagenes_Click(object sender, EventArgs e)
        {
            if (this.panelImágenes.Visible)
            {
                this.lblImagenes.Visible = false;
                this.numericImagenes.Visible = false;
                this.btnAddImagenes.Text = "Agregar imágenes";
                this.listImages = null;
                this.panelImágenes.Visible = false;
                this.Width = this.Width - this.panelImágenes.Width - 2;
                this.numericImagenes.Value = 0;
                this.numericImagenes.Tag = 0;
            }
            else
            {
                this.lblImagenes.Visible = true;
                this.numericImagenes.Visible = true;
                this.btnAddImagenes.Text = "Sin imágenes";
                this.listImages = new List<UploadImage>();
                this.panelImágenes.Visible = true;
                this.Width = this.Width + this.panelImágenes.Width + 2;
                this.numericImagenes.Value = 1;
                this.numericImagenes.Tag = 1;
            }
        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}

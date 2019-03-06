using CapaNegocio;
using CapaPresentacion.Controles;
using CapaPresentacion.Forms.FormsProveedores;
using CapaPresentacion.Forms.FormsTipoArticulos;
using CapaPresentacion.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtTipo.Text = "Seleccione un tipo de artículo";
            this.txtTipo.Tag = null;
            this.txtProveedor.Text = "Seleccione un proveedor";
            this.txtProveedor.Tag = null;
            this.numericCantidad.Value = 0;
            this.numericCantidad.Tag = 0;
            this.txtPrecio.Text = "0";
            this.txtDescripcion.Text = string.Empty;
            this.Articulo = null;
            this.numericImagenes.Value = 0;
            this.numericImagenes.Tag = 0;

            if (this.panelImágenes.Visible)
                this.btnAddImagenes.PerformClick();
        }

        public void AsignarDatosArticulo(Articulo articulo)
        {
            this.Articulo = articulo;
            this.txtNombre.Text = articulo.Nombre_articulo;
            this.txtTipo.Text = articulo.Tipo_articulo;
            this.txtTipo.Tag = articulo.Id_tipo_articulo;
            this.txtProveedor.Text = articulo.Nombre_proveedor;
            this.txtProveedor.Tag = articulo.Id_proveedor;
            this.numericCantidad.Value = articulo.Cantidad;
            this.txtPrecio.Text = articulo.Precio.ToString();
            this.txtDescripcion.Text = articulo.Descripcion_articulo;

            if (articulo.DtImagenes != null)
            {
                this.numericImagenes.Value = articulo.DtImagenes.Rows.Count;
                this.numericImagenes.Tag = articulo.DtImagenes.Rows.Count - 1;

                int cantidad_nueva = 0;
                int cantidad_anterior = 0;

                foreach (DataRow row in articulo.DtImagenes.Rows)
                {
                    cantidad_nueva += 1;
                    if (cantidad_nueva > 0)
                    {
                        if (this.listImages.Count == 0)
                        {
                            UploadImage upload = new UploadImage();
                            upload.Name = "Image" + cantidad_nueva;
                            upload.Numero_imagen = cantidad_nueva;
                            upload.Location = new System.Drawing.Point(0, 0);
                            upload.AsignarImagen(Convert.ToString(row["Imagen"]), "RutaImagenesArticulos");
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
                                upload.AsignarImagen(Convert.ToString(row["Imagen"]), "RutaImagenesArticulos");
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
                        cantidad_anterior = cantidad_nueva;
                    }
                    else
                    {
                        this.listImages = new List<UploadImage>();
                        this.panelImágenes.Controls.Clear();
                    }
                }
            }
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
                    rpta =
                        ArchivosAdjuntos.GuardarArchivo(01, "RutaImagenesArticulos", upload.Nombre_imagen, upload.Ruta_origen);
                    if (rpta.Equals("OK"))
                    {
                        DataRow row = table.NewRow();
                        row["Imagen"] = upload.Nombre_imagen;
                        row["Descripcion_imagen"] = upload.Observaciones != null ? "" : upload.Observaciones;
                        table.Rows.Add(row);
                    }
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
                StartPosition = FormStartPosition.CenterScreen,
                nuevoArticulo = true
            };
            frmObservarProveedores.ondgvDoubleClick += FrmObservarProveedores_ondgvDoubleClick;
            frmObservarProveedores.Show();
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
            observarTipoArticulos.nuevoArticulo = true;
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
            bool result = true;

            if (this.txtNombre.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtNombre, "El nombre del artículo es necesario");
                result = false;
            }

            if (this.txtTipo.Tag.Equals(null))
            {
                this.errorProvider1.SetError(this.txtTipo, "El tipo de artículo es necesario");
                result = false;
            }

            if (this.txtProveedor.Tag.Equals(null))
            {
                this.errorProvider1.SetError(this.txtProveedor, "El proveedor es necesario");
                result = false;
            }

            if (this.numericCantidad.Value.Equals(0))
            {
                this.errorProvider1.SetError(this.numericCantidad, "La cantidad es necesaria");
                result = false;
            }

            if (Int32.TryParse(this.txtPrecio.Text, out int precio))
            {
                if (precio == 0 | precio < 500)
                {
                    this.errorProvider1.SetError(this.txtPrecio, "Verifique el precio, es obligatorio y" +
                                                                    " no puede ser menor que $500");
                    result = false;
                }
            }
            else
            {
                this.errorProvider1.SetError(this.txtPrecio, "El precio solo puede tener números");
                result = false;
            }
            return result;
        }

        private List<string> Variables()
        {
            return new List<string>
            {
                Convert.ToString(this.txtTipo.Tag), this.txtNombre.Text,
                Convert.ToString(this.txtProveedor.Tag), this.numericCantidad.Value.ToString(),
                "", this.txtDescripcion.Text, this.txtPrecio.Text
            };
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.Comprobaciones())
                {
                    int id_articulo;
                    DataTable dtImagenes = this.dtImages(out rpta);

                    string rptaImages = "OK";
                    if (!rpta.Equals("OK"))
                        rptaImages = rpta;

                    rpta =
                        NArticulos.InsertarArticulos(this.Variables(), dtImagenes, out id_articulo);

                    if (rpta.Equals("OK"))
                    {
                        if (rptaImages.Equals("OK"))
                        {
                            Mensajes.MensajeOkForm("Se guardó el artículo correctamente");
                        }
                        else
                        {
                            Mensajes.MensajeInformacion("Se guardó el artículo " +
                            "correctamente pero no se pudieron guardar las imágenes", "Entendido");
                        }
                    }
                }
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
                this.btnAddImagenes.Image = Resources.mas;
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
                this.btnAddImagenes.Image = Resources.negative;

            }
        }

        private Articulo Articulo;
        private bool _isEditar;
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}

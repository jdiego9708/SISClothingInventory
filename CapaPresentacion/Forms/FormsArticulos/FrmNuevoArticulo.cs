using CapaNegocio;
using CapaPresentacion.Controles;
using CapaPresentacion.Forms.FormsProveedores;
using CapaPresentacion.Forms.FormsTipoArticulos;
using CapaPresentacion.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public partial class FrmNuevoArticulo : Form
    {
        public FrmNuevoArticulo()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.txtTipo.Click += TxtTipo_Click;
            this.txtProveedor.Click += TxtProveedor_Click;
            this.txtPrecio.KeyPress += TxtPrecio_KeyPress;
            this.Load += FrmNuevoArticulo_Load;
            this.btnAgregarImagen.Click += BtnAgregarImagen_Click;
        }

        private void BtnAgregarImagen_Click(object sender, EventArgs e)
        {
            this.cantidad_imagenes += 1;
            UploadImage upload = new UploadImage();
            upload.Name = "Image" + cantidad_imagenes;
            upload.Numero_imagen = cantidad_imagenes;
            upload.Location = new System.Drawing.Point(0, 0);
            this.panel1.AddControl(upload);
            this.panel1.RefreshPanel(new UploadImage());
        }

        private void FrmNuevoArticulo_Load(object sender, EventArgs e)
        {
            this.panel1.Location = new Point(this.txtNombre.Location.X +
                this.txtNombre.Width + 10, this.txtNombre.Location.Y);
            this.Controls.Add(this.panel1);
            this.panel1.Visible = true;
            this.panel1.Columns = 1;
            this.toolBox1.Anchor = 
                ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.Controls.Add(toolBox1);
            this.toolBox1.Texto = "Agregar un artículo";
            this.toolBox1.EstablecerTexto();
            this.btnAgregarImagen.PerformClick();
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
            this.cantidad_imagenes = 0;
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
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Limpiar();

                this.cantidad_imagenes = articulo.DtImagenes.Rows.Count;

                int cantidad_nueva = 0;

                foreach (DataRow row in articulo.DtImagenes.Rows)
                {
                    cantidad_nueva += 1;
                    if (cantidad_nueva > 0)
                    {
                        UploadImage upload = new UploadImage();
                        upload.Name = "Image" + cantidad_nueva;
                        upload.Numero_imagen = cantidad_nueva;
                        upload.Location = new System.Drawing.Point(0, 0);
                        upload.Observaciones = Convert.ToString(row["Descripcion_imagen"]);
                        upload.AsignarImagen(Convert.ToString(row["Imagen"]), "RutaImagenesArticulos");
                        this.panel1.AddControl(upload);
                    }
                    else
                    {
                        this.panel1.Limpiar();
                    }
                }
                this.panel1.RefreshPanel(new UploadImage());
            }
        }

        private DataTable dtImages(out string rpta)
        {
            rpta = "OK";
            try
            {
                DataTable table = new DataTable("Images");
                table.Columns.Add("Imagen", typeof(string));
                table.Columns.Add("Descripcion_imagen", typeof(string));

                foreach (UploadImage upload in this.panel1.controls)
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

        private int cantidad_imagenes;
        private Articulo Articulo;
        private bool _isEditar;
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}

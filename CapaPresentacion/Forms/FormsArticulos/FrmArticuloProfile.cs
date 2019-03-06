using CapaPresentacion.Properties;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public partial class FrmArticuloProfile : Form
    {
        public FrmArticuloProfile()
        {
            InitializeComponent();
            this.Load += FrmArticuloProfile_Load;
            this.btnEditar.Click += BtnEditar_Click;
        }
        public event EventHandler onBtnEditarClick;

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (this.onBtnEditarClick != null)
                this.onBtnEditarClick(this.Articulo, e);
            this.Close();
        }

        private void FrmArticuloProfile_Load(object sender, EventArgs e)
        {
            if (this.Articulo != null)
            {
                this.Id_articulo = this.Articulo.Id_articulo;
                this.txtNombre.Text = this.Articulo.Nombre_articulo;
                this.txtTipo.Text = this.Articulo.Tipo_articulo;
                this.txtProveedor.Text = this.Articulo.Nombre_proveedor;
                this.lblCantidad.Text = "Cantidad: " + this.Articulo.Cantidad;
                this.txtPrecio.Text = this.Articulo.Precio.ToString();
                this.txtDescripcion.Text = this.Articulo.Descripcion_articulo;

                if (this.Articulo.DtImagenes != null)
                {
                    string rutaDestino;
                    int cantidad_images = this.Articulo.DtImagenes.Rows.Count;
                    if (cantidad_images == 1)
                    {
                        this.px1.Image = Imagenes.ObtenerImagen("RutaImagenesArticulos",
                            Convert.ToString(this.Articulo.DtImagenes.Rows[0]["Imagen"]), out rutaDestino);
                        this.px1.BringToFront();
                    }
                    else
                    {
                        bool primer_imagen = true;
                        foreach (DataRow row in this.Articulo.DtImagenes.Rows)
                        {
                            if (primer_imagen)
                            {
                                this.px1.Image = Imagenes.ObtenerImagen("RutaImagenesArticulos",
                                    Convert.ToString(row["Imagen"]), out rutaDestino);
                                this.panelImagenes.Tag = this.px1;
                                primer_imagen = false;
                            }
                            else
                            {
                                PictureBox pxAnterior = (PictureBox)this.panelImagenes.Tag;
                                PictureBox px = new PictureBox();
                                px.SizeMode = PictureBoxSizeMode.StretchImage;
                                px.Location = new System.Drawing.Point(pxAnterior.Location.X,
                                    pxAnterior.Location.Y + pxAnterior.Height);
                                this.panelImagenes.Controls.Add(px);
                                this.panelImagenes.Tag = px;
                            }
                        }
                    }
                }
                else
                {
                    this.px1.Image = Resources.SIN_IMAGEN1;
                }
            }
        }

        private int _id_articulo;
        public Articulo Articulo;

        public int Id_articulo { get => _id_articulo; set => _id_articulo = value; }
    }
}

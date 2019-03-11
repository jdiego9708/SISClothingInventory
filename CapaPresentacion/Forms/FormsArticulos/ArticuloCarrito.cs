using CapaPresentacion.Properties;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public partial class ArticuloCarrito : UserControl
    {
        public ArticuloCarrito()
        {
            InitializeComponent();
            this.chkArticulo.CheckedChanged += ChkArticulo_CheckedChanged;
            this.btnVerPerfil.Click += BtnVerPerfil_Click;
            this.btnRemove.Click += BtnRemove_Click;
        }

        private void BtnVerPerfil_Click(object sender, EventArgs e)
        {
            if (this.onBtnVerPerfilClick != null)
                this.onBtnVerPerfilClick(this, e);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (this.onBtnRemoveClick != null)
                this.onBtnRemoveClick(this, e);
        }


        private void ChkArticulo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.onChkArticuloCheckedChanged != null)
                this.onChkArticuloCheckedChanged(sender, e);
        }

        public void AsignarDatos(Articulo art)
        {
            this.Articulo = art;
            this.txtNombreArticulo.Text = art.Nombre_articulo;
            this.txtNombreProveedor.Text = art.Nombre_proveedor;
            this.txtPrecio.Text = "Precio " + art.Precio.ToString("C");
            this.txtCantidad.Text = "Cantidad " + art.Cantidad_carrito;
            this.txtSubTotal.Text = "Subtotal " + (art.Precio * art.Cantidad_carrito).ToString("C");
            string rutaDestino;
            if (art.DtImagenes != null)
            {
                if (art.DtImagenes.Rows.Count > 0)
                    this.pxImagen.Image =
                        Imagenes.ObtenerImagen("RutaImagenesArticulos",
                        Convert.ToString(art.DtImagenes.Rows[0]["Imagen"]),
                        out rutaDestino);
            }
            else
            {
                pxImagen.Image = Resources.SIN_IMAGEN1;
            }
        }

        public event EventHandler onChkArticuloCheckedChanged;
        public event EventHandler onBtnRemoveClick;
        public event EventHandler onBtnVerPerfilClick;

        private string _estado;
        private int _id_articulo;
        public Articulo Articulo;

        public int Id_articulo { get => _id_articulo; set => _id_articulo = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}

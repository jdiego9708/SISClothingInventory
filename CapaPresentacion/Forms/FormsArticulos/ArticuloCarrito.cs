using CapaPresentacion.Properties;
using System;
using System.Data;
using System.Drawing;
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

        public DataRow returnValues(DataTable model, string estado)
        {
            if (this.Articulo.Cantidad_carrito > this.Articulo.Cantidad)
            {
                return null;
            }

            DataRow row = model.NewRow();
            row["Id_detalle_articulo"] = this.Articulo.Id_articulo;
            row["Estado_venta"] = estado; ;
            row["Precio_cobrar"] = this.Articulo.Precio;
            row["Cantidad"] = this.Articulo.Cantidad_carrito;
            row["Observaciones"] = "";
            
            return row;
        }

        public void CalcularSubtotal()
        {
            if (this.Articulo.Cantidad >= this.Articulo.Cantidad_carrito)
            {
                this.txtCantidad.BackColor = Color.FromArgb(178, 245, 200);
                Ready = true;
            }
            else
            {
                this.txtCantidad.BackColor = Color.FromArgb(255, 168, 176);
                Ready = false;
            }

            int subtotal = this.Articulo.Precio * Articulo.Cantidad_carrito;
            this.txtSubTotal.Text = 
                "Subtotal " + Environment.NewLine + 
                (subtotal).ToString("C");
            this.txtSubTotal.Tag = subtotal;
        }

        private void BtnVerPerfil_Click(object sender, EventArgs e)
        {
            if (this.onBtnVerPerfilClick != null)
                this.onBtnVerPerfilClick(this, e);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            this.Articulo.Cantidad_carrito -= 1;
            this.txtCantidad.Text = "Cantidad "+ Environment.NewLine + this.Articulo.Cantidad_carrito;
            CalcularSubtotal();
            if (this.onBtnRemoveClick != null)
                this.onBtnRemoveClick(this, e);
        }

        private void ChkArticulo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.onChkArticuloCheckedChanged != null)
                this.onChkArticuloCheckedChanged(this, e);
        }

        public void AsignarDatos(Articulo art)
        {
            this.Articulo = art;
            this.toolTip1.SetToolTip(this.txtCantidad, "Cantidad en stock " + ( art.Cantidad ));
            this.txtNombreArticulo.Text = art.Nombre_articulo;
            this.txtNombreProveedor.Text = art.Nombre_proveedor;
            this.txtPrecio.Text = "Precio " + Environment.NewLine + art.Precio.ToString("C");
            this.txtCantidad.Text = "Cantidad "+ Environment.NewLine + art.Cantidad_carrito;
            this.CalcularSubtotal();
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
        private bool _ready;

        public int Id_articulo { get => _id_articulo; set => _id_articulo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public bool Ready { get => _ready; set => _ready = value; }
    }
}

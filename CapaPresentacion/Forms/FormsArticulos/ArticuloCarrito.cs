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
            this.BackColorChanged += ArticuloCarrito_BackColorChanged;
        }

        private void ArticuloCarrito_BackColorChanged(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (!this.Ready)
                {
                    control.BackColor = Color.FromArgb(255, 168, 176);
                }
                else
                {
                    control.BackColor = Color.FromArgb(178, 245, 200);
                }
            }
        }

        public DataRow returnValues(DataTable model, string estado)
        {
            this.CalcularSubtotal();
            if (!this.Ready)
            {
                this.BackColor = Color.FromArgb(255, 168, 176);
                return null;
            }
            else
            {
                this.BackColor = Color.FromArgb(178, 245, 200);
            }

            DataRow row = model.NewRow();
            row["Id_detalle_articulo"] = this.Articulo.Id_articulo;
            row["Estado_venta"] = estado;
            row["Precio_cobrar"] = this.Articulo.Precio;
            row["Cantidad"] = this.Articulo.Cantidad_carrito;
            row["Observaciones"] = "";

            return row;
        }

        public void CalcularSubtotal()
        {
            if (this.Articulo.Cantidad >= this.Articulo.Cantidad_carrito)
            {
                Ready = true;
                this.BackColor = Color.FromArgb(178, 245, 200);
                this.errorProvider1.Clear();
                this.chkArticulo.Enabled = true;
            }
            else
            {
                Ready = false;
                this.BackColor = Color.FromArgb(255, 168, 176);
                this.errorProvider1.SetError(this.txtCantidad, "Verifique la cantidad, no hay disponibilidad en stock");
                this.chkArticulo.Enabled = false;
                this.chkArticulo.Checked = false;
            }

            int subtotal = this.Articulo.Precio * Articulo.Cantidad_carrito;
            this.txtSubTotal.Text =
                "Subtotal " + Environment.NewLine +
                (subtotal).ToString("C");
            this.txtSubTotal.Tag = subtotal;
        }

        private void BtnVerPerfil_Click(object sender, EventArgs e)
        {
            this.OnBtnVerPerfilClick?.Invoke(this, e);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            this.Articulo.Cantidad_carrito -= 1;
            this.txtCantidad.Text = "Cantidad " + Environment.NewLine + this.Articulo.Cantidad_carrito;
            CalcularSubtotal();
            this.OnBtnRemoveClick?.Invoke(this, e);
        }

        private void ChkArticulo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            this.CalcularSubtotal();
            this.OnChkArticuloCheckedChanged?.Invoke(this, e);
        }

        public void AsignarDatos(Articulo art)
        {
            this.Articulo = art;
            this.toolTip1.SetToolTip(this.txtCantidad, "Cantidad en stock " + (art.Cantidad));
            this.txtNombreArticulo.Text = art.Nombre_articulo;
            this.txtNombreProveedor.Text = art.Nombre_proveedor;
            this.txtPrecio.Text = "Precio " + Environment.NewLine + art.Precio.ToString("C");
            this.txtCantidad.Text = "Cantidad " + Environment.NewLine + art.Cantidad_carrito;
            this.CalcularSubtotal();
            if (art.DtImagenes != null)
            {
                if (art.DtImagenes.Rows.Count > 0)
                    this.pxImagen.Image =
                        Imagenes.ObtenerImagen("RutaImagenesArticulos",
                        Convert.ToString(art.DtImagenes.Rows[0]["Imagen"]),
                        out string rutaDestino);
            }
            else
            {
                pxImagen.Image = Resources.SIN_IMAGEN1;
            }
        }

        public event EventHandler OnChkArticuloCheckedChanged;
        public event EventHandler OnBtnRemoveClick;
        public event EventHandler OnBtnVerPerfilClick;

        private string _estado;
        private int _id_articulo;
        public Articulo Articulo;
        private bool _ready;

        public int Id_articulo { get => _id_articulo; set => _id_articulo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public bool Ready { get => _ready; set => _ready = value; }
    }
}

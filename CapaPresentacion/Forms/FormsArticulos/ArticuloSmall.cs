using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaPresentacion.Properties;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public partial class ArticuloSmall : UserControl
    {
        public ArticuloSmall()
        {
            InitializeComponent();
            this.btnVerArticulo.Click += BtnVerArticulo_Click;
        }
        public event EventHandler onBtnVerArticuloClick;
        private void BtnVerArticulo_Click(object sender, EventArgs e)
        {
            if (onBtnVerArticuloClick != null)
                onBtnVerArticuloClick(this, e);
        }

        public Articulo articulo;

        public void AsignarDatosArticulo()
        {
            try
            {
                string rpta;
                DataTable dtArticulo =
                    NArticulos.BuscarArticulos("ID ARTICULO", this.Id_articulo.ToString(), out rpta);
                if (dtArticulo != null)
                {
                    articulo = new Articulo();
                    articulo.Id_articulo = this.Id_articulo;
                    articulo.Id_tipo_articulo = Convert.ToInt32(dtArticulo.Rows[0]["Id_tipo_articulo"]);
                    articulo.Tipo_articulo = Convert.ToString(dtArticulo.Rows[0]["Nombre_tipo"]);
                    articulo.Nombre_articulo = Convert.ToString(dtArticulo.Rows[0]["Nombre_articulo"]);
                    articulo.Id_proveedor = Convert.ToInt32(dtArticulo.Rows[0]["Id_proveedor"]);
                    articulo.Nombre_proveedor = Convert.ToString(dtArticulo.Rows[0]["Nombre_proveedor"]);
                    articulo.Cantidad = Convert.ToInt32(dtArticulo.Rows[0]["Cantidad"]);
                    articulo.Tipo_detalle = Convert.ToString(dtArticulo.Rows[0]["Tipo_detalle"]);
                    articulo.Descripcion_articulo = Convert.ToString(dtArticulo.Rows[0]["Descripcion_articulo"]);
                    articulo.Precio = Convert.ToInt32(dtArticulo.Rows[0]["Precio"]);

                    this.txtNombre.Text = articulo.Nombre_articulo;
                    this.txtDescripcion.Text = articulo.Descripcion_articulo;
                    this.lblTipo.Text = articulo.Tipo_articulo;
                    this.lblCantidad.Text = "Cantidad: " + articulo.Cantidad;

                    dtArticulo = 
                        NArticulos.BuscarImagenesArticulos("ID ARTICULO", this.Id_articulo.ToString(), out rpta);
                    if (dtArticulo != null)
                    {
                        articulo.DtImagenes = dtArticulo;
                        //Ajustar tamaño picture
                        int cantidad_images = dtArticulo.Rows.Count;
                        string rutaDestino;
                        if (cantidad_images == 1)
                        {
                            this.px1.Size = new Size(this.px1.Width * 2, this.px1.Height * 2);
                            this.px1.Image = Imagenes.ObtenerImagen("RutaImagenesArticulos",
                                Convert.ToString(dtArticulo.Rows[0]["Imagen"]), out rutaDestino);
                            this.px1.BringToFront();
                        }
                        else if (cantidad_images == 2)
                        {
                            this.px1.Size = new Size(this.px1.Width, this.px1.Height * 2);
                            this.px1.Image = Imagenes.ObtenerImagen("RutaImagenesArticulos",
                            Convert.ToString(dtArticulo.Rows[0]["Imagen"]), out rutaDestino);

                            this.px2.Size = new Size(this.px2.Width, this.px2.Height * 2);
                            this.px2.Image = Imagenes.ObtenerImagen("RutaImagenesArticulos",
                            Convert.ToString(dtArticulo.Rows[1]["Imagen"]), out rutaDestino);

                            this.px1.BringToFront();
                            this.px2.BringToFront();
                        }
                        else if (cantidad_images == 3)
                        {
                            this.px1.Size = new Size(this.px1.Width, this.px1.Height * 2);

                            this.px1.Image = Imagenes.ObtenerImagen("RutaImagenesArticulos",
                            Convert.ToString(dtArticulo.Rows[0]["Imagen"]), out rutaDestino);
                            this.px2.Image = Imagenes.ObtenerImagen("RutaImagenesArticulos",
                            Convert.ToString(dtArticulo.Rows[1]["Imagen"]), out rutaDestino);
                            this.px3.Image = Imagenes.ObtenerImagen("RutaImagenesArticulos",
                            Convert.ToString(dtArticulo.Rows[2]["Imagen"]), out rutaDestino);

                            this.px1.BringToFront();
                        }
                    }
                    else
                    {
                        this.px1.Size = new Size(this.px1.Width * 2, this.px1.Height * 2);
                        this.px1.Image = Resources.SIN_IMAGEN1;
                        this.px1.BringToFront();
                    }
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception("Hubo un error al buscar un artículo");
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AsignarDatosArticulo",
                    "Hubo un error al asignar los datos del artículo", ex.Message);
            }
        }

        private int _id_articulo;
        private bool _isEditar;

        public int Id_articulo { get => _id_articulo; set => _id_articulo = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}

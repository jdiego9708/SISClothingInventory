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
        }

        public void AsignarDatosArticulo()
        {
            try
            {
                string rpta;
                DataTable dtArticulo =
                    NArticulos.BuscarArticulos("ID ARTICULO", this.Id_articulo.ToString(), out rpta);
                if (dtArticulo != null)
                {
                    this.txtNombre.Text = Convert.ToString(dtArticulo.Rows[0]["Nombre_articulo"]);
                    this.txtDescripcion.Text = Convert.ToString(dtArticulo.Rows[0]["Descripcion_articulo"]);
                    this.lblTipo.Text = Convert.ToString(dtArticulo.Rows[0]["Nombre_tipo"]);
                    this.lblCantidad.Text = "Cantidad: " +Convert.ToString(dtArticulo.Rows[0]["Cantidad"]);

                    dtArticulo = 
                        NArticulos.BuscarImagenesArticulos("ID ARTICULO", this.Id_articulo.ToString(), out rpta);
                    if (dtArticulo != null)
                    {
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

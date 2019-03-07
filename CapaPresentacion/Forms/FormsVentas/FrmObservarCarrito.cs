using CapaPresentacion.Forms.FormsArticulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsVentas
{
    public partial class FrmObservarCarrito : Form
    {
        PoperContainer container;

        public FrmObservarCarrito()
        {
            InitializeComponent();
            this.Resize += FrmObservarCarrito_Resize;
            this.Load += FrmObservarCarrito_Load;
        }

        private void FrmObservarCarrito_Load(object sender, EventArgs e)
        {
            this.BuscarArticulos(this.listArticulosSmall);
        }

        private int ancho_panel;

        private void FrmObservarCarrito_Resize(object sender, EventArgs e)
        {
            this.ancho_panel = this.panelArticulos.Width;
        }

        public List<ArticuloSmall> listArticulosSmall;

        private void BuscarArticulos(List<ArticuloSmall> articulos)
        {
            try
            {
                MensajeEspera.ShowWait("Cargando");
                listArticulosSmall = articulos;
                this.panelArticulos.Enabled = true;
                this.label1.Text = listArticulosSmall.Count + " productos o artículos";
                this.panelArticulos.Controls.Clear();
                this.listArticulosSmall.Clear();

                int ancho_total_articulos = 0;
                
                foreach (ArticuloSmall articulo in this.listArticulosSmall)
                {
                    int positionX = 0;
                    int positionY = 0;
                    if (this.listArticulosSmall.Count < 1)
                    {
                        articulo.Location = new Point(positionX, positionY);
                    }
                    else
                    {
                        if (ancho_total_articulos > this.ancho_panel)
                        {
                            ArticuloSmall primerArticulo = this.listArticulosSmall.First<ArticuloSmall>();
                            positionX = 0;
                            positionY = primerArticulo.Location.Y + primerArticulo.Height;
                        }
                        else
                        {
                            ArticuloSmall articuloAnterior = this.listArticulosSmall.Last<ArticuloSmall>();
                            positionX = articuloAnterior.Location.X + articuloAnterior.Width;
                            positionY = articuloAnterior.Location.Y;
                        }
                        articulo.Location = new Point(positionX, positionY);
                    }
                    articulo.onBtnVerArticuloClick += Articulo_onBtnVerArticuloClick;
                    this.panelArticulos.Controls.Add(articulo);
                    this.listArticulosSmall.Add(articulo);
                }
                MensajeEspera.CloseForm();
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarArticulos",
                    "Hubo un error al buscar artículos", ex.Message);
            }
        }

        private void Articulo_onBtnVerArticuloClick(object sender, EventArgs e)
        {
            ArticuloSmall articulo = (ArticuloSmall)sender;
            FrmRealizarVenta realizarVenta = new FrmRealizarVenta()
            {
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                Articulo = articulo.articulo,
                TopLevel = false
            };
            this.container = new PoperContainer(realizarVenta);
            this.container.Show(articulo.btnVerArticulo);
        }
    }
}

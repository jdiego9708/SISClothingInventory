using CapaPresentacion.Forms.FormsArticulos;
using System;
using System.Collections.Generic;
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
        }

        public void BuscarArticulos(List<ArticuloSmall> articulos)
        {
            try
            {
                MensajeEspera.ShowWait("Cargando");
                this.panelArticulos.Enabled = true;
                this.label1.Text = articulos.Count + " productos o artículos";
                this.panelArticulos.Limpiar();

                foreach (ArticuloSmall articulo in articulos)
                {
                    articulo.onBtnVerArticuloClick += Articulo_onBtnVerArticuloClick;
                    this.panelArticulos.AddControl(articulo);
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

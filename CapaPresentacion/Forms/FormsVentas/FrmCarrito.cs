using CapaPresentacion.Controles;
using CapaPresentacion.Forms.FormsArticulos;
using CapaPresentacion.Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsVentas
{
    public partial class FrmCarrito : Form
    {
        PoperContainer container;

        public FrmCarrito()
        {
            InitializeComponent();
            this.Load += FrmObservarCarrito_Load;
            this.panelArticulos.Resize += PanelArticles_Resize;
            this.chkSeleccionarTodos.CheckedChanged += ChkSeleccionarTodos_CheckedChanged;
            this.rdVentaDirecta.CheckedChanged += RdVenta_CheckedChanged;
            this.rdSeparar.CheckedChanged += RdVenta_CheckedChanged;
            this.rdEnvio.CheckedChanged += RdVenta_CheckedChanged;
        }

        private void RdVenta_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.panel1.Controls.Clear();
                switch (Convert.ToString(rd.Tag).ToUpper())
                {
                    case "VENTA":
                        VentaDirecta venta = new VentaDirecta();
                        this.panel1.Controls.Add(venta);
                        break;
                    case "ENVIO":
                        EnvioPedido envio = new EnvioPedido();
                        this.panel1.Controls.Add(envio);
                        break;
                    case "SEPARAR":

                        break;
                }
            }
        }

        int items_seleccionados;

        private void ChkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (chk.Checked)
            {
                foreach (ArticuloCarrito carrito in this.panelArticulos.controls)
                {
                    carrito.chkArticulo.Checked = true;
                }
                this.items_seleccionados = this.panelArticulos.controls.Count;
            }
            else
            {
                foreach (ArticuloCarrito carrito in this.panelArticulos.controls)
                {
                    carrito.chkArticulo.Checked = false;
                }
                this.items_seleccionados = 0;
            }
            this.groupBox1.Text = "Productos seleccionados (" + this.items_seleccionados + ")";
        }

        private void PanelArticles_Resize(object sender, EventArgs e)
        {
            CustomGridPanel panel = (CustomGridPanel)sender;
            if (panel.SizeAutomatica)
            {
                this.panelArticulos.RefreshPanel(new ArticuloCarrito());
            }
        }

        private void FrmObservarCarrito_Load(object sender, EventArgs e)
        {
            this.panelArticulos.SizeAutomatica = false;
            this.panelArticulos.Columns = 1;
        }

        public void BuscarArticulos(List<ArticuloSmall> articulos)
        {
            try
            {
                if (articulos.Count > 10)
                    MensajeEspera.ShowWait("Cargando");

                this.panelArticulos.Enabled = true;
                //this.label1.Text = articulos.Count + " productos o artículos";
                this.panelArticulos.Limpiar();

                List<Articulo> nuevaListaArticulo = new List<Articulo>();
                foreach (ArticuloSmall articulo in articulos)
                {
                    object obj = (object)articulo.articulo;
                    obj = CopyDeep.Copy(obj);
                    Articulo art = (Articulo)obj;
                    nuevaListaArticulo.Add(art);
                }

                List<ArticuloCarrito> nuevaListaSmall = new List<ArticuloCarrito>();
                foreach (Articulo art in nuevaListaArticulo)
                {
                    ArticuloCarrito articulo = new ArticuloCarrito();
                    articulo.Id_articulo = art.Id_articulo;
                    articulo.AsignarDatos(art);
                    articulo.onChkArticuloCheckedChanged += Articulo_onChkArticuloCheckedChanged;
                    articulo.onBtnRemoveClick += Articulo_onBtnRemoveClick;
                    articulo.onBtnVerPerfilClick += Articulo_onBtnVerPerfilClick;
                    this.panelArticulos.AddControl(articulo);
                    nuevaListaSmall.Add(articulo);
                }
                this.panelArticulos.Width = this.Width;
                this.panelArticulos.RefreshPanel(new ArticuloCarrito());
                if (articulos.Count > 10)
                    MensajeEspera.CloseForm();
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarArticulos",
                    "Hubo un error al buscar artículos", ex.Message);
            }
        }

        private void Articulo_onBtnVerPerfilClick(object sender, EventArgs e)
        {
            ArticuloCarrito art = (ArticuloCarrito)sender;
            FrmArticuloProfile profile = new FrmArticuloProfile()
            {
                StartPosition = FormStartPosition.CenterScreen,
                IsVenta = false,
                Articulo = art.Articulo
            };
            profile.btnEditar.Visible = false;
            profile.ShowDialog();
        }

        private void Articulo_onChkArticuloCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            { 
                this.items_seleccionados += 1;
            }
            else
            {
                this.items_seleccionados -= 1;
            }
            this.groupBox1.Text = "Productos seleccionados (" + this.items_seleccionados + ")";
        }

        private void Articulo_onBtnRemoveClick(object sender, EventArgs e)
        {
            ArticuloCarrito art = (ArticuloCarrito)sender;
            this.panelArticulos.RemoveControl(art);
        }
    }
}

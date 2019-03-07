using CapaNegocio;
using CapaPresentacion.Controles;
using CapaPresentacion.Forms.FormsProveedores;
using CapaPresentacion.Forms.FormsTipoArticulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public partial class FrmObservarArticulos : Form
    {
        public FrmObservarArticulos()
        {
            InitializeComponent();
            this.txtBusqueda.onPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.onKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.onLostFocus += TxtBusqueda_onLostFocus;
            this.Load += FrmObservarArticulos_Load;
            this.btnTipoArticulos.Click += BtnTipoArticulos_Click;
            this.btnProveedores.Click += BtnProveedores_Click;
            this.Resize += FrmObservarArticulos_Resize;
        }

        private void FrmObservarArticulos_Resize(object sender, EventArgs e)
        {
            this.ancho_panel = this.panelArticulos.Width;
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            FrmObservarProveedores frmObservar = new FrmObservarProveedores
            {
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                observarArticulo = true
            };
            frmObservar.ondgvDoubleClick += FrmObservar_ondgvDoubleClick;
            frmObservar.ShowDialog();
        }

        private void FrmObservar_ondgvDoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)sender;
            this.txtBusqueda.Texto = Convert.ToString(row.Cells["Nombre_proveedor"].Value);
            this.txtBusqueda.EstablecerTexto();
            this.btnTipoArticulos.Tag = Convert.ToString(row.Cells["Id_proveedor"].Value);
            this.BuscarArticulos("ID PROVEEDOR", Convert.ToString(row.Cells["Id_proveedor"].Value));
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.TextoInicial) || txt.Equals(""))
            {
                this.BuscarArticulos("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
                {
                    this.BuscarArticulos("COMPLETO", "");
                }
                else
                {
                    this.BuscarArticulos("NOMBRE", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
            {
                this.BuscarArticulos("COMPLETO", "");
            }
            else
            {
                this.BuscarArticulos("NOMBRE", txt.Texto);
            }
        }

        private void BtnTipoArticulos_Click(object sender, EventArgs e)
        {
            FrmObservarTipoArticulos frmObservarTipoArticulos = new FrmObservarTipoArticulos
            {
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                observarArticulo = true
            };
            frmObservarTipoArticulos.ondgvDoubleClick += FrmObservarTipoArticulos_ondgvDoubleClick;
            frmObservarTipoArticulos.ShowDialog();
        }

        private void FrmObservarTipoArticulos_ondgvDoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)sender;
            this.txtBusqueda.Texto = Convert.ToString(row.Cells["Nombre_tipo"].Value);
            this.txtBusqueda.EstablecerTexto();
            this.btnTipoArticulos.Tag = Convert.ToString(row.Cells["Id_tipo_articulo"].Value);
            this.BuscarArticulos("TIPO ARTICULO", Convert.ToString(row.Cells["Id_tipo_articulo"].Value));
        }

        private void FrmObservarArticulos_Load(object sender, EventArgs e)
        {
            if (this.IsVenta)
            {
                this.articulosVenta = new List<ArticuloSmall>();
                this.btnCarrito.Visible = true;
            }

            this.Size = new Size(900, 478);
            this.ancho_panel = this.panelArticulos.Width;
            this.toolBox1.Texto = "Observar artículos";
            this.toolBox1.EstablecerTexto();
            this.txtBusqueda.TextoInicial = "Escriba para buscar artículos";
            this.txtBusqueda.EstablecerTextoInicial();
            this.listArticulosSmall = new List<ArticuloSmall>();
            this.BuscarArticulos("COMPLETO", "");
        }

        List<ArticuloSmall> listArticulosSmall;
        List<ArticuloSmall> articulosVenta;

        private void BuscarArticulos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                MensajeEspera.ShowWait("Buscando artículos");
                string rpta;
                DataTable dtArticulos =
                    NArticulos.BuscarArticulos(tipo_busqueda, texto_busqueda, out rpta);
                if (dtArticulos != null)
                {
                    this.panelArticulos.Enabled = true;
                    this.lblResultados.Text = "Se encontraron " + dtArticulos.Rows.Count + " artículos";
                    this.panelArticulos.Controls.Clear();
                    this.listArticulosSmall.Clear();

                    int ancho_total_articulos = 0;
                    foreach (DataRow row in dtArticulos.Rows)
                    {
                        int id_articulo = Convert.ToInt32(row["Id_articulo"]);
                        ArticuloSmall articulo = new ArticuloSmall();
                        ancho_total_articulos += articulo.Width;
                        articulo.Id_articulo = id_articulo;

                        if (this.IsVenta)
                        {
                            articulo.IsVenta = this.IsVenta;
                            articulo.onBtnAddCart += Articulo_onBtnAddCart;
                        }

                        articulo.AsignarDatosArticulo();

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

                        articulo.IsEditar = this.IsEditar;
                        this.panelArticulos.Controls.Add(articulo);
                        this.listArticulosSmall.Add(articulo);
                    }
                }
                else
                {
                    this.panelArticulos.Controls.Clear();
                    this.listArticulosSmall.Clear();
                    this.lblResultados.Text = "No se encontraron artículos";
                    this.panelArticulos.Enabled = false;
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

        private void Articulo_onBtnAddCart(object sender, EventArgs e)
        {
            ArticuloSmall art = (ArticuloSmall)sender;
            this.articulosVenta.Add(art);
            this.btnCarrito.Text = this.articulosVenta.Count.ToString();
        }

        private void Articulo_onBtnVerArticuloClick(object sender, EventArgs e)
        {
            if (this.IsEditar)
            {
                ArticuloSmall articuloSmall = (ArticuloSmall)sender;

                if (this.onEditarArticulo != null)
                    this.onEditarArticulo(articuloSmall.articulo, null);
            }
            else
            {
                ArticuloSmall articuloSmall = (ArticuloSmall)sender;
                FrmArticuloProfile articuloProfile = new FrmArticuloProfile
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Articulo = articuloSmall.articulo,
                    IsVenta = this.IsVenta,
                    ArticuloSmall = articuloSmall
                };
                articuloProfile.onBtnEditarClick += ArticuloProfile_onBtnEditarClick;

                if (this.IsVenta)
                    articuloProfile.onBtnAddCart += Articulo_onBtnAddCart;

                articuloProfile.Show();
            }
        }

        private void ArticuloProfile_onBtnEditarClick(object sender, EventArgs e)
        {
            //Sender es una clase Articulo con los datos necesario
            if (this.onEditarArticulo != null)
                this.onEditarArticulo(sender, null);
        }

        public event EventHandler onEditarArticulo;
        private int ancho_panel;
        private bool _isEditar;
        private bool _isVenta = false;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
        public bool IsVenta { get => _isVenta; set => _isVenta = value; }
    }
}

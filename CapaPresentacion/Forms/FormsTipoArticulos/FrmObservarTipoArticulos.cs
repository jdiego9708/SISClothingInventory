using CapaNegocio;
using CapaPresentacion.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsTipoArticulos
{
    public partial class FrmObservarTipoArticulos : Form
    {
        public FrmObservarTipoArticulos()
        {
            InitializeComponent();
            this.txtBusqueda.onPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.onKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.onLostFocus += TxtBusqueda_onLostFocus;
            this.dgvTipoArticulos.DoubleClick += DgvTipoArticulos_DoubleClick;
            this.Load += FrmObservarTipoArticulos_Load;
        }

        private void FrmObservarTipoArticulos_Load(object sender, EventArgs e)
        {
            this.txtBusqueda.TextoInicial = "Buscar tipos de artículos";
            this.txtBusqueda.EstablecerTextoInicial();
            this.BuscarTipoArticulos("COMPLETO", "");
        }

        private void DgvTipoArticulos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvTipoArticulos.CurrentRow;
                if (row != null)
                {
                    if (this.editarTipoArticulos)
                    {
                        if (this.ondgvDoubleClick != null)
                            this.ondgvDoubleClick(row, e);
                        this.Close();
                    }
                    else if (this.nuevoArticulo)
                    {
                        if (this.ondgvDoubleClick != null)
                            this.ondgvDoubleClick(row, e);
                        this.Close();
                    }
                    else if (this.observarArticulo)
                    {
                        if (this.ondgvDoubleClick != null)
                            this.ondgvDoubleClick(row, e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvTipoArticulos_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.TextoInicial) || txt.Equals(""))
            {
                this.BuscarTipoArticulos("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
                {
                    this.BuscarTipoArticulos("COMPLETO", "");
                }
                else
                {
                    this.BuscarTipoArticulos("NOMBRE", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
            {
                this.BuscarTipoArticulos("COMPLETO", "");
            }
            else
            {
                this.BuscarTipoArticulos("NOMBRE", txt.Texto);
            }
        }

        private void BuscarTipoArticulos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable tableTipoArticulos =
                    NTipo_articulos.BuscarTipoArticulos(tipo_busqueda, texto_busqueda, out string rpta);
                if (tableTipoArticulos != null)
                {
                    this.dgvTipoArticulos.Enabled = true;
                    this.dgvTipoArticulos.PageSize = 30;
                    this.dgvTipoArticulos.SetPagedDataSource(tableTipoArticulos, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id tipo artículo", "Nombre", "Descripción"
                    };

                    bool[] columns_visible =
                    {
                        false, true, true
                    };

                    this.dgvTipoArticulos =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvTipoArticulos,
                        columns_header, columns_visible);
                    this.lblResultados.Text = "Se encontraron " + tableTipoArticulos.Rows.Count + " tipos de artículos";

                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);

                    this.dgvTipoArticulos.clearDataSource();
                    this.dgvTipoArticulos.Enabled = false;
                    this.lblResultados.Text = "No se encontraron tipos de artículos";
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarProveedores",
                    "Hubo un error al buscar un tipo de artículo", ex.Message);
            }
        }

        public event EventHandler ondgvDoubleClick;

        public bool editarTipoArticulos = false;
        public bool nuevoArticulo = false;
        public bool observarArticulo = false;
    }
}

using CapaNegocio;
using CapaPresentacion.Controles;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsProveedores
{
    public partial class FrmObservarProveedores : Form
    {
        public FrmObservarProveedores()
        {
            InitializeComponent();
            this.Load += FrmObservarProveedores_Load;
            this.txtBusqueda.onPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.onKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.onLostFocus += TxtBusqueda_onLostFocus;
            this.dgvProveedores.DoubleClick += DgvProveedores_DoubleClick;
        }


        private void DgvProveedores_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvProveedores.CurrentRow;
                if (row != null)
                {
                    if (this.editarProveedor)
                    {
                        if (this.ondgvDoubleClick != null)
                            this.ondgvDoubleClick(row, e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvProveedores_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.TextoInicial) || txt.Equals(""))
            {
                this.BuscarProveedores("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
                {
                    this.BuscarProveedores("COMPLETO", "");
                }
                else
                {
                    this.BuscarProveedores("TODO", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
            {
                this.BuscarProveedores("COMPLETO", "");
            }
            else
            {
                this.BuscarProveedores("TODO", txt.Texto);
            }
        }

        private void FrmObservarProveedores_Load(object sender, EventArgs e)
        {
            this.lblEncabezaco.Text = this.Text;

            if (this.editarProveedor)
                this.lblEncabezaco.Text = "Seleccione un proveedor para editar";

            this.txtBusqueda.TextoInicial = "Buscar proveedores";
            this.txtBusqueda.EstablecerTextoInicial();
            this.BuscarProveedores("COMPLETO", "");
        }

        private void BuscarProveedores(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable tableProveedores =
                    NProveedores.BuscarProveedores(tipo_busqueda, texto_busqueda, out string rpta);
                if (tableProveedores != null)
                {
                    this.dgvProveedores.Enabled = true;
                    this.dgvProveedores.PageSize = 30;
                    this.dgvProveedores.SetPagedDataSource(tableProveedores, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id proveedor", "Fecha ingreso", "Nombre", "Teléfono", "Correo electrónico"
                    };

                    bool[] columns_visible =
                    {
                            false, false, true, true, true
                    };

                    this.dgvProveedores =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvProveedores,
                        columns_header, columns_visible);
                    this.lblResultados.Text = "Se encontraron " + tableProveedores.Rows.Count + " proveedores";

                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);

                    this.dgvProveedores.clearDataSource();
                    this.dgvProveedores.Enabled = false;
                    this.lblResultados.Text = "No se encontraron proveedores";
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarProveedores",
                    "Hubo un error al buscar un proveedor", ex.Message);
            }
        }

        public event EventHandler ondgvDoubleClick;

        public bool editarProveedor = false;
    }
}

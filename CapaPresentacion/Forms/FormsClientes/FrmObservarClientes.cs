using CapaNegocio;
using CapaPresentacion.Controles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsClientes
{
    public partial class FrmObservarClientes : Form
    {
        public FrmObservarClientes()
        {
            InitializeComponent();
            this.txtBusqueda.onPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.onKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.onLostFocus += TxtBusqueda_onLostFocus;
            this.dgvClientes.DoubleClick += DgvClientes_DoubleClick;
            this.Load += FrmObservarClientes_Load;
        }

        private void FrmObservarClientes_Load(object sender, EventArgs e)
        {
            this.txtBusqueda.TextoInicial = "Ingrese texto para buscar clientes";
            this.txtBusqueda.EstablecerTextoInicial();
        }

        private Cliente GetCliente(object row)
        {
            Cliente cliente = new Cliente();
            List<string> vs = DatagridString.ReturnValuesOfCells(row, 0);
            foreach (string ca in vs)
            {
                cliente.Id_cliente = Convert.ToInt32(vs[0]);
                cliente.Fecha_ingreso = Convert.ToDateTime(vs[1]);
                cliente.Nombre = Convert.ToString(vs[2]);
                cliente.Telefono = Convert.ToString(vs[3]);
                cliente.Correo = Convert.ToString(vs[4]);
            }
            return cliente;
        }

        private void DgvClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvClientes.CurrentRow;
                if (row != null)
                {
                    if (this.ondgvDoubleClick != null)
                        this.ondgvDoubleClick(this.GetCliente(row), e);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvClientes_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.TextoInicial) || txt.Equals(""))
            {
                this.BuscarClientes("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
                {
                    this.BuscarClientes("COMPLETO", "");
                }
                else
                {
                    this.BuscarClientes("TODO", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
            {
                this.BuscarClientes("COMPLETO", "");
            }
            else
            {
                this.BuscarClientes("TODO", txt.Texto);
            }
        }

        private void BuscarClientes(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable tableClientes =
                    NClientes.BuscarClientes(tipo_busqueda, texto_busqueda, out string rpta);
                if (tableClientes != null)
                {
                    this.dgvClientes.Enabled = true;
                    this.dgvClientes.PageSize = 30;
                    this.dgvClientes.SetPagedDataSource(tableClientes, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id cliente", "Fecha de ingreso", "Nombre", "Teléfono", "Correo electrónico"
                    };

                    bool[] columns_visible =
                    {
                         false, false, true, true, true
                    };

                    this.dgvClientes =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvClientes,
                        columns_header, columns_visible);
                    this.lblResultados.Text = "Se encontraron " + tableClientes.Rows.Count + " clientes";

                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);

                    this.dgvClientes.clearDataSource();
                    this.dgvClientes.Enabled = false;
                    this.lblResultados.Text = "No se encontraron clientes";
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarClientes",
                    "Hubo un error al buscar un cliente", ex.Message);
            }
        }

        public event EventHandler ondgvDoubleClick;

        private int _id_cliente;
        private bool _isEditar;

        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}

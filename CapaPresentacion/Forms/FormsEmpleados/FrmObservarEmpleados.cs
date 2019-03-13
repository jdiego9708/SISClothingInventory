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

namespace CapaPresentacion.Forms.FormsEmpleados
{
    public partial class FrmObservarEmpleados : Form
    {
        public FrmObservarEmpleados()
        {
            InitializeComponent();
            this.txtBusqueda.onPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.onKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.onLostFocus += TxtBusqueda_onLostFocus;
            this.dgvEmpleados.DoubleClick += DgvEmpleados_DoubleClick;
        }

        private void DgvEmpleados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvEmpleados.Enabled)
                {
                    DataGridViewRow row = this.dgvEmpleados.CurrentRow;
                    if (row != null & this.IsEditar)
                    {
                        if (this.ondgvDoubleClick != null)
                            this.ondgvDoubleClick(new Empleado(row), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvEmpleados_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.TextoInicial) || txt.Equals(""))
            {
                this.BuscarEmpleados("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
                {
                    this.BuscarEmpleados("COMPLETO", "");
                }
                else
                {
                    this.BuscarEmpleados("TODO", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.TextoInicial))
            {
                this.BuscarEmpleados("COMPLETO", "");
            }
            else
            {
                this.BuscarEmpleados("TODO", txt.Texto);
            }
        }

        private void BuscarEmpleados(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtEmpleados =
                    NEmpleados.BuscarEmpleado(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtEmpleados != null)
                {
                    this.dgvEmpleados.Enabled = true;
                    this.dgvEmpleados.PageSize = 10;
                    this.dgvEmpleados.SetPagedDataSource(dtEmpleados, this.bindingNavigator1);

                    string[] columns_header =
                   {
                        "Id empleado", "Nombre", "Teléfono", "Correo electrónico", "Cargo", "Password"
                    };

                    bool[] columns_visible =
                    {
                         false, true, true, true, true, false
                    };

                    this.dgvEmpleados =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvEmpleados,
                        columns_header, columns_visible);
                    this.lblResultados.Text = "Se encontraron " + dtEmpleados.Rows.Count + " empleados";
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);

                    this.dgvEmpleados.clearDataSource();
                    this.dgvEmpleados.Enabled = false;
                    this.lblResultados.Text = "No se encontraron empleados";
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarEmpleados", 
                    "Hubo un error al buscar empleados", ex.Message);
            }
        }

        public event EventHandler ondgvDoubleClick;

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}

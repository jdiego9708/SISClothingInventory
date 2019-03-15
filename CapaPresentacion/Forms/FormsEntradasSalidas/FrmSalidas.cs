using CapaNegocio;
using CapaPresentacion.Forms.FormsVentas;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsEntradasSalidas
{
    public partial class FrmSalidas : Form
    {
        public FrmSalidas()
        {
            InitializeComponent();
            this.dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            this.Load += FrmSalidas_Load;
        }

        private void FrmSalidas_Load(object sender, EventArgs e)
        {
            this.BuscarSalidas("ENVIOS", "");
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.BuscarSalidas("ENVIOS FECHA", this.dateTimePicker1.Value.ToShortDateString());
        }

        private void BuscarSalidas(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelEnvios.Limpiar();
                string fecha = this.dateTimePicker1.Value.ToShortDateString();
                DataTable dtSalidas =
                    NVentas.BuscarVentas(tipo_busqueda, texto_busqueda, fecha, out string rpta);
                if (dtSalidas != null)
                {
                    this.panelEnvios.Enabled = true;
                    foreach (DataRow row in dtSalidas.Rows)
                    {
                        SalidaSmall salida = new SalidaSmall();
                        salida.AsignarDatos(new VentasEnvios(row));
                        this.panelEnvios.AddControl(salida);
                    }
                    this.panelEnvios.RefreshPanel(new SalidaSmall());
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);

                    this.panelEnvios.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarSalidas",
                    "Hubo un error al buscar las salidas", ex.Message);
            }
        }
    }
}

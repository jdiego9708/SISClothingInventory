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

namespace CapaPresentacion.Forms.FormsPrincipales
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
            this.btnLogin.Click += BtnLogin_Click;
            this.txtPass.KeyPress += TxtPass_onKeyPress;
        }

        private void TxtPass_onKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.btnLogin.PerformClick();
            }
        }

        public event EventHandler onLogin;

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DataTable dtLogin =
                NEmpleados.Login(this.listaEmpleados.Text, this.txtPass.Text, out string rpta);
            if (dtLogin != null)
            {
                this.onLogin?.Invoke(dtLogin, e);
                this.Close();
            }
            else
            {
                Mensajes.MensajeInformacion("La contraseña es incorrecta", "Entendido");
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
                    this.listaEmpleados.DataSource = dtEmpleados;
                    this.listaEmpleados.ValueMember = "Id_empleado";
                    this.listaEmpleados.DisplayMember = "Nombre_empleado";
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarEmpleados",
                    "Hubo un error al buscar empleados en el inicio de sesión", ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.BuscarEmpleados("COMPLETO", "");
        }
    }
}

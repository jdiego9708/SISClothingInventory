using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Forms.FormsPrincipales;

namespace CapaPresentacion.Controles
{
    public partial class ToolBox : UserControl
    {
        public ToolBox()
        {
            InitializeComponent();
            this.MouseMove += ToolBox_MouseMove;
            this.MouseLeave += ToolBox_MouseLeave;
            this.lblEncabezaco.MouseMove += ToolBox_MouseMove;
            this.lblEncabezaco.MouseLeave += ToolBox_MouseLeave;
            this.Click += ToolBox_Click;
            this.lblEncabezaco.Click += ToolBox_Click;
            this.Load += ToolBox_Load;
        }

        public void EstablecerTexto()
        {
            this.lblEncabezaco.Text = this.Texto;
        }

        private void ToolBox_Load(object sender, EventArgs e)
        {
            this.lblEncabezaco.Text = this.Texto;
        }

        private void ToolBox_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is FrmPrincipal principal)
                {
                    principal.StartPosition = FormStartPosition.CenterScreen;
                    principal.WindowState = FormWindowState.Normal;
                    principal.Show();
                    principal.Activate();
                    break;
                }
            }
        }

        private void ToolBox_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(62, 177, 203);
        }

        private void ToolBox_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Teal;
        }

        private string _texto;

        public string Texto { get => _texto; set => _texto = value; }
    }
}

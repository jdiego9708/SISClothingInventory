using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Forms.FormsArticulos;
using CapaPresentacion.Forms.FormsProveedores;

namespace CapaPresentacion.Forms.FormsPrincipales
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            this.btnArticulos.Click += BtnArticulos_Click;
            this.btnProveedores.Click += BtnProveedores_Click;
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null)
            {
                FrmProveedores frm = new FrmProveedores();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormClosed += Frm_FormClosed;
                btn.Tag = frm;
                frm.Show();
            }
            else
            {
                FrmProveedores frm = (FrmProveedores)btn.Tag;
                frm.Activate();
            }
        }

        private void BtnArticulos_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null)
            {
                FrmArticulos frm = new FrmArticulos();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormClosed += Frm_FormClosed;
                btn.Tag = frm;
                frm.Show();
            }
            else
            {
                FrmArticulos frm = (FrmArticulos)btn.Tag;
                frm.Activate();
            }
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            if (frm is FrmArticulos)
            {
                this.btnArticulos.Tag = null;
            }
            else if (frm is FrmProveedores)
            {
                this.btnProveedores.Tag = null;
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public partial class FrmArticulos : Form
    {
        public FrmArticulos()
        {
            InitializeComponent();
            this.btnNuevoArticulo.Click += BtnNuevoArticulo_Click;
        }



        private void BtnNuevoArticulo_Click(object sender, EventArgs e)
        {
            if (panel1.Tag == null)
            {
                FrmNuevoArticulo frm = new FrmNuevoArticulo();
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                this.panel1.Tag = frm;
                frm.Show();
            }
        }
    }
}

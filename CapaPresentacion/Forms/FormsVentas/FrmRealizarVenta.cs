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

namespace CapaPresentacion.Forms.FormsVentas
{
    public partial class FrmRealizarVenta : Form
    {
        public FrmRealizarVenta()
        {
            InitializeComponent();
        }

        private Articulo _articulo;

        public Articulo Articulo { get => _articulo; set => _articulo = value; }
    }
}

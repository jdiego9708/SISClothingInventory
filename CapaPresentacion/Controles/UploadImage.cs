using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class UploadImage : UserControl
    {
        public UploadImage()
        {
            InitializeComponent();
        }

        private int _valor;

        public int Valor { get => _valor; set => _valor = value; }
    }
}

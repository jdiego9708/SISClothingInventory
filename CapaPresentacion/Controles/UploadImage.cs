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

        private string _nombre_imagen;
        private string _ruta_origen;
        private string _ruta_destino;
        private int _valor;

        public int Valor { get => _valor; set => _valor = value; }
        public string Nombre_imagen { get => _nombre_imagen; set => _nombre_imagen = value; }
        public string Ruta_origen { get => _ruta_origen; set => _ruta_origen = value; }
        public string Ruta_destino { get => _ruta_destino; set => _ruta_destino = value; }
    }
}

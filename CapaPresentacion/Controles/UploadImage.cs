using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Properties;

namespace CapaPresentacion.Controles
{
    public partial class UploadImage : UserControl
    {
        public UploadImage()
        {
            InitializeComponent();
            this.btnSeleccionar.Click += BtnSeleccionar_Click;
            this.Load += UploadImage_Load;
            this.btnLimpiar.Click += BtnLimpiar_Click;
        }

        public void AsignarImagen(string nombre_imagen)
        {
            string rutaOr;
            Image Imagen = Imagenes.ObtenerImagen(this.Tipo_imagen, nombre_imagen, out rutaOr);
            this.pxImagen.Image = Imagen;
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.txtImagen.Text = nombre_imagen;
            this.txtImagen.Tag = rutaOr;
            this.Ruta_origen = rutaOr;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtImagen.Text = string.Empty;
            this.txtImagen.Tag = null;
            this.pxImagen.Image = Resources.SIN_IMAGEN1;
        }

        private void UploadImage_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Imagen " + this.Numero_imagen;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo un objeto de tipo OpenFileDialog y lo instancio
                OpenFileDialog archivo = new OpenFileDialog();
                //Esta linea es para que solo se puedan visualizar los archivos con esta extension
                archivo.Filter = "Documentos válidos|*.jpg;*.png;*.jfif";
                //Lo abro como un Dialog
                DialogResult result = archivo.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.pxImagen.Image = Image.FromFile(archivo.FileName);
                    this.txtImagen.Text = archivo.SafeFileName;
                    this.txtImagen.Tag = archivo.FileName;
                    this.Ruta_origen = archivo.FileName;
                    this.Nombre_imagen = archivo.SafeFileName;
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnImagen_Click",
                    "Hubo un error al adjuntar la imagen", ex.Message);
            }
        }

        private string _nombre_imagen;
        private string _ruta_origen;
        private string _ruta_destino;
        private int _numero_imagen;
        private string _tipo_imagen;

        public string Nombre_imagen { get => _nombre_imagen; set => _nombre_imagen = value; }
        public string Ruta_origen { get => _ruta_origen; set => _ruta_origen = value; }
        public string Ruta_destino { get => _ruta_destino; set => _ruta_destino = value; }
        public int Numero_imagen { get => _numero_imagen; set => _numero_imagen = value; }
        public string Tipo_imagen { get => _tipo_imagen; set => _tipo_imagen = value; }
    }
}

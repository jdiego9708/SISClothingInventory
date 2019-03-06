using CapaPresentacion.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class UploadImage : UserControl
    {
        Observacion observacion;
        PoperContainer conObservaciones;

        public UploadImage()
        {
            InitializeComponent();

            this.observacion = new Observacion();
            this.conObservaciones = new PoperContainer(this.observacion);

            this.btnSeleccionar.Click += BtnSeleccionar_Click;
            this.Load += UploadImage_Load;
            this.btnLimpiar.Click += BtnLimpiar_Click;
            this.btnAgregarComentario.Click += BtnAgregarComentario_Click;
            this.observacion.btnCerrar.Click += BtnCerrar_Click;
            this.conObservaciones.Closing += ConObservaciones_Closing;
        }

        private void ConObservaciones_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            this.Observaciones = this.observacion.txtObservacion.Text;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.conObservaciones.Close();
        }

        private void BtnAgregarComentario_Click(object sender, EventArgs e)
        {
            this.conObservaciones.Show(this.btnAgregarComentario);
        }

        public void AsignarImagen(string nombre_imagen, string appKey)
        {
            string rutaOr;
            Image Imagen = Imagenes.ObtenerImagen(appKey, nombre_imagen, out rutaOr);
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
        private string _observaciones;

        public string Nombre_imagen { get => _nombre_imagen; set => _nombre_imagen = value; }
        public string Ruta_origen { get => _ruta_origen; set => _ruta_origen = value; }
        public string Ruta_destino { get => _ruta_destino; set => _ruta_destino = value; }
        public int Numero_imagen { get => _numero_imagen; set => _numero_imagen = value; }
        public string Tipo_imagen { get => _tipo_imagen; set => _tipo_imagen = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
    }
}

using CapaPresentacion.Controles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace CapaPresentacion.Forms.FormsArticulos
{
    public partial class FrmNuevoArticulo : Form
    {
        public FrmNuevoArticulo()
        {
            InitializeComponent();
            this.btnAddImagenes.Click += BtnAddImagenes_Click;
            this.numericImagenes.ValueChanged += NumericImagenes_ValueChanged;
        }

        List<UploadImage> listImages;

        private void NumericImagenes_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numeric = (NumericUpDown)sender;
            int cantidad_nueva = Convert.ToInt32(numeric.Value);
            int cantidad_anterior = Convert.ToInt32(numeric.Tag);
            if (cantidad_nueva > 0)
            {
                if (this.listImages.Count == 0)
                {
                    UploadImage upload = new UploadImage();
                    upload.Name = "Image" + cantidad_nueva;
                    upload.Valor = cantidad_nueva;
                    upload.Location = new System.Drawing.Point(0, 0);
                    this.listImages.Add(upload);
                    this.panelImágenes.Controls.Add(upload);
                }
                else
                {
                    if (cantidad_nueva > cantidad_anterior)
                    {
                        //Obtener último elemento de la lista
                        UploadImage upload = this.listImages.Last<UploadImage>();
                        int y = upload.Location.Y + upload.Height;
                        upload = new UploadImage();
                        upload.Name = "Image" + cantidad_nueva;
                        upload.Valor = cantidad_nueva;
                        upload.Location = new System.Drawing.Point(0, y);
                        this.listImages.Add(upload);
                        this.panelImágenes.Controls.Add(upload);
                    }
                    else
                    {
                        //Obtener último elemento de la lista
                        UploadImage upload = this.listImages.Last<UploadImage>();
                        this.listImages.Remove(upload);
                        this.panelImágenes.Controls.Remove(upload);
                    }
                }
                this.numericImagenes.Tag = cantidad_nueva;
            }
            else
            {
                this.listImages = new List<UploadImage>();
                this.panelImágenes.Controls.Clear();
            }
        }

        private void BtnAddImagenes_Click(object sender, EventArgs e)
        {
            if (this.panelImágenes.Visible)
            {
                this.lblImagenes.Visible = false;
                this.numericImagenes.Visible = false;
                this.btnAddImagenes.Text = "Agregar imágenes";
                this.listImages = null;
                this.panelImágenes.Visible = false;
                this.Width = this.Width - this.panelImágenes.Width - 2;
                this.numericImagenes.Value = 0;
                this.numericImagenes.Tag = 0;
            }
            else
            {
                this.lblImagenes.Visible = true;
                this.numericImagenes.Visible = true;
                this.btnAddImagenes.Text = "Sin imágenes";
                this.listImages = new List<UploadImage>();
                this.panelImágenes.Visible = true;
                this.Width = this.Width + this.panelImágenes.Width + 2;
                this.numericImagenes.Value = 1;
                this.numericImagenes.Tag = 1;
            }
        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}

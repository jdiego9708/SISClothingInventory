using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.IO;

namespace CapaPresentacion
{
    public class Imagenes
    {
        public static Image ObtenerImagen(string tipo, string nombre_imagen, out string rutaDestino)
        {
            rutaDestino = "";
            Image Image = null;
            try
            {
                string ruta = "";
                var appSettings = ConfigurationManager.AppSettings;
                if (nombre_imagen.Equals("SIN IMAGEN"))
                {
                    Image = Properties.Resources.SIN_IMAGEN1;
                }
                else
                {
                    if (tipo.Equals("IMAGENES EQUIPO"))
                    {
                        ruta = appSettings["RutaImagenesEquipo"].ToString();
                        ruta = Path.Combine(ruta, nombre_imagen);
                    }
                    else if (tipo.Equals("IMAGENES USUARIO"))
                    {
                        ruta = appSettings["RutaImagenesUsuario"].ToString();
                        ruta = Path.Combine(ruta, nombre_imagen);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    rutaDestino = ruta;
                    Image = Image.FromFile(ruta);
                }
            }
            catch (Exception ex)
            {
                rutaDestino = ex.Message;
                Image = Properties.Resources.SIN_IMAGEN1;
            }

            return Image;
        }
    }
}

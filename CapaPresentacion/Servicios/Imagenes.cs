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
        public static Image ObtenerImagen(string appKey, string nombre_imagen, out string rutaDestino)
        {
            rutaDestino = "";
            Image Image = null;
            try
            {
                string ruta = "";
                var appSettings = ConfigurationManager.AppSettings;
                if (nombre_imagen.Equals(""))
                {
                    Image = Properties.Resources.SIN_IMAGEN1;
                }
                else
                {
                    rutaDestino = appSettings[appKey].ToString();
                    ruta = Path.Combine(appSettings[appKey].ToString(), nombre_imagen);
                    Image = Image.FromFile(ruta);
                }
            }
            catch (Exception ex)
            {
                rutaDestino = ex.Message;
                Image = null;
            }

            return Image;
        }
    }
}

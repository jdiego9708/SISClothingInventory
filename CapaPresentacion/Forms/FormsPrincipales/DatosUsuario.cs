using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    public class DatosUsuario
    {
        #region PATRON SINGLETON
        private static DatosUsuario _Instancia;
        public static DatosUsuario GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DatosUsuario();
            }
            return _Instancia;
        }
        #endregion

        private int _id_usuario;
        private string _tipo_usuario;
        private string _nombre;

        public int Id_usuario { get => _id_usuario; set => _id_usuario = value; }
        public string Tipo_usuario { get => _tipo_usuario; set => _tipo_usuario = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}


using System.Windows.Forms;

namespace CapaPresentacion
{
    public class LlenarListas
    {
        public static ComboBox ListaTipoUsuarios(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("ADMINISTRADOR");
            lista.Items.Add("CAJERO");
            lista.Items.Add("OTRO");
            return lista;
        }
    }
}

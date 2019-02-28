using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace CapaPresentacion
{
    public class LlenarListas
    {
        public static ComboBox LlenarListaBuscarEquipos(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("NOMBRE");
            lista.Items.Add("SERIAL");
            lista.Items.Add("PLACA UCM");
            lista.Items.Add("REFERENCIA");
            lista.Items.Add("MARCA");
            lista.Items.Add("ESTADO");
            return lista;
        }

        public static ComboBox LlenarListaBuscarProveedores(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("NOMBRE");
            return lista;
        }

        public static ComboBox LlenarListaBuscarFabricantes(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("NOMBRE");
            return lista;
        }

        public static ComboBox LlenarListaUbicacionLaboratorio(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("BLOQUE A");
            lista.Items.Add("BLOQUE B");
            lista.Items.Add("BLOQUE C");
            lista.Items.Add("BLOQUE D");
            lista.Items.Add("BLOQUE E");
            lista.Items.Add("BLOQUE F");
            return lista;
        }

        public static ComboBox LlenarListaBusquedaLaboratorio(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("NOMBRE");
            return lista;
        }

        public static ComboBox ListaEquiposTipoAdquisicion(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("COMPRA");
            lista.Items.Add("COMODATO");
            lista.Items.Add("DONACIÓN");
            lista.Items.Add("NINGUNO");
            return lista;
        }

        public static ComboBox ListaEquiposFuenteAlimentacion(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("ELECTRICA");
            lista.Items.Add("VAPOR");
            lista.Items.Add("HIDRAULICA");
            lista.Items.Add("GASES MEDICIÓN");
            lista.Items.Add("NINGUNO");

            return lista;
        }

        public static ComboBox ListaEquiposTecnologiaPredominante(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("ELECTRICA");
            lista.Items.Add("VAPOR");
            lista.Items.Add("HIDRAULICA");
            lista.Items.Add("GASES MEDICIÓN");
            lista.Items.Add("NINGUNO");

            return lista;
        }

        public static ComboBox ListaEquiposClasificacionBiomedica(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("EQUIPO MÉDICO");
            lista.Items.Add("AGENTES DE DIAGNÓSTICO");
            lista.Items.Add("INSUMOS DE USO ODONTOLÓGICO");
            lista.Items.Add("MATERIALES QUIRÚRGICOS");
            lista.Items.Add("PRODUCTOS HIGIÉNICOS");
            lista.Items.Add("NINGUNO");
            return lista;
        }

        public static ComboBox ListaEquiposNivelRiesgo(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("ALTO");
            lista.Items.Add("MEDIO");
            lista.Items.Add("BAJO");
            return lista;
        }

        public static ComboBox ListaModulosBusqueda(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("NOMBRE");
            lista.Items.Add("LABORATORIO");
            return lista;
        }

        public static ComboBox ListaAccesoriosBusqueda(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("PLACA UCM");
            lista.Items.Add("NOMBRE");
            lista.Items.Add("MARCA");
            lista.Items.Add("REFENCIA");
            lista.Items.Add("SERIAL");
            lista.Items.Add("ESTADO");
            return lista;
        }

        public static ComboBox ListaTipoMantenimiento(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("PREVENTIVO");
            lista.Items.Add("CORRECTIVO");
            lista.Items.Add("RUTINA");
            lista.Items.Add("PREVENTIVO Y CORRECTIVO");
            lista.Items.Add("PREVENTIVO Y RUTINA");
            lista.Items.Add("CORRECTIVO Y RUTINA");
            return lista;
        }

        public static ComboBox ListaTipoUsuarios(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("ADMINISTRADOR DEL SISTEMA");
            lista.Items.Add("COLABORADOR DEL SISTEMA");
            lista.Items.Add("DOCENTE");
            lista.Items.Add("ESTUDIANTE");
            lista.Items.Add("ADMINISTRATIVO");
            lista.Items.Add("OTRO");
            return lista;
        }

        public static ComboBox ListaHoras(ComboBox lista)
        {
            lista.Items.Clear();
            lista.Items.Add("7:00");
            lista.Items.Add("8:00");
            lista.Items.Add("9:00");
            lista.Items.Add("10:00");
            lista.Items.Add("11:00");
            lista.Items.Add("12:00");
            lista.Items.Add("13:00");
            lista.Items.Add("14:00");
            lista.Items.Add("15:00");
            lista.Items.Add("16:00");
            lista.Items.Add("17:00");
            lista.Items.Add("18:00");
            lista.Items.Add("19:00");
            lista.Items.Add("20:00");
            lista.Items.Add("21:00");
            lista.Items.Add("22:00");
            return lista;
        }


    }
}

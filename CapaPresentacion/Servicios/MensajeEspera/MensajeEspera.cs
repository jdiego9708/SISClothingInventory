﻿using System.Threading;

namespace CapaPresentacion
{
    public class MensajeEspera
    {
        private delegate void CloseDelegate();
        private static FrmWait frmWait;

        static public void ShowWait(string mensaje)
        {
            if (frmWait != null)
                return;

            Thread thread = new Thread(new ThreadStart(() => ShowForm(mensaje)));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm(string mensaje)
        {
            frmWait = new FrmWait();
            frmWait.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frmWait.Mensaje = mensaje;
            frmWait.ShowDialog();
        }

        static public void CloseForm()
        {
            try
            {
                if (frmWait == null)
                    return;

                frmWait.Invoke(new CloseDelegate(CloseFormInternal));
            }
            catch (System.Exception)
            {

            }
        }

        static private void CloseFormInternal()
        {
            frmWait.Close();
            frmWait = null;
        }
    }
}

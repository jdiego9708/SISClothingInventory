using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using CapaPresentacion.Servicios.Mensajes;
using CapaPresentacion.Servicios;
using System.Threading;

namespace CapaPresentacion
{
    public class Mensajes
    {
        public static void InputBox(string descripcion, string txt_btn1,
        string txt_btn2, out DialogResult result, out string mensaje)
        {
            FrmInputBox FrmInputBox = new FrmInputBox();
            FrmInputBox.StartPosition = FormStartPosition.CenterScreen;
            FrmInputBox.Descripcion = descripcion;
            FrmInputBox.Texto_boton1 = txt_btn1;
            FrmInputBox.Texto_boton2 = txt_btn2;
            FrmInputBox.TopLevel = true;
            FrmInputBox.TopMost = true;
            FrmInputBox.ShowDialog();
            result = FrmInputBox.DialogResult;
            mensaje = FrmInputBox.Mensaje;
        }
        public static void MensajePregunta(string pregunta, string txt_btn1, 
            string txt_btn2, out DialogResult result)
        {
            FrmMensajePregunta FrmMensajePregunta = new FrmMensajePregunta();
            FrmMensajePregunta.StartPosition = FormStartPosition.CenterScreen;
            FrmMensajePregunta.Pregunta = pregunta;//MessageConvert.ConvertMessage(pregunta, 40);
            FrmMensajePregunta.Boton1 = txt_btn1;
            FrmMensajePregunta.Boton2 = txt_btn2;
            FrmMensajePregunta.TopLevel = true;
            FrmMensajePregunta.TopMost = true;
            FrmMensajePregunta.ShowDialog();
            result = FrmMensajePregunta.DialogResult;
        }


        public static void MensajeInformacion(string mensaje, string texto_boton)
        {
            FrmMensajeInformacion FrmMensajeInformacion = new FrmMensajeInformacion();
            FrmMensajeInformacion.StartPosition = FormStartPosition.CenterScreen;
            FrmMensajeInformacion.Mensaje = mensaje;
            FrmMensajeInformacion.Texto_boton = texto_boton;
            FrmMensajeInformacion.ShowDialog();
        }

        public static void MensajeEspera(string mensaje)
        {
            FrmWait frmWait = new FrmWait();
            frmWait.StartPosition = FormStartPosition.CenterScreen;
            frmWait.Mensaje = mensaje;
            if (!frmWait.IsDisposed)
            {
                frmWait.Show();
            }
        }

        public static void MensajeEspera(string mensaje, Thread proceso)
        {
            FrmWait frmWait = new FrmWait();
            frmWait.StartPosition = FormStartPosition.CenterScreen;
            frmWait.Mensaje = mensaje;
            frmWait.Show();
        }

        public static void MensajeErrorCompleto(string formulario_error, string metodo_error,
            string informacion_error, string detalle_error)
        {
            FrmMensajeErrorCompleto FrmMensajeError = new FrmMensajeErrorCompleto();
            FrmMensajeError.StartPosition = FormStartPosition.CenterScreen;
            FrmMensajeError.FormularioError = formulario_error;
            FrmMensajeError.MetodoError = metodo_error;
            FrmMensajeError.Informacion_corta = informacion_error;
            FrmMensajeError.Detalle_informacion = detalle_error;
            FrmMensajeError.ShowDialog();
        }
        public static void MensajeOkForm(string mensaje)
        {
            FrmMensajeOk FrmMensajeOk = new FrmMensajeOk();
            FrmMensajeOk.TopMost = true;
            FrmMensajeOk.Mensaje = MessageConvert.ConvertMessage(mensaje, 50);
            FrmMensajeOk.StartPosition = FormStartPosition.CenterScreen;
            FrmMensajeOk.ShowDialog();
        }

        public static void MensajeErrorForm(string mensaje)
        {
            FrmMensajeError FrmMensajeErrorForm = new FrmMensajeError();
            FrmMensajeErrorForm.TopMost = true;
            FrmMensajeErrorForm.Mensaje = MessageConvert.ConvertMessage(mensaje, 50);
            FrmMensajeErrorForm.StartPosition = FormStartPosition.CenterScreen;
            FrmMensajeErrorForm.ShowDialog();
        }

        //public static void MensajeOkDialog(string mensaje)
        //{
        //    MessageBox.Show(mensaje, "SIELAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //public static void MensajeErrorDialog(string mensaje)
        //{
        //    MessageBox.Show(mensaje, "SIELAB", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        //public static void MensajeInformacionDialog(string mensaje)
        //{
        //    MessageBox.Show(mensaje, "SIELAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //El mensaje personalizado es un método stático creado para editar los botones que aparecen en el MessageBox
        //public static DialogResult MensajePersonalizado1Boton(string tipo_mensaje, string TextoEnviar, string TextoBoton1)
        //{
        //    DialogResult dialog = new DialogResult();

        //    if (tipo_mensaje.Equals("PREGUNTA"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //    }
        //    else if (tipo_mensaje.Equals("ADVERTENCIA"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    else if (tipo_mensaje.Equals("EXCLAMACION"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    else if (tipo_mensaje.Equals("ERROR"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else if (tipo_mensaje.Equals("INFORMACION"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //    return dialog;
        //}

        //public static DialogResult MensajePersonalizado2Botones(string tipo_mensaje, string TextoEnviar, string TextoBoton1, string TextoBoton2)
        //{
        //    DialogResult dialog = new DialogResult();

        //    if (tipo_mensaje.Equals("PREGUNTA"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    }
        //    else if (tipo_mensaje.Equals("ADVERTENCIA"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //    }
        //    else if (tipo_mensaje.Equals("EXCLAMACION"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        //    }
        //    else if (tipo_mensaje.Equals("ERROR"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        //    }
        //    else if (tipo_mensaje.Equals("INFORMACION"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //    }

        //    return dialog;
        //}

        //public static DialogResult MensajePersonalizado3Botones(string tipo_mensaje, string TextoEnviar, string TextoBoton1, string TextoBoton2, string TextoBoton3)
        //{
        //    DialogResult dialog = new DialogResult();

        //    if (tipo_mensaje.Equals("PREGUNTA"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2, TextoBoton3);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        //    }
        //    else if (tipo_mensaje.Equals("ADVERTENCIA"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2, TextoBoton3);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        //    }
        //    else if (tipo_mensaje.Equals("EXCLAMACION"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2, TextoBoton3);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
        //    }
        //    else if (tipo_mensaje.Equals("ERROR"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2, TextoBoton3);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
        //    }
        //    else if (tipo_mensaje.Equals("INFORMACION"))
        //    {
        //        MsgBoxUtil.HackMessageBox(TextoBoton1, TextoBoton2, TextoBoton3);
        //        dialog = MessageBox.Show(TextoEnviar, "SIELAB", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        //    }

        //    return dialog;
        //}
    }
}

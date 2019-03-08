using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class CustomGridPanel : Panel
    {
        public List<UserControl> controls;
        public CustomGridPanel()
        {
            controls = new List<UserControl>();
            this.AutoScroll = true;
            this.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
                | AnchorStyles.Left) | AnchorStyles.Right)));
        }

        public void AddControl(UserControl control)
        {
            //Si la lista de controles está null creamos una nueva
            if (controls == null)
                controls = new List<UserControl>();

            //Agregamos el control a la lista
            this.controls.Add(control);
            this.RefreshPanel(control);
        }

        public void RemoveControl(UserControl control)
        {
            //Si la lista de controles está null o no hay controles retornamos
            if (controls == null | controls.Count == 0)
                return;

            //Agregamos el control a la lista
            this.controls.Remove(control);
            this.RefreshPanel(control);
        }

        public void Limpiar()
        {
            this.controls.Clear();
            this.Controls.Clear();
        }

        private void RefreshPanel(UserControl control)
        {
            //Limpiar todos los controles que tengamos
            this.Controls.Clear();
            //Si la cantidad de controles es mayor que cero, iniciamos
            if (this.controls.Count > 0)
            {
                //Ancho del panel
                int ancho_panel = this.Width;
                //Cantidad de controles de la lista
                int cantidad_controles = controls.Count;
                //Ancho del control que recibo
                int ancho_x_control = control.Width;
                //Cantidad de columnas en double, división entre ancho panel y ancho por control
                double cantidad_columns = ancho_panel / ancho_x_control;
                //Cantidad de columnas en entero, redondeando el double
                int cantidad_columnas = Convert.ToInt32(Math.Round(cantidad_columns, MidpointRounding.AwayFromZero));
                //Cantidad de filas
                int cantidad_filas = cantidad_controles / cantidad_columnas;

                //Si la cantidad de controles es igual a 1, agregaremos el primer control al panel
                if (cantidad_controles == 1)
                {
                    UserControl user = (UserControl)controls[0];
                    user.Location = new Point(0, 0);
                    this.Controls.Add(user);
                }
                else
                {
                    //Se usa para saber cuantos elementos se debe poner por fila
                    //No puede ser mayor que el número de columnas
                    int column = 1;
                    int positionX = 0;
                    int positionY = 0;
                    foreach (UserControl con in controls)
                    {
                        //Casteo el UserControl
                        UserControl user = (UserControl)con;
                        //Si positionColumn es menor que la cantidad de columnas
                        //continuamos
                        if (column <= cantidad_columnas)
                        {
                            //Asigno la posicion del control
                            user.Location = new Point(positionX, positionY);
                            positionX += user.Width;

                            //Sumar uno a la positionColumn
                            column += 1;
                        }
                        else
                        {
                            //Como ya terminamos en las columnas pasamos a otra fila
                            //Agregamos la información del primer cuadro de la fila
                            positionY += user.Height;
                            column = 1;
                            positionX = 0;

                            user.Location =
                                    new Point(positionX, positionY);
                            positionX += user.Width;
                            column += 1;
                        }
                        this.Controls.Add(user);
                    }
                }
            }
        }
    }
}

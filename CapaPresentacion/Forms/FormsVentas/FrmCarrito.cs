using CapaNegocio;
using CapaPresentacion.Controles;
using CapaPresentacion.Forms.FormsArticulos;
using CapaPresentacion.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsVentas
{
    public partial class FrmCarrito : Form
    {
        public FrmCarrito()
        {
            InitializeComponent();
            this.Load += FrmObservarCarrito_Load;
            this.panelArticulos.Resize += PanelArticles_Resize;
            this.chkSeleccionarTodos.CheckedChanged += ChkSeleccionarTodos_CheckedChanged;
            this.rdVentaDirecta.CheckedChanged += RdVenta_CheckedChanged;
            this.rdSeparar.CheckedChanged += RdVenta_CheckedChanged;
            this.rdEnvio.CheckedChanged += RdVenta_CheckedChanged;
            this.btnTerminar.Click += BtnTerminar_Click;
        }

        private DataTable dtDetalle(string estado, out bool finish, out string rpta)
        {
            DataTable dtDetalle = new DataTable();
            finish = true;
            rpta = "OK";
            try
            {
                dtDetalle.Columns.Add("Id_detalle_articulo", typeof(int));
                dtDetalle.Columns.Add("Estado_venta", typeof(string));
                dtDetalle.Columns.Add("Precio_cobrar", typeof(int));
                dtDetalle.Columns.Add("Cantidad", typeof(int));
                dtDetalle.Columns.Add("Observaciones", typeof(string));
                foreach (ArticuloCarrito art in this.panelArticulos.controls)
                {
                    if (art.chkArticulo.Checked)
                    {
                        if (art.Enabled)
                        {
                            DataRow row = art.returnValues(dtDetalle, estado);

                            if (row == null)
                            {
                                finish = false;
                                dtDetalle = null;
                                break;
                            }
                            else
                            {
                                art.Estado = "TERMINADO";
                                dtDetalle.Rows.Add(row);
                                art.Enabled = false;
                            }
                        }
                        else
                        {
                            finish = true;
                        }
                    }
                    else
                    {
                        if (art.Enabled)
                            finish = false;
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                dtDetalle = null;
            }
            return dtDetalle;
        }

        private void TotalValue(bool manual, int valor)
        {
            if (Int32.TryParse(this.lblTotal.Tag.ToString(), out int valor_lbl))
            {
                int total = valor_lbl;
                //Si el valor es menor que 0, es decir que es negativo y vamos a restar
                if (manual)
                {
                    total += valor;
                }
                else
                {
                    foreach (ArticuloCarrito art in this.panelArticulos.controls)
                    {
                        if (art.Ready)
                        {
                            int precio = art.Articulo.Precio;
                            int cantidad = art.Articulo.Cantidad_carrito;
                            total += precio * cantidad;
                        }
                        else
                        {
                            //int precio = art.Articulo.Precio;
                            //int cantidad = art.Articulo.Cantidad_carrito;
                            //total -= precio * cantidad;
                        }
                    }
                }
                this.lblTotal.Text = "Total: " + total.ToString("C");
                this.lblTotal.Tag = total;
            }
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            string tipo_venta;
            string rpta = "OK";
            string estado = "";
            DatosUsuario datos = DatosUsuario.GetInstancia();
            int id_empleado = datos.Id_usuario;
            bool finish = true;
            try
            {
                if (this.rdEnvio.Checked)
                {
                    tipo_venta = "ENVIO";
                    estado = "PENDIENTE ENVIO";
                    EnvioPedido envio = (EnvioPedido)this.panel1.Controls[0];
                    DataTable detalle = this.dtDetalle(estado, out finish, out rpta);
                    if (detalle != null)
                    {
                        if (envio.Comprobacion(out int id_cliente, out int id_direccion, out string observaciones))
                        {
                            List<string> Variables = new List<string>
                            {
                                id_empleado.ToString(), id_cliente.ToString(), id_direccion.ToString(),
                                tipo_venta, estado, observaciones
                            };
                            if (this.id_venta == 0)
                                rpta = NVentas.InsertarVentas(Variables, detalle, out this.id_venta);
                            else
                                rpta = NVentas.InsertarDetalleVentas(this.id_venta, detalle);

                            if (rpta.Equals("OK"))
                            {
                                Mensajes.MensajeInformacion("Venta realizada correctamente, para seguir " +
                                    "el detalle del envío vaya al módulo de entradas y salidas", "Entendido");
                                if (finish)
                                {
                                    this.Close();
                                }
                            }
                        }
                    }
                }
                else if (this.rdSeparar.Checked)
                {

                }
                else if (this.rdVentaDirecta.Checked)
                {
                    tipo_venta = "VENTA DIRECTA";
                    VentaDirecta venta = (VentaDirecta)this.panel1.Controls[0];
                    estado = "TERMINADO";
                    DataTable detalle = this.dtDetalle(estado, out finish, out rpta);
                    if (detalle != null)
                    {
                        if (venta.Comprobaciones(out int id_cliente,
                            out string tipo_pago, out string observaciones))
                        {
                            List<string> Variables = new List<string>
                                {
                                    id_empleado.ToString(), id_cliente.ToString(), "0",
                                    tipo_venta, estado, observaciones
                                };

                            if (this.id_venta == 0)
                                rpta = NVentas.InsertarVentas(Variables, detalle, out this.id_venta);
                            else
                                rpta = NVentas.InsertarDetalleVentas(this.id_venta, detalle);

                            if (rpta.Equals("OK"))
                            {
                                Mensajes.MensajeOkForm("¡Venta realizada correctamente!");
                                if (finish)
                                {
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnTerminar_Click",
                    "Hubo un error al terminar el pedido", ex.Message);
            }
        }

        private void RdVenta_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.panel1.Controls.Clear();
                switch (Convert.ToString(rd.Tag).ToUpper())
                {
                    case "VENTA":
                        VentaDirecta venta = new VentaDirecta();
                        this.panel1.Controls.Add(venta);
                        break;
                    case "ENVIO":
                        EnvioPedido envio = new EnvioPedido();
                        this.panel1.Controls.Add(envio);
                        break;
                    case "SEPARAR":

                        break;
                }
            }
        }

        int items_seleccionados;

        private void ChkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                this.lblTotal.Tag = 0;
                foreach (ArticuloCarrito carrito in this.panelArticulos.controls)
                {
                    carrito.chkArticulo.Checked = true;
                }
                this.items_seleccionados = this.panelArticulos.controls.Count;
            }
            else
            {
                foreach (ArticuloCarrito carrito in this.panelArticulos.controls)
                {
                    carrito.chkArticulo.Checked = false;
                }
                this.items_seleccionados = 0;
            }
            this.groupBox1.Text = "Productos seleccionados (" + this.items_seleccionados + ")";
        }

        private void PanelArticles_Resize(object sender, EventArgs e)
        {
            CustomGridPanel panel = (CustomGridPanel)sender;
            if (panel.SizeAutomatica)
            {
                this.panelArticulos.RefreshPanel(new ArticuloCarrito());
            }
        }

        private void FrmObservarCarrito_Load(object sender, EventArgs e)
        {
            this.panelArticulos.SizeAutomatica = false;
            this.panelArticulos.Columns = 1;
            this.rdVentaDirecta.Checked = true;
        }

        //Lista original, no se efectuan cambios
        List<Articulo> listArticulos;

        public void BuscarArticulos(List<ArticuloSmall> articulos)
        {
            try
            {
                if (articulos.Count > 10)
                    MensajeEspera.ShowWait("Cargando");

                this.panelArticulos.Enabled = true;
                //this.label1.Text = articulos.Count + " productos o artículos";
                this.panelArticulos.Limpiar();

                this.listArticulos = new List<Articulo>();
                foreach (ArticuloSmall articulo in articulos)
                {
                    object obj = (object)articulo.articulo;
                    obj = CopyDeep.Copy(obj);
                    Articulo art = (Articulo)obj;
                    listArticulos.Add(art);
                }

                this.chkSeleccionarTodos.Checked = true;

                List<ArticuloCarrito> nuevaListaSmall = new List<ArticuloCarrito>();
                foreach (Articulo art in listArticulos)
                {
                    ArticuloCarrito articulo = new ArticuloCarrito();
                    articulo.Id_articulo = art.Id_articulo;
                    articulo.AsignarDatos(art);
                    articulo.Tag = art.Id_articulo;
                    articulo.chkArticulo.Checked = true;
                    articulo.OnChkArticuloCheckedChanged += Articulo_onChkArticuloCheckedChanged;
                    articulo.OnBtnRemoveClick += Articulo_onBtnRemoveClick;
                    articulo.OnBtnVerPerfilClick += Articulo_onBtnVerPerfilClick;
                    this.panelArticulos.AddControl(articulo);
                    nuevaListaSmall.Add(articulo);
                    //this.TotalValue(true, art.Precio * art.Cantidad_carrito);
                }

                this.TotalValue(false, 0);
                this.items_seleccionados = this.panelArticulos.controls.Count;
                this.groupBox1.Text = "Productos seleccionados (" + this.items_seleccionados + ")";

                this.panelArticulos.Width = this.Width;
                this.panelArticulos.RefreshPanel(new ArticuloCarrito());
                if (articulos.Count > 10)
                    MensajeEspera.CloseForm();
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarArticulos",
                    "Hubo un error al buscar artículos", ex.Message);
            }
        }

        private void Articulo_onBtnVerPerfilClick(object sender, EventArgs e)
        {
            ArticuloCarrito art = (ArticuloCarrito)sender;
            FrmArticuloProfile profile = new FrmArticuloProfile()
            {
                StartPosition = FormStartPosition.CenterScreen,
                IsVenta = false,
                Articulo = art.Articulo
            };
            profile.btnEditar.Visible = false;
            profile.ShowDialog();
        }

        private void Articulo_onChkArticuloCheckedChanged(object sender, EventArgs e)
        {
            ArticuloCarrito art = (ArticuloCarrito)sender;
            int total = 0;
            if (art.Ready)
            {
                if (art.chkArticulo.Checked)
                {
                    total = art.Articulo.Precio * art.Articulo.Cantidad_carrito;
                    this.items_seleccionados += 1;
                    this.TotalValue(true, total);
                }
                else
                {
                    total = art.Articulo.Precio * art.Articulo.Cantidad_carrito;
                    this.items_seleccionados -= 1;
                    this.TotalValue(true, -total);
                }
            }
            else
            {
                this.items_seleccionados -= 1;
            }

            if (this.items_seleccionados == this.panelArticulos.controls.Count)
                this.chkSeleccionarTodos.Checked = true;

            this.groupBox1.Text = "Productos seleccionados (" + this.items_seleccionados + ")";
        }

        private void Articulo_onBtnRemoveClick(object sender, EventArgs e)
        {
            ArticuloCarrito art = (ArticuloCarrito)sender;
            int cantidad_articulo = 0;
            int precio_articulo_restado = 0;

            precio_articulo_restado = art.Articulo.Precio;
            cantidad_articulo = art.Articulo.Cantidad_carrito;

            this.TotalValue(true, -precio_articulo_restado);

            if (cantidad_articulo <= 0)
            {
                this.panelArticulos.RemoveControl(art);
                this.panelArticulos.RefreshPanel(art);
            }
        }

        private int id_venta = 0;
    }
}

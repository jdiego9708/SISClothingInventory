using CapaPresentacion.Forms.FormsArticulos;
using CapaPresentacion.Forms.FormsClientes;
using CapaPresentacion.Forms.FormsEntradasSalidas;
using CapaPresentacion.Forms.FormsProveedores;
using CapaPresentacion.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.FormsPrincipales
{
    public partial class FrmPrincipal : Form
    {
        Articulos controlArticulos;
        Proveedores controlProveedores;
        Clientes controlClientes;
        Ventas controlVentas;
        EntradasSalidas controlEntradasSalidas;
        PoperContainer container;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.btnArticulos.Click += BtnArticulos_Click;
            this.btnProveedores.Click += BtnProveedores_Click;
            this.btnClientes.Click += BtnClientes_Click;
            this.btnVentas.Click += BtnVentas_Click;
            this.btnUnlock.Click += BtnUnlock_Click;
            this.btnEntradasSalidas.Click += BtnEntradasSalidas_Click;
            this.Load += FrmPrincipal_Load;
        }

        #region ENTRADAS Y SALIDAS
        private void BtnEntradasSalidas_Click(object sender, EventArgs e)
        {
            this.controlEntradasSalidas = new EntradasSalidas();
            this.container = new PoperContainer(controlEntradasSalidas);
            this.controlEntradasSalidas.btnSalidas.Click += BtnSalidas_Click;
            this.container.Show(Cursor.Position);
        }

        private void BtnSalidas_Click(object sender, EventArgs e)
        {
            this.container.Close();
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmSalidas castForm)
                {
                    castForm.WindowState = FormWindowState.Maximized;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmSalidas form = new FrmSalidas
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmSalidas"
            };
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }
        #endregion

        #region VENTAS

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            this.controlVentas = new Ventas();
            this.container = new PoperContainer(controlVentas);
            this.controlVentas.btnNuevaVenta.Click += BtnNuevaVenta_Click;
            this.container.Show(Cursor.Position);
        }

        private void BtnNuevaVenta_Click(object sender, EventArgs e)
        {
            this.container.Close();
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmObservarArticulos castForm)
                {
                    castForm.WindowState = FormWindowState.Maximized;
                    castForm.IsVenta = true;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmObservarArticulos form = new FrmObservarArticulos
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmObservarArticulos",
                IsVenta = true
            };
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }
        #endregion

        #region Clientes

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            this.controlClientes = new Clientes();
            this.container = new PoperContainer(controlClientes);
            this.controlClientes.btnAgregarCliente.Click += BtnAgregarCliente_Click;
            this.controlClientes.btnEditarCliente.Click += BtnEditarCliente_Click;
            this.controlClientes.btnObservarClientes.Click += BtnObservarClientes_Click;
            this.container.Show(Cursor.Position);
        }

        private void BtnObservarClientes_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmObservarClientes castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmObservarClientes form = new FrmObservarClientes
            {
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmObservarClientes"
            };
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        private void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmObservarClientes castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Text = "Seleccione un cliente";
                    castForm.IsEditar = true;
                    castForm.ondgvDoubleClick += CastForm_ondgvDoubleClick1;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmObservarClientes form = new FrmObservarClientes
            {
                StartPosition = FormStartPosition.CenterScreen,
                IsEditar = true,
                Text = "Seleccione un cliente",
                Name = "FrmObservarClientes"
            };
            form.ondgvDoubleClick += CastForm_ondgvDoubleClick1;
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        private void CastForm_ondgvDoubleClick1(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmNuevoCliente castForm)
                {
                    Cliente cliente = (Cliente)sender;
                    castForm.IsEditar = true;
                    castForm.AsignarDatosEditar(cliente);
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmNuevoCliente form = new FrmNuevoCliente
            {
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmNuevoCliente",
                IsEditar = true
            };
            Cliente clientee = (Cliente)sender;
            form.AsignarDatosEditar(clientee);
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        private void BtnAgregarCliente_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmNuevoCliente castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmNuevoCliente form = new FrmNuevoCliente
            {
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmNuevoCliente"
            };
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        #endregion

        #region Proveedores
        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            this.controlProveedores = new Proveedores();
            this.container = new PoperContainer(controlProveedores);
            this.controlProveedores.btnAgregarProveedor.Click += BtnAgregarProveedor_Click;
            this.controlProveedores.btnEditarProveedor.Click += BtnEditarProveedor_Click;
            this.controlProveedores.btnObservarProveedores.Click += BtnObservarProveedores_Click;
            this.container.Show(Cursor.Position);
        }

        private void BtnObservarProveedores_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmObservarProveedores castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmObservarProveedores form = new FrmObservarProveedores
            {
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmObservarProveedores"
            };
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        private void BtnEditarProveedor_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmObservarProveedores castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Text = "Seleccione un proveedor";
                    castForm.editarProveedor = true;
                    castForm.ondgvDoubleClick += CastForm_ondgvDoubleClick;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmObservarProveedores form = new FrmObservarProveedores
            {
                StartPosition = FormStartPosition.CenterScreen,
                editarProveedor = true,
                Text = "Seleccione un proveedor",
                Name = "FrmObservarProveedores"
            };
            form.ondgvDoubleClick += CastForm_ondgvDoubleClick;
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        private void CastForm_ondgvDoubleClick(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmAgregarProveedor castForm)
                {
                    castForm.IsEditar = true;
                    castForm.AsignarDatos(DatagridString.ReturnValuesOfCells(sender, 0));
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmAgregarProveedor form = new FrmAgregarProveedor
            {
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmAgregarProveedor",
                IsEditar = true
            };
            form.AsignarDatos(DatagridString.ReturnValuesOfCells(sender, 0));
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        private void BtnAgregarProveedor_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmAgregarProveedor castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmAgregarProveedor form = new FrmAgregarProveedor
            {
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmAgregarProveedor"
            };
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }
        #endregion

        #region Articulos
        private void BtnArticulos_Click(object sender, EventArgs e)
        {
            this.controlArticulos = new Articulos();
            this.container = new PoperContainer(controlArticulos);
            this.controlArticulos.btnAgregarArticulo.Click += BtnAgregarArticulo_Click;
            this.controlArticulos.btnEditarArticulo.Click += BtnEditarArticulo_Click;
            this.controlArticulos.btnObservarArticulos.Click += BtnObservarArticulos_Click;
            this.container.Show(Cursor.Position);
        }

        private void BtnObservarArticulos_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmObservarArticulos castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmObservarArticulos form = new FrmObservarArticulos
            {
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmObservarArticulos"
            };
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        private void BtnEditarArticulo_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmObservarArticulos castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Text = "Seleccione un artículo";
                    castForm.IsEditar = true;
                    castForm.onEditarArticulo += Form_onEditarArticulo;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            //Form frm = this.formsAbiertos.Find(x => x.Name == "FrmObservarArticulos");
            FrmObservarArticulos form = new FrmObservarArticulos
            {
                StartPosition = FormStartPosition.CenterScreen,
                IsEditar = true,
                Text = "Seleccione un artículo",
                Name = "FrmObservarArticulos"
            };
            form.onEditarArticulo += Form_onEditarArticulo;
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);

        }

        private void Form_onEditarArticulo(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)sender;

            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmNuevoArticulo castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.IsEditar = true;
                    castForm.Text = "Editar los datos de un artículo";
                    castForm.Name = "FrmNuevoArticulo";
                    castForm.AsignarDatosArticulo(articulo);
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmNuevoArticulo form = new FrmNuevoArticulo
            {
                StartPosition = FormStartPosition.CenterScreen,
                IsEditar = true,
                Text = "Editar los datos de un artículo",
                Name = "FrmNuevoArticulo"
            };
            form.AsignarDatosArticulo(articulo);
            form.FormClosed += Frm_FormClosed;
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        private void Frm_articuloProfile_edit(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)sender;

            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmNuevoArticulo castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.IsEditar = true;
                    castForm.Text = "Editar los datos de un artículo";
                    castForm.Name = "FrmNuevoArticulo";
                    castForm.Show();
                    castForm.AsignarDatosArticulo(articulo);
                    castForm.Activate();
                    return;
                }
            }

            FrmNuevoArticulo form = new FrmNuevoArticulo
            {
                StartPosition = FormStartPosition.CenterScreen,
                IsEditar = true,
                Text = "Editar los datos de un artículo",
                Name = "FrmNuevoArticulo"
            };
            form.AsignarDatosArticulo(articulo);
            form.FormClosed += Frm_FormClosed;
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }

        private void BtnAgregarArticulo_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.formsAbiertos)
            {
                if (formulario is FrmNuevoArticulo castForm)
                {
                    castForm.WindowState = FormWindowState.Normal;
                    castForm.Show();
                    castForm.Activate();
                    return;
                }
            }

            FrmNuevoArticulo form = new FrmNuevoArticulo
            {
                StartPosition = FormStartPosition.CenterScreen,
                Name = "FrmNuevoArticulo"
            };
            form.FormClosed += Frm_FormClosed;
            form.Show();
            Form frm = (Form)form;
            this.formsAbiertos.Add(frm);
        }
        #endregion

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            this.formsAbiertos.Remove(frm);
        }

        List<Form> formsAbiertos = new List<Form>();

        private void BtnUnlock_Click(object sender, EventArgs e)
        {
            if (bloqueado)
            {
                FrmLogin login = new FrmLogin()
                {
                    FormBorderStyle = FormBorderStyle.None,
                    TopLevel = false
                };
                login.onLogin += Login_onLogin;
                login.Show();
                this.container = new PoperContainer(login);
                this.container.Show(this.btnUnlock);
            }
            else
            {
                bloqueado = true;
                this.btnUnlock.Image = Resources.locked;
                this.btnArticulos.Enabled = false;
                this.btnProveedores.Enabled = false;
                this.btnClientes.Enabled = false;
                this.btnVentas.Enabled = false;
                this.btnEstadisticas.Enabled = false;
                this.btnEntradasSalidas.Enabled = false;
                this.btnMantenimiento.Enabled = false;
                this.btnConfig.Enabled = false;
                this.btnPendientes.Enabled = false;
            }
        }

        private void Login_onLogin(object sender, EventArgs e)
        {
            this.container.Close();
            bloqueado = false;
            this.btnUnlock.Image = Resources.unlocked;
            this.btnArticulos.Enabled = true;
            this.btnProveedores.Enabled = true;
            this.btnClientes.Enabled = true;
            this.btnVentas.Enabled = true;
            this.btnEstadisticas.Enabled = true;
            this.btnEntradasSalidas.Enabled = true;
            this.btnMantenimiento.Enabled = true;
            this.btnConfig.Enabled = true;
            this.btnPendientes.Enabled = true;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.btnUnlock.PerformClick();
            //Código para mostrar notificaciones
        }

        private bool bloqueado = false;
    }
}

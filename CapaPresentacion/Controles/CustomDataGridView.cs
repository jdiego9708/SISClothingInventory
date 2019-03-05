using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();

            this.EnableHeadersVisualStyles = false;
            //Mostrar botón de agregar filas
            this.AllowUserToAddRows = false;
            //Mostrar botón de eliminar filas
            this.AllowUserToDeleteRows = false;
            //Habilitar cambiar el tamaño de columnas
            this.AllowUserToResizeColumns = false;
            //Habilitar cambiar tamaño de las filas
            this.AllowUserToResizeRows = false;
            //Valor que se muestra en celda con valor null
            this.DefaultCellStyle.NullValue = "No hay dato";
            //Ajustar tamaño de encabezado de columna
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //Ajustar tamaño de encabezado de fila
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //Establecer el alto por default
            this.RowTemplate.Height = 30;
            //Seleccionar toda la fila al dar en una celda
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Seleccionar varias filas
            this.MultiSelect = true;
            //Establece el color de fondo de un estilo de celda
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            /**Obtiene o establece el estilo de celda predeterminado que se aplicará
            a las filas impares**/
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            //Los bordes del contenedor enlazado
            this.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            //Como se determina el ancho de las columnas
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //Color de fondo de todo el datagridview
            this.BackgroundColor = System.Drawing.Color.White;
            //Borde datagridview
            this.BorderStyle = BorderStyle.None;
            //Estilo de borde de celda
            this.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            //Estilo de borde a los encabezados de columna
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //Posición del texto de la celda
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Color de fondo de la celda
            dataGridViewCellStyle2.BackColor = Color.FromArgb(34, 143, 168);
            //Fuente aplicada a el estilo de la celda
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            //Color de la letra de las celdas
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(245, 245, 245);
            //Color de fondo cuando se selecciona una celda
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(242, 242, 242);
            //Color de la letra cuando está en modo selección
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(100, 97, 90);
            //Obtiene o establece un valor que indica si el texto debe continuar la linea o se trunca
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            //Obtiene o establece el estilo de todas las celdas
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            //Alineación del texto de cabecera
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //Color de fondo del estilo de cabecera
            dataGridViewCellStyle3.BackColor = Color.FromArgb(227, 224, 217);
            //Fuente para la cabecera
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            //Color de letra para la cabecera
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlDark;
            //Color de fondo utilizado cuando se selecciona una celda
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ScrollBar;
            //Color de letra utilizado cuando cambia el color de fondo
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            //Especificar si el texto sigue o se trunca
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            //Establecer el estilo por default de la cabecera
            this.DefaultCellStyle = dataGridViewCellStyle3;
            //this.Location = new System.Drawing.Point(12, 132);
            this.Name = "Datagrid";
            //Editar celdas
            this.ReadOnly = false;
            //Estilo de borde de las celdas de encabezado de fila
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //Mostrar columna que contiene los encabezados de fila
            this.RowHeadersVisible = false;
            //Color de fondo de una celda
            dataGridViewCellStyle4.BackColor = Color.FromArgb(245, 245, 245);
            //Obtiene el estilo por default de las celdas
            this.RowsDefaultCellStyle = dataGridViewCellStyle4;
            //this.Size = new System.Drawing.Size(857, 334);
            this.TabIndex = 7;
            this.Refresh();
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        public int _pageSize = 10;

        BindingSource bs = new BindingSource();
        BindingList<DataTable> tables = new BindingList<DataTable>();
        public void SetPagedDataSource(DataTable dataTable, BindingNavigator bnav)
        {
            DataTable dt = null;
            this.clearDataSource();
            int counter = 1;
            foreach (DataRow dr in dataTable.Rows)
            {
                if (counter == 1)
                {
                    dt = dataTable.Clone();
                    tables.Add(dt);
                }
                dt.Rows.Add(dr.ItemArray);
                if (PageSize < ++counter)
                {
                    counter = 1;
                }
            }
            bnav.BindingSource = bs;
            bs.DataSource = tables;
            bs.PositionChanged += bs_PositionChanged;
            bs_PositionChanged(bs, EventArgs.Empty);
        }
        void bs_PositionChanged(object sender, EventArgs e)
        {
            this.DataSource = tables[bs.Position];
        }

        public void clearDataSource()
        {
            this.tables = new BindingList<DataTable>();
            this.DataSource = null;
            this.bs = new BindingSource();
        }
    }
}

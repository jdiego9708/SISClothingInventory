namespace CapaPresentacion.Forms.FormsVentas
{
    partial class FrmCarrito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarrito));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnArticulos = new System.Windows.Forms.Button();
            this.chkSeleccionarTodos = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTipoVenta = new System.Windows.Forms.Panel();
            this.rdVentaDirecta = new System.Windows.Forms.RadioButton();
            this.rdEnvio = new System.Windows.Forms.RadioButton();
            this.rdSeparar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelArticulos = new CapaPresentacion.Controles.CustomGridPanel();
            this.groupBox1.SuspendLayout();
            this.panelTipoVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnArticulos
            // 
            this.btnArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArticulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(177)))), ((int)(((byte)(203)))));
            this.btnArticulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArticulos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnArticulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnArticulos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulos.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulos.ForeColor = System.Drawing.Color.White;
            this.btnArticulos.Image = ((System.Drawing.Image)(resources.GetObject("btnArticulos.Image")));
            this.btnArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArticulos.Location = new System.Drawing.Point(4, 423);
            this.btnArticulos.Name = "btnArticulos";
            this.btnArticulos.Size = new System.Drawing.Size(202, 39);
            this.btnArticulos.TabIndex = 1;
            this.btnArticulos.Text = "Finalizar";
            this.toolTip1.SetToolTip(this.btnArticulos, "Finalice el pedido para los elementos seleccionados");
            this.btnArticulos.UseVisualStyleBackColor = false;
            // 
            // chkSeleccionarTodos
            // 
            this.chkSeleccionarTodos.AutoSize = true;
            this.chkSeleccionarTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSeleccionarTodos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSeleccionarTodos.Location = new System.Drawing.Point(225, 6);
            this.chkSeleccionarTodos.Name = "chkSeleccionarTodos";
            this.chkSeleccionarTodos.Size = new System.Drawing.Size(131, 21);
            this.chkSeleccionarTodos.TabIndex = 18;
            this.chkSeleccionarTodos.Text = "Seleccionar todos";
            this.chkSeleccionarTodos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.panelTipoVenta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnArticulos);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 470);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos seleccionados";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Location = new System.Drawing.Point(3, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 291);
            this.panel1.TabIndex = 7;
            // 
            // panelTipoVenta
            // 
            this.panelTipoVenta.Controls.Add(this.rdVentaDirecta);
            this.panelTipoVenta.Controls.Add(this.rdEnvio);
            this.panelTipoVenta.Controls.Add(this.rdSeparar);
            this.panelTipoVenta.Location = new System.Drawing.Point(3, 21);
            this.panelTipoVenta.Name = "panelTipoVenta";
            this.panelTipoVenta.Size = new System.Drawing.Size(203, 76);
            this.panelTipoVenta.TabIndex = 6;
            // 
            // rdVentaDirecta
            // 
            this.rdVentaDirecta.AutoSize = true;
            this.rdVentaDirecta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdVentaDirecta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdVentaDirecta.Location = new System.Drawing.Point(2, 2);
            this.rdVentaDirecta.Name = "rdVentaDirecta";
            this.rdVentaDirecta.Size = new System.Drawing.Size(117, 24);
            this.rdVentaDirecta.TabIndex = 2;
            this.rdVentaDirecta.TabStop = true;
            this.rdVentaDirecta.Tag = "VENTA";
            this.rdVentaDirecta.Text = "Venta directa";
            this.rdVentaDirecta.UseVisualStyleBackColor = true;
            // 
            // rdEnvio
            // 
            this.rdEnvio.AutoSize = true;
            this.rdEnvio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdEnvio.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdEnvio.Location = new System.Drawing.Point(2, 23);
            this.rdEnvio.Name = "rdEnvio";
            this.rdEnvio.Size = new System.Drawing.Size(65, 24);
            this.rdEnvio.TabIndex = 3;
            this.rdEnvio.TabStop = true;
            this.rdEnvio.Tag = "ENVIO";
            this.rdEnvio.Text = "Envío";
            this.rdEnvio.UseVisualStyleBackColor = true;
            // 
            // rdSeparar
            // 
            this.rdSeparar.AutoSize = true;
            this.rdSeparar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdSeparar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSeparar.Location = new System.Drawing.Point(2, 46);
            this.rdSeparar.Name = "rdSeparar";
            this.rdSeparar.Size = new System.Drawing.Size(80, 24);
            this.rdSeparar.TabIndex = 4;
            this.rdSeparar.TabStop = true;
            this.rdSeparar.Tag = "SEPARAR";
            this.rdSeparar.Text = "Separar";
            this.rdSeparar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(59, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // panelArticulos
            // 
            this.panelArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelArticulos.AutoScroll = true;
            this.panelArticulos.Columns = 0;
            this.panelArticulos.Location = new System.Drawing.Point(225, 33);
            this.panelArticulos.Name = "panelArticulos";
            this.panelArticulos.Size = new System.Drawing.Size(617, 531);
            this.panelArticulos.SizeAutomatica = false;
            this.panelArticulos.TabIndex = 2;
            // 
            // FrmCarrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 576);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkSeleccionarTodos);
            this.Controls.Add(this.panelArticulos);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmCarrito";
            this.Text = "Carrito";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelTipoVenta.ResumeLayout(false);
            this.panelTipoVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controles.CustomGridPanel panelArticulos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkSeleccionarTodos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnArticulos;
        private System.Windows.Forms.RadioButton rdVentaDirecta;
        private System.Windows.Forms.RadioButton rdEnvio;
        private System.Windows.Forms.RadioButton rdSeparar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTipoVenta;
        private System.Windows.Forms.Panel panel1;
    }
}
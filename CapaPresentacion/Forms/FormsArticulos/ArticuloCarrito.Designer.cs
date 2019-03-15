namespace CapaPresentacion.Forms.FormsArticulos
{
    partial class ArticuloCarrito
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloCarrito));
            this.chkArticulo = new System.Windows.Forms.CheckBox();
            this.txtNombreArticulo = new System.Windows.Forms.TextBox();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.pxImagen = new System.Windows.Forms.PictureBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnVerPerfil = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pxImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkArticulo
            // 
            this.chkArticulo.AutoSize = true;
            this.chkArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkArticulo.Location = new System.Drawing.Point(7, 13);
            this.chkArticulo.Name = "chkArticulo";
            this.chkArticulo.Size = new System.Drawing.Size(15, 14);
            this.chkArticulo.TabIndex = 1;
            this.chkArticulo.UseVisualStyleBackColor = true;
            // 
            // txtNombreArticulo
            // 
            this.txtNombreArticulo.BackColor = System.Drawing.Color.White;
            this.txtNombreArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreArticulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNombreArticulo.ForeColor = System.Drawing.Color.Gray;
            this.txtNombreArticulo.Location = new System.Drawing.Point(84, 1);
            this.txtNombreArticulo.Name = "txtNombreArticulo";
            this.txtNombreArticulo.ReadOnly = true;
            this.txtNombreArticulo.Size = new System.Drawing.Size(145, 16);
            this.txtNombreArticulo.TabIndex = 2;
            this.txtNombreArticulo.Text = "Nombre  artículo";
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.BackColor = System.Drawing.Color.White;
            this.txtNombreProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreProveedor.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNombreProveedor.ForeColor = System.Drawing.Color.Gray;
            this.txtNombreProveedor.Location = new System.Drawing.Point(84, 24);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.ReadOnly = true;
            this.txtNombreProveedor.Size = new System.Drawing.Size(145, 16);
            this.txtNombreProveedor.TabIndex = 3;
            this.txtNombreProveedor.Text = "Nombre proveedor";
            // 
            // pxImagen
            // 
            this.pxImagen.Location = new System.Drawing.Point(28, 0);
            this.pxImagen.Name = "pxImagen";
            this.pxImagen.Size = new System.Drawing.Size(49, 41);
            this.pxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pxImagen.TabIndex = 0;
            this.pxImagen.TabStop = false;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.White;
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecio.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.ForeColor = System.Drawing.Color.Gray;
            this.txtPrecio.Location = new System.Drawing.Point(235, 0);
            this.txtPrecio.Multiline = true;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(79, 38);
            this.txtPrecio.TabIndex = 5;
            this.txtPrecio.Text = "Precio";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidad.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.Gray;
            this.txtCantidad.Location = new System.Drawing.Point(316, 0);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.ReadOnly = true;
            this.txtCantidad.Size = new System.Drawing.Size(65, 38);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.Text = "Cantidad";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BackColor = System.Drawing.Color.White;
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSubTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.Color.Gray;
            this.txtSubTotal.Location = new System.Drawing.Point(398, 0);
            this.txtSubTotal.Multiline = true;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(74, 38);
            this.txtSubTotal.TabIndex = 7;
            this.txtSubTotal.Text = "SubTotal";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.BackgroundImage = global::CapaPresentacion.Properties.Resources.negative;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(477, 8);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(25, 25);
            this.btnRemove.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnRemove, "Reducir 1");
            this.btnRemove.UseVisualStyleBackColor = false;
            // 
            // btnVerPerfil
            // 
            this.btnVerPerfil.BackColor = System.Drawing.Color.White;
            this.btnVerPerfil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerPerfil.BackgroundImage")));
            this.btnVerPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerPerfil.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnVerPerfil.FlatAppearance.BorderSize = 0;
            this.btnVerPerfil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVerPerfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnVerPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPerfil.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVerPerfil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerPerfil.Location = new System.Drawing.Point(508, 8);
            this.btnVerPerfil.Name = "btnVerPerfil";
            this.btnVerPerfil.Size = new System.Drawing.Size(25, 25);
            this.btnVerPerfil.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnVerPerfil, "Ver perfil");
            this.btnVerPerfil.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ArticuloCarrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnVerPerfil);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtNombreProveedor);
            this.Controls.Add(this.txtNombreArticulo);
            this.Controls.Add(this.chkArticulo);
            this.Controls.Add(this.pxImagen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gray;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ArticuloCarrito";
            this.Size = new System.Drawing.Size(536, 41);
            ((System.ComponentModel.ISupportInitialize)(this.pxImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pxImagen;
        private System.Windows.Forms.TextBox txtNombreArticulo;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtSubTotal;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.Button btnVerPerfil;
        public System.Windows.Forms.CheckBox chkArticulo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

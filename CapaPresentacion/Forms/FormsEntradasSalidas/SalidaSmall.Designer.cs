namespace CapaPresentacion.Forms.FormsEntradasSalidas
{
    partial class SalidaSmall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalidaSmall));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuienRecibe = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.gbEstado = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnFinalizado = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnEnCamino = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInicio = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbEstado.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtCorreo);
            this.groupBox1.Controls.Add(this.txtQuienRecibe);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de salida:";
            // 
            // txtQuienRecibe
            // 
            this.txtQuienRecibe.BackColor = System.Drawing.Color.White;
            this.txtQuienRecibe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuienRecibe.ForeColor = System.Drawing.Color.Gray;
            this.txtQuienRecibe.Location = new System.Drawing.Point(7, 103);
            this.txtQuienRecibe.Name = "txtQuienRecibe";
            this.txtQuienRecibe.ReadOnly = true;
            this.txtQuienRecibe.Size = new System.Drawing.Size(367, 18);
            this.txtQuienRecibe.TabIndex = 2;
            this.txtQuienRecibe.Text = "Quien recibe";
            this.txtQuienRecibe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.ForeColor = System.Drawing.Color.Gray;
            this.txtDireccion.Location = new System.Drawing.Point(7, 81);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(367, 18);
            this.txtDireccion.TabIndex = 1;
            this.txtDireccion.Text = "Dirección";
            this.txtDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCliente.ForeColor = System.Drawing.Color.Gray;
            this.txtCliente.Location = new System.Drawing.Point(7, 17);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(367, 18);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.Text = "Cliente";
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbEstado
            // 
            this.gbEstado.Controls.Add(this.groupBox5);
            this.gbEstado.Controls.Add(this.groupBox4);
            this.gbEstado.Controls.Add(this.groupBox3);
            this.gbEstado.Location = new System.Drawing.Point(4, 145);
            this.gbEstado.Name = "gbEstado";
            this.gbEstado.Size = new System.Drawing.Size(380, 122);
            this.gbEstado.TabIndex = 1;
            this.gbEstado.TabStop = false;
            this.gbEstado.Text = "Seguimiento (Estado actual:)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnFinalizado);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(274, 33);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(80, 62);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Finalizado";
            // 
            // btnFinalizado
            // 
            this.btnFinalizado.BackColor = System.Drawing.Color.White;
            this.btnFinalizado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFinalizado.BackgroundImage")));
            this.btnFinalizado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFinalizado.Cursor = System.Windows.Forms.Cursors.No;
            this.btnFinalizado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnFinalizado.FlatAppearance.BorderSize = 0;
            this.btnFinalizado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFinalizado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnFinalizado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizado.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFinalizado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizado.Location = new System.Drawing.Point(22, 16);
            this.btnFinalizado.Name = "btnFinalizado";
            this.btnFinalizado.Size = new System.Drawing.Size(38, 37);
            this.btnFinalizado.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btnFinalizado, "El pedido está en su fase de entrega");
            this.btnFinalizado.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnEnCamino);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(152, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(80, 62);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "En camino";
            // 
            // btnEnCamino
            // 
            this.btnEnCamino.BackColor = System.Drawing.Color.White;
            this.btnEnCamino.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnCamino.BackgroundImage")));
            this.btnEnCamino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnCamino.Cursor = System.Windows.Forms.Cursors.No;
            this.btnEnCamino.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEnCamino.FlatAppearance.BorderSize = 0;
            this.btnEnCamino.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEnCamino.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEnCamino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnCamino.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnCamino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnCamino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnCamino.Location = new System.Drawing.Point(20, 16);
            this.btnEnCamino.Name = "btnEnCamino";
            this.btnEnCamino.Size = new System.Drawing.Size(38, 37);
            this.btnEnCamino.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnEnCamino, "El envío está en camino");
            this.btnEnCamino.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Controls.Add(this.btnInicio);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(29, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(80, 62);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Inicio";
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.White;
            this.btnInicio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInicio.BackgroundImage")));
            this.btnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(20, 15);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(38, 37);
            this.btnInicio.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btnInicio, "Inicie el envío");
            this.btnInicio.UseVisualStyleBackColor = false;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.ForeColor = System.Drawing.Color.Gray;
            this.txtCorreo.Location = new System.Drawing.Point(7, 38);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.ReadOnly = true;
            this.txtCorreo.Size = new System.Drawing.Size(367, 18);
            this.txtCorreo.TabIndex = 3;
            this.txtCorreo.Text = "Correo electrónico";
            this.txtCorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.White;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.ForeColor = System.Drawing.Color.Gray;
            this.txtTelefono.Location = new System.Drawing.Point(7, 60);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(367, 18);
            this.txtTelefono.TabIndex = 4;
            this.txtTelefono.Text = "Teléfono";
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SalidaSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbEstado);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gray;
            this.Name = "SalidaSmall";
            this.Size = new System.Drawing.Size(387, 270);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbEstado.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.GroupBox gbEstado;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnFinalizado;
        private System.Windows.Forms.Button btnEnCamino;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.TextBox txtQuienRecibe;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
    }
}

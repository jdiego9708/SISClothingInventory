namespace CapaPresentacion.Forms.FormsVentas
{
    partial class EnvioPedido
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
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdEfectivo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelQuienRecibe = new System.Windows.Forms.Panel();
            this.panelOtroCliente = new System.Windows.Forms.Panel();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdOtro = new System.Windows.Forms.RadioButton();
            this.rdMismoCliente = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReferencias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listaCalleCarrera = new System.Windows.Forms.ComboBox();
            this.txtNumeroCalleCarrera = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelQuienRecibe.SuspendLayout();
            this.panelOtroCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCliente.Location = new System.Drawing.Point(3, 25);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(200, 18);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.Text = "Seleccione un cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdEfectivo);
            this.groupBox1.Location = new System.Drawing.Point(3, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 49);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Método de pago";
            // 
            // rdEfectivo
            // 
            this.rdEfectivo.AutoSize = true;
            this.rdEfectivo.Location = new System.Drawing.Point(7, 19);
            this.rdEfectivo.Name = "rdEfectivo";
            this.rdEfectivo.Size = new System.Drawing.Size(71, 21);
            this.rdEfectivo.TabIndex = 0;
            this.rdEfectivo.TabStop = true;
            this.rdEfectivo.Text = "Efectivo";
            this.rdEfectivo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.txtNumero2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.panelQuienRecibe);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtReferencias);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtNumero1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.listaCalleCarrera);
            this.groupBox2.Controls.Add(this.txtNumeroCalleCarrera);
            this.groupBox2.Location = new System.Drawing.Point(3, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 345);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dirección de envío";
            // 
            // txtNumero2
            // 
            this.txtNumero2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNumero2.Location = new System.Drawing.Point(146, 56);
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(47, 25);
            this.txtNumero2.TabIndex = 3;
            this.txtNumero2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "--";
            // 
            // panelQuienRecibe
            // 
            this.panelQuienRecibe.AutoSize = true;
            this.panelQuienRecibe.Controls.Add(this.panelOtroCliente);
            this.panelQuienRecibe.Controls.Add(this.rdOtro);
            this.panelQuienRecibe.Controls.Add(this.rdMismoCliente);
            this.panelQuienRecibe.Location = new System.Drawing.Point(9, 181);
            this.panelQuienRecibe.Name = "panelQuienRecibe";
            this.panelQuienRecibe.Size = new System.Drawing.Size(184, 140);
            this.panelQuienRecibe.TabIndex = 15;
            // 
            // panelOtroCliente
            // 
            this.panelOtroCliente.AutoSize = true;
            this.panelOtroCliente.Controls.Add(this.txtTelefono);
            this.panelOtroCliente.Controls.Add(this.label6);
            this.panelOtroCliente.Controls.Add(this.txtNombre);
            this.panelOtroCliente.Controls.Add(this.label5);
            this.panelOtroCliente.Location = new System.Drawing.Point(3, 30);
            this.panelOtroCliente.Name = "panelOtroCliente";
            this.panelOtroCliente.Size = new System.Drawing.Size(178, 104);
            this.panelOtroCliente.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTelefono.Location = new System.Drawing.Point(3, 72);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(172, 25);
            this.txtTelefono.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Teléfono:";
            // 
            // txtNombre
            // 
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombre.Location = new System.Drawing.Point(3, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(172, 25);
            this.txtNombre.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nombre";
            // 
            // rdOtro
            // 
            this.rdOtro.AutoSize = true;
            this.rdOtro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdOtro.Location = new System.Drawing.Point(116, 3);
            this.rdOtro.Name = "rdOtro";
            this.rdOtro.Size = new System.Drawing.Size(53, 21);
            this.rdOtro.TabIndex = 1;
            this.rdOtro.TabStop = true;
            this.rdOtro.Text = "Otro";
            this.rdOtro.UseVisualStyleBackColor = true;
            // 
            // rdMismoCliente
            // 
            this.rdMismoCliente.AutoSize = true;
            this.rdMismoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdMismoCliente.Location = new System.Drawing.Point(3, 3);
            this.rdMismoCliente.Name = "rdMismoCliente";
            this.rdMismoCliente.Size = new System.Drawing.Size(107, 21);
            this.rdMismoCliente.TabIndex = 0;
            this.rdMismoCliente.TabStop = true;
            this.rdMismoCliente.Text = "Mismo cliente";
            this.rdMismoCliente.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "¿Quién recibe el pedido?";
            // 
            // txtReferencias
            // 
            this.txtReferencias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReferencias.Location = new System.Drawing.Point(9, 106);
            this.txtReferencias.Multiline = true;
            this.txtReferencias.Name = "txtReferencias";
            this.txtReferencias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReferencias.Size = new System.Drawing.Size(184, 46);
            this.txtReferencias.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Otras referencias:";
            // 
            // txtNumero1
            // 
            this.txtNumero1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNumero1.Location = new System.Drawing.Point(80, 56);
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(47, 25);
            this.txtNumero1.TabIndex = 2;
            this.txtNumero1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Número (#)";
            // 
            // listaCalleCarrera
            // 
            this.listaCalleCarrera.BackColor = System.Drawing.Color.White;
            this.listaCalleCarrera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaCalleCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaCalleCarrera.FormattingEnabled = true;
            this.listaCalleCarrera.Location = new System.Drawing.Point(9, 25);
            this.listaCalleCarrera.Name = "listaCalleCarrera";
            this.listaCalleCarrera.Size = new System.Drawing.Size(110, 25);
            this.listaCalleCarrera.TabIndex = 0;
            // 
            // txtNumeroCalleCarrera
            // 
            this.txtNumeroCalleCarrera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNumeroCalleCarrera.Location = new System.Drawing.Point(125, 25);
            this.txtNumeroCalleCarrera.Name = "txtNumeroCalleCarrera";
            this.txtNumeroCalleCarrera.Size = new System.Drawing.Size(68, 25);
            this.txtNumeroCalleCarrera.TabIndex = 1;
            this.txtNumeroCalleCarrera.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 452);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Observaciones de la venta";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObservaciones.Location = new System.Drawing.Point(6, 472);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(197, 46);
            this.txtObservaciones.TabIndex = 1;
            // 
            // EnvioPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gray;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EnvioPedido";
            this.Size = new System.Drawing.Size(210, 561);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelQuienRecibe.ResumeLayout(false);
            this.panelQuienRecibe.PerformLayout();
            this.panelOtroCliente.ResumeLayout(false);
            this.panelOtroCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdEfectivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNumeroCalleCarrera;
        private System.Windows.Forms.ComboBox listaCalleCarrera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReferencias;
        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelQuienRecibe;
        private System.Windows.Forms.RadioButton rdMismoCliente;
        private System.Windows.Forms.RadioButton rdOtro;
        private System.Windows.Forms.Panel panelOtroCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObservaciones;
    }
}

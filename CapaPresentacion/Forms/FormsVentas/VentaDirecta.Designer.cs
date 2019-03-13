namespace CapaPresentacion.Forms.FormsVentas
{
    partial class VentaDirecta
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
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbMetodoPago = new System.Windows.Forms.GroupBox();
            this.rdTarjeta = new System.Windows.Forms.RadioButton();
            this.rdEfectivo = new System.Windows.Forms.RadioButton();
            this.gbMetodoPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCliente.Location = new System.Drawing.Point(4, 25);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(193, 18);
            this.txtCliente.TabIndex = 5;
            this.txtCliente.Text = "Seleccione un cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cliente";
            // 
            // gbMetodoPago
            // 
            this.gbMetodoPago.Controls.Add(this.rdTarjeta);
            this.gbMetodoPago.Controls.Add(this.rdEfectivo);
            this.gbMetodoPago.Location = new System.Drawing.Point(4, 50);
            this.gbMetodoPago.Name = "gbMetodoPago";
            this.gbMetodoPago.Size = new System.Drawing.Size(200, 73);
            this.gbMetodoPago.TabIndex = 6;
            this.gbMetodoPago.TabStop = false;
            this.gbMetodoPago.Text = "Método de pago";
            // 
            // rdTarjeta
            // 
            this.rdTarjeta.AutoSize = true;
            this.rdTarjeta.Location = new System.Drawing.Point(7, 41);
            this.rdTarjeta.Name = "rdTarjeta";
            this.rdTarjeta.Size = new System.Drawing.Size(65, 21);
            this.rdTarjeta.TabIndex = 1;
            this.rdTarjeta.TabStop = true;
            this.rdTarjeta.Text = "Tarjeta";
            this.rdTarjeta.UseVisualStyleBackColor = true;
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
            // VentaDirecta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbMetodoPago);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gray;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VentaDirecta";
            this.Size = new System.Drawing.Size(206, 130);
            this.gbMetodoPago.ResumeLayout(false);
            this.gbMetodoPago.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbMetodoPago;
        private System.Windows.Forms.RadioButton rdTarjeta;
        private System.Windows.Forms.RadioButton rdEfectivo;
    }
}

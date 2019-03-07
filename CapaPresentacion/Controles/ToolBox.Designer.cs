namespace CapaPresentacion.Controles
{
    partial class ToolBox
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
            this.lblEncabezaco = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblEncabezaco
            // 
            this.lblEncabezaco.AutoSize = true;
            this.lblEncabezaco.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezaco.ForeColor = System.Drawing.Color.White;
            this.lblEncabezaco.Location = new System.Drawing.Point(2, -2);
            this.lblEncabezaco.Name = "lblEncabezaco";
            this.lblEncabezaco.Size = new System.Drawing.Size(91, 20);
            this.lblEncabezaco.TabIndex = 17;
            this.lblEncabezaco.Text = "Encabezado";
            this.toolTip1.SetToolTip(this.lblEncabezaco, "Mostrar menú principal");
            // 
            // ToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(177)))), ((int)(((byte)(203)))));
            this.Controls.Add(this.lblEncabezaco);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ToolBox";
            this.Size = new System.Drawing.Size(431, 16);
            this.toolTip1.SetToolTip(this, "Mostrar menú principal");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEncabezaco;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

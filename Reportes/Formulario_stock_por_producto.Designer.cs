namespace Trabajo_Final_Poo.Reportes
{
    partial class Formulario_stock_por_producto
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
            this.lstStockDeProductos = new System.Windows.Forms.ListBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstStockDeProductos
            // 
            this.lstStockDeProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStockDeProductos.FormattingEnabled = true;
            this.lstStockDeProductos.ItemHeight = 25;
            this.lstStockDeProductos.Location = new System.Drawing.Point(159, 38);
            this.lstStockDeProductos.Name = "lstStockDeProductos";
            this.lstStockDeProductos.Size = new System.Drawing.Size(475, 279);
            this.lstStockDeProductos.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(362, 361);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Formulario_stock_por_producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lstStockDeProductos);
            this.Name = "Formulario_stock_por_producto";
            this.Text = "Formulario_stock_por_producto";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstStockDeProductos;
        private System.Windows.Forms.Button btnSalir;
    }
}
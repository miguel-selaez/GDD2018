namespace FrbaHotel.RegistrarConsumible
{
    partial class Facturacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_estadia = new System.Windows.Forms.TextBox();
            this.btn_fact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro Estadia";
            // 
            // txt_estadia
            // 
            this.txt_estadia.Location = new System.Drawing.Point(111, 30);
            this.txt_estadia.Name = "txt_estadia";
            this.txt_estadia.Size = new System.Drawing.Size(85, 20);
            this.txt_estadia.TabIndex = 1;
            // 
            // btn_fact
            // 
            this.btn_fact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fact.Location = new System.Drawing.Point(41, 96);
            this.btn_fact.Name = "btn_fact";
            this.btn_fact.Size = new System.Drawing.Size(146, 32);
            this.btn_fact.TabIndex = 2;
            this.btn_fact.Text = "Facturar Consumos";
            this.btn_fact.UseVisualStyleBackColor = true;
            this.btn_fact.Click += new System.EventHandler(this.btn_fact_Click);
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 151);
            this.Controls.Add(this.btn_fact);
            this.Controls.Add(this.txt_estadia);
            this.Controls.Add(this.label1);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_estadia;
        private System.Windows.Forms.Button btn_fact;
    }
}
﻿namespace FrbaHotel.Login
{
    partial class LoginSeleccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginSeleccion));
            this.lbRol = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbHoteles = new System.Windows.Forms.ComboBox();
            this.hotelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnContinue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRol.Location = new System.Drawing.Point(52, 37);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(121, 18);
            this.lbRol.TabIndex = 4;
            this.lbRol.Text = "Seleccione un Rol:";
            this.lbRol.Click += new System.EventHandler(this.lbRol_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione un Hotel:";
            // 
            // cbRoles
            // 
            this.cbRoles.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.rolBindingSource, "Id", true));
            this.cbRoles.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rolBindingSource, "Descripcion", true));
            this.cbRoles.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(55, 58);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(319, 26);
            this.cbRoles.TabIndex = 6;
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataSource = typeof(FrbaHotel.Model.Rol);
            // 
            // cbHoteles
            // 
            this.cbHoteles.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.hotelBindingSource, "Id", true));
            this.cbHoteles.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hotelBindingSource, "Nombre", true));
            this.cbHoteles.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHoteles.FormattingEnabled = true;
            this.cbHoteles.Location = new System.Drawing.Point(55, 137);
            this.cbHoteles.Name = "cbHoteles";
            this.cbHoteles.Size = new System.Drawing.Size(319, 26);
            this.cbHoteles.TabIndex = 7;
            // 
            // hotelBindingSource
            // 
            this.hotelBindingSource.DataSource = typeof(FrbaHotel.Model.Hotel);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.SystemColors.Control;
            this.btnContinue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(161, 187);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(103, 30);
            this.btnContinue.TabIndex = 8;
            this.btnContinue.Text = "Continuar";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
<<<<<<< HEAD
=======
            // 
>>>>>>> 56eb8fbafba252bc253249b4b2bbe7b47c5be063
            // LoginSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 229);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.cbHoteles);
            this.Controls.Add(this.cbRoles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginSeleccion";
            this.Text = "FRBAHotel";
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.ComboBox cbHoteles;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private System.Windows.Forms.BindingSource hotelBindingSource;
    }
}
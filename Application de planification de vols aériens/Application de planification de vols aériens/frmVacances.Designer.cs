namespace Application_de_planification_de_vols_aériens
{
    partial class frmVacances
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
            this.lblSemaine1Debut = new System.Windows.Forms.Label();
            this.lblSemaine1Fin = new System.Windows.Forms.Label();
            this.dtpSemain1Debut = new System.Windows.Forms.DateTimePicker();
            this.dtpSemain1Fin = new System.Windows.Forms.DateTimePicker();
            this.cmdValider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSemaine1Debut
            // 
            this.lblSemaine1Debut.AutoSize = true;
            this.lblSemaine1Debut.Location = new System.Drawing.Point(12, 19);
            this.lblSemaine1Debut.Name = "lblSemaine1Debut";
            this.lblSemaine1Debut.Size = new System.Drawing.Size(129, 13);
            this.lblSemaine1Debut.TabIndex = 0;
            this.lblSemaine1Debut.Text = "Date de commencement :";
            // 
            // lblSemaine1Fin
            // 
            this.lblSemaine1Fin.AutoSize = true;
            this.lblSemaine1Fin.Location = new System.Drawing.Point(12, 48);
            this.lblSemaine1Fin.Name = "lblSemaine1Fin";
            this.lblSemaine1Fin.Size = new System.Drawing.Size(65, 13);
            this.lblSemaine1Fin.TabIndex = 7;
            this.lblSemaine1Fin.Text = "Date de fin :";
            // 
            // dtpSemain1Debut
            // 
            this.dtpSemain1Debut.Location = new System.Drawing.Point(216, 19);
            this.dtpSemain1Debut.Name = "dtpSemain1Debut";
            this.dtpSemain1Debut.Size = new System.Drawing.Size(200, 20);
            this.dtpSemain1Debut.TabIndex = 17;
            // 
            // dtpSemain1Fin
            // 
            this.dtpSemain1Fin.Location = new System.Drawing.Point(216, 48);
            this.dtpSemain1Fin.Name = "dtpSemain1Fin";
            this.dtpSemain1Fin.Size = new System.Drawing.Size(200, 20);
            this.dtpSemain1Fin.TabIndex = 18;
            // 
            // cmdValider
            // 
            this.cmdValider.Location = new System.Drawing.Point(354, 89);
            this.cmdValider.Name = "cmdValider";
            this.cmdValider.Size = new System.Drawing.Size(75, 23);
            this.cmdValider.TabIndex = 20;
            this.cmdValider.Text = "Valider";
            this.cmdValider.UseVisualStyleBackColor = true;
            this.cmdValider.Click += new System.EventHandler(this.cmdValider_Click);
            // 
            // frmVacances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 125);
            this.Controls.Add(this.cmdValider);
            this.Controls.Add(this.dtpSemain1Fin);
            this.Controls.Add(this.dtpSemain1Debut);
            this.Controls.Add(this.lblSemaine1Fin);
            this.Controls.Add(this.lblSemaine1Debut);
            this.Name = "frmVacances";
            this.Text = "Vacances";
            this.Load += new System.EventHandler(this.frmVacances_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSemaine1Debut;
        private System.Windows.Forms.Label lblSemaine1Fin;
        private System.Windows.Forms.DateTimePicker dtpSemain1Debut;
        private System.Windows.Forms.DateTimePicker dtpSemain1Fin;
        private System.Windows.Forms.Button cmdValider;
    }
}
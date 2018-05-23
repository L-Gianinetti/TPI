namespace Application_de_planification_de_vols_aériens
{
    partial class frmAffectationVol
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
            this.lblPilotesDisponbiles = new System.Windows.Forms.Label();
            this.lblPilotesAffectes = new System.Windows.Forms.Label();
            this.lstPilotesDisponibles = new System.Windows.Forms.ListBox();
            this.lstPilotesAffectes = new System.Windows.Forms.ListBox();
            this.cmdAjouter = new System.Windows.Forms.Button();
            this.cmdPlanifier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPilotesDisponbiles
            // 
            this.lblPilotesDisponbiles.AutoSize = true;
            this.lblPilotesDisponbiles.Location = new System.Drawing.Point(12, 38);
            this.lblPilotesDisponbiles.Name = "lblPilotesDisponbiles";
            this.lblPilotesDisponbiles.Size = new System.Drawing.Size(155, 13);
            this.lblPilotesDisponbiles.TabIndex = 0;
            this.lblPilotesDisponbiles.Text = "Pilotes disponibles pour ce vol :";
            // 
            // lblPilotesAffectes
            // 
            this.lblPilotesAffectes.AutoSize = true;
            this.lblPilotesAffectes.Location = new System.Drawing.Point(12, 209);
            this.lblPilotesAffectes.Name = "lblPilotesAffectes";
            this.lblPilotesAffectes.Size = new System.Drawing.Size(133, 13);
            this.lblPilotesAffectes.TabIndex = 1;
            this.lblPilotesAffectes.Text = "Pilotes à affecter à ce vol :";
            // 
            // lstPilotesDisponibles
            // 
            this.lstPilotesDisponibles.FormattingEnabled = true;
            this.lstPilotesDisponibles.Location = new System.Drawing.Point(207, 38);
            this.lstPilotesDisponibles.Name = "lstPilotesDisponibles";
            this.lstPilotesDisponibles.Size = new System.Drawing.Size(120, 95);
            this.lstPilotesDisponibles.TabIndex = 2;
            // 
            // lstPilotesAffectes
            // 
            this.lstPilotesAffectes.FormattingEnabled = true;
            this.lstPilotesAffectes.Location = new System.Drawing.Point(207, 209);
            this.lstPilotesAffectes.Name = "lstPilotesAffectes";
            this.lstPilotesAffectes.Size = new System.Drawing.Size(120, 95);
            this.lstPilotesAffectes.TabIndex = 3;
            // 
            // cmdAjouter
            // 
            this.cmdAjouter.Location = new System.Drawing.Point(207, 148);
            this.cmdAjouter.Name = "cmdAjouter";
            this.cmdAjouter.Size = new System.Drawing.Size(75, 23);
            this.cmdAjouter.TabIndex = 4;
            this.cmdAjouter.Text = "Ajouter";
            this.cmdAjouter.UseVisualStyleBackColor = true;
            this.cmdAjouter.Click += new System.EventHandler(this.cmdAjouter_Click);
            // 
            // cmdPlanifier
            // 
            this.cmdPlanifier.Location = new System.Drawing.Point(207, 318);
            this.cmdPlanifier.Name = "cmdPlanifier";
            this.cmdPlanifier.Size = new System.Drawing.Size(75, 23);
            this.cmdPlanifier.TabIndex = 5;
            this.cmdPlanifier.Text = "Planifier";
            this.cmdPlanifier.UseVisualStyleBackColor = true;
            this.cmdPlanifier.Click += new System.EventHandler(this.cmdPlanifier_Click);
            // 
            // frmAffectationVol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 353);
            this.Controls.Add(this.cmdPlanifier);
            this.Controls.Add(this.cmdAjouter);
            this.Controls.Add(this.lstPilotesAffectes);
            this.Controls.Add(this.lstPilotesDisponibles);
            this.Controls.Add(this.lblPilotesAffectes);
            this.Controls.Add(this.lblPilotesDisponbiles);
            this.Name = "frmAffectationVol";
            this.Text = "Affectation d\'un vol ";
            this.Load += new System.EventHandler(this.frmAffectationVol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPilotesDisponbiles;
        private System.Windows.Forms.Label lblPilotesAffectes;
        private System.Windows.Forms.ListBox lstPilotesDisponibles;
        private System.Windows.Forms.ListBox lstPilotesAffectes;
        private System.Windows.Forms.Button cmdAjouter;
        private System.Windows.Forms.Button cmdPlanifier;
    }
}
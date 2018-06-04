namespace Application_de_planification_de_vols_aériens
{
    partial class frmFlightAssignment
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
            this.lblAvailablePilots = new System.Windows.Forms.Label();
            this.lblAssignedPilots = new System.Windows.Forms.Label();
            this.lstAvailablePilots = new System.Windows.Forms.ListBox();
            this.lstAssignedPilots = new System.Windows.Forms.ListBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdPlan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAvailablePilots
            // 
            this.lblAvailablePilots.AutoSize = true;
            this.lblAvailablePilots.Location = new System.Drawing.Point(12, 38);
            this.lblAvailablePilots.Name = "lblAvailablePilots";
            this.lblAvailablePilots.Size = new System.Drawing.Size(155, 13);
            this.lblAvailablePilots.TabIndex = 0;
            this.lblAvailablePilots.Text = "Pilotes disponibles pour ce vol :";
            // 
            // lblAssignedPilots
            // 
            this.lblAssignedPilots.AutoSize = true;
            this.lblAssignedPilots.Location = new System.Drawing.Point(12, 209);
            this.lblAssignedPilots.Name = "lblAssignedPilots";
            this.lblAssignedPilots.Size = new System.Drawing.Size(133, 13);
            this.lblAssignedPilots.TabIndex = 1;
            this.lblAssignedPilots.Text = "Pilotes à affecter à ce vol :";
            // 
            // lstAvailablePilots
            // 
            this.lstAvailablePilots.FormattingEnabled = true;
            this.lstAvailablePilots.Location = new System.Drawing.Point(207, 38);
            this.lstAvailablePilots.Name = "lstAvailablePilots";
            this.lstAvailablePilots.Size = new System.Drawing.Size(120, 95);
            this.lstAvailablePilots.TabIndex = 2;
            this.lstAvailablePilots.SelectedIndexChanged += new System.EventHandler(this.lstAvailablePilots_SelectedIndexChanged);
            // 
            // lstAssignedPilots
            // 
            this.lstAssignedPilots.FormattingEnabled = true;
            this.lstAssignedPilots.Location = new System.Drawing.Point(207, 209);
            this.lstAssignedPilots.Name = "lstAssignedPilots";
            this.lstAssignedPilots.Size = new System.Drawing.Size(120, 95);
            this.lstAssignedPilots.TabIndex = 3;
            this.lstAssignedPilots.SelectedIndexChanged += new System.EventHandler(this.lstAssignedPilots_SelectedIndexChanged);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(207, 148);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "Ajouter";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdPlan
            // 
            this.cmdPlan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdPlan.Location = new System.Drawing.Point(207, 318);
            this.cmdPlan.Name = "cmdPlan";
            this.cmdPlan.Size = new System.Drawing.Size(75, 23);
            this.cmdPlan.TabIndex = 5;
            this.cmdPlan.Text = "Planifier";
            this.cmdPlan.UseVisualStyleBackColor = true;
            this.cmdPlan.Click += new System.EventHandler(this.cmdPlan_Click);
            // 
            // frmFlightAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 353);
            this.Controls.Add(this.cmdPlan);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lstAssignedPilots);
            this.Controls.Add(this.lstAvailablePilots);
            this.Controls.Add(this.lblAssignedPilots);
            this.Controls.Add(this.lblAvailablePilots);
            this.Name = "frmFlightAssignment";
            this.Text = "Affectation d\'un vol ";
            this.Load += new System.EventHandler(this.frmFlightAssignment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAvailablePilots;
        private System.Windows.Forms.Label lblAssignedPilots;
        private System.Windows.Forms.ListBox lstAvailablePilots;
        private System.Windows.Forms.ListBox lstAssignedPilots;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdPlan;
    }
}
namespace Application_de_planification_de_vols_aériens
{
    partial class frmVacancesAffichage
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
            this.dgvVacation = new System.Windows.Forms.DataGridView();
            this.cmdOK = new System.Windows.Forms.Button();
            this.colDebut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacation)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVacation
            // 
            this.dgvVacation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVacation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDebut,
            this.colFin});
            this.dgvVacation.Location = new System.Drawing.Point(22, 35);
            this.dgvVacation.Name = "dgvVacation";
            this.dgvVacation.Size = new System.Drawing.Size(442, 111);
            this.dgvVacation.TabIndex = 0;
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(191, 194);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // colDebut
            // 
            this.colDebut.HeaderText = "Date début";
            this.colDebut.Name = "colDebut";
            this.colDebut.Width = 200;
            // 
            // colFin
            // 
            this.colFin.HeaderText = "Date fin";
            this.colFin.Name = "colFin";
            this.colFin.Width = 200;
            // 
            // frmVacancesAffichage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 247);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.dgvVacation);
            this.Name = "frmVacancesAffichage";
            this.Text = "VacancesAffichage";
            this.Load += new System.EventHandler(this.frmVacancesAffichage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVacation;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFin;
    }
}
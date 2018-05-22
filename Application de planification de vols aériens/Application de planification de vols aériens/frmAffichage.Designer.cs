namespace Application_de_planification_de_vols_aériens
{
    partial class Affichage
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
            this.cmdAffichage = new System.Windows.Forms.Button();
            this.cmdGestion = new System.Windows.Forms.Button();
            this.pnlEntete = new System.Windows.Forms.Panel();
            this.grbAffichage = new System.Windows.Forms.GroupBox();
            this.grbLignes = new System.Windows.Forms.GroupBox();
            this.dgvLignes = new System.Windows.Forms.DataGridView();
            this.grbVols = new System.Windows.Forms.GroupBox();
            this.cmdPlanifier = new System.Windows.Forms.Button();
            this.dgvVols = new System.Windows.Forms.DataGridView();
            this.grbPilotes = new System.Windows.Forms.GroupBox();
            this.cmdPlanifierVacances = new System.Windows.Forms.Button();
            this.cmdAfficherVacances = new System.Windows.Forms.Button();
            this.cmdGenererPlanning = new System.Windows.Forms.Button();
            this.lblMois = new System.Windows.Forms.Label();
            this.cboMois = new System.Windows.Forms.ComboBox();
            this.dgvPilotes = new System.Windows.Forms.DataGridView();
            this.colIdLigne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLieuDepart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLieuArrivee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLigne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateDepart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateArrivee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPilote1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPilote2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdPilot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAeroportAffectation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeuresVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEntete.SuspendLayout();
            this.grbAffichage.SuspendLayout();
            this.grbLignes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).BeginInit();
            this.grbVols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVols)).BeginInit();
            this.grbPilotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPilotes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAffichage
            // 
            this.cmdAffichage.Location = new System.Drawing.Point(312, 21);
            this.cmdAffichage.Name = "cmdAffichage";
            this.cmdAffichage.Size = new System.Drawing.Size(75, 23);
            this.cmdAffichage.TabIndex = 1;
            this.cmdAffichage.Text = "Affichage";
            this.cmdAffichage.UseVisualStyleBackColor = true;
            // 
            // cmdGestion
            // 
            this.cmdGestion.Location = new System.Drawing.Point(53, 21);
            this.cmdGestion.Name = "cmdGestion";
            this.cmdGestion.Size = new System.Drawing.Size(75, 23);
            this.cmdGestion.TabIndex = 0;
            this.cmdGestion.Text = "Gestion";
            this.cmdGestion.UseVisualStyleBackColor = true;
            this.cmdGestion.Click += new System.EventHandler(this.cmdGestion_Click);
            // 
            // pnlEntete
            // 
            this.pnlEntete.Controls.Add(this.cmdAffichage);
            this.pnlEntete.Controls.Add(this.cmdGestion);
            this.pnlEntete.Location = new System.Drawing.Point(12, 12);
            this.pnlEntete.Name = "pnlEntete";
            this.pnlEntete.Size = new System.Drawing.Size(870, 65);
            this.pnlEntete.TabIndex = 1;
            // 
            // grbAffichage
            // 
            this.grbAffichage.Controls.Add(this.grbLignes);
            this.grbAffichage.Controls.Add(this.grbVols);
            this.grbAffichage.Controls.Add(this.grbPilotes);
            this.grbAffichage.Location = new System.Drawing.Point(12, 96);
            this.grbAffichage.Name = "grbAffichage";
            this.grbAffichage.Size = new System.Drawing.Size(940, 710);
            this.grbAffichage.TabIndex = 0;
            this.grbAffichage.TabStop = false;
            this.grbAffichage.Text = "Affichage";
            this.grbAffichage.Enter += new System.EventHandler(this.grbAffichage_Enter);
            // 
            // grbLignes
            // 
            this.grbLignes.Controls.Add(this.dgvLignes);
            this.grbLignes.Location = new System.Drawing.Point(7, 576);
            this.grbLignes.Name = "grbLignes";
            this.grbLignes.Size = new System.Drawing.Size(851, 128);
            this.grbLignes.TabIndex = 2;
            this.grbLignes.TabStop = false;
            this.grbLignes.Text = "Lignes";
            // 
            // dgvLignes
            // 
            this.dgvLignes.AllowUserToOrderColumns = true;
            this.dgvLignes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLignes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdLigne,
            this.colLieuDepart,
            this.colLieuArrivee,
            this.colDistance});
            this.dgvLignes.Location = new System.Drawing.Point(7, 20);
            this.dgvLignes.Name = "dgvLignes";
            this.dgvLignes.Size = new System.Drawing.Size(569, 85);
            this.dgvLignes.TabIndex = 0;
            // 
            // grbVols
            // 
            this.grbVols.Controls.Add(this.cmdPlanifier);
            this.grbVols.Controls.Add(this.dgvVols);
            this.grbVols.Location = new System.Drawing.Point(7, 370);
            this.grbVols.Name = "grbVols";
            this.grbVols.Size = new System.Drawing.Size(927, 200);
            this.grbVols.TabIndex = 1;
            this.grbVols.TabStop = false;
            this.grbVols.Text = "Vols";
            // 
            // cmdPlanifier
            // 
            this.cmdPlanifier.Location = new System.Drawing.Point(805, 145);
            this.cmdPlanifier.Name = "cmdPlanifier";
            this.cmdPlanifier.Size = new System.Drawing.Size(110, 23);
            this.cmdPlanifier.TabIndex = 5;
            this.cmdPlanifier.Text = "Planifier";
            this.cmdPlanifier.UseVisualStyleBackColor = true;
            this.cmdPlanifier.Click += new System.EventHandler(this.cmdPlanifier_Click);
            // 
            // dgvVols
            // 
            this.dgvVols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colLigne,
            this.colDateDepart,
            this.colDateArrivee,
            this.colPilote1,
            this.colPilote2});
            this.dgvVols.Location = new System.Drawing.Point(7, 20);
            this.dgvVols.Name = "dgvVols";
            this.dgvVols.Size = new System.Drawing.Size(792, 159);
            this.dgvVols.TabIndex = 0;
            // 
            // grbPilotes
            // 
            this.grbPilotes.Controls.Add(this.cmdPlanifierVacances);
            this.grbPilotes.Controls.Add(this.cmdAfficherVacances);
            this.grbPilotes.Controls.Add(this.cmdGenererPlanning);
            this.grbPilotes.Controls.Add(this.lblMois);
            this.grbPilotes.Controls.Add(this.cboMois);
            this.grbPilotes.Controls.Add(this.dgvPilotes);
            this.grbPilotes.Location = new System.Drawing.Point(7, 20);
            this.grbPilotes.Name = "grbPilotes";
            this.grbPilotes.Size = new System.Drawing.Size(845, 344);
            this.grbPilotes.TabIndex = 0;
            this.grbPilotes.TabStop = false;
            this.grbPilotes.Text = "Pilotes";
            // 
            // cmdPlanifierVacances
            // 
            this.cmdPlanifierVacances.Location = new System.Drawing.Point(689, 48);
            this.cmdPlanifierVacances.Name = "cmdPlanifierVacances";
            this.cmdPlanifierVacances.Size = new System.Drawing.Size(150, 23);
            this.cmdPlanifierVacances.TabIndex = 6;
            this.cmdPlanifierVacances.Text = "Planifier les vacances";
            this.cmdPlanifierVacances.UseVisualStyleBackColor = true;
            this.cmdPlanifierVacances.Click += new System.EventHandler(this.cmdPlanifierVacances_Click);
            // 
            // cmdAfficherVacances
            // 
            this.cmdAfficherVacances.Location = new System.Drawing.Point(689, 19);
            this.cmdAfficherVacances.Name = "cmdAfficherVacances";
            this.cmdAfficherVacances.Size = new System.Drawing.Size(150, 23);
            this.cmdAfficherVacances.TabIndex = 5;
            this.cmdAfficherVacances.Text = "Afficher les vacances";
            this.cmdAfficherVacances.UseVisualStyleBackColor = true;
            this.cmdAfficherVacances.Click += new System.EventHandler(this.cmdAfficherVacances_Click);
            // 
            // cmdGenererPlanning
            // 
            this.cmdGenererPlanning.Location = new System.Drawing.Point(689, 126);
            this.cmdGenererPlanning.Name = "cmdGenererPlanning";
            this.cmdGenererPlanning.Size = new System.Drawing.Size(110, 23);
            this.cmdGenererPlanning.TabIndex = 4;
            this.cmdGenererPlanning.Text = "Générer planning";
            this.cmdGenererPlanning.UseVisualStyleBackColor = true;
            this.cmdGenererPlanning.Click += new System.EventHandler(this.cmdGenererPlanning_Click);
            // 
            // lblMois
            // 
            this.lblMois.AutoSize = true;
            this.lblMois.Location = new System.Drawing.Point(27, 305);
            this.lblMois.Name = "lblMois";
            this.lblMois.Size = new System.Drawing.Size(89, 13);
            this.lblMois.TabIndex = 3;
            this.lblMois.Text = "Mois de l\'horaire :";
            // 
            // cboMois
            // 
            this.cboMois.FormattingEnabled = true;
            this.cboMois.Location = new System.Drawing.Point(122, 302);
            this.cboMois.Name = "cboMois";
            this.cboMois.Size = new System.Drawing.Size(121, 21);
            this.cboMois.TabIndex = 2;
            // 
            // dgvPilotes
            // 
            this.dgvPilotes.AllowUserToOrderColumns = true;
            this.dgvPilotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPilotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdPilot,
            this.colNom,
            this.colPrenom,
            this.colAeroportAffectation,
            this.colHeuresVol});
            this.dgvPilotes.Location = new System.Drawing.Point(30, 19);
            this.dgvPilotes.Name = "dgvPilotes";
            this.dgvPilotes.Size = new System.Drawing.Size(593, 277);
            this.dgvPilotes.TabIndex = 1;
            this.dgvPilotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPilotes_CellContentClick);
            // 
            // colIdLigne
            // 
            this.colIdLigne.HeaderText = "Id";
            this.colIdLigne.Name = "colIdLigne";
            this.colIdLigne.Width = 50;
            // 
            // colLieuDepart
            // 
            this.colLieuDepart.HeaderText = "Lieu de départ";
            this.colLieuDepart.Name = "colLieuDepart";
            this.colLieuDepart.Width = 200;
            // 
            // colLieuArrivee
            // 
            this.colLieuArrivee.HeaderText = "Lieu d\'arrivée";
            this.colLieuArrivee.Name = "colLieuArrivee";
            this.colLieuArrivee.Width = 200;
            // 
            // colDistance
            // 
            this.colDistance.HeaderText = "Distance";
            this.colDistance.Name = "colDistance";
            this.colDistance.Width = 75;
            // 
            // colName
            // 
            this.colName.HeaderText = "Nom";
            this.colName.Name = "colName";
            // 
            // colLigne
            // 
            this.colLigne.HeaderText = "Ligne";
            this.colLigne.Name = "colLigne";
            this.colLigne.Width = 50;
            // 
            // colDateDepart
            // 
            this.colDateDepart.HeaderText = "Date départ";
            this.colDateDepart.Name = "colDateDepart";
            this.colDateDepart.Width = 200;
            // 
            // colDateArrivee
            // 
            this.colDateArrivee.HeaderText = "Date arrivée";
            this.colDateArrivee.Name = "colDateArrivee";
            this.colDateArrivee.Width = 200;
            // 
            // colPilote1
            // 
            this.colPilote1.HeaderText = "Pilote n°1";
            this.colPilote1.Name = "colPilote1";
            // 
            // colPilote2
            // 
            this.colPilote2.HeaderText = "Pilote n°2";
            this.colPilote2.Name = "colPilote2";
            // 
            // colIdPilot
            // 
            this.colIdPilot.HeaderText = "Id";
            this.colIdPilot.Name = "colIdPilot";
            this.colIdPilot.Width = 25;
            // 
            // colNom
            // 
            this.colNom.HeaderText = "Nom";
            this.colNom.Name = "colNom";
            this.colNom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colPrenom
            // 
            this.colPrenom.HeaderText = "Prénom";
            this.colPrenom.Name = "colPrenom";
            // 
            // colAeroportAffectation
            // 
            this.colAeroportAffectation.HeaderText = "Aéroport d\'affectation";
            this.colAeroportAffectation.Name = "colAeroportAffectation";
            this.colAeroportAffectation.Width = 250;
            // 
            // colHeuresVol
            // 
            this.colHeuresVol.HeaderText = "Heures de vol à son actif";
            this.colHeuresVol.Name = "colHeuresVol";
            this.colHeuresVol.Width = 75;
            // 
            // Affichage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 818);
            this.Controls.Add(this.grbAffichage);
            this.Controls.Add(this.pnlEntete);
            this.Name = "Affichage";
            this.Text = "Planification de vols aériens - Affichage";
            this.Load += new System.EventHandler(this.Affichage_Load);
            this.pnlEntete.ResumeLayout(false);
            this.grbAffichage.ResumeLayout(false);
            this.grbLignes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).EndInit();
            this.grbVols.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVols)).EndInit();
            this.grbPilotes.ResumeLayout(false);
            this.grbPilotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPilotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAffichage;
        private System.Windows.Forms.Button cmdGestion;
        private System.Windows.Forms.Panel pnlEntete;
        private System.Windows.Forms.GroupBox grbAffichage;
        private System.Windows.Forms.GroupBox grbLignes;
        private System.Windows.Forms.DataGridView dgvLignes;
        private System.Windows.Forms.GroupBox grbVols;
        private System.Windows.Forms.Button cmdPlanifier;
        private System.Windows.Forms.DataGridView dgvVols;
        private System.Windows.Forms.GroupBox grbPilotes;
        private System.Windows.Forms.Button cmdPlanifierVacances;
        private System.Windows.Forms.Button cmdAfficherVacances;
        private System.Windows.Forms.Button cmdGenererPlanning;
        private System.Windows.Forms.Label lblMois;
        private System.Windows.Forms.ComboBox cboMois;
        private System.Windows.Forms.DataGridView dgvPilotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLigne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLieuDepart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLieuArrivee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLigne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateDepart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateArrivee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPilote1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPilote2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPilot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAeroportAffectation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeuresVol;
    }
}
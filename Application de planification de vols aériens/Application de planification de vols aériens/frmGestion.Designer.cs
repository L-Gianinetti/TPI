namespace Application_de_planification_de_vols_aériens
{
    partial class frmGestion
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
            this.Entete = new System.Windows.Forms.Panel();
            this.cmdAffichage = new System.Windows.Forms.Button();
            this.cmdGestion = new System.Windows.Forms.Button();
            this.grbGestion = new System.Windows.Forms.GroupBox();
            this.grbLigne = new System.Windows.Forms.GroupBox();
            this.cboLieuArrivee = new System.Windows.Forms.ComboBox();
            this.cboLieuDepart = new System.Windows.Forms.ComboBox();
            this.cmdAjouterLigne = new System.Windows.Forms.Button();
            this.lblLieuDepart = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblLieuArrivee = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.grbVol = new System.Windows.Forms.GroupBox();
            this.nudMArrivee = new System.Windows.Forms.NumericUpDown();
            this.nudHArrivee = new System.Windows.Forms.NumericUpDown();
            this.nudMDepart = new System.Windows.Forms.NumericUpDown();
            this.nudHDepart = new System.Windows.Forms.NumericUpDown();
            this.lblHeureArrivee = new System.Windows.Forms.Label();
            this.lblHeureDepart = new System.Windows.Forms.Label();
            this.cboLigne = new System.Windows.Forms.ComboBox();
            this.cmdAjouterVol = new System.Windows.Forms.Button();
            this.dtpDateArrivee = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDepart = new System.Windows.Forms.DateTimePicker();
            this.lblDateDepart = new System.Windows.Forms.Label();
            this.lblDateArrivee = new System.Windows.Forms.Label();
            this.lblLigne = new System.Windows.Forms.Label();
            this.grbPilote = new System.Windows.Forms.GroupBox();
            this.cboAeroportAffectation = new System.Windows.Forms.ComboBox();
            this.cmdAjouterPilote = new System.Windows.Forms.Button();
            this.txtHeuresVol = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblHeuresVol = new System.Windows.Forms.Label();
            this.lblAeroportAffectation = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.cmdDateArrivee = new System.Windows.Forms.Button();
            this.Entete.SuspendLayout();
            this.grbGestion.SuspendLayout();
            this.grbLigne.SuspendLayout();
            this.grbVol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMArrivee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHArrivee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMDepart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHDepart)).BeginInit();
            this.grbPilote.SuspendLayout();
            this.SuspendLayout();
            // 
            // Entete
            // 
            this.Entete.Controls.Add(this.cmdAffichage);
            this.Entete.Controls.Add(this.cmdGestion);
            this.Entete.Location = new System.Drawing.Point(28, 12);
            this.Entete.Name = "Entete";
            this.Entete.Size = new System.Drawing.Size(869, 54);
            this.Entete.TabIndex = 2;
            // 
            // cmdAffichage
            // 
            this.cmdAffichage.Location = new System.Drawing.Point(312, 21);
            this.cmdAffichage.Name = "cmdAffichage";
            this.cmdAffichage.Size = new System.Drawing.Size(75, 23);
            this.cmdAffichage.TabIndex = 1;
            this.cmdAffichage.Text = "Affichage";
            this.cmdAffichage.UseVisualStyleBackColor = true;
            this.cmdAffichage.Click += new System.EventHandler(this.cmdAffichage_Click);
            // 
            // cmdGestion
            // 
            this.cmdGestion.Location = new System.Drawing.Point(53, 21);
            this.cmdGestion.Name = "cmdGestion";
            this.cmdGestion.Size = new System.Drawing.Size(75, 23);
            this.cmdGestion.TabIndex = 0;
            this.cmdGestion.Text = "Gestion";
            this.cmdGestion.UseVisualStyleBackColor = true;
            // 
            // grbGestion
            // 
            this.grbGestion.Controls.Add(this.grbLigne);
            this.grbGestion.Controls.Add(this.grbVol);
            this.grbGestion.Controls.Add(this.grbPilote);
            this.grbGestion.Location = new System.Drawing.Point(28, 84);
            this.grbGestion.Name = "grbGestion";
            this.grbGestion.Size = new System.Drawing.Size(869, 644);
            this.grbGestion.TabIndex = 3;
            this.grbGestion.TabStop = false;
            this.grbGestion.Text = "Gestion";
            // 
            // grbLigne
            // 
            this.grbLigne.Controls.Add(this.cboLieuArrivee);
            this.grbLigne.Controls.Add(this.cboLieuDepart);
            this.grbLigne.Controls.Add(this.cmdAjouterLigne);
            this.grbLigne.Controls.Add(this.lblLieuDepart);
            this.grbLigne.Controls.Add(this.lblDistance);
            this.grbLigne.Controls.Add(this.lblLieuArrivee);
            this.grbLigne.Controls.Add(this.txtDistance);
            this.grbLigne.Location = new System.Drawing.Point(7, 386);
            this.grbLigne.Name = "grbLigne";
            this.grbLigne.Size = new System.Drawing.Size(851, 210);
            this.grbLigne.TabIndex = 2;
            this.grbLigne.TabStop = false;
            this.grbLigne.Text = "Ligne";
            // 
            // cboLieuArrivee
            // 
            this.cboLieuArrivee.FormattingEnabled = true;
            this.cboLieuArrivee.Location = new System.Drawing.Point(535, 34);
            this.cboLieuArrivee.Name = "cboLieuArrivee";
            this.cboLieuArrivee.Size = new System.Drawing.Size(291, 21);
            this.cboLieuArrivee.TabIndex = 19;
            // 
            // cboLieuDepart
            // 
            this.cboLieuDepart.FormattingEnabled = true;
            this.cboLieuDepart.Location = new System.Drawing.Point(110, 35);
            this.cboLieuDepart.Name = "cboLieuDepart";
            this.cboLieuDepart.Size = new System.Drawing.Size(224, 21);
            this.cboLieuDepart.TabIndex = 18;
            // 
            // cmdAjouterLigne
            // 
            this.cmdAjouterLigne.Location = new System.Drawing.Point(710, 181);
            this.cmdAjouterLigne.Name = "cmdAjouterLigne";
            this.cmdAjouterLigne.Size = new System.Drawing.Size(75, 23);
            this.cmdAjouterLigne.TabIndex = 17;
            this.cmdAjouterLigne.Text = "Ajouter";
            this.cmdAjouterLigne.UseVisualStyleBackColor = true;
            this.cmdAjouterLigne.Click += new System.EventHandler(this.cmdAjouterLigne_Click);
            // 
            // lblLieuDepart
            // 
            this.lblLieuDepart.AutoSize = true;
            this.lblLieuDepart.Location = new System.Drawing.Point(23, 34);
            this.lblLieuDepart.Name = "lblLieuDepart";
            this.lblLieuDepart.Size = new System.Drawing.Size(81, 13);
            this.lblLieuDepart.TabIndex = 2;
            this.lblLieuDepart.Text = "Lieu de départ :";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(23, 166);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(188, 13);
            this.lblDistance.TabIndex = 7;
            this.lblDistance.Text = "Distance séparant les deux lieux (km) :";
            // 
            // lblLieuArrivee
            // 
            this.lblLieuArrivee.AutoSize = true;
            this.lblLieuArrivee.Location = new System.Drawing.Point(453, 34);
            this.lblLieuArrivee.Name = "lblLieuArrivee";
            this.lblLieuArrivee.Size = new System.Drawing.Size(76, 13);
            this.lblLieuArrivee.TabIndex = 5;
            this.lblLieuArrivee.Text = "Lieu d\'arrivée :";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(234, 166);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(100, 20);
            this.txtDistance.TabIndex = 11;
            // 
            // grbVol
            // 
            this.grbVol.Controls.Add(this.cmdDateArrivee);
            this.grbVol.Controls.Add(this.nudMArrivee);
            this.grbVol.Controls.Add(this.nudHArrivee);
            this.grbVol.Controls.Add(this.nudMDepart);
            this.grbVol.Controls.Add(this.nudHDepart);
            this.grbVol.Controls.Add(this.lblHeureArrivee);
            this.grbVol.Controls.Add(this.lblHeureDepart);
            this.grbVol.Controls.Add(this.cboLigne);
            this.grbVol.Controls.Add(this.cmdAjouterVol);
            this.grbVol.Controls.Add(this.dtpDateArrivee);
            this.grbVol.Controls.Add(this.dtpDateDepart);
            this.grbVol.Controls.Add(this.lblDateDepart);
            this.grbVol.Controls.Add(this.lblDateArrivee);
            this.grbVol.Controls.Add(this.lblLigne);
            this.grbVol.Location = new System.Drawing.Point(7, 200);
            this.grbVol.Name = "grbVol";
            this.grbVol.Size = new System.Drawing.Size(851, 180);
            this.grbVol.TabIndex = 1;
            this.grbVol.TabStop = false;
            this.grbVol.Text = "Vol";
            // 
            // nudMArrivee
            // 
            this.nudMArrivee.Enabled = false;
            this.nudMArrivee.Location = new System.Drawing.Point(539, 68);
            this.nudMArrivee.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMArrivee.Name = "nudMArrivee";
            this.nudMArrivee.Size = new System.Drawing.Size(40, 20);
            this.nudMArrivee.TabIndex = 24;
            // 
            // nudHArrivee
            // 
            this.nudHArrivee.Enabled = false;
            this.nudHArrivee.Location = new System.Drawing.Point(493, 68);
            this.nudHArrivee.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHArrivee.Name = "nudHArrivee";
            this.nudHArrivee.Size = new System.Drawing.Size(40, 20);
            this.nudHArrivee.TabIndex = 23;
            // 
            // nudMDepart
            // 
            this.nudMDepart.Location = new System.Drawing.Point(171, 68);
            this.nudMDepart.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMDepart.Name = "nudMDepart";
            this.nudMDepart.Size = new System.Drawing.Size(40, 20);
            this.nudMDepart.TabIndex = 21;
            this.nudMDepart.ValueChanged += new System.EventHandler(this.nudMDepart_ValueChanged);
            // 
            // nudHDepart
            // 
            this.nudHDepart.Location = new System.Drawing.Point(123, 68);
            this.nudHDepart.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHDepart.Name = "nudHDepart";
            this.nudHDepart.Size = new System.Drawing.Size(40, 20);
            this.nudHDepart.TabIndex = 20;
            this.nudHDepart.ValueChanged += new System.EventHandler(this.nudHDepart_ValueChanged);
            // 
            // lblHeureArrivee
            // 
            this.lblHeureArrivee.AutoSize = true;
            this.lblHeureArrivee.Location = new System.Drawing.Point(408, 68);
            this.lblHeureArrivee.Name = "lblHeureArrivee";
            this.lblHeureArrivee.Size = new System.Drawing.Size(85, 13);
            this.lblHeureArrivee.TabIndex = 19;
            this.lblHeureArrivee.Text = "Heure d\'arrivée :";
            // 
            // lblHeureDepart
            // 
            this.lblHeureDepart.AutoSize = true;
            this.lblHeureDepart.Location = new System.Drawing.Point(26, 68);
            this.lblHeureDepart.Name = "lblHeureDepart";
            this.lblHeureDepart.Size = new System.Drawing.Size(90, 13);
            this.lblHeureDepart.TabIndex = 18;
            this.lblHeureDepart.Text = "Heure de départ :";
            // 
            // cboLigne
            // 
            this.cboLigne.FormattingEnabled = true;
            this.cboLigne.Location = new System.Drawing.Point(113, 103);
            this.cboLigne.Name = "cboLigne";
            this.cboLigne.Size = new System.Drawing.Size(586, 21);
            this.cboLigne.TabIndex = 17;
            this.cboLigne.SelectedIndexChanged += new System.EventHandler(this.cboLigne_SelectedIndexChanged);
            // 
            // cmdAjouterVol
            // 
            this.cmdAjouterVol.Location = new System.Drawing.Point(710, 138);
            this.cmdAjouterVol.Name = "cmdAjouterVol";
            this.cmdAjouterVol.Size = new System.Drawing.Size(75, 23);
            this.cmdAjouterVol.TabIndex = 16;
            this.cmdAjouterVol.Text = "Ajouter";
            this.cmdAjouterVol.UseVisualStyleBackColor = true;
            this.cmdAjouterVol.Click += new System.EventHandler(this.cmdAjouterVol_Click);
            // 
            // dtpDateArrivee
            // 
            this.dtpDateArrivee.Enabled = false;
            this.dtpDateArrivee.Location = new System.Drawing.Point(493, 34);
            this.dtpDateArrivee.Name = "dtpDateArrivee";
            this.dtpDateArrivee.Size = new System.Drawing.Size(200, 20);
            this.dtpDateArrivee.TabIndex = 11;
            // 
            // dtpDateDepart
            // 
            this.dtpDateDepart.Location = new System.Drawing.Point(113, 34);
            this.dtpDateDepart.Name = "dtpDateDepart";
            this.dtpDateDepart.Size = new System.Drawing.Size(200, 20);
            this.dtpDateDepart.TabIndex = 10;
            this.dtpDateDepart.ValueChanged += new System.EventHandler(this.dtpDateDepart_ValueChanged);
            // 
            // lblDateDepart
            // 
            this.lblDateDepart.AutoSize = true;
            this.lblDateDepart.Location = new System.Drawing.Point(23, 34);
            this.lblDateDepart.Name = "lblDateDepart";
            this.lblDateDepart.Size = new System.Drawing.Size(84, 13);
            this.lblDateDepart.TabIndex = 6;
            this.lblDateDepart.Text = "Date de départ :";
            // 
            // lblDateArrivee
            // 
            this.lblDateArrivee.AutoSize = true;
            this.lblDateArrivee.Location = new System.Drawing.Point(408, 34);
            this.lblDateArrivee.Name = "lblDateArrivee";
            this.lblDateArrivee.Size = new System.Drawing.Size(79, 13);
            this.lblDateArrivee.TabIndex = 8;
            this.lblDateArrivee.Text = "Date d\'arrivée :";
            // 
            // lblLigne
            // 
            this.lblLigne.AutoSize = true;
            this.lblLigne.Location = new System.Drawing.Point(19, 103);
            this.lblLigne.Name = "lblLigne";
            this.lblLigne.Size = new System.Drawing.Size(39, 13);
            this.lblLigne.TabIndex = 4;
            this.lblLigne.Text = "Ligne :";
            // 
            // grbPilote
            // 
            this.grbPilote.Controls.Add(this.cboAeroportAffectation);
            this.grbPilote.Controls.Add(this.cmdAjouterPilote);
            this.grbPilote.Controls.Add(this.txtHeuresVol);
            this.grbPilote.Controls.Add(this.txtPrenom);
            this.grbPilote.Controls.Add(this.txtNom);
            this.grbPilote.Controls.Add(this.lblPrenom);
            this.grbPilote.Controls.Add(this.lblHeuresVol);
            this.grbPilote.Controls.Add(this.lblAeroportAffectation);
            this.grbPilote.Controls.Add(this.lblNom);
            this.grbPilote.Location = new System.Drawing.Point(7, 20);
            this.grbPilote.Name = "grbPilote";
            this.grbPilote.Size = new System.Drawing.Size(845, 170);
            this.grbPilote.TabIndex = 0;
            this.grbPilote.TabStop = false;
            this.grbPilote.Text = "Pilote";
            // 
            // cboAeroportAffectation
            // 
            this.cboAeroportAffectation.FormattingEnabled = true;
            this.cboAeroportAffectation.Location = new System.Drawing.Point(155, 98);
            this.cboAeroportAffectation.Name = "cboAeroportAffectation";
            this.cboAeroportAffectation.Size = new System.Drawing.Size(234, 21);
            this.cboAeroportAffectation.TabIndex = 16;
            // 
            // cmdAjouterPilote
            // 
            this.cmdAjouterPilote.Location = new System.Drawing.Point(710, 121);
            this.cmdAjouterPilote.Name = "cmdAjouterPilote";
            this.cmdAjouterPilote.Size = new System.Drawing.Size(75, 23);
            this.cmdAjouterPilote.TabIndex = 15;
            this.cmdAjouterPilote.Text = "Ajouter";
            this.cmdAjouterPilote.UseVisualStyleBackColor = true;
            this.cmdAjouterPilote.Click += new System.EventHandler(this.cmdAjouterPilote_Click);
            // 
            // txtHeuresVol
            // 
            this.txtHeuresVol.Location = new System.Drawing.Point(618, 39);
            this.txtHeuresVol.Name = "txtHeuresVol";
            this.txtHeuresVol.Size = new System.Drawing.Size(100, 20);
            this.txtHeuresVol.TabIndex = 14;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(155, 66);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(100, 20);
            this.txtPrenom.TabIndex = 13;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(155, 40);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 10;
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(23, 66);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(49, 13);
            this.lblPrenom.TabIndex = 9;
            this.lblPrenom.Text = "Prénom :";
            // 
            // lblHeuresVol
            // 
            this.lblHeuresVol.AutoSize = true;
            this.lblHeuresVol.Location = new System.Drawing.Point(471, 39);
            this.lblHeuresVol.Name = "lblHeuresVol";
            this.lblHeuresVol.Size = new System.Drawing.Size(131, 13);
            this.lblHeuresVol.TabIndex = 3;
            this.lblHeuresVol.Text = "Heures de vol à son actif :";
            // 
            // lblAeroportAffectation
            // 
            this.lblAeroportAffectation.AutoSize = true;
            this.lblAeroportAffectation.Location = new System.Drawing.Point(23, 98);
            this.lblAeroportAffectation.Name = "lblAeroportAffectation";
            this.lblAeroportAffectation.Size = new System.Drawing.Size(114, 13);
            this.lblAeroportAffectation.TabIndex = 1;
            this.lblAeroportAffectation.Text = "Aéroport d\'affectation :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(23, 39);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 13);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom :";
            // 
            // cmdDateArrivee
            // 
            this.cmdDateArrivee.Location = new System.Drawing.Point(445, 138);
            this.cmdDateArrivee.Name = "cmdDateArrivee";
            this.cmdDateArrivee.Size = new System.Drawing.Size(118, 23);
            this.cmdDateArrivee.TabIndex = 25;
            this.cmdDateArrivee.Text = "Voir date arrivée";
            this.cmdDateArrivee.UseVisualStyleBackColor = true;
            this.cmdDateArrivee.Click += new System.EventHandler(this.cmdDateArrivee_Click);
            // 
            // frmGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 772);
            this.Controls.Add(this.grbGestion);
            this.Controls.Add(this.Entete);
            this.Name = "frmGestion";
            this.Text = "frmGestion";
            this.Load += new System.EventHandler(this.frmGestion_Load);
            this.Entete.ResumeLayout(false);
            this.grbGestion.ResumeLayout(false);
            this.grbLigne.ResumeLayout(false);
            this.grbLigne.PerformLayout();
            this.grbVol.ResumeLayout(false);
            this.grbVol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMArrivee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHArrivee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMDepart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHDepart)).EndInit();
            this.grbPilote.ResumeLayout(false);
            this.grbPilote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Entete;
        private System.Windows.Forms.Button cmdAffichage;
        private System.Windows.Forms.Button cmdGestion;
        private System.Windows.Forms.GroupBox grbGestion;
        private System.Windows.Forms.GroupBox grbLigne;
        private System.Windows.Forms.GroupBox grbVol;
        private System.Windows.Forms.GroupBox grbPilote;
        private System.Windows.Forms.Label lblLieuDepart;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblLieuArrivee;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label lblDateDepart;
        private System.Windows.Forms.Label lblDateArrivee;
        private System.Windows.Forms.Label lblLigne;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblHeuresVol;
        private System.Windows.Forms.Label lblAeroportAffectation;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtHeuresVol;
        private System.Windows.Forms.Button cmdAjouterLigne;
        private System.Windows.Forms.Button cmdAjouterVol;
        private System.Windows.Forms.DateTimePicker dtpDateArrivee;
        private System.Windows.Forms.DateTimePicker dtpDateDepart;
        private System.Windows.Forms.Button cmdAjouterPilote;
        private System.Windows.Forms.ComboBox cboAeroportAffectation;
        private System.Windows.Forms.ComboBox cboLieuArrivee;
        private System.Windows.Forms.ComboBox cboLieuDepart;
        private System.Windows.Forms.ComboBox cboLigne;
        private System.Windows.Forms.NumericUpDown nudMArrivee;
        private System.Windows.Forms.NumericUpDown nudHArrivee;
        private System.Windows.Forms.NumericUpDown nudMDepart;
        private System.Windows.Forms.NumericUpDown nudHDepart;
        private System.Windows.Forms.Label lblHeureArrivee;
        private System.Windows.Forms.Label lblHeureDepart;
        private System.Windows.Forms.Button cmdDateArrivee;
    }
}
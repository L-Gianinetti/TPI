﻿namespace Application_de_planification_de_vols_aériens
{
    partial class frmDisplay
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
            this.cmdManagement = new System.Windows.Forms.Button();
            this.pnlEntete = new System.Windows.Forms.Panel();
            this.grbDisplay = new System.Windows.Forms.GroupBox();
            this.grbLines = new System.Windows.Forms.GroupBox();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.colIdLigne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLieuDepart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLieuArrivee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbFlights = new System.Windows.Forms.GroupBox();
            this.cmdPlan = new System.Windows.Forms.Button();
            this.dgvFlights = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLigne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartureAirport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrivalAirport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateDepart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateArrivee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPilote1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPilote2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbPilots = new System.Windows.Forms.GroupBox();
            this.cmdPlanVacation = new System.Windows.Forms.Button();
            this.cmdDisplayVacation = new System.Windows.Forms.Button();
            this.cmdGeneratePlanning = new System.Windows.Forms.Button();
            this.lblMois = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.dgvPilots = new System.Windows.Forms.DataGridView();
            this.colIdPilot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPilotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPilotFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignmentAirport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlightHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEntete.SuspendLayout();
            this.grbDisplay.SuspendLayout();
            this.grbLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.grbFlights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).BeginInit();
            this.grbPilots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPilots)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdManagement
            // 
            this.cmdManagement.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdManagement.Location = new System.Drawing.Point(590, 19);
            this.cmdManagement.Name = "cmdManagement";
            this.cmdManagement.Size = new System.Drawing.Size(81, 23);
            this.cmdManagement.TabIndex = 0;
            this.cmdManagement.Text = "Gestion";
            this.cmdManagement.UseVisualStyleBackColor = true;
            this.cmdManagement.Click += new System.EventHandler(this.cmdManagement_Click);
            // 
            // pnlEntete
            // 
            this.pnlEntete.Controls.Add(this.cmdManagement);
            this.pnlEntete.Location = new System.Drawing.Point(12, 12);
            this.pnlEntete.Name = "pnlEntete";
            this.pnlEntete.Size = new System.Drawing.Size(1388, 65);
            this.pnlEntete.TabIndex = 1;
            // 
            // grbDisplay
            // 
            this.grbDisplay.Controls.Add(this.grbLines);
            this.grbDisplay.Controls.Add(this.grbFlights);
            this.grbDisplay.Controls.Add(this.grbPilots);
            this.grbDisplay.Location = new System.Drawing.Point(12, 96);
            this.grbDisplay.Name = "grbDisplay";
            this.grbDisplay.Size = new System.Drawing.Size(1401, 810);
            this.grbDisplay.TabIndex = 0;
            this.grbDisplay.TabStop = false;
            this.grbDisplay.Text = "Affichage";
            // 
            // grbLines
            // 
            this.grbLines.Controls.Add(this.dgvLines);
            this.grbLines.Location = new System.Drawing.Point(7, 370);
            this.grbLines.Name = "grbLines";
            this.grbLines.Size = new System.Drawing.Size(1381, 228);
            this.grbLines.TabIndex = 2;
            this.grbLines.TabStop = false;
            this.grbLines.Text = "Affichage des lignes existantes";
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToOrderColumns = true;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdLigne,
            this.colLieuDepart,
            this.colLieuArrivee,
            this.colDistance});
            this.dgvLines.Location = new System.Drawing.Point(7, 20);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.Size = new System.Drawing.Size(554, 202);
            this.dgvLines.TabIndex = 0;
            // 
            // colIdLigne
            // 
            this.colIdLigne.HeaderText = "Id";
            this.colIdLigne.Name = "colIdLigne";
            this.colIdLigne.Width = 35;
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
            // grbFlights
            // 
            this.grbFlights.Controls.Add(this.cmdPlan);
            this.grbFlights.Controls.Add(this.dgvFlights);
            this.grbFlights.Location = new System.Drawing.Point(7, 604);
            this.grbFlights.Name = "grbFlights";
            this.grbFlights.Size = new System.Drawing.Size(1381, 200);
            this.grbFlights.TabIndex = 1;
            this.grbFlights.TabStop = false;
            this.grbFlights.Text = "Affichage des vols existants/ Affectation d\'un vol à un pilote";
            // 
            // cmdPlan
            // 
            this.cmdPlan.Location = new System.Drawing.Point(1222, 156);
            this.cmdPlan.Name = "cmdPlan";
            this.cmdPlan.Size = new System.Drawing.Size(110, 23);
            this.cmdPlan.TabIndex = 5;
            this.cmdPlan.Text = "Planifier";
            this.cmdPlan.UseVisualStyleBackColor = true;
            this.cmdPlan.Click += new System.EventHandler(this.cmdPlan_Click);
            // 
            // dgvFlights
            // 
            this.dgvFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colLigne,
            this.colDepartureAirport,
            this.colArrivalAirport,
            this.colDateDepart,
            this.colDateArrivee,
            this.colPilote1,
            this.colPilote2});
            this.dgvFlights.Location = new System.Drawing.Point(7, 20);
            this.dgvFlights.Name = "dgvFlights";
            this.dgvFlights.Size = new System.Drawing.Size(1176, 159);
            this.dgvFlights.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.HeaderText = "Nom";
            this.colName.Name = "colName";
            this.colName.Width = 150;
            // 
            // colLigne
            // 
            this.colLigne.HeaderText = "Ligne";
            this.colLigne.Name = "colLigne";
            this.colLigne.Width = 35;
            // 
            // colDepartureAirport
            // 
            this.colDepartureAirport.HeaderText = "Aéroprt de départ";
            this.colDepartureAirport.Name = "colDepartureAirport";
            this.colDepartureAirport.Width = 125;
            // 
            // colArrivalAirport
            // 
            this.colArrivalAirport.HeaderText = "Aéroport d\'arrivée";
            this.colArrivalAirport.Name = "colArrivalAirport";
            this.colArrivalAirport.Width = 200;
            // 
            // colDateDepart
            // 
            this.colDateDepart.HeaderText = "Date départ";
            this.colDateDepart.Name = "colDateDepart";
            this.colDateDepart.Width = 110;
            // 
            // colDateArrivee
            // 
            this.colDateArrivee.HeaderText = "Date arrivée";
            this.colDateArrivee.Name = "colDateArrivee";
            this.colDateArrivee.Width = 110;
            // 
            // colPilote1
            // 
            this.colPilote1.HeaderText = "Pilote n°1";
            this.colPilote1.Name = "colPilote1";
            this.colPilote1.Width = 200;
            // 
            // colPilote2
            // 
            this.colPilote2.HeaderText = "Pilote n°2";
            this.colPilote2.Name = "colPilote2";
            this.colPilote2.Width = 200;
            // 
            // grbPilots
            // 
            this.grbPilots.Controls.Add(this.cmdPlanVacation);
            this.grbPilots.Controls.Add(this.cmdDisplayVacation);
            this.grbPilots.Controls.Add(this.cmdGeneratePlanning);
            this.grbPilots.Controls.Add(this.lblMois);
            this.grbPilots.Controls.Add(this.cboMonth);
            this.grbPilots.Controls.Add(this.dgvPilots);
            this.grbPilots.Location = new System.Drawing.Point(7, 20);
            this.grbPilots.Name = "grbPilots";
            this.grbPilots.Size = new System.Drawing.Size(1381, 344);
            this.grbPilots.TabIndex = 0;
            this.grbPilots.TabStop = false;
            this.grbPilots.Text = "Affichage des pilotes existants / Gestion des vacances / Génération du planning";
            // 
            // cmdPlanVacation
            // 
            this.cmdPlanVacation.Location = new System.Drawing.Point(643, 61);
            this.cmdPlanVacation.Name = "cmdPlanVacation";
            this.cmdPlanVacation.Size = new System.Drawing.Size(150, 23);
            this.cmdPlanVacation.TabIndex = 6;
            this.cmdPlanVacation.Text = "Planifier les vacances";
            this.cmdPlanVacation.UseVisualStyleBackColor = true;
            this.cmdPlanVacation.Click += new System.EventHandler(this.cmdPlanVacation_Click);
            // 
            // cmdDisplayVacation
            // 
            this.cmdDisplayVacation.Location = new System.Drawing.Point(643, 19);
            this.cmdDisplayVacation.Name = "cmdDisplayVacation";
            this.cmdDisplayVacation.Size = new System.Drawing.Size(150, 23);
            this.cmdDisplayVacation.TabIndex = 5;
            this.cmdDisplayVacation.Text = "Afficher les vacances";
            this.cmdDisplayVacation.UseVisualStyleBackColor = true;
            this.cmdDisplayVacation.Click += new System.EventHandler(this.cmdDisplayVacation_Click);
            // 
            // cmdGeneratePlanning
            // 
            this.cmdGeneratePlanning.Location = new System.Drawing.Point(643, 109);
            this.cmdGeneratePlanning.Name = "cmdGeneratePlanning";
            this.cmdGeneratePlanning.Size = new System.Drawing.Size(110, 23);
            this.cmdGeneratePlanning.TabIndex = 4;
            this.cmdGeneratePlanning.Text = "Générer planning";
            this.cmdGeneratePlanning.UseVisualStyleBackColor = true;
            this.cmdGeneratePlanning.Click += new System.EventHandler(this.cmdGeneratePlaning_Click);
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
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(122, 302);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 21);
            this.cboMonth.TabIndex = 2;
            // 
            // dgvPilots
            // 
            this.dgvPilots.AllowUserToOrderColumns = true;
            this.dgvPilots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPilots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdPilot,
            this.colPilotName,
            this.colPilotFirstName,
            this.colAssignmentAirport,
            this.colFlightHours});
            this.dgvPilots.Location = new System.Drawing.Point(30, 19);
            this.dgvPilots.Name = "dgvPilots";
            this.dgvPilots.Size = new System.Drawing.Size(595, 277);
            this.dgvPilots.TabIndex = 1;
            // 
            // colIdPilot
            // 
            this.colIdPilot.HeaderText = "Id";
            this.colIdPilot.Name = "colIdPilot";
            this.colIdPilot.Width = 25;
            // 
            // colPilotName
            // 
            this.colPilotName.HeaderText = "Nom";
            this.colPilotName.Name = "colPilotName";
            this.colPilotName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colPilotFirstName
            // 
            this.colPilotFirstName.HeaderText = "Prénom";
            this.colPilotFirstName.Name = "colPilotFirstName";
            // 
            // colAssignmentAirport
            // 
            this.colAssignmentAirport.HeaderText = "Aéroport d\'affectation";
            this.colAssignmentAirport.Name = "colAssignmentAirport";
            this.colAssignmentAirport.Width = 250;
            // 
            // colFlightHours
            // 
            this.colFlightHours.HeaderText = "Heures de vol à son actif";
            this.colFlightHours.Name = "colFlightHours";
            this.colFlightHours.Width = 75;
            // 
            // frmDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 918);
            this.Controls.Add(this.grbDisplay);
            this.Controls.Add(this.pnlEntete);
            this.Name = "frmDisplay";
            this.Text = "Planification de vols aériens - frmDisplay";
            this.Load += new System.EventHandler(this.frmDisplay_Load);
            this.pnlEntete.ResumeLayout(false);
            this.grbDisplay.ResumeLayout(false);
            this.grbLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.grbFlights.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).EndInit();
            this.grbPilots.ResumeLayout(false);
            this.grbPilots.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPilots)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdManagement;
        private System.Windows.Forms.Panel pnlEntete;
        private System.Windows.Forms.GroupBox grbDisplay;
        private System.Windows.Forms.GroupBox grbLines;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.GroupBox grbFlights;
        private System.Windows.Forms.Button cmdPlan;
        private System.Windows.Forms.DataGridView dgvFlights;
        private System.Windows.Forms.GroupBox grbPilots;
        private System.Windows.Forms.Button cmdPlanVacation;
        private System.Windows.Forms.Button cmdDisplayVacation;
        private System.Windows.Forms.Button cmdGeneratePlanning;
        private System.Windows.Forms.Label lblMois;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.DataGridView dgvPilots;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPilot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPilotName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPilotFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignmentAirport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlightHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLigne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLieuDepart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLieuArrivee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLigne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartureAirport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrivalAirport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateDepart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateArrivee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPilote1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPilote2;
    }
}
namespace Application_de_planification_de_vols_aériens
{
    partial class frmManagement
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
            this.cmdDisplay = new System.Windows.Forms.Button();
            this.grbManagement = new System.Windows.Forms.GroupBox();
            this.grbLine = new System.Windows.Forms.GroupBox();
            this.cboArrivalPlace = new System.Windows.Forms.ComboBox();
            this.cboDeparturePlace = new System.Windows.Forms.ComboBox();
            this.cmdAddLine = new System.Windows.Forms.Button();
            this.lblDeparturePlace = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblArrivalPlace = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.grbFlight = new System.Windows.Forms.GroupBox();
            this.cmdArrivalDate = new System.Windows.Forms.Button();
            this.nudMArrival = new System.Windows.Forms.NumericUpDown();
            this.nudHArrival = new System.Windows.Forms.NumericUpDown();
            this.nudMDeparture = new System.Windows.Forms.NumericUpDown();
            this.nudHDeparture = new System.Windows.Forms.NumericUpDown();
            this.lblArrivalHour = new System.Windows.Forms.Label();
            this.lblDepartureHour = new System.Windows.Forms.Label();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.cmdAddFlight = new System.Windows.Forms.Button();
            this.dtpArrivalDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDepartureDate = new System.Windows.Forms.DateTimePicker();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.lblArrivalDate = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.grbPilot = new System.Windows.Forms.GroupBox();
            this.cboAssignmentAirport = new System.Windows.Forms.ComboBox();
            this.cmdAddPilot = new System.Windows.Forms.Button();
            this.txtFlightHours = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblFlightHours = new System.Windows.Forms.Label();
            this.lblAssignmentAirport = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.Entete.SuspendLayout();
            this.grbManagement.SuspendLayout();
            this.grbLine.SuspendLayout();
            this.grbFlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMArrival)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHArrival)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMDeparture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHDeparture)).BeginInit();
            this.grbPilot.SuspendLayout();
            this.SuspendLayout();
            // 
            // Entete
            // 
            this.Entete.Controls.Add(this.cmdDisplay);
            this.Entete.Location = new System.Drawing.Point(28, 12);
            this.Entete.Name = "Entete";
            this.Entete.Size = new System.Drawing.Size(869, 54);
            this.Entete.TabIndex = 2;
            // 
            // cmdDisplay
            // 
            this.cmdDisplay.Location = new System.Drawing.Point(33, 16);
            this.cmdDisplay.Name = "cmdDisplay";
            this.cmdDisplay.Size = new System.Drawing.Size(75, 23);
            this.cmdDisplay.TabIndex = 1;
            this.cmdDisplay.Text = "Affichage";
            this.cmdDisplay.UseVisualStyleBackColor = true;
            this.cmdDisplay.Click += new System.EventHandler(this.cmdDisplay_Click);
            // 
            // grbManagement
            // 
            this.grbManagement.Controls.Add(this.grbLine);
            this.grbManagement.Controls.Add(this.grbFlight);
            this.grbManagement.Controls.Add(this.grbPilot);
            this.grbManagement.Location = new System.Drawing.Point(28, 84);
            this.grbManagement.Name = "grbManagement";
            this.grbManagement.Size = new System.Drawing.Size(869, 644);
            this.grbManagement.TabIndex = 3;
            this.grbManagement.TabStop = false;
            this.grbManagement.Text = "Gestion";
            // 
            // grbLine
            // 
            this.grbLine.Controls.Add(this.cboArrivalPlace);
            this.grbLine.Controls.Add(this.cboDeparturePlace);
            this.grbLine.Controls.Add(this.cmdAddLine);
            this.grbLine.Controls.Add(this.lblDeparturePlace);
            this.grbLine.Controls.Add(this.lblDistance);
            this.grbLine.Controls.Add(this.lblArrivalPlace);
            this.grbLine.Controls.Add(this.txtDistance);
            this.grbLine.Location = new System.Drawing.Point(7, 386);
            this.grbLine.Name = "grbLine";
            this.grbLine.Size = new System.Drawing.Size(851, 210);
            this.grbLine.TabIndex = 2;
            this.grbLine.TabStop = false;
            this.grbLine.Text = "Ligne";
            // 
            // cboArrivalPlace
            // 
            this.cboArrivalPlace.FormattingEnabled = true;
            this.cboArrivalPlace.Location = new System.Drawing.Point(535, 34);
            this.cboArrivalPlace.Name = "cboArrivalPlace";
            this.cboArrivalPlace.Size = new System.Drawing.Size(291, 21);
            this.cboArrivalPlace.TabIndex = 19;
            // 
            // cboDeparturePlace
            // 
            this.cboDeparturePlace.FormattingEnabled = true;
            this.cboDeparturePlace.Location = new System.Drawing.Point(110, 35);
            this.cboDeparturePlace.Name = "cboDeparturePlace";
            this.cboDeparturePlace.Size = new System.Drawing.Size(224, 21);
            this.cboDeparturePlace.TabIndex = 18;
            // 
            // cmdAddLine
            // 
            this.cmdAddLine.Location = new System.Drawing.Point(710, 181);
            this.cmdAddLine.Name = "cmdAddLine";
            this.cmdAddLine.Size = new System.Drawing.Size(75, 23);
            this.cmdAddLine.TabIndex = 17;
            this.cmdAddLine.Text = "Ajouter";
            this.cmdAddLine.UseVisualStyleBackColor = true;
            this.cmdAddLine.Click += new System.EventHandler(this.cmdAddLine_Click);
            // 
            // lblDeparturePlace
            // 
            this.lblDeparturePlace.AutoSize = true;
            this.lblDeparturePlace.Location = new System.Drawing.Point(23, 34);
            this.lblDeparturePlace.Name = "lblDeparturePlace";
            this.lblDeparturePlace.Size = new System.Drawing.Size(81, 13);
            this.lblDeparturePlace.TabIndex = 2;
            this.lblDeparturePlace.Text = "Lieu de départ :";
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
            // lblArrivalPlace
            // 
            this.lblArrivalPlace.AutoSize = true;
            this.lblArrivalPlace.Location = new System.Drawing.Point(453, 34);
            this.lblArrivalPlace.Name = "lblArrivalPlace";
            this.lblArrivalPlace.Size = new System.Drawing.Size(76, 13);
            this.lblArrivalPlace.TabIndex = 5;
            this.lblArrivalPlace.Text = "Lieu d\'arrivée :";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(234, 166);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(100, 20);
            this.txtDistance.TabIndex = 11;
            // 
            // grbFlight
            // 
            this.grbFlight.Controls.Add(this.cmdArrivalDate);
            this.grbFlight.Controls.Add(this.nudMArrival);
            this.grbFlight.Controls.Add(this.nudHArrival);
            this.grbFlight.Controls.Add(this.nudMDeparture);
            this.grbFlight.Controls.Add(this.nudHDeparture);
            this.grbFlight.Controls.Add(this.lblArrivalHour);
            this.grbFlight.Controls.Add(this.lblDepartureHour);
            this.grbFlight.Controls.Add(this.cboLine);
            this.grbFlight.Controls.Add(this.cmdAddFlight);
            this.grbFlight.Controls.Add(this.dtpArrivalDate);
            this.grbFlight.Controls.Add(this.dtpDepartureDate);
            this.grbFlight.Controls.Add(this.lblDepartureDate);
            this.grbFlight.Controls.Add(this.lblArrivalDate);
            this.grbFlight.Controls.Add(this.lblLine);
            this.grbFlight.Location = new System.Drawing.Point(7, 200);
            this.grbFlight.Name = "grbFlight";
            this.grbFlight.Size = new System.Drawing.Size(851, 180);
            this.grbFlight.TabIndex = 1;
            this.grbFlight.TabStop = false;
            this.grbFlight.Text = "Vol";
            // 
            // cmdArrivalDate
            // 
            this.cmdArrivalDate.Location = new System.Drawing.Point(445, 138);
            this.cmdArrivalDate.Name = "cmdArrivalDate";
            this.cmdArrivalDate.Size = new System.Drawing.Size(118, 23);
            this.cmdArrivalDate.TabIndex = 25;
            this.cmdArrivalDate.Text = "Voir date arrivée";
            this.cmdArrivalDate.UseVisualStyleBackColor = true;
            this.cmdArrivalDate.Click += new System.EventHandler(this.cmdDateArrivee_Click);
            // 
            // nudMArrival
            // 
            this.nudMArrival.Enabled = false;
            this.nudMArrival.Location = new System.Drawing.Point(539, 68);
            this.nudMArrival.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMArrival.Name = "nudMArrival";
            this.nudMArrival.Size = new System.Drawing.Size(40, 20);
            this.nudMArrival.TabIndex = 24;
            // 
            // nudHArrival
            // 
            this.nudHArrival.Enabled = false;
            this.nudHArrival.Location = new System.Drawing.Point(493, 68);
            this.nudHArrival.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHArrival.Name = "nudHArrival";
            this.nudHArrival.Size = new System.Drawing.Size(40, 20);
            this.nudHArrival.TabIndex = 23;
            // 
            // nudMDeparture
            // 
            this.nudMDeparture.Location = new System.Drawing.Point(171, 68);
            this.nudMDeparture.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMDeparture.Name = "nudMDeparture";
            this.nudMDeparture.Size = new System.Drawing.Size(40, 20);
            this.nudMDeparture.TabIndex = 21;
            this.nudMDeparture.ValueChanged += new System.EventHandler(this.nudMDepart_ValueChanged);
            // 
            // nudHDeparture
            // 
            this.nudHDeparture.Location = new System.Drawing.Point(123, 68);
            this.nudHDeparture.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHDeparture.Name = "nudHDeparture";
            this.nudHDeparture.Size = new System.Drawing.Size(40, 20);
            this.nudHDeparture.TabIndex = 20;
            this.nudHDeparture.ValueChanged += new System.EventHandler(this.nudHDepart_ValueChanged);
            // 
            // lblArrivalHour
            // 
            this.lblArrivalHour.AutoSize = true;
            this.lblArrivalHour.Location = new System.Drawing.Point(408, 68);
            this.lblArrivalHour.Name = "lblArrivalHour";
            this.lblArrivalHour.Size = new System.Drawing.Size(85, 13);
            this.lblArrivalHour.TabIndex = 19;
            this.lblArrivalHour.Text = "Heure d\'arrivée :";
            // 
            // lblDepartureHour
            // 
            this.lblDepartureHour.AutoSize = true;
            this.lblDepartureHour.Location = new System.Drawing.Point(26, 68);
            this.lblDepartureHour.Name = "lblDepartureHour";
            this.lblDepartureHour.Size = new System.Drawing.Size(90, 13);
            this.lblDepartureHour.TabIndex = 18;
            this.lblDepartureHour.Text = "Heure de départ :";
            // 
            // cboLine
            // 
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(113, 103);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(586, 21);
            this.cboLine.TabIndex = 17;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLigne_SelectedIndexChanged);
            // 
            // cmdAddFlight
            // 
            this.cmdAddFlight.Location = new System.Drawing.Point(710, 138);
            this.cmdAddFlight.Name = "cmdAddFlight";
            this.cmdAddFlight.Size = new System.Drawing.Size(75, 23);
            this.cmdAddFlight.TabIndex = 16;
            this.cmdAddFlight.Text = "Ajouter";
            this.cmdAddFlight.UseVisualStyleBackColor = true;
            this.cmdAddFlight.Click += new System.EventHandler(this.cmdAddVol_Click);
            // 
            // dtpArrivalDate
            // 
            this.dtpArrivalDate.Enabled = false;
            this.dtpArrivalDate.Location = new System.Drawing.Point(493, 34);
            this.dtpArrivalDate.Name = "dtpArrivalDate";
            this.dtpArrivalDate.Size = new System.Drawing.Size(200, 20);
            this.dtpArrivalDate.TabIndex = 11;
            // 
            // dtpDepartureDate
            // 
            this.dtpDepartureDate.Location = new System.Drawing.Point(113, 34);
            this.dtpDepartureDate.Name = "dtpDepartureDate";
            this.dtpDepartureDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDepartureDate.TabIndex = 10;
            this.dtpDepartureDate.ValueChanged += new System.EventHandler(this.dtpDateDepart_ValueChanged);
            // 
            // lblDepartureDate
            // 
            this.lblDepartureDate.AutoSize = true;
            this.lblDepartureDate.Location = new System.Drawing.Point(23, 34);
            this.lblDepartureDate.Name = "lblDepartureDate";
            this.lblDepartureDate.Size = new System.Drawing.Size(84, 13);
            this.lblDepartureDate.TabIndex = 6;
            this.lblDepartureDate.Text = "Date de départ :";
            // 
            // lblArrivalDate
            // 
            this.lblArrivalDate.AutoSize = true;
            this.lblArrivalDate.Location = new System.Drawing.Point(408, 34);
            this.lblArrivalDate.Name = "lblArrivalDate";
            this.lblArrivalDate.Size = new System.Drawing.Size(79, 13);
            this.lblArrivalDate.TabIndex = 8;
            this.lblArrivalDate.Text = "Date d\'arrivée :";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(19, 103);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(39, 13);
            this.lblLine.TabIndex = 4;
            this.lblLine.Text = "Ligne :";
            // 
            // grbPilot
            // 
            this.grbPilot.Controls.Add(this.cboAssignmentAirport);
            this.grbPilot.Controls.Add(this.cmdAddPilot);
            this.grbPilot.Controls.Add(this.txtFlightHours);
            this.grbPilot.Controls.Add(this.txtFirstName);
            this.grbPilot.Controls.Add(this.txtName);
            this.grbPilot.Controls.Add(this.lblFirstName);
            this.grbPilot.Controls.Add(this.lblFlightHours);
            this.grbPilot.Controls.Add(this.lblAssignmentAirport);
            this.grbPilot.Controls.Add(this.lblName);
            this.grbPilot.Location = new System.Drawing.Point(7, 20);
            this.grbPilot.Name = "grbPilot";
            this.grbPilot.Size = new System.Drawing.Size(845, 170);
            this.grbPilot.TabIndex = 0;
            this.grbPilot.TabStop = false;
            this.grbPilot.Text = "Pilote";
            // 
            // cboAssignmentAirport
            // 
            this.cboAssignmentAirport.FormattingEnabled = true;
            this.cboAssignmentAirport.Location = new System.Drawing.Point(155, 98);
            this.cboAssignmentAirport.Name = "cboAssignmentAirport";
            this.cboAssignmentAirport.Size = new System.Drawing.Size(234, 21);
            this.cboAssignmentAirport.TabIndex = 16;
            // 
            // cmdAddPilot
            // 
            this.cmdAddPilot.Location = new System.Drawing.Point(710, 121);
            this.cmdAddPilot.Name = "cmdAddPilot";
            this.cmdAddPilot.Size = new System.Drawing.Size(75, 23);
            this.cmdAddPilot.TabIndex = 15;
            this.cmdAddPilot.Text = "Ajouter";
            this.cmdAddPilot.UseVisualStyleBackColor = true;
            this.cmdAddPilot.Click += new System.EventHandler(this.cmdAddPilote_Click);
            // 
            // txtFlightHours
            // 
            this.txtFlightHours.Location = new System.Drawing.Point(618, 39);
            this.txtFlightHours.Name = "txtFlightHours";
            this.txtFlightHours.Size = new System.Drawing.Size(100, 20);
            this.txtFlightHours.TabIndex = 14;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(155, 66);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 13;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(155, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 10;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(23, 66);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(49, 13);
            this.lblFirstName.TabIndex = 9;
            this.lblFirstName.Text = "Prénom :";
            // 
            // lblFlightHours
            // 
            this.lblFlightHours.AutoSize = true;
            this.lblFlightHours.Location = new System.Drawing.Point(471, 39);
            this.lblFlightHours.Name = "lblFlightHours";
            this.lblFlightHours.Size = new System.Drawing.Size(131, 13);
            this.lblFlightHours.TabIndex = 3;
            this.lblFlightHours.Text = "Heures de vol à son actif :";
            // 
            // lblAssignmentAirport
            // 
            this.lblAssignmentAirport.AutoSize = true;
            this.lblAssignmentAirport.Location = new System.Drawing.Point(23, 98);
            this.lblAssignmentAirport.Name = "lblAssignmentAirport";
            this.lblAssignmentAirport.Size = new System.Drawing.Size(114, 13);
            this.lblAssignmentAirport.TabIndex = 1;
            this.lblAssignmentAirport.Text = "Aéroport d\'affectation :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nom :";
            // 
            // frmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 772);
            this.Controls.Add(this.grbManagement);
            this.Controls.Add(this.Entete);
            this.Name = "frmManagement";
            this.Text = "frmGestion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManagement_FormClosing);
            this.Load += new System.EventHandler(this.frmManagement_Load);
            this.Entete.ResumeLayout(false);
            this.grbManagement.ResumeLayout(false);
            this.grbLine.ResumeLayout(false);
            this.grbLine.PerformLayout();
            this.grbFlight.ResumeLayout(false);
            this.grbFlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMArrival)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHArrival)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMDeparture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHDeparture)).EndInit();
            this.grbPilot.ResumeLayout(false);
            this.grbPilot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Entete;
        private System.Windows.Forms.Button cmdDisplay;
        private System.Windows.Forms.GroupBox grbManagement;
        private System.Windows.Forms.GroupBox grbLine;
        private System.Windows.Forms.GroupBox grbFlight;
        private System.Windows.Forms.GroupBox grbPilot;
        private System.Windows.Forms.Label lblDeparturePlace;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblArrivalPlace;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label lblDepartureDate;
        private System.Windows.Forms.Label lblArrivalDate;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblFlightHours;
        private System.Windows.Forms.Label lblAssignmentAirport;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFlightHours;
        private System.Windows.Forms.Button cmdAddLine;
        private System.Windows.Forms.Button cmdAddFlight;
        private System.Windows.Forms.DateTimePicker dtpArrivalDate;
        private System.Windows.Forms.DateTimePicker dtpDepartureDate;
        private System.Windows.Forms.Button cmdAddPilot;
        private System.Windows.Forms.ComboBox cboAssignmentAirport;
        private System.Windows.Forms.ComboBox cboArrivalPlace;
        private System.Windows.Forms.ComboBox cboDeparturePlace;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.NumericUpDown nudMArrival;
        private System.Windows.Forms.NumericUpDown nudHArrival;
        private System.Windows.Forms.NumericUpDown nudMDeparture;
        private System.Windows.Forms.NumericUpDown nudHDeparture;
        private System.Windows.Forms.Label lblArrivalHour;
        private System.Windows.Forms.Label lblDepartureHour;
        private System.Windows.Forms.Button cmdArrivalDate;
    }
}
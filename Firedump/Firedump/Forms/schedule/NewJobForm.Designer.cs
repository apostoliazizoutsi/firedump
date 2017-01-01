namespace Firedump.Forms.schedule
{
    partial class NewJobForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.cmbdatabase = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericDay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericHour = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericMinute = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.tbjobname = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbdatabase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbServers);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server";
            // 
            // cmbServers
            // 
            this.cmbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServers.FormattingEnabled = true;
            this.cmbServers.Location = new System.Drawing.Point(9, 41);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Size = new System.Drawing.Size(130, 21);
            this.cmbServers.TabIndex = 4;
            this.cmbServers.SelectionChangeCommitted += new System.EventHandler(this.cmbServers_SelectionChangeCommitted);
            // 
            // cmbdatabase
            // 
            this.cmbdatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdatabase.FormattingEnabled = true;
            this.cmbdatabase.Location = new System.Drawing.Point(150, 41);
            this.cmbdatabase.Name = "cmbdatabase";
            this.cmbdatabase.Size = new System.Drawing.Size(130, 21);
            this.cmbdatabase.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Database";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericMinute);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericHour);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericDay);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Day Of the Week";
            // 
            // numericDay
            // 
            this.numericDay.Location = new System.Drawing.Point(10, 36);
            this.numericDay.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDay.Name = "numericDay";
            this.numericDay.Size = new System.Drawing.Size(87, 20);
            this.numericDay.TabIndex = 1;
            this.numericDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hour";
            // 
            // numericHour
            // 
            this.numericHour.Location = new System.Drawing.Point(113, 36);
            this.numericHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericHour.Name = "numericHour";
            this.numericHour.Size = new System.Drawing.Size(87, 20);
            this.numericHour.TabIndex = 3;
            this.numericHour.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Minute";
            // 
            // numericMinute
            // 
            this.numericMinute.Location = new System.Drawing.Point(217, 36);
            this.numericMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericMinute.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMinute.Name = "numericMinute";
            this.numericMinute.Size = new System.Drawing.Size(87, 20);
            this.numericMinute.TabIndex = 5;
            this.numericMinute.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set Job";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.setjobclick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Job Name:";
            // 
            // tbjobname
            // 
            this.tbjobname.Location = new System.Drawing.Point(69, 188);
            this.tbjobname.Name = "tbjobname";
            this.tbjobname.Size = new System.Drawing.Size(187, 20);
            this.tbjobname.TabIndex = 4;
            // 
            // NewJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 227);
            this.Controls.Add(this.tbjobname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewJobForm";
            this.Text = "JobForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbdatabase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericMinute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericDay;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbjobname;
    }
}
namespace Firedump.Forms.schedule
{
    partial class SchedulerForm
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
            this.serviceManager1 = new Firedump.usercontrols.ServiceManager();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serviceManager1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 240);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Manager";
            // 
            // serviceManager1
            // 
            this.serviceManager1.Location = new System.Drawing.Point(6, 19);
            this.serviceManager1.Name = "serviceManager1";
            this.serviceManager1.Size = new System.Drawing.Size(424, 197);
            this.serviceManager1.TabIndex = 0;
            // 
            // SchedulerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 392);
            this.Controls.Add(this.groupBox1);
            this.Name = "SchedulerForm";
            this.Text = "SchedulerForm";
            this.Load += new System.EventHandler(this.SchedulerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private usercontrols.ServiceManager serviceManager1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
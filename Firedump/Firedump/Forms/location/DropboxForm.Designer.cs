namespace Firedump.Forms.location
{
    partial class DropboxForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.bsaveconnect = new System.Windows.Forms.Button();
            this.tbtoken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstatus = new System.Windows.Forms.Label();
            this.linfo = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.bsaveconnect);
            this.groupBox1.Controls.Add(this.tbtoken);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dropbox user  Credentials";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(423, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Visit to get the token:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(409, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(216, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://www.dropbox.com/developers/apps";
            // 
            // bsaveconnect
            // 
            this.bsaveconnect.Location = new System.Drawing.Point(521, 41);
            this.bsaveconnect.Name = "bsaveconnect";
            this.bsaveconnect.Size = new System.Drawing.Size(111, 23);
            this.bsaveconnect.TabIndex = 6;
            this.bsaveconnect.Text = "Save and Connect";
            this.bsaveconnect.UseVisualStyleBackColor = true;
            this.bsaveconnect.Click += new System.EventHandler(this.bsaveconnect_Click);
            // 
            // tbtoken
            // 
            this.tbtoken.Location = new System.Drawing.Point(53, 38);
            this.tbtoken.Name = "tbtoken";
            this.tbtoken.Size = new System.Drawing.Size(364, 20);
            this.tbtoken.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Token:";
            // 
            // lstatus
            // 
            this.lstatus.AutoSize = true;
            this.lstatus.Location = new System.Drawing.Point(16, 91);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(40, 13);
            this.lstatus.TabIndex = 1;
            this.lstatus.Text = "Status:";
            // 
            // linfo
            // 
            this.linfo.AutoSize = true;
            this.linfo.Location = new System.Drawing.Point(62, 91);
            this.linfo.Name = "linfo";
            this.linfo.Size = new System.Drawing.Size(25, 13);
            this.linfo.TabIndex = 2;
            this.linfo.Text = "Info";
            // 
            // DropboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 422);
            this.Controls.Add(this.linfo);
            this.Controls.Add(this.lstatus);
            this.Controls.Add(this.groupBox1);
            this.Name = "DropboxForm";
            this.Text = "DropboxForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbtoken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bsaveconnect;
        private System.Windows.Forms.Label lstatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label linfo;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
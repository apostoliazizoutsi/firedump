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
            this.bsaveconnect = new System.Windows.Forms.Button();
            this.tbtoken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbappsecret = new System.Windows.Forms.TextBox();
            this.tbappkey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bsaveconnect);
            this.groupBox1.Controls.Add(this.tbtoken);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbappsecret);
            this.groupBox1.Controls.Add(this.tbappkey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dropbox user  Credentials";
            // 
            // bsaveconnect
            // 
            this.bsaveconnect.Location = new System.Drawing.Point(514, 82);
            this.bsaveconnect.Name = "bsaveconnect";
            this.bsaveconnect.Size = new System.Drawing.Size(111, 23);
            this.bsaveconnect.TabIndex = 6;
            this.bsaveconnect.Text = "Save and Connect";
            this.bsaveconnect.UseVisualStyleBackColor = true;
            this.bsaveconnect.Click += new System.EventHandler(this.bsaveconnect_Click);
            // 
            // tbtoken
            // 
            this.tbtoken.Location = new System.Drawing.Point(74, 85);
            this.tbtoken.Name = "tbtoken";
            this.tbtoken.Size = new System.Drawing.Size(364, 20);
            this.tbtoken.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Token:";
            // 
            // tbappsecret
            // 
            this.tbappsecret.Location = new System.Drawing.Point(74, 50);
            this.tbappsecret.Name = "tbappsecret";
            this.tbappsecret.Size = new System.Drawing.Size(150, 20);
            this.tbappsecret.TabIndex = 3;
            // 
            // tbappkey
            // 
            this.tbappkey.Location = new System.Drawing.Point(74, 20);
            this.tbappkey.Name = "tbappkey";
            this.tbappkey.Size = new System.Drawing.Size(150, 20);
            this.tbappkey.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "App secret:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "App key:";
            // 
            // lstatus
            // 
            this.lstatus.AutoSize = true;
            this.lstatus.Location = new System.Drawing.Point(13, 141);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(60, 13);
            this.lstatus.TabIndex = 1;
            this.lstatus.Text = "status label";
            // 
            // DropboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 422);
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
        private System.Windows.Forms.TextBox tbappsecret;
        private System.Windows.Forms.TextBox tbappkey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbtoken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bsaveconnect;
        private System.Windows.Forms.Label lstatus;
    }
}
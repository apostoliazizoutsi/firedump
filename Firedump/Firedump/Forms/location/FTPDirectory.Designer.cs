﻿namespace Firedump.Forms.location
{
    partial class FTPDirectory
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.btusepath = new System.Windows.Forms.Button();
            this.tbpath = new System.Windows.Forms.TextBox();
            this.bgoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(2, 74);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(712, 369);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // btusepath
            // 
            this.btusepath.Location = new System.Drawing.Point(12, 45);
            this.btusepath.Name = "btusepath";
            this.btusepath.Size = new System.Drawing.Size(85, 23);
            this.btusepath.TabIndex = 4;
            this.btusepath.Text = "Use this path";
            this.btusepath.UseVisualStyleBackColor = true;
            this.btusepath.Click += new System.EventHandler(this.btusepath_Click);
            // 
            // tbpath
            // 
            this.tbpath.Location = new System.Drawing.Point(103, 18);
            this.tbpath.Name = "tbpath";
            this.tbpath.Size = new System.Drawing.Size(611, 20);
            this.tbpath.TabIndex = 6;
            // 
            // bgoBack
            // 
            this.bgoBack.Location = new System.Drawing.Point(12, 16);
            this.bgoBack.Name = "bgoBack";
            this.bgoBack.Size = new System.Drawing.Size(85, 23);
            this.bgoBack.TabIndex = 7;
            this.bgoBack.Text = "Go back";
            this.bgoBack.UseVisualStyleBackColor = true;
            this.bgoBack.Click += new System.EventHandler(this.bgoBack_Click);
            // 
            // FTPDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 445);
            this.Controls.Add(this.bgoBack);
            this.Controls.Add(this.tbpath);
            this.Controls.Add(this.btusepath);
            this.Controls.Add(this.listView1);
            this.Name = "FTPDirectory";
            this.Text = "FTPDirectory";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FTPDirectory_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btusepath;
        private System.Windows.Forms.TextBox tbpath;
        private System.Windows.Forms.Button bgoBack;
    }
}
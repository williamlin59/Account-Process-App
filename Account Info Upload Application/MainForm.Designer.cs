using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System;
using System.Collections.Generic;
namespace Account_Info_Upload_Application
{
    partial class MainForm
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
            this.browse = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.upload = new System.Windows.Forms.Button();
            this.filerOpener = new System.Windows.Forms.OpenFileDialog();
            this.uploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.percentage = new System.Windows.Forms.Label();
            this.task = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(403, 72);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(100, 32);
            this.browse.TabIndex = 0;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.choose_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(12, 75);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(373, 26);
            this.fileTextBox.TabIndex = 1;
            this.fileTextBox.TextChanged += new System.EventHandler(this.FileSelect_TextChanged);
            // 
            // upload
            // 
            this.upload.Location = new System.Drawing.Point(403, 111);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(100, 34);
            this.upload.TabIndex = 2;
            this.upload.Text = "Upload";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // filerOpener
            // 
            this.filerOpener.FileName = "filerOpener";
            this.filerOpener.Filter = "CSV files (*.csv)|*.csv|All Files (*.*)|*.*";
            this.filerOpener.FilterIndex = 1;
            // 
            // uploadProgressBar
            // 
            this.uploadProgressBar.Location = new System.Drawing.Point(12, 168);
            this.uploadProgressBar.Name = "uploadProgressBar";
            this.uploadProgressBar.Size = new System.Drawing.Size(373, 33);
            this.uploadProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.uploadProgressBar.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // percentage
            // 
            this.percentage.AutoSize = true;
            this.percentage.BackColor = System.Drawing.SystemColors.Control;
            this.percentage.Location = new System.Drawing.Point(172, 204);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(32, 20);
            this.percentage.TabIndex = 4;
            this.percentage.Text = "0%";
            // 
            // task
            // 
            this.task.AutoSize = true;
            this.task.Location = new System.Drawing.Point(399, 168);
            this.task.Name = "task";
            this.task.Size = new System.Drawing.Size(0, 20);
            this.task.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 244);
            this.Controls.Add(this.task);
            this.Controls.Add(this.percentage);
            this.Controls.Add(this.uploadProgressBar);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.browse);
            this.Name = "MainForm";
            this.Text = "Transaction Data Upload App";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.OpenFileDialog filerOpener;
        private System.Windows.Forms.ProgressBar uploadProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Label percentage;
        private Label task;
    }
}


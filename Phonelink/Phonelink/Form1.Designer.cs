
namespace Phonelink
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextUpdateCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.contextEnablePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "PhoneLink";
            this.trayIcon.Visible = true;
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextUpdateCheck,
            this.contextEnablePassword,
            this.toolStripSeparator1,
            this.contextMenuExit});
            this.trayMenu.Name = "contextMenuStrip1";
            this.trayMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.trayMenu.Size = new System.Drawing.Size(200, 98);
            // 
            // contextUpdateCheck
            // 
            this.contextUpdateCheck.CheckOnClick = true;
            this.contextUpdateCheck.Name = "contextUpdateCheck";
            this.contextUpdateCheck.Size = new System.Drawing.Size(199, 22);
            this.contextUpdateCheck.Text = "Check for New Releases";
            this.contextUpdateCheck.CheckedChanged += new System.EventHandler(this.toolStripMenuItem1_CheckedChanged);
            // 
            // contextEnablePassword
            // 
            this.contextEnablePassword.CheckOnClick = true;
            this.contextEnablePassword.Name = "contextEnablePassword";
            this.contextEnablePassword.Size = new System.Drawing.Size(199, 22);
            this.contextEnablePassword.Text = "Enable Password";
            this.contextEnablePassword.CheckedChanged += new System.EventHandler(this.toolStripMenuItem1_CheckedChanged_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // contextMenuExit
            // 
            this.contextMenuExit.Name = "contextMenuExit";
            this.contextMenuExit.Size = new System.Drawing.Size(199, 22);
            this.contextMenuExit.Text = "Exit";
            this.contextMenuExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 209);
            this.Enabled = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Phonelink";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExit;
        private System.Windows.Forms.ToolStripMenuItem contextUpdateCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextEnablePassword;
    }
}


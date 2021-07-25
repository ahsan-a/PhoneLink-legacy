
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
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ContextMenuAppname = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextEnablePassword = new System.Windows.Forms.ToolStripMenuItem();
			this.FormTitle = new System.Windows.Forms.Label();
			this.EnablePassword = new System.Windows.Forms.CheckBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.AutoUpdateCheck = new System.Windows.Forms.CheckBox();
			this.Checkboxes = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Port = new System.Windows.Forms.TextBox();
			this.PortLabel = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.PasswordInput = new System.Windows.Forms.TextBox();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.ChangeSaveLocation = new System.Windows.Forms.Button();
			this.SaveLocationLabel = new System.Windows.Forms.Label();
			this.SaveSettingsButton = new System.Windows.Forms.Button();
			this.contextMenu.SuspendLayout();
			this.Checkboxes.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// trayIcon
			// 
			this.trayIcon.ContextMenuStrip = this.contextMenu;
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "PhoneLink";
			this.trayIcon.Visible = true;
			this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
			// 
			// contextMenu
			// 
			this.contextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
			this.contextMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuAppname,
            this.toolStripSeparator1,
            this.openSettingsToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.contextMenu.Size = new System.Drawing.Size(174, 104);
			// 
			// ContextMenuAppname
			// 
			this.ContextMenuAppname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ContextMenuAppname.Enabled = false;
			this.ContextMenuAppname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ContextMenuAppname.ForeColor = System.Drawing.Color.White;
			this.ContextMenuAppname.Image = ((System.Drawing.Image)(resources.GetObject("ContextMenuAppname.Image")));
			this.ContextMenuAppname.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ContextMenuAppname.Name = "ContextMenuAppname";
			this.ContextMenuAppname.Padding = new System.Windows.Forms.Padding(1);
			this.ContextMenuAppname.Size = new System.Drawing.Size(175, 22);
			this.ContextMenuAppname.Text = "Phonelink";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
			// 
			// openSettingsToolStripMenuItem
			// 
			this.openSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
			this.openSettingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.openSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
			this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
			this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.openSettingsToolStripMenuItem.Text = "Open Settings";
			this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.OpenSettings_Click);
			// 
			// checkForUpdatesToolStripMenuItem
			// 
			this.checkForUpdatesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
			this.checkForUpdatesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
			this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
			this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
			this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
			this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// contextEnablePassword
			// 
			this.contextEnablePassword.Name = "contextEnablePassword";
			this.contextEnablePassword.Size = new System.Drawing.Size(32, 19);
			// 
			// FormTitle
			// 
			this.FormTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.FormTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormTitle.ForeColor = System.Drawing.Color.White;
			this.FormTitle.Location = new System.Drawing.Point(0, 0);
			this.FormTitle.Name = "FormTitle";
			this.FormTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.FormTitle.Size = new System.Drawing.Size(547, 59);
			this.FormTitle.TabIndex = 1;
			this.FormTitle.Text = "Phonelink";
			this.FormTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// EnablePassword
			// 
			this.EnablePassword.AutoSize = true;
			this.EnablePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EnablePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
			this.EnablePassword.Location = new System.Drawing.Point(0, 0);
			this.EnablePassword.Name = "EnablePassword";
			this.EnablePassword.Size = new System.Drawing.Size(142, 24);
			this.EnablePassword.TabIndex = 4;
			this.EnablePassword.Text = "Enable Password";
			this.EnablePassword.UseVisualStyleBackColor = true;
			// 
			// AutoUpdateCheck
			// 
			this.AutoUpdateCheck.AutoSize = true;
			this.AutoUpdateCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AutoUpdateCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
			this.AutoUpdateCheck.Location = new System.Drawing.Point(0, 20);
			this.AutoUpdateCheck.Name = "AutoUpdateCheck";
			this.AutoUpdateCheck.Size = new System.Drawing.Size(160, 24);
			this.AutoUpdateCheck.TabIndex = 5;
			this.AutoUpdateCheck.Text = "Auto Update Check";
			this.AutoUpdateCheck.UseVisualStyleBackColor = true;
			// 
			// Checkboxes
			// 
			this.Checkboxes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Checkboxes.Controls.Add(this.AutoUpdateCheck);
			this.Checkboxes.Controls.Add(this.EnablePassword);
			this.Checkboxes.Location = new System.Drawing.Point(200, 62);
			this.Checkboxes.Name = "Checkboxes";
			this.Checkboxes.Size = new System.Drawing.Size(164, 44);
			this.Checkboxes.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.Port);
			this.panel1.Controls.Add(this.PortLabel);
			this.panel1.Location = new System.Drawing.Point(133, 128);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(281, 26);
			this.panel1.TabIndex = 7;
			// 
			// Port
			// 
			this.Port.Location = new System.Drawing.Point(88, 4);
			this.Port.MaxLength = 5;
			this.Port.Name = "Port";
			this.Port.Size = new System.Drawing.Size(190, 20);
			this.Port.TabIndex = 1;
			this.Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortKeypress);
			// 
			// PortLabel
			// 
			this.PortLabel.AutoSize = true;
			this.PortLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PortLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
			this.PortLabel.Location = new System.Drawing.Point(4, 4);
			this.PortLabel.Name = "PortLabel";
			this.PortLabel.Size = new System.Drawing.Size(37, 20);
			this.PortLabel.TabIndex = 0;
			this.PortLabel.Text = "Port";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.PasswordInput);
			this.panel2.Controls.Add(this.PasswordLabel);
			this.panel2.Location = new System.Drawing.Point(133, 160);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(281, 26);
			this.panel2.TabIndex = 8;
			// 
			// PasswordInput
			// 
			this.PasswordInput.Location = new System.Drawing.Point(88, 4);
			this.PasswordInput.Name = "PasswordInput";
			this.PasswordInput.Size = new System.Drawing.Size(190, 20);
			this.PasswordInput.TabIndex = 1;
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.AutoSize = true;
			this.PasswordLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
			this.PasswordLabel.Location = new System.Drawing.Point(3, 1);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(73, 20);
			this.PasswordLabel.TabIndex = 0;
			this.PasswordLabel.Text = "Password";
			// 
			// ChangeSaveLocation
			// 
			this.ChangeSaveLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
			this.ChangeSaveLocation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
			this.ChangeSaveLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChangeSaveLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ChangeSaveLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
			this.ChangeSaveLocation.Location = new System.Drawing.Point(182, 250);
			this.ChangeSaveLocation.Name = "ChangeSaveLocation";
			this.ChangeSaveLocation.Size = new System.Drawing.Size(183, 30);
			this.ChangeSaveLocation.TabIndex = 9;
			this.ChangeSaveLocation.TabStop = false;
			this.ChangeSaveLocation.Text = "Change Save File Location";
			this.ChangeSaveLocation.UseVisualStyleBackColor = false;
			this.ChangeSaveLocation.Click += new System.EventHandler(this.ChangeSaveLocation_Click);
			// 
			// SaveLocationLabel
			// 
			this.SaveLocationLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveLocationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
			this.SaveLocationLabel.Location = new System.Drawing.Point(6, 189);
			this.SaveLocationLabel.Name = "SaveLocationLabel";
			this.SaveLocationLabel.Size = new System.Drawing.Size(534, 55);
			this.SaveLocationLabel.TabIndex = 11;
			this.SaveLocationLabel.Text = "Save File Location";
			this.SaveLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SaveSettingsButton
			// 
			this.SaveSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(208)))));
			this.SaveSettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
			this.SaveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveSettingsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
			this.SaveSettingsButton.Location = new System.Drawing.Point(182, 286);
			this.SaveSettingsButton.Name = "SaveSettingsButton";
			this.SaveSettingsButton.Size = new System.Drawing.Size(183, 30);
			this.SaveSettingsButton.TabIndex = 12;
			this.SaveSettingsButton.TabStop = false;
			this.SaveSettingsButton.Text = "Save Settings";
			this.SaveSettingsButton.UseVisualStyleBackColor = false;
			this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(547, 343);
			this.Controls.Add(this.SaveSettingsButton);
			this.Controls.Add(this.SaveLocationLabel);
			this.Controls.Add(this.ChangeSaveLocation);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Checkboxes);
			this.Controls.Add(this.FormTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Phonelink";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.contextMenu.ResumeLayout(false);
			this.Checkboxes.ResumeLayout(false);
			this.Checkboxes.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ToolStripMenuItem contextEnablePassword;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextMenuAppname;
		private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Label FormTitle;
		private System.Windows.Forms.CheckBox EnablePassword;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.CheckBox AutoUpdateCheck;
		private System.Windows.Forms.Panel Checkboxes;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox Port;
		private System.Windows.Forms.Label PortLabel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox PasswordInput;
		private System.Windows.Forms.Label PasswordLabel;
		private System.Windows.Forms.Button ChangeSaveLocation;
		private System.Windows.Forms.Label SaveLocationLabel;
		private System.Windows.Forms.Button SaveSettingsButton;
	}
}


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
            this.OpenSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextUpdateCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.contextEnablePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SubmitNewSettings = new System.Windows.Forms.Button();
            this.EditSaveFileLocation = new System.Windows.Forms.Button();
            this.EnablePasswordBox = new System.Windows.Forms.CheckBox();
            this.UpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PortInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.currentFilelocation = new System.Windows.Forms.Label();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "PhoneLink";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenSettings,
            this.toolStripSeparator2,
            this.contextUpdateCheck,
            this.contextEnablePassword,
            this.toolStripSeparator1,
            this.contextMenuExit});
            this.trayMenu.Name = "contextMenuStrip1";
            this.trayMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.trayMenu.Size = new System.Drawing.Size(200, 104);
            // 
            // OpenSettings
            // 
            this.OpenSettings.Name = "OpenSettings";
            this.OpenSettings.Size = new System.Drawing.Size(199, 22);
            this.OpenSettings.Text = "Open Settings";
            this.OpenSettings.Click += new System.EventHandler(this.OpenSettings_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
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
            // title
            // 
            this.title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.title.Size = new System.Drawing.Size(432, 262);
            this.title.TabIndex = 6;
            this.title.Text = "PhoneLink Settings";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(432, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Some changes will be applied on app restart. Sorry about this UI.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SubmitNewSettings
            // 
            this.SubmitNewSettings.Location = new System.Drawing.Point(181, 214);
            this.SubmitNewSettings.Name = "SubmitNewSettings";
            this.SubmitNewSettings.Size = new System.Drawing.Size(75, 23);
            this.SubmitNewSettings.TabIndex = 5;
            this.SubmitNewSettings.Text = "Submit";
            this.SubmitNewSettings.UseVisualStyleBackColor = true;
            this.SubmitNewSettings.Click += new System.EventHandler(this.SubmitNewSettings_Click);
            // 
            // EditSaveFileLocation
            // 
            this.EditSaveFileLocation.Location = new System.Drawing.Point(148, 166);
            this.EditSaveFileLocation.Name = "EditSaveFileLocation";
            this.EditSaveFileLocation.Size = new System.Drawing.Size(141, 23);
            this.EditSaveFileLocation.TabIndex = 4;
            this.EditSaveFileLocation.Text = "Edit Save File Location";
            this.EditSaveFileLocation.UseVisualStyleBackColor = true;
            this.EditSaveFileLocation.Click += new System.EventHandler(this.EditSaveFileLocation_Click);
            // 
            // EnablePasswordBox
            // 
            this.EnablePasswordBox.AutoSize = true;
            this.EnablePasswordBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnablePasswordBox.Location = new System.Drawing.Point(156, 50);
            this.EnablePasswordBox.Name = "EnablePasswordBox";
            this.EnablePasswordBox.Size = new System.Drawing.Size(129, 21);
            this.EnablePasswordBox.TabIndex = 0;
            this.EnablePasswordBox.Text = "Enable Password";
            this.EnablePasswordBox.UseVisualStyleBackColor = true;
            // 
            // UpdateCheckBox
            // 
            this.UpdateCheckBox.AutoSize = true;
            this.UpdateCheckBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateCheckBox.Location = new System.Drawing.Point(152, 75);
            this.UpdateCheckBox.Name = "UpdateCheckBox";
            this.UpdateCheckBox.Size = new System.Drawing.Size(138, 21);
            this.UpdateCheckBox.TabIndex = 1;
            this.UpdateCheckBox.Text = "Check for Updates";
            this.UpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(106, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Edit Port";
            // 
            // PortInput
            // 
            this.PortInput.Location = new System.Drawing.Point(203, 107);
            this.PortInput.MaxLength = 6;
            this.PortInput.Name = "PortInput";
            this.PortInput.Size = new System.Drawing.Size(141, 20);
            this.PortInput.TabIndex = 2;
            this.PortInput.WordWrap = false;
            this.PortInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(67, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Edit Password";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(203, 133);
            this.PasswordInput.MaxLength = 6;
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(141, 20);
            this.PasswordInput.TabIndex = 3;
            this.PasswordInput.WordWrap = false;
            // 
            // currentFilelocation
            // 
            this.currentFilelocation.AutoSize = true;
            this.currentFilelocation.Location = new System.Drawing.Point(12, 193);
            this.currentFilelocation.Name = "currentFilelocation";
            this.currentFilelocation.Size = new System.Drawing.Size(0, 13);
            this.currentFilelocation.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 262);
            this.Controls.Add(this.currentFilelocation);
            this.Controls.Add(this.UpdateCheckBox);
            this.Controls.Add(this.EnablePasswordBox);
            this.Controls.Add(this.EditSaveFileLocation);
            this.Controls.Add(this.SubmitNewSettings);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PortInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Phonelink";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExit;
        private System.Windows.Forms.ToolStripMenuItem contextUpdateCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextEnablePassword;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SubmitNewSettings;
        private System.Windows.Forms.Button EditSaveFileLocation;
        private System.Windows.Forms.CheckBox EnablePasswordBox;
        private System.Windows.Forms.CheckBox UpdateCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PortInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.ToolStripMenuItem OpenSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label currentFilelocation;
    }
}



using Discord_Raid_Tool_Final.Properties;

namespace Discord_Raid_Tool_Final
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
            this.components = new System.ComponentModel.Container();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.NavigatePanel = new System.Windows.Forms.Panel();
            this.CreditsButton = new System.Windows.Forms.Button();
            this.OtherButton = new System.Windows.Forms.Button();
            this.VoiceButton = new System.Windows.Forms.Button();
            this.UsersButton = new System.Windows.Forms.Button();
            this.GuildsButton = new System.Windows.Forms.Button();
            this.WebhooksButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelPanel = new System.Windows.Forms.Panel();
            this.MainLabel = new System.Windows.Forms.Label();
            this.TimerRGB = new System.Windows.Forms.Timer(this.components);
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.ButtonsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.LabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ButtonsPanel.Controls.Add(this.NavigatePanel);
            this.ButtonsPanel.Controls.Add(this.CreditsButton);
            this.ButtonsPanel.Controls.Add(this.OtherButton);
            this.ButtonsPanel.Controls.Add(this.VoiceButton);
            this.ButtonsPanel.Controls.Add(this.UsersButton);
            this.ButtonsPanel.Controls.Add(this.GuildsButton);
            this.ButtonsPanel.Controls.Add(this.WebhooksButton);
            this.ButtonsPanel.Controls.Add(this.panel1);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(176, 558);
            this.ButtonsPanel.TabIndex = 0;
            // 
            // NavigatePanel
            // 
            this.NavigatePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.NavigatePanel.Location = new System.Drawing.Point(-1, 151);
            this.NavigatePanel.Name = "NavigatePanel";
            this.NavigatePanel.Size = new System.Drawing.Size(3, 68);
            this.NavigatePanel.TabIndex = 14;
            // 
            // CreditsButton
            // 
            this.CreditsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.CreditsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreditsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CreditsButton.FlatAppearance.BorderSize = 0;
            this.CreditsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CreditsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsButton.ForeColor = System.Drawing.Color.Red;
            this.CreditsButton.Location = new System.Drawing.Point(0, 490);
            this.CreditsButton.Name = "CreditsButton";
            this.CreditsButton.Size = new System.Drawing.Size(176, 68);
            this.CreditsButton.TabIndex = 13;
            this.CreditsButton.Text = "Credits";
            this.CreditsButton.UseVisualStyleBackColor = false;
            this.CreditsButton.Click += new System.EventHandler(this.CreditsButton_Click);
            // 
            // OtherButton
            // 
            this.OtherButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.OtherButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OtherButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.OtherButton.FlatAppearance.BorderSize = 0;
            this.OtherButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.OtherButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.OtherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OtherButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherButton.ForeColor = System.Drawing.Color.Red;
            this.OtherButton.Location = new System.Drawing.Point(0, 422);
            this.OtherButton.Name = "OtherButton";
            this.OtherButton.Size = new System.Drawing.Size(176, 68);
            this.OtherButton.TabIndex = 12;
            this.OtherButton.Text = "Other";
            this.OtherButton.UseVisualStyleBackColor = false;
            this.OtherButton.Click += new System.EventHandler(this.OtherButton_Click);
            // 
            // VoiceButton
            // 
            this.VoiceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.VoiceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.VoiceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.VoiceButton.FlatAppearance.BorderSize = 0;
            this.VoiceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VoiceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VoiceButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoiceButton.ForeColor = System.Drawing.Color.Red;
            this.VoiceButton.Location = new System.Drawing.Point(0, 354);
            this.VoiceButton.Name = "VoiceButton";
            this.VoiceButton.Size = new System.Drawing.Size(176, 68);
            this.VoiceButton.TabIndex = 11;
            this.VoiceButton.Text = "Voice";
            this.VoiceButton.UseVisualStyleBackColor = false;
            this.VoiceButton.Click += new System.EventHandler(this.VoiceButton_Click);
            // 
            // UsersButton
            // 
            this.UsersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.UsersButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UsersButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.UsersButton.FlatAppearance.BorderSize = 0;
            this.UsersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.UsersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.UsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsersButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersButton.ForeColor = System.Drawing.Color.Red;
            this.UsersButton.Location = new System.Drawing.Point(0, 286);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(176, 68);
            this.UsersButton.TabIndex = 10;
            this.UsersButton.Text = "Users";
            this.UsersButton.UseVisualStyleBackColor = false;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // GuildsButton
            // 
            this.GuildsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.GuildsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.GuildsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.GuildsButton.FlatAppearance.BorderSize = 0;
            this.GuildsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.GuildsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.GuildsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuildsButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuildsButton.ForeColor = System.Drawing.Color.Red;
            this.GuildsButton.Location = new System.Drawing.Point(0, 218);
            this.GuildsButton.Name = "GuildsButton";
            this.GuildsButton.Size = new System.Drawing.Size(176, 68);
            this.GuildsButton.TabIndex = 9;
            this.GuildsButton.Text = "Guilds";
            this.GuildsButton.UseVisualStyleBackColor = false;
            this.GuildsButton.Click += new System.EventHandler(this.GuildsButton_Click);
            // 
            // WebhooksButton
            // 
            this.WebhooksButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.WebhooksButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.WebhooksButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.WebhooksButton.FlatAppearance.BorderSize = 0;
            this.WebhooksButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.WebhooksButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.WebhooksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WebhooksButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebhooksButton.ForeColor = System.Drawing.Color.Red;
            this.WebhooksButton.Location = new System.Drawing.Point(0, 150);
            this.WebhooksButton.Name = "WebhooksButton";
            this.WebhooksButton.Size = new System.Drawing.Size(176, 68);
            this.WebhooksButton.TabIndex = 8;
            this.WebhooksButton.Text = "Webhooks";
            this.WebhooksButton.UseVisualStyleBackColor = false;
            this.WebhooksButton.Click += new System.EventHandler(this.WebhooksButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 150);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Discord_Raid_Tool_Final.Properties.Resources.photo_2015_07_31_07_43_54;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LabelPanel
            // 
            this.LabelPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.LabelPanel.Controls.Add(this.MainLabel);
            this.LabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelPanel.Location = new System.Drawing.Point(176, 0);
            this.LabelPanel.Name = "LabelPanel";
            this.LabelPanel.Size = new System.Drawing.Size(731, 100);
            this.LabelPanel.TabIndex = 1;
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Font = new System.Drawing.Font("Nirmala UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainLabel.ForeColor = System.Drawing.Color.White;
            this.MainLabel.Location = new System.Drawing.Point(76, 18);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(579, 65);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "MisgavRaidYourMom Tool\n";
            // 
            // TimerRGB
            // 
            this.TimerRGB.Enabled = true;
            this.TimerRGB.Interval = 5;
            this.TimerRGB.Tick += new System.EventHandler(this.TimerRGB_Tick);
            // 
            // PanelContainer
            // 
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(176, 100);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(731, 458);
            this.PanelContainer.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(907, 558);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.LabelPanel);
            this.Controls.Add(this.ButtonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ButtonsPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.LabelPanel.ResumeLayout(false);
            this.LabelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Panel LabelPanel;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Timer TimerRGB;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Button OtherButton;
        private System.Windows.Forms.Button VoiceButton;
        private System.Windows.Forms.Button UsersButton;
        private System.Windows.Forms.Button GuildsButton;
        private System.Windows.Forms.Button WebhooksButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CreditsButton;
        private System.Windows.Forms.Panel NavigatePanel;
    }
}
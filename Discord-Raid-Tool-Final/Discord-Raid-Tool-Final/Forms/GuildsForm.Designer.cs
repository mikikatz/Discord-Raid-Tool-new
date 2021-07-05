
namespace Discord_Raid_Tool_Final.Forms
{
    partial class GuildsForm
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
            this.BullyOwnerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GuildIdTextBox = new System.Windows.Forms.TextBox();
            this.ChannelIdTextBox = new System.Windows.Forms.TextBox();
            this.BanEveryoneButton = new System.Windows.Forms.Button();
            this.DeleteRolesButton = new System.Windows.Forms.Button();
            this.SpamRolesButton = new System.Windows.Forms.Button();
            this.NukeGuildButton = new System.Windows.Forms.Button();
            this.TagEveryoneButton = new System.Windows.Forms.Button();
            this.NoUsageButton = new System.Windows.Forms.Button();
            this.MessageEveryoneButton = new System.Windows.Forms.Button();
            this.SpamTagUserButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.GuildInviteCodeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.JoinButton = new System.Windows.Forms.Button();
            this.LeaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BullyOwnerButton
            // 
            this.BullyOwnerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BullyOwnerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BullyOwnerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BullyOwnerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BullyOwnerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BullyOwnerButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BullyOwnerButton.ForeColor = System.Drawing.Color.White;
            this.BullyOwnerButton.Location = new System.Drawing.Point(73, 324);
            this.BullyOwnerButton.Name = "BullyOwnerButton";
            this.BullyOwnerButton.Size = new System.Drawing.Size(191, 58);
            this.BullyOwnerButton.TabIndex = 8;
            this.BullyOwnerButton.Text = "Bully owner";
            this.BullyOwnerButton.UseVisualStyleBackColor = false;
            this.BullyOwnerButton.Click += new System.EventHandler(this.BullyOwnerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Guild Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(126, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Channel Id:";
            // 
            // GuildIdTextBox
            // 
            this.GuildIdTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.GuildIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GuildIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.GuildIdTextBox.ForeColor = System.Drawing.Color.White;
            this.GuildIdTextBox.Location = new System.Drawing.Point(128, 28);
            this.GuildIdTextBox.Name = "GuildIdTextBox";
            this.GuildIdTextBox.Size = new System.Drawing.Size(477, 22);
            this.GuildIdTextBox.TabIndex = 11;
            this.GuildIdTextBox.TextChanged += new System.EventHandler(this.GuildIdTextBox_TextChanged);
            // 
            // ChannelIdTextBox
            // 
            this.ChannelIdTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ChannelIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChannelIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ChannelIdTextBox.ForeColor = System.Drawing.Color.White;
            this.ChannelIdTextBox.Location = new System.Drawing.Point(128, 131);
            this.ChannelIdTextBox.Name = "ChannelIdTextBox";
            this.ChannelIdTextBox.Size = new System.Drawing.Size(477, 22);
            this.ChannelIdTextBox.TabIndex = 12;
            this.ChannelIdTextBox.TextChanged += new System.EventHandler(this.ChannelIdTextBox_TextChanged);
            // 
            // BanEveryoneButton
            // 
            this.BanEveryoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BanEveryoneButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BanEveryoneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BanEveryoneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BanEveryoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BanEveryoneButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BanEveryoneButton.ForeColor = System.Drawing.Color.White;
            this.BanEveryoneButton.Location = new System.Drawing.Point(467, 324);
            this.BanEveryoneButton.Name = "BanEveryoneButton";
            this.BanEveryoneButton.Size = new System.Drawing.Size(191, 58);
            this.BanEveryoneButton.TabIndex = 13;
            this.BanEveryoneButton.Text = "Ban everyone";
            this.BanEveryoneButton.UseVisualStyleBackColor = false;
            this.BanEveryoneButton.Click += new System.EventHandler(this.BanEveryoneButton_Click);
            // 
            // DeleteRolesButton
            // 
            this.DeleteRolesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.DeleteRolesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DeleteRolesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DeleteRolesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DeleteRolesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteRolesButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteRolesButton.ForeColor = System.Drawing.Color.White;
            this.DeleteRolesButton.Location = new System.Drawing.Point(73, 388);
            this.DeleteRolesButton.Name = "DeleteRolesButton";
            this.DeleteRolesButton.Size = new System.Drawing.Size(191, 58);
            this.DeleteRolesButton.TabIndex = 14;
            this.DeleteRolesButton.Text = "Delete roles";
            this.DeleteRolesButton.UseVisualStyleBackColor = false;
            this.DeleteRolesButton.Click += new System.EventHandler(this.DeleteRolesButton_Click);
            // 
            // SpamRolesButton
            // 
            this.SpamRolesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.SpamRolesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SpamRolesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SpamRolesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SpamRolesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpamRolesButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpamRolesButton.ForeColor = System.Drawing.Color.White;
            this.SpamRolesButton.Location = new System.Drawing.Point(270, 388);
            this.SpamRolesButton.Name = "SpamRolesButton";
            this.SpamRolesButton.Size = new System.Drawing.Size(191, 58);
            this.SpamRolesButton.TabIndex = 15;
            this.SpamRolesButton.Text = "Spam roles";
            this.SpamRolesButton.UseVisualStyleBackColor = false;
            this.SpamRolesButton.Click += new System.EventHandler(this.SpamRolesButton_Click);
            // 
            // NukeGuildButton
            // 
            this.NukeGuildButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.NukeGuildButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NukeGuildButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NukeGuildButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NukeGuildButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NukeGuildButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NukeGuildButton.ForeColor = System.Drawing.Color.White;
            this.NukeGuildButton.Location = new System.Drawing.Point(73, 260);
            this.NukeGuildButton.Name = "NukeGuildButton";
            this.NukeGuildButton.Size = new System.Drawing.Size(191, 58);
            this.NukeGuildButton.TabIndex = 16;
            this.NukeGuildButton.Text = "Nuke guild";
            this.NukeGuildButton.UseVisualStyleBackColor = false;
            this.NukeGuildButton.Click += new System.EventHandler(this.NukeGuildButton_Click);
            // 
            // TagEveryoneButton
            // 
            this.TagEveryoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.TagEveryoneButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TagEveryoneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TagEveryoneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TagEveryoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TagEveryoneButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TagEveryoneButton.ForeColor = System.Drawing.Color.White;
            this.TagEveryoneButton.Location = new System.Drawing.Point(270, 260);
            this.TagEveryoneButton.Name = "TagEveryoneButton";
            this.TagEveryoneButton.Size = new System.Drawing.Size(191, 58);
            this.TagEveryoneButton.TabIndex = 17;
            this.TagEveryoneButton.Text = "Tag everyone non stop";
            this.TagEveryoneButton.UseVisualStyleBackColor = false;
            this.TagEveryoneButton.Click += new System.EventHandler(this.TagEveryoneButton_Click);
            // 
            // NoUsageButton
            // 
            this.NoUsageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.NoUsageButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NoUsageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NoUsageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NoUsageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoUsageButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoUsageButton.ForeColor = System.Drawing.Color.White;
            this.NoUsageButton.Location = new System.Drawing.Point(467, 260);
            this.NoUsageButton.Name = "NoUsageButton";
            this.NoUsageButton.Size = new System.Drawing.Size(191, 58);
            this.NoUsageButton.TabIndex = 18;
            this.NoUsageButton.Text = "No usage :(";
            this.NoUsageButton.UseVisualStyleBackColor = false;
            this.NoUsageButton.Click += new System.EventHandler(this.NoUsageButton_Click);
            // 
            // MessageEveryoneButton
            // 
            this.MessageEveryoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.MessageEveryoneButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.MessageEveryoneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.MessageEveryoneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.MessageEveryoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MessageEveryoneButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageEveryoneButton.ForeColor = System.Drawing.Color.White;
            this.MessageEveryoneButton.Location = new System.Drawing.Point(270, 324);
            this.MessageEveryoneButton.Name = "MessageEveryoneButton";
            this.MessageEveryoneButton.Size = new System.Drawing.Size(191, 58);
            this.MessageEveryoneButton.TabIndex = 19;
            this.MessageEveryoneButton.Text = "Send message to everyone in guild";
            this.MessageEveryoneButton.UseVisualStyleBackColor = false;
            this.MessageEveryoneButton.Click += new System.EventHandler(this.MessageEveryoneButton_Click);
            // 
            // SpamTagUserButton
            // 
            this.SpamTagUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.SpamTagUserButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SpamTagUserButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SpamTagUserButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SpamTagUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpamTagUserButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpamTagUserButton.ForeColor = System.Drawing.Color.White;
            this.SpamTagUserButton.Location = new System.Drawing.Point(467, 388);
            this.SpamTagUserButton.Name = "SpamTagUserButton";
            this.SpamTagUserButton.Size = new System.Drawing.Size(191, 58);
            this.SpamTagUserButton.TabIndex = 20;
            this.SpamTagUserButton.Text = "Spam message";
            this.SpamTagUserButton.UseVisualStyleBackColor = false;
            this.SpamTagUserButton.Click += new System.EventHandler(this.SpamTagUserButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(126, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Message:";
            // 
            // GuildInviteCodeTextBox
            // 
            this.GuildInviteCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.GuildInviteCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GuildInviteCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.GuildInviteCodeTextBox.ForeColor = System.Drawing.Color.White;
            this.GuildInviteCodeTextBox.Location = new System.Drawing.Point(129, 80);
            this.GuildInviteCodeTextBox.Name = "GuildInviteCodeTextBox";
            this.GuildInviteCodeTextBox.Size = new System.Drawing.Size(476, 22);
            this.GuildInviteCodeTextBox.TabIndex = 24;
            this.GuildInviteCodeTextBox.TextChanged += new System.EventHandler(this.GuildInviteCodeTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(125, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Guild Invite:";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.MessageTextBox.ForeColor = System.Drawing.Color.White;
            this.MessageTextBox.Location = new System.Drawing.Point(128, 182);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(477, 22);
            this.MessageTextBox.TabIndex = 25;
            this.MessageTextBox.TextChanged += new System.EventHandler(this.MessageTextBox_TextChanged);
            // 
            // JoinButton
            // 
            this.JoinButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.JoinButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.JoinButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.JoinButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.JoinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinButton.ForeColor = System.Drawing.Color.White;
            this.JoinButton.Location = new System.Drawing.Point(611, 80);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(81, 22);
            this.JoinButton.TabIndex = 26;
            this.JoinButton.Text = "Join";
            this.JoinButton.UseVisualStyleBackColor = false;
            this.JoinButton.Click += new System.EventHandler(this.JoinButton_Click);
            // 
            // LeaveButton
            // 
            this.LeaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.LeaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LeaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LeaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LeaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeaveButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaveButton.ForeColor = System.Drawing.Color.White;
            this.LeaveButton.Location = new System.Drawing.Point(611, 28);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(81, 22);
            this.LeaveButton.TabIndex = 27;
            this.LeaveButton.Text = "Leave";
            this.LeaveButton.UseVisualStyleBackColor = false;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
            // 
            // GuildsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(731, 458);
            this.Controls.Add(this.LeaveButton);
            this.Controls.Add(this.JoinButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.GuildInviteCodeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SpamTagUserButton);
            this.Controls.Add(this.MessageEveryoneButton);
            this.Controls.Add(this.NoUsageButton);
            this.Controls.Add(this.TagEveryoneButton);
            this.Controls.Add(this.NukeGuildButton);
            this.Controls.Add(this.SpamRolesButton);
            this.Controls.Add(this.DeleteRolesButton);
            this.Controls.Add(this.BanEveryoneButton);
            this.Controls.Add(this.ChannelIdTextBox);
            this.Controls.Add(this.GuildIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BullyOwnerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GuildsForm";
            this.Text = "GuildsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BullyOwnerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GuildIdTextBox;
        private System.Windows.Forms.TextBox ChannelIdTextBox;
        private System.Windows.Forms.Button BanEveryoneButton;
        private System.Windows.Forms.Button DeleteRolesButton;
        private System.Windows.Forms.Button SpamRolesButton;
        private System.Windows.Forms.Button NukeGuildButton;
        private System.Windows.Forms.Button TagEveryoneButton;
        private System.Windows.Forms.Button NoUsageButton;
        private System.Windows.Forms.Button MessageEveryoneButton;
        private System.Windows.Forms.Button SpamTagUserButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GuildInviteCodeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button JoinButton;
        private System.Windows.Forms.Button LeaveButton;
    }
}
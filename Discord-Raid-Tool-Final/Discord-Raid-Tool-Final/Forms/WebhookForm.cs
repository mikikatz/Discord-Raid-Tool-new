using Discord;
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QvoidDiscord.Discord;

namespace Discord_Raid_Tool_Final.Forms
{
    public partial class WebhookForm : Form
    {
        private DiscordSocketClient client = new DiscordSocketClient();
        private EmbedMaker embed = new EmbedMaker();
        private EmbedAuthor embedAuthor = new EmbedAuthor();
        private EmbedFooter embedFooter = new EmbedFooter();
        private Webhook Webhook = null;
        private DiscordWebhookProfile webhookProfile = new DiscordWebhookProfile();

        public WebhookForm()
        {
            InitializeComponent();
        }

        private void WebhookForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("If you would like to send embed message than fill the information, if you want to spam without embed then just fill the messsage content and leave the color as it is.");
            try { client = Settings.DiscordClients[0]; }
            catch { this.Enabled = false; }
        }

        private void ColorPictureBox_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() == DialogResult.OK)
                ColorPictureBox.BackColor = colorPicker.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool embedBool = false;

            if (ColorPictureBox.BackColor == Color.WhiteSmoke)
                embedBool = false;
            else
                embedBool = true;

            new Thread(() =>
            {
                if (embedBool)
                {
                    if (FooterTimestampCheck.Checked)
                        embed.Timestamp = DateTime.UtcNow;

                    embed.ThumbnailUrl = ThumbnailText.Text;
                    embed.ImageUrl = ImageText.Text;
                    embed.Title = EmbedTitle.Text;
                    embed.Description = ContentText.Text;
                    embed.Author = embedAuthor;
                    embed.Footer = embedFooter;
                    embed.Color = ColorPictureBox.BackColor;
                    for (int i = 0; i < 2; ++i)
                    {
                        new Thread(() =>
                        {
                            while (true)
                                client.SendWebhookMessage(Webhook.Id, Webhook.Token, MessageContentTextBox.Text, embed, webhookProfile);
                        }).Start();
                    }
                }
                else
                {
                    for (int i = 0; i < 2; ++i)
                    {
                        new Thread(() =>
                        {
                            while (true)
                                client.SendWebhookMessage(Webhook.Id, Webhook.Token, MessageContentTextBox.Text);
                        }).Start();
                    }
                }
            }).Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Contains("webhooks/"))
                {
                    string[] splits = textBox1.Text.Substring(textBox1.Text.IndexOf("webhooks/")).Split('/');
                    //HttpWebRequest

                    //webhook = client.GetWebhook(ulong.Parse(splits[1]), splits[2]);
                    Webhook = new Webhook(textBox1.Text);
                    MessageBox.Show("Webhook loaded!");
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = "";
            IO.InputBox("Enter the new name (Leave blank to stay the same): ", "Promt", ref value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Webhook.URL) || String.IsNullOrWhiteSpace(Webhook.URL))
            {
                MessageBox.Show("Not a vaild webhook");
                return;
            }

            try
            {
                Webhook.Delete();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddFieldBtn_Click(object sender, EventArgs e)
        {
            embed.AddField(FieldName.Text, FieldValue.Text, fieldInLineCheck.Checked);
        }

        private void AuthorName_TextChanged(object sender, EventArgs e)
        {
            embedAuthor.Name = AuthorName.Text;
        }

        private void AuthorLink_TextChanged(object sender, EventArgs e)
        {
            embedAuthor.Url = AuthorLink.Text;
        }

        private void AuthorIconURL_TextChanged(object sender, EventArgs e)
        {
            embedAuthor.IconUrl = AuthorIconURL.Text;
        }

        private void ContentText_TextChanged(object sender, EventArgs e)
        {
            embed.Description = ContentText.Text;
        }

        private void EmbedTitle_TextChanged(object sender, EventArgs e)
        {
            embed.Title = EmbedTitle.Text;
        }

        private void EmbedName_TextChanged(object sender, EventArgs e)
        {
            webhookProfile = new DiscordWebhookProfile { Username = EmbedName.Text };
        }

        private void FooterText_TextChanged(object sender, EventArgs e)
        {
            embedFooter.Text = FooterText.Text;
        }

        private void FooterIconUrl_TextChanged(object sender, EventArgs e)
        {
            embedFooter.IconUrl = FooterIconUrl.Text;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord.Gateway;
using Discord_Raid_Tool_Final.Forms;
using static Discord_Raid_Tool_Final.TokensChecker;

namespace Discord_Raid_Tool_Final
{
    public partial class MainForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private GuildsForm guildsForm = new GuildsForm();
        private UsersForm usersForm = new UsersForm();
        private CreditsForm creditsForm = new CreditsForm();
        private VoiceForm voiceForm = new VoiceForm();
        private OtherForm otherForm = new OtherForm();
        private WebhookForm webhookForm = new WebhookForm();

        public MainForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

            Visuals.Movers movers = new Visuals.Movers(this);
            LabelPanel.MouseDown += movers.MouseDown;
            LabelPanel.MouseUp += movers.MouseUp;
            LabelPanel.MouseMove += movers.MouseMove;

            MainLabel.MouseDown += movers.MouseDown;
            MainLabel.MouseUp += movers.MouseUp;
            MainLabel.MouseMove += movers.MouseMove;

            pictureBox1.MouseDown += movers.MouseDown;
            pictureBox1.MouseUp += movers.MouseUp;
            pictureBox1.MouseMove += movers.MouseMove;

            this.guildsForm.TopLevel = false;
            this.PanelContainer.Controls.Add(guildsForm);

            this.usersForm.TopLevel = false;
            this.PanelContainer.Controls.Add(usersForm);

            this.voiceForm.TopLevel = false;
            this.PanelContainer.Controls.Add(voiceForm);

            this.webhookForm.TopLevel = false;
            this.PanelContainer.Controls.Add(webhookForm);

            this.otherForm.TopLevel = false;
            this.PanelContainer.Controls.Add(otherForm);

            this.creditsForm.TopLevel = false;
            this.PanelContainer.Controls.Add(creditsForm);

            HideForms(GuildsButton);
            guildsForm.Show();
        }

        private void HideForms(Button btn)
        {
            try
            {
                NavigatePanel.Top = btn.Top;
                creditsForm.Hide();
                guildsForm.Hide();
                usersForm.Hide();
                voiceForm.Hide();
                webhookForm.Hide();
                otherForm.Hide();
            }
            catch { }
        }

        private bool CheckForTokens()
        {
            if (Settings.Tokens.Count <= 0)
            {
                MessageBox.Show("No tokens were loaded.");
                return false;
            }

            return true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InputTokens inputTokensForm = new InputTokens();

            inputTokensForm.FormClosed += delegate
            {
                if (Settings.Tokens.Count == 0)
                {
                    SystemSounds.Hand.Play();
                    MainForm_Load(sender, e);
                }
                else
                {
                    inputTokensForm.Visible = false;
                    inputTokensForm.TopMost = false;

                    new Thread(() => { MessageBox.Show("Checking the tokens and connection into them, pls wait."); }).Start();
                    TokensList list = DiscordUtils.CheckTokens(Settings.Tokens);
                    Settings.Tokens = list.Working;

                    new Thread(() =>
                    {
                        foreach (var token in Settings.Tokens)
                        {
                            DiscordSocketClient client = new DiscordSocketClient();
                            client.Login(token);

                            Thread.Sleep(50);
                            Settings.DiscordClients.Add(client);
                        }
                    }).Start();

                    this.Show();
                }
            };
            inputTokensForm.TopMost = true;
            inputTokensForm.Show();

            Thread thread = new Thread(() =>
            {
                while (inputTokensForm.Visible)
                {
                    Thread.Sleep(10);

                    Point frm2Point = new Point((this.Location.X + this.Width) / 2, (this.Location.Y + this.Height) / 2);
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (frm2Point != inputTokensForm.Location)
                            inputTokensForm.Location = frm2Point;
                    });
                }
            });
            thread.Start();

            Thread thread2 = new Thread(() =>
            {
                HideForms(new Button());
                while (Program.thread.IsAlive)
                {
                    Thread.Sleep(100);

                    this.Invoke((MethodInvoker)delegate
                    {
                        UsersButton.Visible = false;
                        WebhooksButton.Visible = false;
                        GuildsButton.Visible = false;
                        OtherButton.Visible = false;
                        VoiceButton.Visible = false;
                        CreditsButton.Visible = false;
                    });
                }

                this.Invoke((MethodInvoker)delegate
                {
                    UsersButton.Visible = true;
                    WebhooksButton.Visible = true;
                    GuildsButton.Visible = true;
                    OtherButton.Visible = true;
                    VoiceButton.Visible = true;
                    CreditsButton.Visible = true;
                });
            });
            thread2.Start();
        }

        private void TimerRGB_Tick(object sender, EventArgs e)
        {
            Color color = Visuals.RGB.SpectrumColor();
            MainLabel.ForeColor = color;
            NavigatePanel.BackColor = color;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void WebhooksButton_Click(object sender, EventArgs e)
        {
            if (!CheckForTokens())
                return;

            HideForms(WebhooksButton);
            webhookForm.Show();
        }

        private void GuildsButton_Click(object sender, EventArgs e)
        {
            if (!CheckForTokens())
                return;

            HideForms(GuildsButton);
            guildsForm.Show();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            if (!CheckForTokens())
                return;

            HideForms(UsersButton);
            usersForm.Show();
        }

        private void VoiceButton_Click(object sender, EventArgs e)
        {
            if (!CheckForTokens())
                return;

            HideForms(VoiceButton);
            voiceForm.Show();
        }

        private void OtherButton_Click(object sender, EventArgs e)
        {
            if (!CheckForTokens())
                return;

            HideForms(OtherButton);
            otherForm.Show();
        }

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            if (!CheckForTokens())
                return;

            HideForms(CreditsButton);
            creditsForm.Show();
        }
    }
}
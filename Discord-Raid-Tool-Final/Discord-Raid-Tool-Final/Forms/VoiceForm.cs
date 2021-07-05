using Discord.Gateway;
using Discord.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord_Raid_Tool_Final.Forms
{
    public partial class VoiceForm : Form
    {
        private DiscordSocketClient client = new DiscordSocketClient();
        private bool Muted = false;
        private bool Deafened = false;
        private bool PlaySong = false;
        private bool Camera = false;
        private bool Livestream = false;
        private bool SpamConnectDisconnect = false;
        private bool Send = false;
        private bool PlayEarrape = false;

        public VoiceForm()
        {
            InitializeComponent();
        }

        private void VoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = Settings.DiscordClients[0];
                client.OnLoggedIn += Client_OnLoggedIn;
                client.OnJoinedVoiceChannel += Client_OnJoinedVoiceChannel;
                client.OnLeftVoiceChannel += Client_OnLeftVoiceChannel;

                if (!File.Exists("ffmpeg.exe") || !File.Exists("libsodium.dll") || !File.Exists("opus.dll"))
                {
                    var dialog = MessageBox.Show("You missing the voice binaries, without them this form won't work would you like to install them?");
                    if (dialog == DialogResult.OK)
                    {
                        new Thread(() => { MessageBox.Show("Installing, it might take a while, I will beep 4 times when the download is ended and you will be redirect into the form."); });
                        new WebClient().DownloadFile("https://anarchyteam.dev/voice_binaries.zip", "voice_binaries.zip");
                        ZipFile.ExtractToDirectory("voice_binaries.zip", $"{Application.StartupPath}\\");
                        foreach (var file in Directory.GetFiles("voice_binaries"))
                            File.Move(file, file.Split('\\')[1]);

                        Directory.Delete("voice_binaries");
                        Console.Beep(1200, 500);
                        Console.Beep(1000, 500);
                        Console.Beep(800, 500);
                        Console.Beep(600, 500);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = false;
            }
        }

        private void NukeGuildButton_Click(object sender, EventArgs e)
        {
            PlaySong = true;
            client.GetVoiceClient(ulong.Parse(GuildIdTextBox.Text)).Connect(ulong.Parse(ChannelIdTextBox.Text), new VoiceConnectionProperties() { Muted = Muted, Deafened = Deafened, Video = Camera });
        }

        private void Client_OnLeftVoiceChannel(DiscordSocketClient client, VoiceDisconnectEventArgs args)
        {
            client.GetVoiceClient(ulong.Parse(GuildIdTextBox.Text)).Connect(ulong.Parse(ChannelIdTextBox.Text), new VoiceConnectionProperties() { Muted = Muted, Deafened = Deafened, Video = Camera });
        }

        private void Client_OnJoinedVoiceChannel(DiscordSocketClient client, VoiceConnectEventArgs args)
        {
            if (Livestream)
                args.Client.Livestream.Start();

            if (SpamConnectDisconnect)
            {
                args.Client.Disconnect();
                Send = true;
            }

            if (PlaySong)
            {
                while (args.Client.State == MediaConnectionState.Ready)
                {
                    args.Client.Microphone.SetSpeakingState(DiscordSpeakingFlags.Soundshare);
                    args.Client.Microphone.CopyFrom(DiscordVoiceUtils.GetAudioStream(textBox1.Text));
                    PlaySong = false;
                    break;
                }
            }

            if (PlayEarrape)
            {
                while (args.Client.State == MediaConnectionState.Ready)
                {
                    args.Client.Microphone.SetSpeakingState(DiscordSpeakingFlags.Soundshare);
                    args.Client.Microphone.CopyFrom(DiscordVoiceUtils.GetAudioStream(textBox1.Text));
                    PlayEarrape = false;
                    break;
                }
            }
        }

        private void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            client.GetVoiceClient(ulong.Parse(GuildIdTextBox.Text)).Connect(ulong.Parse(ChannelIdTextBox.Text), new VoiceConnectionProperties() { Muted = Muted, Deafened = Camera });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            client.GetVoiceClient(ulong.Parse(GuildIdTextBox.Text)).Connect(ulong.Parse(ChannelIdTextBox.Text), new VoiceConnectionProperties() { Muted = Muted, Deafened = Deafened });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.GetVoiceClient(ulong.Parse(GuildIdTextBox.Text)).Connect(ulong.Parse(ChannelIdTextBox.Text), new VoiceConnectionProperties() { Muted = Muted, Deafened = Deafened });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            client.GetVoiceClient(ulong.Parse(GuildIdTextBox.Text)).Connect(ulong.Parse(ChannelIdTextBox.Text), new VoiceConnectionProperties() { Muted = Muted, Deafened = Deafened, Video = Camera });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Livestream = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.GetVoiceClient(ulong.Parse(GuildIdTextBox.Text)).Connect(ulong.Parse(ChannelIdTextBox.Text), new VoiceConnectionProperties() { Muted = Muted, Deafened = Deafened, Video = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayEarrape = true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select a song.";
            dialog.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";
            if (dialog.ShowDialog() == DialogResult.OK)
                textBox1.Text = dialog.FileName;
        }
    }
}
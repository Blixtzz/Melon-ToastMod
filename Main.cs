using Harmony;
using MelonLoader;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;
using ToastClient.Modules;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using System.Threading.Tasks;
using VRC.SDKBase;

namespace ToastClient
{
    public class ToastClient : MelonMod
    {
        //fuck configs :/
        public static uiish UI;
        public External.DiscordRpc.EventHandlers handlers;
        public External.DiscordRpc.RichPresence presence;
        internal AssetBundlePatch AssetBundlePatch { get; private set; }
        public override void OnApplicationStart()
        {
            var timer = new Stopwatch();
            timer.Start();
            InitializePatches();
            InitUI();
            UI.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            dRPCInitialize();
            InitConfig();
            timer.Stop();
            MelonLogger.Msg(timer.ElapsedMilliseconds + " <-- milliseconds taken to apply patches n shit");
        }
        public static void InitializePatches()
        {
            new Thread(() => { ToastClientPatches.InitEventPatch(new Harmony.HarmonyInstance("Toast.Event")); }).Start();
            new Thread(() => { AssetBundlePatch.assetBundlePatch(new Harmony.HarmonyInstance("Toast.AssetBundle")); }).Start();
            Shared.Modules.Add(new Modules.LeaveJoin());
            Shared.utils = new Utils();
            Shared.modules = new Modules.Modules();
            foreach (BaseModule mod in Shared.Modules)
            {
                mod.Init();
            }
        }
        public static void InitUI()
        {
            new uiish();
            UI = new uiish();
            UI.Show();
        }
        public void dRPCInitialize()
        {
            this.handlers = default(External.DiscordRpc.EventHandlers);
            External.DiscordRpc.Initialize("995525450321363044", ref this.handlers, true, null);
            this.presence.details = "ToastMod";
            this.presence.state = "Toast";
            this.presence.startTimestamp = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            this.presence.partyId = "ae488379-351d-4a4f-ad32-2b9b01c91657";
            this.presence.largeImageKey = "balls";
            this.presence.smallImageKey = "meow";
            this.presence.partySize = 1;
            this.presence.partyMax = 69420;
            this.presence.joinSecret = "MTI4NzM0OjFpMmhuZToxMjMxMjM= ";
            System.Timers.Timer timer = new System.Timers.Timer(15000.0);
            timer.AutoReset = true;
            timer.Enabled = true;
            External.DiscordRpc.UpdatePresence(ref this.presence);
        }
        public static void InitConfig()
        {
            var allText = File.ReadAllLines("ToastClient/Config.toast");
            for (int i = 0; i < allText.Length; i++)
                switch (allText[i])
                {
                    case "AntiGays = true;":
                        UI.checkBox1.Checked = true; ToastClientPatches.ProtectFromGays = true;
                        continue;
                    case "AntiGays = false;":
                        UI.checkBox1.Checked = false; ToastClientPatches.ProtectFromGays = false;
                        continue;
                    case "AntiVideo = true;":
                        UI.checkBox16.Checked = true; BaseChecks.VideoPlayerThing = true;
                        continue;
                    case "AntiVideo = false;":
                        UI.checkBox16.Checked = false; BaseChecks.VideoPlayerThing = false;
                        continue;
                    case "Esp = true;":
                        UI.checkBox19.Checked = true; OptomizeHandlers.Esp = true;
                        continue;
                    case "Esp = false;":
                        UI.checkBox19.Checked = false; OptomizeHandlers.Esp = false;
                        continue;
                    case "Logging = true;":
                        UI.checkBox22.Checked = true; AssetBundlePatch.AvatarLogging = true;
                        continue;
                    case "Logging = false;":
                        UI.checkBox22.Checked = false; AssetBundlePatch.AvatarLogging = false;
                        continue;
                    case "Inf = true;":
                        UI.checkBox12.Checked = true; Shared.modules.inf = true;
                        continue;
                    case "Inf = false;":
                        UI.checkBox12.Checked = false; Shared.modules.inf = false;
                        continue;
                    case "Bhop = true;":
                        UI.checkBox11.Checked = true; Shared.modules.bhop = true;
                        continue;
                    case "Bhop = false;":
                        UI.checkBox11.Checked = false; Shared.modules.bhop = false;
                        continue;
                    case "FriendScreen = true;":
                        UI.checkBox9.Checked = true; LeaveJoin.FriendJoin = true;
                        continue;
                    case "FriendScreen = false;":
                        UI.checkBox9.Checked = false; LeaveJoin.FriendJoin = false;
                        continue;
                }
            MelonLogger.Msg(ConsoleColor.Cyan, "\n _                  _\r\n| |_ ___   __ _ ___| |_\r\n| __/ _ \\ / _` / __| __|\r\n| || (_) | (_| \\__ | |_\r\n \\__\\___/ \\__,_|___/\\__|\n _       _ _   _       _ _             _\r\n(_)_ __ (_| |_(_) __ _| (_)_______  __| |\r\n| | '_ \\| | __| |/ _` | | |_  / _ \\/ _` |\r\n| | | | | | |_| | (_| | | |/ |  __| (_| |\r\n|_|_| |_|_|\\__|_|\\__,_|_|_/___\\___|\\__,_|");
        }
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            int rpc = ToastClientPatches.RPC;
            int avi = ToastClientPatches.AVI3;
            if (rpc != 0 && avi != 0)
            {
                MelonLogger.Msg("returned [false] 6 -> " + rpc);
                MelonLogger.Msg("returned [false] 9 -> " + avi);
            }
            ToastClientPatches.RPC = 0; ToastClientPatches.AVI3 = 0;
        }
        public override void OnLevelWasInitialized(int level)
        {
            if (UI.checkBox1.Checked)
            {
                ToastClientPatches.evokeLog = 1;
            }
            if (UI.checkBox16.Checked)
            {
                BaseChecks.VideoPlayerThing = true;
            }
            else { return; }
        }
        public override void OnUpdate()
        {
            Shared.modules.OnUpdate();
        }
        public override void OnApplicationQuit()
        {
            Process.GetCurrentProcess().Kill();
        }
        public override void OnGUI()
        {
            Shared.modules.OnGUI();
        }
    }
}
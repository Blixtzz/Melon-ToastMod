using ExitGames.Client.Photon;
using Harmony;
using MelonLoader;
using Photon.Realtime;
using System;
using ToastClient.External;
using UnhollowerBaseLib;
using VRC;
using System.Windows.Forms;
using System.IO;
using VRC.SDK3.Internal.Video.Components.AVPro;
using System.Collections.Generic;
using VRC.SDKBase;
using UnityEngine;
using static VRC.Dynamics.CollisionShapes;

namespace ToastClient.Modules
{
    class ToastClientPatches
    {
        public static void InitEventPatch(Harmony.HarmonyInstance harmony)
        {
            try
            {
                harmony.Patch(typeof(LoadBalancingClient).GetMethod("OnEvent"), new HarmonyMethod(AccessTools.Method(typeof(ToastClientPatches), nameof(OnEvent))));
                MelonLogger.Msg("[Patch] Analytics\nCredits to Decider#6666, Null, Azurilex, and lots of others for help :>");
            }
            catch
            {
                MelonLogger.Msg(ConsoleColor.Red, "[Patch] Analytics Error while Patching Events");
            }
        }
        public static VRCPlayer GetPlayerbyphotonid(int B)
        {
            var Players = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;
            foreach (var ob in Players)
                if (ob.GetVRCPlayerApi().playerId == B)
                {
                    return ob.GetVRCPlayer();
                }
            return null;
        }

        public static bool OnEvent(ref EventData __0)
        {
            if (ProcAddID)
            {
                var log = ToastClient.UI.textBox1.Text;
                var a = GetPlayerbyphotonid(System.Convert.ToInt32(log));
                if (log != null)
                {
                    Clipboard.SetText(a.prop_Player_0.field_Private_APIUser_0.displayName + " -> " + a.prop_Player_0.field_Private_APIUser_0.id);
                }
            }
            if (eventforPlayer)
            {
                var disable = Shared.BlackListed;
                if (__0.Sender == disable._player.GetVRCPlayerApi().playerId)
                {
                    if (__0.Code != 12 || __0.Code == 1)
                    {
                        return false;
                    }
                }
            }
            if (disableEvent)
            {
                var disable = ToastClient.UI.textBox1.Text;
                if (__0.Code == Convert.ToInt32(disable) && disable != null)
                {
                    return false;
                }
            }
            if (ToastClientPatches.HitMeAgain && __0.Code != 12)
            {
                switch (__0.Code)
                {
                    case 1:
                        if (e1log)
                        {
                            var bytes = __0.CustomData.Cast<Il2CppArrayBase<byte>>();
                            MelonLogger.Msg($"({__0.Code} <- Code)  (Length -> {bytes.Length})  ({__0.Sender} -> Sender)");
                        }
                        break;
                    case 6:
                        if (e6log)
                        {
                            var bytes = __0.CustomData.Cast<Il2CppArrayBase<byte>>();
                            MelonLogger.Msg($"({__0.Code} <- Code)  (Length -> {bytes.Length})  ({__0.Sender} -> Sender)");
                        }
                        break;
                    case 9:
                        if (e9log)
                        {
                            var bytes = __0.CustomData.Cast<Il2CppArrayBase<byte>>();
                            MelonLogger.Msg($"({__0.Code} <- Code)  (Length -> {bytes.Length})  ({__0.Sender} -> Sender)");
                        }
                        break;
                }
                MelonLogger.Msg(__0.Code + " || " + __0.Sender);
            }
            if (ToastClientPatches.ProtectFromGays)
            {
                switch (__0.Code)
                {
                    case 1:
                        var bytes = __0.CustomData.Cast<Il2CppArrayBase<byte>>();
                        if (bytes.Length == 71 || bytes.Length == 218 || bytes.Length == 37 || bytes.Length == 398)
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        public static int count = 0;
        public static bool deletePortals;
        public static bool disableEvent;
        public static bool eventforPlayer;
        public static bool ProcAddID;
        public static bool logbase = true;
        public static bool e1log;
        public static bool e6log;
        public static bool e9log;
        public static bool ProtectFromGays = true;
        public static bool HitMeAgain;
    }
}
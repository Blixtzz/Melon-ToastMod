using MelonLoader;
using UnityEngine;
using VRC;
using System;
using UnityEngine.UI;
using System.Diagnostics;
using System.Timers;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using System.Threading;

namespace ToastClient.Modules
{
    public class BaseChecks : BaseModule
    {

        public static bool LagCheck = true;
        public static bool VideoPlayerThing = true;
        public static bool MenuColor = true;
        public static bool WAWName = true;
        public static int holster = 0;
        public static int delayColor = 0;

        public override void OnUpdate()
        {
            if (Player.prop_Player_0 != null)
            {
                if (ToastClientPatches.ProtectFromGays)
                {
                    if (ToastClientPatches.evokeLog != 0)
                    {
                        ToastClientPatches.evokeLog++;
                        if (ToastClientPatches.evokeLog >= 600)
                        {
                            MelonLogger.Msg(System.ConsoleColor.Green, "Join Events Over, initializing antis");
                            ToastClientPatches.evokeLog = 0;
                        }
                    }
                    if (Shared.smallManager.ElapsedMilliseconds > 2000)
                    {
                        Shared.smallManager.Restart();
                        ToastClientPatches.avi3 = 0;
                        ToastClientPatches.rpc = 0;
                    }
                }
                if (LagCheck)
                {
                    try
                    {
                        if (!Application.isFocused) { Application.targetFrameRate = 25; }
                        if (Application.isFocused) { Application.targetFrameRate = 165; }
                    }
                    catch { }
                }
                if (VideoPlayerThing)
                {
                    Misce.OptomizeVP();
                    VideoPlayerThing = false;
                }
            }
        }
    }
}
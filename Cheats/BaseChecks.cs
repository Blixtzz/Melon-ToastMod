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
        public static bool MenuColor = true;
        public static bool WAWName = true;
        public static int holster = 0;

        public override void OnUpdate()
        {
            if (Player.prop_Player_0 != null)
            {
                if (LagCheck)
                {
                        if (!Application.isFocused) { Application.targetFrameRate = 25; }
                        if (Application.isFocused) { Application.targetFrameRate = 165; }
                }
            }
        }
    }
}
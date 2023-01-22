using System;
using System.Collections.Generic;
using System.Diagnostics;
using ToastClient.Modules;
using VRC;
using MelonLoader;
using VRC.SDKBase;
using UnityEngine;

namespace ToastClient
{
    public class Shared : BaseModule
    {
        public static Modules.Modules modules;
        public static Utils utils;
        private static Player targetPlayer;
        private static VRCPlayer blackListed;
        private static VRC_Pickup targetPickup;
        public static List<BaseModule> Modules = new List<BaseModule>();
        public static VRCPlayer BlackListed
        {
            get => blackListed;
            set { blackListed = value; }
        }
        public static Player TargetPlayer
        {
            get => targetPlayer;
            set { targetPlayer = value;}
        }
        public static VRC_Pickup TargetPickup
        {
            get => targetPickup;
            set
            {
                targetPickup = value;
            }
        }
    }
}
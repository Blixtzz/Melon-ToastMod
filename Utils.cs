using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.SDKBase;

namespace ToastClient
{
    public class Utils
    {
        private static VRC_Pickup[] pickups;

        public static Player GetPlayer(string name)
        {
            Il2CppSystem.Collections.Generic.List<Player> players = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].prop_APIUser_0.displayName == name)
                {
                    return players[i];
                }
            }
            return null;
        }
      
        public static VRC_Pickup getpickup(string name)
        {
            pickups = UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();
            foreach (VRC_Pickup vrcpickup in pickups)
            {
                if (vrcpickup.name == name)
                {
                    return vrcpickup;
                }
            }
            return null;
        }
    }
}
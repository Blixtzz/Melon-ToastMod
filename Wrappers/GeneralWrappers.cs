using ToastClient.External;
using UnityEngine;
using VRC;
using VRC.Core;

namespace ToastClient.Wrappers
{
    public static class GeneralWrappers
    {
        public static PlayerManager GetPlayerManager() { return PlayerManager.field_Private_Static_PlayerManager_0; }
        public static string GetRoomId() { return APIUser.CurrentUser.location; }

        public static HighlightsFX GetHighlightsFX() { return HighlightsFX.prop_HighlightsFX_0; }
        public static Color GetTrustColor(VRC.Player player)
        {
            return VRCPlayer.Method_Public_Static_Color_APIUser_0(player.GetAPIUser());
        }

        public static void EnableOutline(this HighlightsFX instance, Renderer renderer, bool state) => instance.Method_Public_Void_Renderer_Boolean_0(renderer, state); //First method to take renderer, bool parameters

        public static VRCUiPopupManager GetVRCUiPopupManager() { return VRCUiPopupManager.prop_VRCUiPopupManager_0; }

        public static void AlertPopup(this VRCUiPopupManager manager, string title, string text) => manager.Method_Public_Void_String_String_Single_0(title, text, 10f);

        public static Player[] GetAllPlayers()
        {
            return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
        }
        public static APIUser GetAPIUser(Player player)
        {
            return player.field_Private_APIUser_0;
        }
        public static ApiAvatar GetApiAvatar(Player player)
        {
            return player.prop_ApiAvatar_0;
        }
        public static Player GetPlayer(string ID)
        {
            var Players = GetAllPlayers();
            for (int i = 0; i < Players.Length; i++)
            {
                var player = Players[i];
                if (GetAPIUser(player).id == ID)
                {
                    return player;
                }
            }
            return null;
        }

        public static VRCPlayer GetVRCPlayer(VRCPlayer vrcplayer)
        {
            return (VRCPlayer)vrcplayer.prop_VRCPlayerApi_0.displayName;
        }
        public static Player LocalPlayer
        {
            get
            {
                return Player.prop_Player_0;
            }
        }
    }
}
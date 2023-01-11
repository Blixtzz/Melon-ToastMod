using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.DataModel;
using VRC.SDKBase;
using VRC.UI;

namespace ToastClient.External
{
    static class PlayerExtensions
    {
        public static VRCPlayer LocalVRCPlayer => VRCPlayer.field_Internal_Static_VRCPlayer_0;

        public static VRCPlayerApi GetVRCPlayerApi(this Player player)
        {
            return player.field_Private_VRCPlayerApi_0;
        }

        public static string GetName(this Player player)
        {
            return player.GetAPIUser().displayName;
        }
        public static VRCPlayer GetVRCPlayer(this Player player)
        {
            return player._vrcplayer;
        }

        public static APIUser GetAPIUser(this Player player)
        {
            return player.field_Private_APIUser_0;
        }
    }
}
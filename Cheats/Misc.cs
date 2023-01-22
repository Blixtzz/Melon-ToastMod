using Harmony;
using MelonLoader;
using Photon.Realtime;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using TMPro;
using ToastClient.External;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Core;
using VRC.Networking;
using VRC.SDKBase;
using VRC.Udon;
using VRC.UI;
using Player = VRC.Player;

namespace ToastClient.Modules
{
    class Misce : BaseModule
    {
        public static void UdonMoment()
        {
            foreach (var Udon in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
            {
                foreach (var UdonEvent in Udon._eventTable)
                {
                    Udon.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, UdonEvent.Key);
                }
            }
        }
        public static void UdonTable()
        {
            foreach (var Udon in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
            {
                foreach (var UdonEvent in Udon._eventTable)
                {
                    MelonLogger.Msg($"{UdonEvent.Key} => Key");
                }
            }
        }
        public static bool JoinWorldById()
        {
            var id = System.Windows.Forms.Clipboard.GetText().Trim();
            Networking.GoToRoom(id);
            return true;
        }
        public static void Serialization()
        {
            VRC.Player.prop_Player_0.gameObject.GetComponent<FlatBufferNetworkSerializer>().enabled = !VRC.Player.prop_Player_0.gameObject.GetComponent<FlatBufferNetworkSerializer>().enabled;
        }
        public static void TPose()
        {
            External.PlayerExtensions.LocalVRCPlayer.field_Internal_GameObject_0.GetComponent<Animator>().enabled = !External.PlayerExtensions.LocalVRCPlayer.field_Internal_GameObject_0.GetComponent<Animator>().enabled;
        }
        public static void Beyblade()//wtf
        {
            Wrappers.GeneralWrappers.LocalPlayer.transform.rotation = new Quaternion(0f, 0f, 100f + 1f, 0f);
        }
        public static float Speed(float speed)
        {
            var a = Wrappers.GeneralWrappers.LocalPlayer.field_Private_VRCPlayerApi_0.GetWalkSpeed();
            Wrappers.GeneralWrappers.LocalPlayer.prop_VRCPlayerApi_0.SetWalkSpeed(a + speed);
            var b = Wrappers.GeneralWrappers.LocalPlayer.field_Private_VRCPlayerApi_0.GetRunSpeed();
            Wrappers.GeneralWrappers.LocalPlayer.prop_VRCPlayerApi_0.SetRunSpeed(b + speed);
            return speed;
        }
        public static void ForcePickups() //this is from kirai
        {
            VRC.SDKBase.VRC_Pickup[] array = UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();
            for (int i = 0; i < array.Length; i++)
            {
                array[i].DisallowTheft = false;
                array[i].pickupable = true;
            }
        }
        public static void UseLegacyLoco()
        {
            Wrappers.GeneralWrappers.LocalPlayer.prop_VRCPlayerApi_0.UseLegacyLocomotion();
        }
        public static void GetJumpImpulse()
        {
            Networking.LocalPlayer.SetJumpImpulse(4);
        }
        public static void Respawn()
        {
            Player.prop_Player_0.transform.position = new Vector3(Player.prop_Player_0.transform.position.x, float.MinValue, Player.prop_Player_0.transform.position.z);
        }
        public static void Break()
        {
            Bred = !Bred;
            if (Bred)
            {
                Player.prop_Player_0.transform.position = new Vector3(Player.prop_Player_0.transform.position.x, 1000000, Player.prop_Player_0.transform.position.z);
            }
            if (!Bred)
            {
                Misce.Respawn();
            }
        }
        public static void ClickTP()
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = raycastHit.point;
            }
        }
        public static void PerformHide(bool value)
        {
            var HidePreview = GameObject.FindObjectsOfType<VRCUiManager>().First(x => x.name.StartsWith("UserInterface"));
            if (value == true)
            {
                AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.gameObject.SetActive(false);
                VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCAvatarManager_0.gameObject.SetActive(false);
                HidePreview.transform.FindChild("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Panel_SelectedAvatar/Panel_MM_AvatarViewer").gameObject.SetActive(false);
            }
            if (value == false)
            {
                AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.gameObject.SetActive(true);
                VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCAvatarManager_0.gameObject.SetActive(true);
                HidePreview.transform.FindChild("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Panel_SelectedAvatar/Panel_MM_AvatarViewer").gameObject.SetActive(true);
            }
        }
        public static void ClearAssets()
        {
            AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.field_Private_Cache_0.ClearCache();
            AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.field_Private_Queue_1_ObjectPublicInStInCoBoUnInStObBoUnique_0.Clear();
            AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.field_Private_Queue_1_ObjectPublicInStInCoBoUnInStObBoUnique_1.Clear();
        }
        public static void Inf()
        {
            if (!Networking.LocalPlayer.IsPlayerGrounded())
            {
                Vector3 velocity = Networking.LocalPlayer.GetVelocity();
                velocity.y = Networking.LocalPlayer.GetJumpImpulse();
                Networking.LocalPlayer.SetVelocity(velocity);
                Networking.LocalPlayer.SetJumpImpulse(velocity.y);
            }
        }
        public static void Bhop()
        {
            if (Networking.LocalPlayer.IsPlayerGrounded())
            {
                Vector3 velocity = Networking.LocalPlayer.GetVelocity();
                velocity.y = Networking.LocalPlayer.GetJumpImpulse();
                Networking.LocalPlayer.SetVelocity(velocity);
                Networking.LocalPlayer.SetJumpImpulse(velocity.y);
            }
        }
        public static void ChangeAvi(string avatarId)
        {
            var apiModelContainer = new ApiModelContainer<ApiAvatar>
            {
                OnSuccess = new Action<ApiContainer>(c =>
                {
                    var pageAvatar = Resources.FindObjectsOfTypeAll<PageAvatar>()[0];
                    var apiAvatar = new ApiAvatar
                    {
                        id = avatarId
                    };
                    pageAvatar.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = apiAvatar;
                    pageAvatar.ChangeToSelectedAvatar();
                })
            };
            API.SendRequest($"avatars/{avatarId}", 0, apiModelContainer, null, true, true, 3600f, 2);
        }
        public static void MakeFunky()
        {
            var player = Player.prop_Player_0;
            player.transform.Find("ForwardDirection/Avatar").GetComponent<RootMotion.FinalIK.VRIK>().fixTransforms = !player.transform.Find("ForwardDirection/Avatar").GetComponent<RootMotion.FinalIK.VRIK>().fixTransforms;
        }
        public static void bSpoof()
        {
            Spoof = !Spoof;
            string original = "";
            if (Spoof)
            {
                original = Player.prop_Player_0.field_Private_APIUser_0.displayName;
                Player.prop_Player_0.field_Private_APIUser_0.displayName = "Blue-kun";
            }
            if (!Spoof)
            {
                Player.prop_Player_0.field_Private_APIUser_0.displayName = original;
            }
        }
        static HighlightsFXStandalone friendH;
        static HighlightsFXStandalone othersH;
        static HighlightsFXStandalone tagvleH;
        static HighlightsFXStandalone fewdyH;
        public static void HighlightPlayer(Player player, bool state)
        {
            if (player != null)
            {
                if (state)
                {
                    Renderer renderer;
                    Transform select = player.transform.Find("SelectRegion");
                    renderer = (select?.GetComponent<Renderer>());
                    var highlightsFx = HighlightsFX.field_Private_Static_HighlightsFX_0;

                    friendH = highlightsFx.gameObject.AddComponent<HighlightsFXStandalone>();
                    friendH.highlightColor = Color.yellow;
                    othersH = highlightsFx.gameObject.AddComponent<HighlightsFXStandalone>();
                    othersH.highlightColor = Wrappers.GeneralWrappers.GetTrustColor(player);
                    tagvleH = highlightsFx.gameObject.AddComponent<HighlightsFXStandalone>();
                    tagvleH.highlightColor = new Color32(100, 15, 15, 255);
                    fewdyH = highlightsFx.gameObject.AddComponent<HighlightsFXStandalone>();
                    fewdyH.highlightColor = new Color32(42, 0, 0, 255);

                    GetHighlightsFX(player.field_Private_APIUser_0).Method_Public_Void_Renderer_Boolean_0(renderer, state);
                }
            }
        }
        private static HighlightsFXStandalone GetHighlightsFX(APIUser apiUser)
        {
            if (apiUser.id == "usr_deba259f-5c16-4aa2-972f-93620eeae80f")
                return tagvleH;
            if (apiUser.id == "usr_ed315637-0128-4024-97a0-ad3f236df819")
                return fewdyH;
            if (APIUser.IsFriendsWith(apiUser.id))
                return friendH;
            return othersH;
        }
        public static void DeleteVideoPlayers()
        {
            try
            {
                var define = RoomManager.field_Internal_Static_ApiWorld_0.name;
                if (define != null)
                {
                    {
                        GameObject[] ALL = Resources.FindObjectsOfTypeAll<GameObject>();
                        foreach (GameObject go in ALL)
                        {
                            if (go.GetComponent<VRCSDK2.VRC_SyncVideoStream>() || go.GetComponent<VRCSDK2.VRC_SyncVideoPlayer>() || go.GetComponent<UnityEngine.Video.VideoPlayer>() || go.GetComponent<SyncVideoPlayer>() || go.GetComponent<SyncVideoStream>() || go.GetComponent<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer>())
                            {
                                MelonLogger.Msg(ConsoleColor.Cyan, go.name + " -> [potential ip logger]");
                                GameObject.DestroyImmediate(go);
                                Resources.UnloadUnusedAssets();
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private static VRC_Pickup[] pickups;
        public static void DeletePickups()
        {
            pickups = UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();
            if (pickups != null)
            {
                foreach (VRC_Pickup pickup in pickups)
                {
                    GameObject.DestroyImmediate(pickup.gameObject);
                }
            }              
            Resources.UnloadUnusedAssets();
        }
        private static PortalInternal[] ports;
        public static void DeletePortals()
        {
            ports = UnityEngine.Object.FindObjectsOfType<PortalInternal>();
            if (ports != null)
            {
                foreach (PortalInternal port in ports)
                {
                    GameObject.DestroyImmediate(port.gameObject);
                }
                Resources.UnloadUnusedAssets();
            }
        }
        public static void RemoveVRIK()
        {
            var player = Player.prop_Player_0;
            var ik = player.transform.Find("ForwardDirection/Avatar").GetComponent<RootMotion.FinalIK.VRIK>();
            GameObject.DestroyImmediate(ik);
        }



        public static bool Spoof = false;
        public static bool Bred = false;
    }
}

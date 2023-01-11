using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.SDKBase;
using UnityEngine;
using VRC.Networking;
using VRC;
using MelonLoader;
using System.Collections;
using VRC.Core;
using UnhollowerRuntimeLib;
using ToastClient.External;

namespace ToastClient.Modules
{
    public class OptomizeHandlers : BaseModule
    {
        public override void OnUpdate()
        {
            if (Player.prop_Player_0 != null)
            {
                if (bHop)
                {
                    if (Networking.LocalPlayer.IsPlayerGrounded())
                    {
                        Vector3 velocity = Networking.LocalPlayer.GetVelocity();
                        velocity.y = Networking.LocalPlayer.GetJumpImpulse();
                        Networking.LocalPlayer.SetVelocity(velocity);
                        Networking.LocalPlayer.SetJumpImpulse(velocity.y);
                    }
                }
                if (Spam)
                {
                    var a = new EmojiMenu();
                    a.TriggerEmoji(13);
                }
                if (TTTP)
                {
                    VRC.Player.prop_Player_0.transform.position = Shared.TargetPlayer.transform.position;
                }
                if (TPtoTargetPickup)
                {
                    if (!Networking.LocalPlayer.IsPlayerGrounded())
                    {
                        Vector3 velocity = Networking.LocalPlayer.GetVelocity();
                        velocity.y = Networking.LocalPlayer.GetJumpImpulse();
                        Networking.LocalPlayer.SetVelocity(velocity);
                        Networking.LocalPlayer.SetJumpImpulse(velocity.y);
                    }
                    Player.prop_Player_0.transform.position = Shared.TargetPickup.transform.position;
                }
                if (TpiToring)
                {
                    if (Networking.GetOwner(Shared.TargetPickup.gameObject) != Networking.LocalPlayer)
                        Networking.SetOwner(Networking.LocalPlayer, Shared.TargetPickup.gameObject);
                    Shared.TargetPickup.transform.position = new Vector3(Player.prop_Player_0.transform.position.x, Player.prop_Player_0.transform.position.y + 0.1f, Player.prop_Player_0.transform.position.z);
                }
                if (fakeLag)
                {
                    countFrames++;
                    if (countFrames == 500)
                    {
                        countFrames = 0;
                        Player.prop_Player_0.gameObject.GetComponent<FlatBufferNetworkSerializer>().enabled = !Player.prop_Player_0.gameObject.GetComponent<FlatBufferNetworkSerializer>().enabled;
                    }
                }
                if (!Esp)
                {
                    foreach (Player player in Wrappers.GeneralWrappers.GetAllPlayers())
                        Misce.HighlightPlayer(player, false);
                    Esp = true;
                }
                if (IKTweaks)
                {
                    if (ikcount)
                    {
                        var player = Player.prop_Player_0;
                        Transform aviTransform = player.transform.Find("ForwardDirection/Avatar");
                        Transform[] All = aviTransform.GetComponentsInChildren<Transform>();
                        foreach (Transform item in All)
                        {
                            if (item.name == ToastClient.UI.textBox3.Text)
                            {
                                MelonLogger.Msg($"{item.name} -> found");
                                lArm = item.gameObject;
                            }
                            if (item.name == ToastClient.UI.textBox4.Text)
                            {
                                MelonLogger.Msg($"{item.name} -> found");
                                rArm = item.gameObject;
                            }
                        }
                        Misce.RemoveVRIK();
                        ikcount = false;
                    }
                    if (!ikcount)
                    {
                        System.Random rnd = new System.Random();
                        for (int i = 0; i < 3; i++)
                        {
                            x = rnd.Next(256);
                            y = rnd.Next(256);
                            z = rnd.Next(256);
                        }
                        if (lArm != null)
                            lArm.transform.eulerAngles = new Vector3(x, y, z);
                        if (rArm != null)
                            rArm.transform.eulerAngles = new Vector3(x, y, z);
                    }
                }
                if (!IKTweaks)
                {
                    lArm = null;
                    rArm = null;
                }
            }
        }
        public static bool TPtoTargetPickup;
        public static bool bHop;
        public static bool Spam;
        public static bool TTTP;
        public static bool TpiToring;
        public static bool fakeLag;
        public static bool antiPickup;
        public static bool HiddenRobots = true;
        public static bool Esp = true;
        public static bool BoneEsp = false;
        public static bool IKTweaks;
        public static bool ikcount = true;
        public static int countFrames = 0;

        private static GameObject lArm;
        private static GameObject rArm;
        float x = 0;
        float y = 0;
        float z = 0;
    }
}
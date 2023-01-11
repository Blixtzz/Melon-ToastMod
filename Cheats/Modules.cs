using MelonLoader;
using Photon.Realtime;
using System.Collections.Generic;
using System.Windows.Forms;
using TMPro;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using Player = VRC.Player;

namespace ToastClient.Modules
{
    public class Modules
    {
        public List<BaseModule> modules = new List<BaseModule>();
        public LeaveJoin onevents;
        public BaseChecks nps;
        public OptomizeHandlers opH;
        public Modules()
        {
            this.modules.Add(this.opH = new OptomizeHandlers());
            this.modules.Add(this.onevents = new LeaveJoin());
            this.modules.Add(this.nps = new BaseChecks());
        }
        public bool inf = false;
        public bool bhop = true;
        bool TP = false;
        public void OnUpdate()
        {
            for (int i = 0; i < this.modules.Count; i++)
            {
                this.modules[i].OnUpdate();
            }
            KeyBinds();
        }
        public void OnGUI()
        {
            try
            {
                if (LeaveJoin.FriendJoin)
                {
                    if (LeaveJoin.FriendCount != 0 && PlayerManager.prop_PlayerManager_0 != null)
                    {
                        int x = 0;
                        int distance = 0;
                        var Players = Wrappers.GeneralWrappers.GetAllPlayers();
                        for (int i = 0; i < Players.Length; i++)
                        {
                            var player = Players[i];
                            if (player.field_Private_APIUser_0.isFriend && player != null)
                            {
                                GUI.Label(new Rect(x, distance, 100, 25), player.field_Private_APIUser_0.displayName);
                                distance = distance + 20;
                                if (distance > 400)
                                {
                                    distance = 0;
                                    x = x + 200;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
        public void KeyBinds()
        {
            if (Player.prop_Player_0 != null)
            {
                /*good*/
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    OptomizeHandlers.bHop =
                        !OptomizeHandlers.bHop;
                }
                /*good*/
                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {
                    Misce.TPose(); 
                    Misce.UseLegacyLoco(); 
                    Misce.ForcePickups(); }
                /*good*/
                if (Input.GetKeyDown(KeyCode.Backspace)) { Misce.Serialization(); }
                /*good*/
                if (Input.GetKeyDown(KeyCode.K)) { Misce.AvatarLog(); }
                /*good*/
                if (Input.GetKeyDown(KeyCode.F1)) { ToastClient.UI.WindowState = FormWindowState.Minimized; ToastClient.UI.WindowState = FormWindowState.Normal; }
                /*good*/
                if (Input.GetKeyDown(KeyCode.T)) { TP = !TP; if (TP) { ThirdPerson.InitTPerson(); } if (!TP) { ThirdPerson.DisableTPerson(); } }
                /*good*/
                if (Input.GetKeyDown(KeyCode.Slash))
                {
                    Misce.Respawn();
                }
                /*good*/
                if (Input.GetKeyDown(KeyCode.Numlock))
                {
                    var id = System.Windows.Forms.Clipboard.GetText().Trim();
                    Misce.ChangeAvi(id);
                }
                /*good*/
                if (Input.GetKey(KeyCode.Space) || VRCInputManager.Method_Public_Static_VRCInput_String_0("Jump").field_Private_Boolean_0)
                {
                    if (inf)
                    {
                        Misce.Inf();
                    }
                    if (bhop)
                    {
                        Misce.Bhop();
                    }
                }
                /*good*/
                if (Input.GetKeyDown(KeyCode.Mouse2))
                {
                    Misce.ClickTP();
                }
                /*good*/
                if (Input.GetKeyDown(KeyCode.B))
                {
                    OptomizeHandlers.Spam = !OptomizeHandlers.Spam;
                }
                /*good*/
                if (Input.GetKeyDown(KeyCode.N))
                {
                    Misce.MakeFunky();
                }
                /*good*/
            }
        }
    }
}
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
        public BaseChecks nps;
        public OptomizeHandlers opH;
        public Modules()
        {
            this.modules.Add(this.opH = new OptomizeHandlers());
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
                    Misce.UseLegacyLoco(); 
                    Misce.ForcePickups(); 
                }
                /*good*/
                if (Input.GetKeyDown(KeyCode.Backspace)) { Misce.Serialization(); }
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
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ToastClient.Modules;
using UnityEngine;
using VRC.SDKBase;
using VRC.Networking;
using Player = VRC.Player;
using VRC.DataModel;
using System.Collections.Generic;

namespace ToastClient
{
    public partial class uiish : Form
    {
        public static uiish UI;
        private static VRC_Pickup[] pickups;
        public uiish()
        {
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var id = System.Windows.Forms.Clipboard.GetText().Trim();
            Misce.ChangeAvi(id);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Misce.Beyblade();
        }
        private void uiish_Load(object sender, EventArgs e)
        {
        }

        private Form activeForm = null;

        private void openPrisonEscape(Form form)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.None;
            PrisonEscape.Controls.Add(form);
            PrisonEscape.Tag = form;
            form.BringToFront();
            form.Show();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Misce.Respawn();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Wrappers.GeneralWrappers.GetRoomId());
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Misce.UdonMoment();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Misce.GetJumpImpulse();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Misce.TPose();
        }

        private void uiish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            Misce.JoinWorldById();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ToastClientPatches.ProtectFromGays = !ToastClientPatches.ProtectFromGays;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ToastClientPatches.HitMeAgain = !ToastClientPatches.HitMeAgain;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            Misce.Speed(1);
            var sped = Wrappers.GeneralWrappers.LocalPlayer.field_Private_VRCPlayerApi_0.GetRunSpeed();
            listBox3.Items.Add("speed: " + sped);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            Misce.Speed(-1);
            var sped = Wrappers.GeneralWrappers.LocalPlayer.field_Private_VRCPlayerApi_0.GetRunSpeed();
            listBox3.Items.Add("speed: " + sped);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                OptomizeHandlers.TTTP = true;
            }
            if (!checkBox5.Checked)
            {
                OptomizeHandlers.TTTP = false;
            }
        }
        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            Shared.TargetPlayer = Utils.GetPlayer(listBox2.SelectedItem.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Players = Shared.TargetPlayer;
            var playeravatar = Wrappers.GeneralWrappers.GetApiAvatar(Players);
            var player = External.PlayerExtensions.GetName(Players);
            if (Players != null)
            {
                Clipboard.SetText(player + "\n" + Players.field_Private_APIUser_0.id + "\n" + playeravatar.id + "\n" + playeravatar.assetUrl + "\n" + playeravatar.releaseStatus + "\n" + playeravatar.imageUrl);
            }

        }


        private void button14_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            pickups = UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();
            foreach (VRC_Pickup pickup in pickups)
            {
                listBox4.Items.Add(pickup.name);
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_DoubleClick(object sender, EventArgs e)
        {
            Shared.TargetPickup = Utils.getpickup(listBox4.SelectedItem.ToString());
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                OptomizeHandlers.TPtoTargetPickup = true;
            }
            if (!checkBox6.Checked)
            {
                OptomizeHandlers.TPtoTargetPickup = false;
            }

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                OptomizeHandlers.TpiToring = true;
            }
            if (!checkBox7.Checked)
            {
                OptomizeHandlers.TpiToring = false;
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Environment.CurrentDirectory + "\\VRChat.exe", Environment.CommandLine);
            }
            catch { }
            Process.GetCurrentProcess().Kill();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            Misce.DeletePickups();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            Shared.modules.bhop = !Shared.modules.bhop;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            Shared.modules.inf = !Shared.modules.inf;
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            ToastClientPatches.e1log = !ToastClientPatches.e1log;
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            ToastClientPatches.e6log = !ToastClientPatches.e6log;
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            ToastClientPatches.e9log = !ToastClientPatches.e9log;
        }
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            ToastClientPatches.disableEvent = !ToastClientPatches.disableEvent;
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            ToastClientPatches.ProcAddID = !ToastClientPatches.ProcAddID;
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            AssetBundlePatch.AvatarLogging = !AssetBundlePatch.AvatarLogging;
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            BaseChecks.VideoPlayerThing = !BaseChecks.VideoPlayerThing;
        }

        private void checkBox9_CheckedChanged_1(object sender, EventArgs e)
        {
            LeaveJoin.FriendJoin = !LeaveJoin.FriendJoin;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            OptomizeHandlers.fakeLag = !OptomizeHandlers.fakeLag;
            if (!checkBox10.Checked)
            {
                VRC.Player.prop_Player_0.gameObject.GetComponent<FlatBufferNetworkSerializer>().enabled = true;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            ToastClientPatches.eventforPlayer = !ToastClientPatches.eventforPlayer;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            OptomizeHandlers.Esp = !OptomizeHandlers.Esp;
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            Misce.bSpoof();
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            Misce.Break();
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            Misce.DeletePortals();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            var sped = Wrappers.GeneralWrappers.LocalPlayer.field_Private_VRCPlayerApi_0.GetRunSpeed();
            Wrappers.GeneralWrappers.LocalPlayer.field_Private_VRCPlayerApi_0.SetRunSpeed(0);
            listBox3.Items.Add("speed: " + sped);
        }

        private void uiish_Shown(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Misce.UdonTable();
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            OptomizeHandlers.IKTweaks = !OptomizeHandlers.IKTweaks;
            OptomizeHandlers.ikcount = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
           VRC.Player.prop_Player_0.gameObject.GetComponent<GamelikeInputController>().field_Protected_NeckMouseRotator_0.field_Public_NeckRange_0 = new NeckRange(-360, 360, 360);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool prisonMenu = true;
        private void button10_Click(object sender, EventArgs e)
        {
            prisonMenu = !prisonMenu;
            if (prisonMenu)
            {
                PrisonEscape.Show();
            }
            else
            {
                PrisonEscape.Hide();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private bool antis = false;
        private void button15_Click_1(object sender, EventArgs e)
        {
            antis = !antis;
            if (antis)
            {
                panel1.Dock = DockStyle.Fill;
                panel1.Show();
            }
            else
            {
                panel1.Dock = DockStyle.None;
                panel1.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool qol = false;
        private void button23_Click(object sender, EventArgs e)
        {
            qol = !qol;
            if (qol)
            {
                panel4.Show();
                panel4.Dock = DockStyle.Fill;
            }
            else
            {
                panel4.Dock = DockStyle.None;
                panel4.Hide();
            }
        }
        private bool exploits = false;
        private void button22_Click_1(object sender, EventArgs e)
        {
            exploits = !exploits;
            if (exploits)
            {
                panel3.Show();
                panel3.Dock = DockStyle.Fill;
            }
            else { panel3.Hide(); panel3.Dock = DockStyle.None; }
        }
        private bool logging = false;

        private void button20_Click_1(object sender, EventArgs e)
        {
            logging = !logging;
            if (logging)
            {
                panel2.Dock = DockStyle.Fill;
                panel2.Show();
            }
            else
            {
                panel2.Hide();
                panel2.Dock = DockStyle.None;
            }
        }

        private void PrisonEscape_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            Misce.PrisonEscapeGodMod();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var id = Shared.TargetPlayer.prop_ApiAvatar_0.id;
            Misce.ChangeAvi(id);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.enabled = false;
            else
            {
                Misce.ClearAssets();
                AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.enabled = true;
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked)
                Misce.PerformHide(true);
            else
            {
                Misce.PerformHide(false);
            }
        }
    }
}
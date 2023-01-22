using System;
using System.Runtime.InteropServices;
using System.Timers;

namespace ToastClient.External
{
    // Token: 0x02000002 RID: 2
    public class DiscordRpc
    {
        // Token: 0x06000001 RID: 1
        [DllImport("ToastClient/Resources/discord-rpc", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Initialize")]
        public static extern void Initialize(string applicationId, ref DiscordRpc.EventHandlers handlers, bool autoRegister, string optionalSteamId);

        // Token: 0x06000002 RID: 2
        [DllImport("ToastClient/Resources/discord-rpc", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RunCallbacks")]
        public static extern void RunCallbacks();

        // Token: 0x06000003 RID: 3
        [DllImport("ToastClient/Resources/discord-rpc", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Shutdown")]
        public static extern void Shutdown();

        // Token: 0x06000004 RID: 4
        [DllImport("ToastClient/Resources/discord-rpc", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UpdatePresence")]
        public static extern void UpdatePresence(ref DiscordRpc.RichPresence presence);

        // Token: 0x06000005 RID: 5 RVA: 0x00002050 File Offset: 0x00000250
        internal static void Initialize(string v1, ref object handlers, bool v2, object p)
        {
            throw new NotImplementedException();
        }

        // Token: 0x02000046 RID: 70
        // (Invoke) Token: 0x06000167 RID: 359
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DisconnectedCallback(int errorCode, string message);

        // Token: 0x02000047 RID: 71
        // (Invoke) Token: 0x0600016B RID: 363
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ErrorCallback(int errorCode, string message);

        // Token: 0x02000048 RID: 72
        public struct EventHandlers
        {
            // Token: 0x04000133 RID: 307
            public DiscordRpc.ReadyCallback readyCallback;

            // Token: 0x04000134 RID: 308
            public DiscordRpc.DisconnectedCallback disconnectedCallback;

            // Token: 0x04000135 RID: 309
            public DiscordRpc.ErrorCallback errorCallback;
        }

        // Token: 0x02000049 RID: 73
        // (Invoke) Token: 0x0600016F RID: 367
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ReadyCallback();

        // Token: 0x0200004A RID: 74
        [Serializable]
        public struct RichPresence
        {
            // Token: 0x04000136 RID: 310
            public string state;

            // Token: 0x04000137 RID: 311
            public string details;

            // Token: 0x04000138 RID: 312
            public long startTimestamp;

            // Token: 0x04000139 RID: 313
            public long endTimestamp;

            // Token: 0x0400013A RID: 314
            public string largeImageKey;

            // Token: 0x0400013B RID: 315
            public string largeImageText;

            // Token: 0x0400013C RID: 316
            public string smallImageKey;

            // Token: 0x0400013D RID: 317
            public string smallImageText;

            // Token: 0x0400013E RID: 318
            public string partyId;

            // Token: 0x0400013F RID: 319
            public int partySize;

            // Token: 0x04000140 RID: 320
            public int partyMax;

            // Token: 0x04000141 RID: 321
            public string matchSecret;

            // Token: 0x04000142 RID: 322
            public string joinSecret;

            // Token: 0x04000143 RID: 323
            public string spectateSecret;
            public string button;

            // Token: 0x04000144 RID: 324
            public bool instance;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MethodBase = System.Reflection.MethodBase;
using MelonLoader;
using System.Reflection;

namespace ToastClient.Modules
{
    class PatchHandler
    {
        public string ID { get; set; }

        public MethodBase TargetMethod { get; set; }

        public HarmonyMethod Prefix { get; set; }

        public PatchHandler(string Identifier, MethodBase Target, HarmonyMethod After)
        {
            ID = Identifier;
            TargetMethod = Target;
            Prefix = After;
        }

        public void ApplyPatch()
        {
            try
            {
                HarmonyLib.Harmony instance = new HarmonyLib.Harmony(ID);
                instance.Patch(TargetMethod, Prefix, null);
                MelonLogger.Msg($"{ID} Successfully patched.");
            }
            catch (Exception ex)
            {
                MelonLogger.Error(ex.Message);
            }
        }

        public static HarmonyMethod GetLocalPatch(Type type, string name) { return new HarmonyLib.HarmonyMethod(type.GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic)); }
    }
}

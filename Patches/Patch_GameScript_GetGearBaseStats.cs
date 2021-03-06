using UnityEngine;
using HarmonyLib;
using System.Reflection;
using GadgetCore.API;

namespace URP.Patches
{
    [HarmonyPatch(typeof(GameScript))]
    [HarmonyPatch("GetGearBaseStats")]
    [HarmonyGadget("URP")]
    public static class Patch_GameScript_GetGearBaseStats
    {
        [HarmonyPrefix]
        public static bool Prefix(int id, ref int[] __result)
        {
            switch (id)
            {
                case 1004:
                    __result = new int[] { 2, 0, 2, 0, 0, 0 };
                    return false;
                case 1024:
                    __result = new int[] { 8, 0, 4, 0, 0, 2 };
                    return false;
                case 1025:
                    __result = new int[] { 4, 0, 8, 0, 0, 2 };
                    return false;
                case 1026:
                    __result = new int[] { 6, 0, 6, 0, 0, 2 };
                    return false;
                default:
                    return true;
            }
        }
    }
}